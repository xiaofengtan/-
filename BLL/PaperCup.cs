using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JxPrint.BLL
{
    public class PaperCup : papersheet
    {
        public PaperCup(int type,int num):base(type,num)
        {
            ProductName = "纸杯";
            Model.P_MaterialList m = new Model.P_MaterialList();
            m.StandId= type;
            m.Num = num;
            m.MType = 3;
            m.Price = DAL.Paper_Stand.GetPrice(type, num);
            m.StandName = "纸杯";
            AllMaterial = new List<Model.P_MaterialList>();
            AllMaterial.Add(m);
            ProductId = 8;
        }
    }
}
