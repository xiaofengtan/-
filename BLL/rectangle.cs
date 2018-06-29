using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JxPrint.BLL
{
    public class rectang
    {
        public int Id;
        public string Name;
        public int Length;
        public int Height;
        public int MId;
        public int Num;
        public int Kaidu;

        public override string ToString()
        {
            if (Id > 0)
                return Name;
            else
            {
                string s = Kaidu.ToString() + "开(";
                s += Length.ToString() + "X" + Height.ToString() + ")"+Name;
                return s;
            }
        }
    }
  
}
