using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JxPrint.BLL
{
   public  class GetRequest
    {
        /// <summary>
        /// 添加工艺，判断是否有相同type的工艺
        /// </summary>
        /// <param name="processid">工艺id</param>
        /// <param name="rectlist">工艺类列表</param>
        /// <param name="l">长</param>
        /// <param name="h">高</param>
        /// <param name="q">数量</param>
        /// <returns></returns>
        public  List<Model.recttange> GetProcessList(int processid, List<Model.recttange> rectlist,int l,int h,int q) 
        {
            Model.Process pro1 = DAL.Process.GetModel(processid);
            for (int i = 0; i < rectlist.Count;i++)
            {
                Model.Process pro = DAL.Process.GetModel(rectlist[i].Id);
                if (pro1.TypeId == pro.TypeId)
                {
                    rectlist[i].Id = processid;
                    rectlist[i].Name = pro1.ProcessName;
                    if (l > 0 && h > 0)
                    {
                        rectlist[i].length = l;
                        rectlist[i].height = h;
                    }
                    if (q > 0)
                    {
                        rectlist[i].QuNum = q;
                    }
                }
                else//没有同类型的工艺 
                {
                    Model.recttange rect = new Model.recttange();
                    rect.Id = processid;
                    rect.Name = pro1.ProcessName;
                    if (l > 0 && h > 0)
                    {
                        rect.length = l;
                        rect.height = h;
                    }
                    if (q > 0)
                    {
                        rect.QuNum = q;
                    }
                    rectlist.Add(rect);
                }
            }//循环结束
            return rectlist;
        }
       
       /// <summary>
       /// 内页页码判断
       /// </summary>
       /// <param name="pagenum"></param>
       /// <returns></returns>
        public  int  GetPage(int pagenum)
        {
            if (pagenum % 4 == 0)
                return pagenum;
            else
                return pagenum + 4 ;
        }
    }
}
