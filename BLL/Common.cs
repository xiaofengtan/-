using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JxPrint.BLL
{
    public class Common
    {
   
        /// <summary>
        /// 把MODEL.RECTTANGE 转换成RECTANG;
        /// </summary>
        /// <param name="r"></param>
        /// <returns></returns>
        public static  rectang GetRectByModle(Model.recttange r)
        {
            rectang rect = new rectang();
            rect.Id = r.Id;
            rect.Height = r.height;
            rect.Length = r.length;
            rect.MId = r.MId;
            rect.Name = r.Name;
            rect.Num = r.QuNum;
            return rect;
        }

        public static  int CaculationWeight(int l, int h, int num, int kg)
        {
            int weight;
            double s = (double)l * h;
            s = s * kg;
            s = s * num;
            double xishu = (double)(1000 * 1000 * 1000);
            double r = s / xishu;
            weight = Convert.ToInt32(r);
            return weight;
        }

        public static rectang GetPaperRect(rectang old)
        {
            rectang newsize = new rectang();
            FoldSheet fd;
            if (old.Id > 0)
            {
                fd = new FoldSheet(old.Id);
            }
            else
            {
                fd = new FoldSheet(old.Length, old.Height);
            }
            if (fd != null)
            {
                return fd.NewSize;
            }
            return null;
        }
        public static int GetDeliver(int SendMode, int Weight)
        {
            int price = 0;
            if (SendMode == 0)
                return 0;
            if (SendMode == 1)
            {
                price = 20;
                if ((Weight - 20) > 0)
                {
                    price+=(Weight - 20) /2;
                }
            }
            if (SendMode == 2)
            {
                price = 30;
                if ((Weight - 20) > 0)
                {
                    price += (Weight - 20) / 4;
                }
            }

            return price;
        }
        public static Model.recttange GetPaperRect(Model.recttange size)
        {
            rectang old = GetRectByModle(size);
            rectang newsize = new rectang();
            Model.recttange result = new Model.recttange();
            FoldSheet fd;
            if (old.Id > 0)
            {
                fd = new FoldSheet(old.Id);
            }
            else
            {
                fd = new FoldSheet(old.Length, old.Height);
            }
            if (fd != null)
            {
                result.Id = fd.NewSize.Id;
                result.length = fd.NewSize.Length;
                result.height = fd.NewSize.Height;
                result.Name = fd.NewSize.Name;
                result.QuNum = fd.NewSize.Kaidu;
                return result;
            }
            return null;
        }
    }

    public class MakeTable
    {
        string TableHeadFormat = " <table><tr><td colspan={0} align=center>{1}</td></tr>{2}</table>";
        string TableLine = "<tr>{0}</tr>";
        string TableCell = "<td>{0}</td>";
        List<string> CellList = null;
        int CellNumPreLine;
        string TableName;
        public string Result;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="linenum">行数</param>
        /// <param name="cellnum">每行表格数量，一定为偶数个</param>
        /// <param name="tablename"></param>
        public MakeTable(int cellnum, string tablename)
        {
            CellNumPreLine = cellnum;
            TableName = tablename;
            CellList = new List<string>();
        }
        public void InserCell(string Name, string Value)
        {
            string td1 = string.Format(TableCell, Name);
            string td2 = string.Format(TableCell, Value);
            CellList.Add(td1);
            CellList.Add(td2);
        }
        public string GetResult()
        {
            int total = CellList.Count/2;
            int left = total % (CellNumPreLine);
            int lines = total / (CellNumPreLine );
            
            //自动补齐整行；
            if (left > 0)
            {
                lines = lines + 1;
                left = lines * CellNumPreLine - total ;
                string blank = "&nbsp;";
                for (int i = 0; i <left; i++)
                {
                    InserCell(blank, blank);
                }
            }
            int index = 0;
            string AllLine = "";
            for (int j = 0; j < lines; j++)
            {
                string line = "";
                for (int k = 0; k < CellNumPreLine; k++)
                {
                    line += CellList[index];
                    line += CellList[index + 1];
                    index = index + 2;
                    if (index >=CellList.Count)
                    {
                        break;
                    }
                }
                AllLine += string.Format(TableLine, line);
            }
            Result = string.Format(TableHeadFormat, CellNumPreLine * 2, TableName, AllLine);
            return Result;
        }
    }
}
