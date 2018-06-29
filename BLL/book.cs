using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Script.Serialization;

namespace JxPrint.BLL
{
    public class book : papersheet
    {
       
        public decimal AllThick;
       

        /// <summary>
        /// 初始化一个封面没有折页，拉页等特殊工艺的画册；
        /// </summary>
        /// <param name="size">封面尺寸ID</param>
        /// <param name="PaperId">纸张ID</param>
        /// <param name="ProNum">产品数量</param>
        /// <param name="bindtype">装订方式</param>
        /// <param name="color">封面颜色</param>
        public book(Model.recttange psize, int ProNum, int color)
            : base(psize, ProNum, color)
        {
            if (psize.QuNum % 2 > 0)
                psize.QuNum = (psize.QuNum / 2 + 1) * 2;
            ProductName = "画册";
            ProductId = 1;
            Cover.UnitName = "画册封面";
        }
        /// <summary>
        /// 插入标准内页。使用成品尺寸
        /// </summary>
        /// <param name="paperid"></param>
        /// <param name="page"></param>
        /// <param name="color"></param>
        public void InsertInner(int paperid, int page, int color)
        {
            if (page > 0)
            {
                if (page % 2 > 0)
                    page = (page / 2 + 1) * 2;
                rectang size = new rectang();
                size.Id = ProductSize.Id;
                size.Name = ProductSize.Name;
                size.Length = ProductSize.Length;
                size.Height = ProductSize.Height;
                size.MId = paperid;
                size.Num = page;
                ProductUnit p1 = new ProductUnit(size.Id, size.Length, size.Height, paperid, color, page, 0, 0, ProductNum);
                InserInner(p1);
            }
           
        }
        /// <summary>
        /// c插入一个非标准的产品内页，可修改相应参数；
        /// </summary>
        /// <param name="paperid">纸张ID</param>
        /// <param name="page">页码数</param>
        /// <param name="color">颜色</param>
        /// <param name="papersource">纸张来源</param>
        /// <param name="contextrepeat">有无内容</param>
        public void InsertInner(int paperid,int page,int color,int papersource,int contextrepeat)
        {
            if (page > 0)
            {
                if (page % 2 > 0)
                    page = (page / 2 + 1) * 2;
                rectang size = new rectang();
                size.Id = ProductSize.Id;
                size.Name = ProductSize.Name;
                size.Length = ProductSize.Length;
                size.Height = ProductSize.Height;
                size.MId = paperid;
                size.Num = page;
                ProductUnit p1 = new ProductUnit(size.Id, size.Length, size.Height, paperid, color, page, papersource, contextrepeat, ProductNum);
                InserInner(p1);
            }
        }
       
        /// <summary>
        /// 把一个初始化好的产品插入到队列INNER中；
        /// </summary>
        /// <param name="p"></param>
        private void InserInner(ProductUnit p1)
        {
            AllThick += p1.thick;
            //如果内页总厚度超过规定厚度，需要重新计算封面的尺寸；
            if (AllThick > ConstantValue.Process.ThickLast)
                ReSetCover(Convert.ToInt32(p1.thick ));
            if (IsHeban(Cover, p1))
            {
                Cover.PageNum+= p1.Size.Num;
                Cover.ReCaculation();
            }
            else
            {
                if (Inner == null)
                {
                    Inner = new List<ProductUnit>();
                }
                p1.GroupId = Inner.Count + 1;
                p1.UnitName = "画册内页" + Inner.Count.ToString();
                Inner.Add(p1);
            }
        }
        
        private bool IsHeban(ProductUnit p1, ProductUnit p2)
        {
            return ((p1.UserPaper.Id == p2.UserPaper.Id) && (p1.Color == p2.Color) && (p1.Size.Length == p2.Size.Length) && (p1.PaperSource == p2.PaperSource));
        }
        /// <summary>
        /// 把装订工艺插入到工艺序列，并插入配页工艺
        /// </summary>
        /// <param name="bindtype"></param>
        public void InserBind(int bindtype)
        {
            BindType = bindtype;
            List<Model.recttange> plist = new List<Model.recttange>();
            Model.P_ProcessList w1 = new Model.P_ProcessList();

            Model.Process p = DAL.Process.GetModel(bindtype);
            if (p != null)
            {
                w1.ProcessId = p.ProcessId;
                w1.ProcessName = p.ProcessName;
                w1.Num = ProductNum;
                w1.PType = 2;
                w1.GroupId = 0;
                int extend = p.MinExtendPaper;
                w1.Price = DAL.C_ProcessPrice.GetPrice(w1.ProcessId, w1.Num);
                Cover.ExtendNum += extend;
                w1.ListCode = Cover.UnitName;
                Process.Add(w1);
                int id = p.MustNext;
                if (id > 0)
                {
                    Model.Process p2 = DAL.Process.GetModel(id);
                    Model.P_ProcessList w2 = new Model.P_ProcessList();
                    int alltie = 0;
                   
                    if (Inner != null)
                    {
                        foreach (ProductUnit p1 in Inner)
                        {
                            alltie += p1.PrintPs.HalfPsNum + p1.PrintPs.AllPsNum + p1.PrintPs.QuarPsNum;
                            p1.ExtendNum += p2.MinExtendPaper;
                            p1.ExtendRatio = ConstantValue.Process.ExtendRatio;
                        }
                    }
                    alltie += Cover.PrintPs.HalfPsNum + Cover.PrintPs.AllPsNum + Cover.PrintPs.QuarPsNum;
                    w2.ProcessId = id;
                    w2.GroupId = 1;
                    w2.ProcessName = p2.ProcessName;
                    w2.Num = alltie * ProductNum;
                    w2.PType = 2;
                    w2.Price = DAL.C_ProcessPrice.GetPrice(w2.ProcessId, w2.Num);
                    w2.ListCode = "内页总贴";
                    Process.Add(w2);
                }
            }
        }
     
        /// <summary>

        public override string ToString()
        {
            string result = "";
            StringBuilder sb = new StringBuilder();
            JavaScriptSerializer jsson = new JavaScriptSerializer();
            jsson.Serialize(this, sb);
            result = sb.ToString();
            return result;
        }
    }
}
