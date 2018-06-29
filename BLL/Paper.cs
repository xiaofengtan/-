using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JxPrint.BLL
{
    public class Paper
    {
        public int Id;
        public string PaperName;
        public int kg;
        public int ThickXishu;
        public int Num;
        public decimal PaperPrice;

        public Paper(int id, int sizeid)
        {
            Model.Paper_Stand p = DAL.Paper_Stand.GetModel(id);
            if (p != null)
            {
                if (sizeid < 2)
                {
                    p.StandName = "正规" + p.StandName;
                }
                else
                {
                    p = DAL.Paper_Stand.GetModel("StandName like '%" + p.StandName + "%' and SizeId=1");
                    if (p == null)
                    {
                        p = DAL.Paper_Stand.GetModel(id);
                    }
                    p.StandName = "大规" + p.StandName;
                }
                Id = p.Id;
                kg = p.KG;
                PaperName = p.StandName;
                PaperPrice = p.SalesUnitPrice;

                int t = p.TypeId;
                int xishu;
                switch (t)
                {
                    case 1:
                        {
                            xishu = ConstantValue.Paper.ThickTB;
                            break;
                        }
                    case 2:
                        {
                            xishu = ConstantValue.Paper.ThickSJ;
                            break;
                        }
                    case 6:
                        {
                            xishu = ConstantValue.Paper.ThickYF;
                            break;
                        }
                    default:
                        {
                            xishu = ConstantValue.Paper.ThickOther;
                            break;
                        }
                }
                ThickXishu = xishu;
            }
        }
    }
}
