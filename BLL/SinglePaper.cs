using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JxPrint.BLL
{
    public class SinglePaper :papersheet
    {
        public int TNum;
        public SinglePaper(Model.recttange psize, int ProNum, int color,int TypeNum)
            : base(psize, ProNum, color)
        {
            ProductName = "单页";
            ProductId = 3;
            Cover.UnitName = "单页";
            TNum = TypeNum;
            if (TypeNum > 1)
            {
                bool IsSingle=Cover.PageNum == 1;
                //if (IsSingle)
                //    Cover.PageNum = 2;
                Cover.PageNum = Cover.PageNum * TNum;
                Cover.ReCaculation();
                if (IsSingle)
                {
                    Cover.PaperNum = Cover.PaperNum * 2;
                }

                ProductName = TypeNum.ToString()+"种 单页";
            }
        }
        
    }
}
