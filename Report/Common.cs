using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Forms;
using System.Data;
using NPOI.XSSF;
using NPOI.XSSF.UserModel;
using NPOI.SS.UserModel;


namespace Report
{
    public class Common
    {
        public static int[] NoDisplayIn= { 0, 1,12,13,14};
        public static int[] NodisplayOut = { 0, 1, 10 };

        public static void BindCombox(ComboBox cbx, List<Model.NameType> list)
        {
            Model.NameType[] mylist = new Model.NameType[list.Count];
            list.CopyTo(mylist);
            cbx.DataSource = mylist;
            cbx.DisplayMember = "Name";
            cbx.ValueMember = "Id";
            //cbx.SelectedIndex = -1;
        }

        public static XSSFWorkbook BuildWorkbook(DataTable dt,string SheetName)
        {
            var book = new XSSFWorkbook();
            ISheet sheet = book.CreateSheet(SheetName);
          
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                IRow drow = sheet.CreateRow(i);
                for (int j = 0; j < dt.Columns.Count; j++)
                {
                    ICell cell = drow.CreateCell(j, CellType.STRING);
                    cell.SetCellValue(dt.Rows[i][j].ToString());
                }
            }
            return book;
        }

        public static XSSFWorkbook BuildWorkbook(DataGridView dt, string SheetName,int[] width,bool color)
        {
            var book = new XSSFWorkbook();
            ISheet sheet = book.CreateSheet(SheetName);

            XSSFCellStyle NoStyle = SetNormalCellStyle(book);

            XSSFCellStyle Style7 =SetCellStyle7(book);

            XSSFCellStyle Style17 = SetCellStyle17(book);

            IRow d0 = sheet.CreateRow(0);
            d0.Height = 600;
            int index = 0;
            sheet.AddMergedRegion(new NPOI.SS.Util.CellRangeAddress(0, 0, 0, dt.ColumnCount-1));
            ICell cell0 = d0.CreateCell(0, CellType.STRING);
            setTitleCellStyle(book, cell0);
         
            cell0.SetCellValue(SheetName);
            IRow d1 = sheet.CreateRow(1);
            for (int k = 0; k < dt.Columns.Count; k++)
            {
                if (dt.Columns[k].Visible)
                {
                    ICell cell = d1.CreateCell(index, CellType.STRING);
                    cell.CellStyle = NoStyle;
                    
                    cell.SetCellValue(dt.Columns[k].HeaderText);
                    index++;
                }
            }

            for (int i = 0; i < dt.Rows.Count - 1; i++)
            {
                index = 0;
                IRow drow = sheet.CreateRow(i + 2);

                for (int k1 = 0; k1 < dt.Columns.Count; k1++)
                {
                    if (dt.Columns[k1].Visible)
                    {
                        ICell cell = drow.CreateCell(index, CellType.STRING);
                        if (k1 != 8 || k1 != 17)
                        {
                            cell.CellStyle = NoStyle;
                        }
                        if (k1 == 8)
                        {
                            cell.CellStyle = Style7;
                        }
                        if (k1 == 17)
                        {
                            cell.CellStyle = Style17;
                        }

                        if (dt.Rows[i].Cells[k1].Value != null)
                        {
                            cell.SetCellValue(dt.Rows[i].Cells[k1].Value.ToString());

                            string vd11 = dt.Rows[i].Cells[k1].Value.ToString();
                            string vd = vd11.Replace('%', ' ');
                            decimal vt = 0;

                            if (decimal.TryParse(vd, out vt))
                            {
                                if (vt > 30 && vd11.IndexOf('%') > 0)
                                {
                                    setGreenCellStyle(book, cell);
                                }
                                if (vt < 0)
                                {
                                    setRedCellStyle(book, cell);
                                }
                            }
                        }
                        else
                        {
                            cell.SetCellValue("");
                        }
                    }
                    index++;
                }
            }
            
            
            //自动列宽
            for (int i = 0; i < dt.ColumnCount - 1; i++)
            {
                sheet.SetColumnWidth(i, width[i]*256+200);
            }
            return book;
        }

