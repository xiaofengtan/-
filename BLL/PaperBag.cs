using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JxPrint.BLL
{
    public class PaperBag : papersheet
    {
        public PaperBag(Model.recttange psize, int ProNum, int color)
            : base(psize, ProNum, color)
        {
            ProductName = "纸袋";
            ProductId = 6;
            InsertSingleProcess(26, ProNum);
            InsertSingleProcess(27, ProNum);
            Cover.UnitName = "纸袋";
        }
    }
}
