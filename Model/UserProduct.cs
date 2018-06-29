using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Script.Serialization;

namespace Model
{
    [Serializable]
    
    public class UserProduct
    {
        public  P_Order Order;
        public  List<OrderPart> Part;
        public  List<P_MaterialList2> Material;
        public  List<P_ProcessList2> Process;

        public int BindType;

        public UserProduct()
        {
            Order = new P_Order();
            Part = new List<OrderPart>();
        }

        public UserProduct(P_Order order)
        {
            Order = order;
            Part = new List<OrderPart>();
        }

        public int AddPart(OrderPart part)
        {
            if (Order != null)
            {
                Part.Add(part);
                return Part.Count;
            }
            return -1;
        }

        public int Save()
        {
            int result = 0;
            DataSource.SQLServerSource ss = new DataSource.SQLServerSource();
            ss.BeginTransaction();
            try
            {
                int id = DataSource.ORMHelper.InsertModelId<P_Order>(Order, ss);
                Order.OrderId = id;
                for (int i = 0; i < Part.Count; i++)
                {
                    int pid = DataSource.ORMHelper.InsertModelId<OrderPart>(Part[i],ss);
                    for(int j=0;j<Process.Count;j++)
                    {
                        if (Process[j].PartId == i)
                        {
                            Process[j].PartId = pid;
                            DataSource.ORMHelper.InsertModel<P_ProcessList2>(Process[j], ss);
                        }
                        if (Material[j].PartId == i)
                        {
                            Material[j].PartId = pid;
                            DataSource.ORMHelper.InsertModel<P_MaterialList2>(Material[j], ss);
                        }
                    }
                    result++;
                }
                ss.Commit();
            }
            catch
            {
                ss.Rollback();
                result = -1;
            }
            return result;
        }
    }
}