        private static XSSFCellStyle SetNormalCellStyle(XSSFWorkbook workbook)
        {
            XSSFCellStyle style = (XSSFCellStyle)workbook.CreateCellStyle();
           
            style.BorderBottom = NPOI.SS.UserModel.BorderStyle.THIN;
            style.BorderLeft = NPOI.SS.UserModel.BorderStyle.THIN;
            style.BorderRight = NPOI.SS.UserModel.BorderStyle.THIN;
            style.BorderTop = NPOI.SS.UserModel.BorderStyle.THIN;
            style.Alignment = NPOI.SS.UserModel.HorizontalAlignment.RIGHT;
            return style;
        }
        private static XSSFCellStyle SetCellStyle7(XSSFWorkbook workbook)
        {
            XSSFCellStyle style = (XSSFCellStyle)workbook.CreateCellStyle();

            XSSFFont ffont = (XSSFFont)workbook.CreateFont();

            ffont.Color = 18;
            style.SetFont(ffont);

            style.BorderBottom = NPOI.SS.UserModel.BorderStyle.THIN;
            style.BorderLeft = NPOI.SS.UserModel.BorderStyle.THIN;
            style.BorderRight = NPOI.SS.UserModel.BorderStyle.THIN;
            style.BorderTop = NPOI.SS.UserModel.BorderStyle.THIN;
            style.Alignment = NPOI.SS.UserModel.HorizontalAlignment.RIGHT;
            return style;
        }

        private static XSSFCellStyle SetCellStyle17(XSSFWorkbook workbook)
        {
            XSSFCellStyle style = (XSSFCellStyle)workbook.CreateCellStyle();

            style.BorderBottom = NPOI.SS.UserModel.BorderStyle.THIN;
            style.BorderLeft = NPOI.SS.UserModel.BorderStyle.THIN;
            style.BorderRight = NPOI.SS.UserModel.BorderStyle.THIN;
            style.BorderTop = NPOI.SS.UserModel.BorderStyle.THIN;
            style.Alignment = NPOI.SS.UserModel.HorizontalAlignment.LEFT;
            return style;
        }

        private static void setRedCellStyle(XSSFWorkbook workbook, ICell cell)
        {
            XSSFCellStyle fCellStyle = (XSSFCellStyle)workbook.CreateCellStyle();
            XSSFFont ffont = (XSSFFont)workbook.CreateFont();
          
            ffont.Color = 10;
            fCellStyle.SetFont(ffont);

            fCellStyle.VerticalAlignment = NPOI.SS.UserModel.VerticalAlignment.CENTER;//垂直对齐
            fCellStyle.Alignment = NPOI.SS.UserModel.HorizontalAlignment.RIGHT;//水平对齐

            fCellStyle.BorderBottom = NPOI.SS.UserModel.BorderStyle.THIN;
            fCellStyle.BorderLeft = NPOI.SS.UserModel.BorderStyle.THIN;
            fCellStyle.BorderRight = NPOI.SS.UserModel.BorderStyle.THIN;
            fCellStyle.BorderTop = NPOI.SS.UserModel.BorderStyle.THIN;
          
            cell.CellStyle = fCellStyle;
        }

        private static void setGreenCellStyle(XSSFWorkbook workbook, ICell cell)
        {
            XSSFCellStyle fCellStyle = (XSSFCellStyle)workbook.CreateCellStyle();
            XSSFFont ffont = (XSSFFont)workbook.CreateFont();

            ffont.Color = 51;
            fCellStyle.SetFont(ffont);

            fCellStyle.VerticalAlignment = NPOI.SS.UserModel.VerticalAlignment.CENTER;//垂直对齐
            fCellStyle.Alignment = NPOI.SS.UserModel.HorizontalAlignment.CENTER;//水平对齐

            fCellStyle.BorderBottom = NPOI.SS.UserModel.BorderStyle.THIN;
            fCellStyle.BorderLeft = NPOI.SS.UserModel.BorderStyle.THIN;
            fCellStyle.BorderRight = NPOI.SS.UserModel.BorderStyle.THIN;
            fCellStyle.BorderTop = NPOI.SS.UserModel.BorderStyle.THIN;

            cell.CellStyle = fCellStyle;
        }

        private static void setTitleCellStyle(XSSFWorkbook workbook, ICell cell)
        {
            XSSFCellStyle fCellStyle = (XSSFCellStyle)workbook.CreateCellStyle();
            XSSFFont ffont = (XSSFFont)workbook.CreateFont();
            ffont.FontHeight = 5 * 5;
            ffont.FontName = "宋体";
            //ffont.Color = 10;
            fCellStyle.SetFont(ffont);

            fCellStyle.VerticalAlignment = NPOI.SS.UserModel.VerticalAlignment.CENTER;//垂直对齐
            fCellStyle.Alignment = NPOI.SS.UserModel.HorizontalAlignment.CENTER;//水平对齐

            fCellStyle.BorderBottom = NPOI.SS.UserModel.BorderStyle.THIN;
            fCellStyle.BorderLeft = NPOI.SS.UserModel.BorderStyle.THIN;
            fCellStyle.BorderRight = NPOI.SS.UserModel.BorderStyle.THIN;
            fCellStyle.BorderTop = NPOI.SS.UserModel.BorderStyle.THIN;
            cell.CellStyle = fCellStyle;
        }
    }
}
