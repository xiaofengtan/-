using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JxPrint.BLL
{
   public class Envelope : papersheet
    {
        public Envelope(Model.recttange psize, int ProNum, int color)
            : base(psize, ProNum, color)
        {
            InsertSingleProcess(28, ProNum);
            ProductName = "信封";
            ProductId = 5;
        }
    }
}
