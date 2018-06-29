using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Forms;
using System.Data;
using System.IO;
using NPOI.XSSF;
using NPOI.XSSF.UserModel;
using NPOI.SS.UserModel;


namespace PrintStroe
{
    public class Common
    {
        public static int[] NoDisplayIn = { 0, 1, 12, 13, 14 };
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

        public static  int  CalNumPreTon(int l, int h, int kg)
        {
            int num = 0;
            decimal area = l * h;
            area = area / (decimal)1000000.0;
            decimal weight = area * kg;
            decimal n = 1000000 / weight;
            num =(int) n;
            return num;
        }

        public static XSSFWorkbook BuildWorkbook(DataTable dt, string SheetName)
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
            //自动列宽
            //for (int i = 0; i <dt.Columns.Count; i++)
            //    sheet.AutoSizeColumn(i, true);
            return book;
        }

        public static XSSFWorkbook BuildWorkbook(DataGridView dt, string SheetName)
        {
            var book = new XSSFWorkbook();
            ISheet sheet = book.CreateSheet(SheetName);
            IRow d1 = sheet.CreateRow(0);
            int index = 0;
            for (int k = 0; k < dt.Columns.Count; k++)
            {
                if (dt.Columns[k].Visible)
                {
                    ICell cell = d1.CreateCell(index, CellType.STRING);
                    cell.SetCellValue(dt.Columns[k].HeaderText);
                    index++;
                }
            }

            for (int i = 1; i < dt.Rows.Count; i++)
            {
                IRow drow = sheet.CreateRow(i);
                index = 0;
                for (int k1 = 0; k1 < dt.Columns.Count; k1++)
                {
                    if (dt.Columns[k1].Visible)
                    {
                        ICell cell = drow.CreateCell(index, CellType.NUMERIC);
                        if (dt.Rows[i].Cells[k1].Value != null)
                        {
                            cell.SetCellValue(dt.Rows[i].Cells[k1].Value.ToString());
                        }
                        else
                        {
                            cell.SetCellValue("");
                        }
                        index++;
                    }
                }
            }
            //自动列宽
            //for (int i = 0; i < index; i++)
            //    sheet.AutoSizeColumn(i,true);
            return book;
        }

        public static DataTable ExcelToDataTable(string filePath, bool isColumnName)
        {
            DataTable dataTable = null;
            FileStream fs = null;
            DataColumn column = null;
            DataRow dataRow = null;
            IWorkbook workbook = null;
            ISheet sheet = null;
            IRow row = null;
            ICell cell = null;
            int startRow = 0;
            try
            {
                using (fs = File.OpenRead(filePath))
                {
                    // 2007版本
                    if (filePath.IndexOf(".xlsx") > 0)
                        workbook = new XSSFWorkbook(fs);
                    // 2003版本
                    else if (filePath.IndexOf(".xls") > 0)
                        workbook = new XSSFWorkbook(fs);

                    if (workbook != null)
                    {
                        sheet = workbook.GetSheetAt(0);//读取第一个sheet，当然也可以循环读取每个sheet
                        dataTable = new DataTable();
                        if (sheet != null)
                        {
                            int rowCount = sheet.LastRowNum;//总行数
                            if (rowCount > 0)
                            {
                                IRow firstRow = sheet.GetRow(0);//第一行
                                int cellCount = firstRow.LastCellNum;//列数

                                //构建datatable的列
                                if (isColumnName)
                                {
                                    startRow = 1;//如果第一行是列名，则从第二行开始读取
                                    for (int i = firstRow.FirstCellNum; i < cellCount; ++i)
                                    {
                                        cell = firstRow.GetCell(i);
                                        if (cell != null)
                                        {
                                            if (cell.StringCellValue != null)
                                            {
                                                column = new DataColumn(cell.StringCellValue);
                                                dataTable.Columns.Add(column);
                                            }
                                        }
                                    }
                                }
                                else
                                {
                                    for (int i = firstRow.FirstCellNum; i < cellCount; ++i)
                                    {
                                        column = new DataColumn("column" + (i + 1));
                                        dataTable.Columns.Add(column);
                                    }
                                }

                                //填充行
                                for (int i = startRow; i <= rowCount; ++i)
                                {
                                    row = sheet.GetRow(i);
                                    if (row == null) continue;

                                    dataRow = dataTable.NewRow();
                                    for (int j = row.FirstCellNum; j < cellCount; ++j)
                                    {
                                        cell = row.GetCell(j);
                                        if (cell == null)
                                        {
                                            dataRow[j] = "";
                                        }
                                        else
                                        {
                                            //CellType(Unknown = -1,Numeric = 0,String = 1,Formula = 2,Blank = 3,Boolean = 4,Error = 5,)
                                            switch (cell.CellType)
                                            {
                                                case CellType.BLANK:
                                                    dataRow[j] = "";
                                                    break;
                                                case CellType.NUMERIC:
                                                    short format = cell.CellStyle.DataFormat;
                                                    //对时间格式（2015.12.5、2015/12/5、2015-12-5等）的处理
                                                    if (format == 14 || format == 31 || format == 57 || format == 58)
                                                        dataRow[j] = cell.DateCellValue;
                                                    else
                                                        dataRow[j] = cell.NumericCellValue;
                                                    break;
                                                case CellType.STRING:
                                                    dataRow[j] = cell.StringCellValue;
                                                    break;
                                                default:
                                                    dataRow[j] = cell.StringCellValue;
                                                    break;
                                            }
                                        }
                                    }
                                    dataTable.Rows.Add(dataRow);
                                }
                            }
                        }
                    }
                }
                return dataTable;
            }
            catch (Exception)
            {
                if (fs != null)
                {
                    fs.Close();
                }
                return null;
            }
        }
    }
}
