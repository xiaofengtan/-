using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace JxPrint.BLL
{
    public static class caculation
    {
        /// <summary>
        /// 根据页码数，开数，数量来计算大张数量。
        /// </summary>
        /// <param name="page"></param>
        /// <param name="kaidu"></param>
        /// <param name="num"></param>
        /// <returns></returns>
        private static int GetAllPaper(int page, int kaidu, int num)
        {
            int result = 0;
            if (page == 1)
                page = 2;
            page = page / 2;
            result = num * page / kaidu;
            return result;
        }
        /// <summary>
        /// 计算成品重量，根据纸尺寸，克重，计算出公斤数
        /// </summary>
        /// <param name="size"></param>
        /// <param name="kg"></param>
        /// <param name="Page"></param>
        /// <param name="productNum"></param>
        /// <returns></returns>
        public static int CalWeight(Model.recttange size, int kg, int Page, int productNum)
        {
            int result = 0;
            double r = (double) size.length * size.height * kg * Page * productNum /(double)( 2 * 1000 * 1000*1000);
            result = Convert.ToInt32(r);
            return result;
        }

        public static int CalWeight(rectang size, int kg, int Page, int productNum)
        {
            int result = 0;
            double r = (double)size.Length * size.Height * kg * Page * productNum / (double)(2 * 1000 * 1000 * 1000);
            result = Convert.ToInt32(r);
            return result;
        }
       
        /// <summary>
        /// 插入用户选择的工艺序列，同时插入用户选择工艺中的隐含工艺，也就是MUSTNEXT中的工艺，关联工艺的必须加工尺寸一致。
        /// </summary>
        /// <param name="mr"></param>
        /// <returns>工艺总数</returns>
        public  static List<Model.recttange> InsertProcess(List<Model.recttange> mr)
        {
            List<Model.recttange> RProcess = new List<Model.recttange>();
            int count = 0;
            Model.recttange next;
            foreach (Model.recttange r in mr)
            {
                count++;
                RProcess.Add(r);
                next = AddNexeProcess(r);
                while (next != null)
                {
                    count++;
                    RProcess.Add(next);
                    next = AddNexeProcess(next);
                }
            }
           return  RProcess;
        }

        /// <summary>
        /// 增加用户选择工艺
        /// mr结构为id为processid,length ,heigth;
        /// 同时增加某工艺的隐含工艺。
        /// </summary>
        /// <param name="mr"></param>
        private static Model.recttange AddNexeProcess(Model.recttange mr)
        {
            Model.recttange r1 = null;
            Model.Process p1 = DAL.Process.GetModel(mr.Id);
            int next = p1.MustNext;
            if (next > 0)
            {
                r1 = new Model.recttange();
                r1.length = mr.length;
                r1.height = mr.height;
                r1.QuNum = mr.QuNum;
                r1.Id = next;
            }
            return r1;
        }
        /// <summary>
        /// 检查用户序列中是否有某种工艺，并返回该工艺在序列中的索引号；
        /// </summary>
        /// <param name="UserList"></param>
        /// <param name="ProcessId"></param>
        /// <returns></returns>
        private static int CheckUserProcessList(List<Model.recttange> UserList, int ProcessId)
        {
            int index = -1;
            for (int i = 0; i < UserList.Count; i++)
            {
                if (UserList[i].Id == ProcessId)
                {
                    return i;
                }

            }
            return index;

        }

        /// <summary>
        /// 把用户选择工艺序列和数据库内存的某个产品的具体固定序列进行合并，得到最终的工艺序列；
        /// </summary>
        /// <param name="UserList"></param>
        /// <returns></returns>

        private static List<Model.P_ProductProcess> GetAllProcess( List<Model.recttange> UserList, int productid)
        {
            List<Model.P_ProductProcess> ResultList = new List<Model.P_ProductProcess>();
            Model.P_ProductProcess ppp;
            List<Model.recttange> LastUserProcessList=InsertProcess( UserList);
            DataSet ds = DAL.R_ProductProcess.GetList("ProductId=" + productid.ToString() + " order by NO");
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                Model.R_ProductProcess rpp = DAL.R_ProductProcess.DataRowToModel(dr);
                int index = CheckUserProcessList(LastUserProcessList, rpp.ProcessId);
                if (rpp.MustMark > 0 || index > 0)//说明该工艺是用户选择或者必须工艺；
                {
                    ppp = new Model.P_ProductProcess();
                    if (index > 0)
                    {
                        ppp.LengthParameter = LastUserProcessList[index].length;
                        ppp.HeightParameter = LastUserProcessList[index].height;
                        ppp.QuantityParameter = LastUserProcessList[index].QuNum;
                    }
                    if (rpp.MustMark>0)
                    {
                        ppp.MaterialId = rpp.MaterialId;
                    }
                    ppp.ProcessId = rpp.ProcessId;
                    ppp.ProcessType = rpp.ProcessType;
                    ppp.Mode = rpp.Mode;
                    ResultList.Add(ppp);
                }
            }
            return ResultList;
        }
       

        public static Model.Working GetProcess(int pid)
        {
            Model.Working w = new Model.Working();
            Model.Process p = DAL.Process.GetModel(pid);
            if (p != null)
            {
                w.Pid = pid;
                w.Pname = p.ProcessName;
                w.ExtendPaper = p.MinExtendPaper;
                w.ExtendRatio = p.ExtendRatio;
                return w;
            }
            else
                return null;
            
        }
    }
}
