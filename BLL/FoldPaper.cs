using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JxPrint.BLL
{
    public class FoldPaper : papersheet
    {
        public FoldPaper(Model.recttange size, int ProNum, int color)
            : base(size, ProNum,color)
        {
            ProductName = "折页";
            ProductId = 4;
            Cover.UnitName = "折页";
        }
        public FoldPaper(Model.recttange size, int ProNum, int color, int lfold, int hfold,int TypeNum)
            : base(size, ProNum,color )
        {
            ProductName = "折页";
            ProductId = 4;
            int i = 0;
            if (lfold > 1)
            {
                ResetCoverLpage(lfold);
                i = lfold - 1;
            }
            if (hfold > 1)
            {
                ResetCoverHpage(hfold);
                i = i + hfold - 1;
            }

            if (i > 0)
            {
                InsertSingleProcess(7, ProNum * i);
            }
            Cover.UnitName = "折页";
            if (TypeNum > 1)
            {
                Cover.PageNum = Cover.PageNum * TypeNum;
                Cover.ReCaculation();
               
                ProductName = TypeNum.ToString() + "种 折页";
            }
            
            //Cover.ReCaculation();

        }
    }
}
