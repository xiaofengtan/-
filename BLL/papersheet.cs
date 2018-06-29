using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Script.Serialization;

namespace JxPrint.BLL
{
    public class papersheet
    {
        public int BindType;

        public string ProductCode;
        public string ProductName;
        public int ProductId;
        
        public int ProductNum;
        public int AllWeight;
        public int PaperWeight;

        public ProductUnit Cover;
        public rectang ProductSize;

        public List<Model.P_ProcessList> Process;
        public List<Model.P_MaterialList> AllMaterial;
        public List<Model.P_PrintList> PrintList;

        public Model.ResultPrice AllPrice;
        public string UserRequest="";

        public List<ProductUnit> Inner;
       
       
        /// <summary>
        /// 用于销售某个产品，如纸杯
        /// </summary>
        /// <param name="id">PaperStandId </param>
        /// <param name="num">数量</param>
        public papersheet(int id, int num)
        {
            ProductSize = new rectang();

            ProductSize.Length = 210;
            ProductSize.Height = 285;
            ProductSize.Kaidu = 16;
            ProductSize.Name = "";

           
            //UserRequest = "test!";

            Cover = new ProductUnit(12, 210, 285, 5, 0, 2, 1, 2, num);
            Cover.GroupId = 0;
            Cover.UnitName = "纸杯";

            ProductNum = num;
            Model.material m = new Model.material();
            m.Mid = id;
            m.Num = num;
            m.Price = DAL.C_StandPrice.GetPrice(id, num);

        }
       
       /// <summary>
       /// 
       /// </summary>
        /// <param name="psize">size.id 尺寸ID,size.Length长, size.Height高, size.MId纸的ID,size.Num页码数,
        /// psize.Status纸张来源，psize.b1 内容是否重复</param>
       /// <param name="ProNum">产品数量</param>
       /// <param name="color">颜色数</param>
        public papersheet(Model.recttange psize, int ProNum, int color)
        {
            rectang size = new rectang();
            size = Common.GetRectByModle(psize);
            ProductSize = new rectang();
            if (size.Id > 0)
            {
                ProductSize.Id = size.Id;
                Model.ProductSize p = DAL.ProductSize.GetModel(size.Id);
                ProductSize.Length = p.StandLength;
                ProductSize.Height = p.StandHeight;
                ProductSize.Kaidu = p.Kaidu;
                ProductSize.Name = p.NickName;
            }
            else
            {
                ProductSize.Length = psize.length;
                ProductSize.Height = psize.height;
                FoldSheet fd = new FoldSheet(ProductSize.Length, ProductSize.Height);
                if (fd.OldSize != null)
                {
                    ProductSize.Kaidu = fd.OldSize.Kaidu;
                    ProductSize.Name = fd.OldSize.Name;
                }
            }
            ProductNum = ProNum;
            Cover = new ProductUnit(size.Id,size.Length, size.Height, size.MId, color, size.Num, psize.Status, psize.b1, ProNum);
            Cover.GroupId = 0;
            Cover.UnitName = ProductName;
            //UserRequest = "test!";
        }

        public  void Init(ProductUnit pu)
        {
            CaculationPrintProcess(pu);
            CaculationUnitMaterial(pu);
        }
        /// <summary>
        /// 增加构件的尺寸，如勒口，书脊
        /// </summary>
        /// <param name="length"></param>
        public void ReSetCover(int length)
        {
            Cover.Size.Id = -1;
            if (Cover.Size.Num == 4)
            {
                Cover.Size.Length = Cover.Size.Length*2 + length;
            }
            else
                Cover.Size.Length += length;
            Cover.PageNum = 2;
            Cover.ReCaculation();
        }
        /// <summary>
        /// 水平方向折页；用于拉页，折页；
        /// </summary>
        /// <param name="FoldNum"></param>
        public void ReSetCoverPage(int FoldNum)
        {
            Cover.Size.Id = -1;
            int newlength= ProductSize.Length * (FoldNum + 2);
            if(Cover.Size.Num==4)
            {
                Cover.Size.Length=newlength;
            }
            else
            {
                Cover.Size.Length+=ProductSize.Length*FoldNum;
            }
            Cover.PageNum = 2;
            Cover.ReCaculation();
        }
        /// <summary>
        /// 垂直方向折页
        /// </summary>
        /// <param name="FoldNum"></param>
        public void ResetCoverHpage(int FoldNum)
        {
            Cover.Size.Id = -1;
            Cover.Size.Height = ProductSize.Height * FoldNum;
            Cover.PageNum = 2;
            Cover.ReCaculation();
        }
        public void ResetCoverLpage(int FoldNum)
        {
            Cover.Size.Id = -1;
            Cover.Size.Length = ProductSize.Length * FoldNum;
            Cover.PageNum = 2;
            Cover.ReCaculation();
        }
     
        /// <summary>
        /// 计算一个产品的材料清单。纸和版的数量。
        /// </summary>
        /// <returns></returns>
        public  void  CaculationUnitMaterial( ProductUnit cover)
        {
            if (cover != null)
            {
                if (AllMaterial == null)
                    AllMaterial = new List<Model.P_MaterialList>();
                if (cover.PaperSource == 0)
                {
                    Model.P_MaterialList m1 = new Model.P_MaterialList();
                    m1.StandId= cover.UserPaper.Id;
                    m1.StandName = cover.UserPaper.PaperName;
                    m1.MType = 1;
                    m1.UnitPrice = cover.UserPaper.PaperPrice;
                    m1.GroupId = cover.GroupId;
                    m1.ExtendNum = cover.ExtendNum;
                    m1.ExtendRatio = cover.ExtendRatio;
                    m1.Num = cover.PaperNum;
                    m1.Price = Convert.ToInt32((m1.Num+m1.ExtendNum) * m1.UnitPrice);
                    m1.ListCode = cover.UnitName;
                    AllMaterial.Add(m1);
                }

                if (cover.PrintPs != null)
                {
                    Model.P_MaterialList m2 = new Model.P_MaterialList();
                    if (cover.Color > 2)
                        m2.StandId = ConstantValue.Process.ColorPsid;
                    else
                        m2.StandId = ConstantValue.Process.BlackPsid;
                    m2.MType = 2;
                    int tie = cover.PrintPs.AllPsNum * 2 + cover.PrintPs.HalfPsNum + cover.PrintPs.QuarPsNum;
                    m2.Num = tie * cover.PrintPs.Color;
                    m2.StandName = cover.PrintPs.PsName;
                    m2.UnitPrice=cover.PrintPs.UnitPrice;
                    m2.GroupId = cover.GroupId;
                    m2.Price=Convert.ToInt32(m2.Num*m2.UnitPrice);
                    m2.ListCode = cover.UnitName;
                    AllMaterial.Add(m2);
                }
            }
        }
      
        /// <summary>
        /// 计算一个部件的印刷费用，含开机费和印工费；
        /// </summary>
        /// <param name="color"></param>
        /// <returns></returns>
        public void CaculationPrintProcess(ProductUnit pu)
        {
            if (Process == null)
            {
                Process = new List<Model.P_ProcessList>();
            }
            int PrintId,PrintPsId;
            if (pu.PrintPs == null)
            {
                pu.ReCaculation();
            }
            if(pu.PrintPs.Color>2)
            {
                PrintId=ConstantValue.Process.ColorPrint;
                PrintPsId=ConstantValue.Process.MakeColorPs;
            }
            else
            { 
                PrintId=ConstantValue.Process.BlackPrint;
                PrintPsId=ConstantValue.Process.MakeBlackPs;
            }
            Model.P_ProcessList w1 = new Model.P_ProcessList();
            Model.P_ProcessList w2 = new Model.P_ProcessList();
            int printnum=pu.PrintPs.AllPrintNum+pu.PrintPs.HalfPrintNum+pu.PrintPs.QuarPrintNum;
            int tie = pu.PrintPs.AllPsNum * 2 + pu.PrintPs.HalfPsNum + pu.PrintPs.QuarPsNum;
            int makenum=tie;
            
            //插入并计算印工费
            if (pu.Color> 0)
            {
                w1.ProcessId = PrintId;
                w1.Num = printnum;
                if (pu.Size.Num > 1)
                {
                    w1.Num = w1.Num * 2;
                }
                w1.ProcessName = "印工费";
                if (w1.Num > 1)
                {
                    w1.Price = DAL.C_ProcessPrice.GetPrice(w1.ProcessId, w1.Num);
                }
                else
                    w1.Price = 0;
                w1.GroupId = pu.GroupId;
                w1.PType = 1;
                w1.ListCode = pu.UnitName;
                //增加印刷的损耗；
                pu.ExtendRatio = ConstantValue.Process.ExtendRatio;
                pu.ExtendNum += tie * ConstantValue.Process.ExtendBase / pu.PrintPaper.Kaidu;

                //插入并计算开机费
                if (pu.ContentRepeat < 2)
                {
                    w2.ProcessId = PrintPsId;
                    w2.ProcessName = "开机费";
                    w2.Num = tie;
                    w2.GroupId = pu.GroupId;
                    w2.PType = 1;
                    w2.Price = DAL.C_ProcessPrice.GetPrice(w2.ProcessId, w2.Num);
                    w2.ListCode = pu.UnitName;
                    Process.Add(w2);
                }
                Process.Add(w1);
            }
        }

        public void InsertProces(List<Model.recttange> plist)
        {
           
            if (Process == null)
            {
                Process = new List<Model.P_ProcessList>();
            }
            foreach (Model.recttange r in plist)
            {

                Model.P_ProcessList w = new Model.P_ProcessList();
                w.GroupId = r.MId;
               
                Model.Process p = DAL.Process.GetModel(r.Id);
                if (p != null)
                {
                    w.ProcessId = p.ProcessId;
                    w.ProcessName = p.ProcessName;
                    int type = p.AreaMarking;
                    if (type == 1)
                    {
                        w.ArHeight = ProductSize.Height;
                        w.ArLength = ProductSize.Length;
                        int s = w.ArHeight * w.ArLength;
                        if (ProductId == 1&&w.GroupId==0)
                        {
                            s = Cover.Size.Height * Cover.Size.Length *  2;
                        }
                        if (ProductId == 4)
                        {
                            s = Cover.Size.Length * Cover.Size.Height;
                        }
                        double s0 = s;
                        s0 = s0 * ProductNum;
                        s0 = s0 / 1000000;
                        w.Num = Convert.ToInt32(s0);
                    }
                    if (type == 0)
                    {
                        w.Num = ProductNum;
                    }
                    if (type == 12)
                    {
                        w.Num = r.length * ProductNum;
                    }
                    if (type == 13)
                    {
                        w.Num = r.QuNum;
                    }
                    int extend = p.MinExtendPaper;
                    w.Price = DAL.C_ProcessPrice.GetPrice(r.Id, w.Num);
                    w.GroupId = 0;
                    if (w.GroupId == 0)
                    {
                        Cover.ExtendRatio = p.ExtendRatio;
                        Cover.ExtendNum += extend;
                        w.ListCode = Cover.UnitName;
                    }
                    else
                    {
                        if (Inner != null)
                        {
                            if (w.GroupId <= Inner.Count)
                            {
                                Inner[w.GroupId - 1].ExtendRatio = p.ExtendRatio;
                                Inner[w.GroupId - 1].ExtendNum += extend;
                                w.ListCode = Inner[w.GroupId - 1].UnitName;
                            }
                        }
                        else
                        {
                            return;
                        }
                    }
                    w.b1 = 1;
                    Process.Add(w);
                }
            }
        }

        public void InsertSingleProcess(int ProcessId,int Num)
        {
            if (Process == null)
            {
                Process = new List<Model.P_ProcessList>();
            }
            Model.P_ProcessList w = new Model.P_ProcessList();
            Model.Process mp = DAL.Process.GetModel(ProcessId);
            if (mp != null)
            {
                w.ProcessId = ProcessId;
                w.Num = Num;
                w.ProcessName = mp.ProcessName;
                w.ListCode = Cover.UnitName;
                w.GroupId = 0;
                w.Price = DAL.C_ProcessPrice.GetPrice(ProcessId, Num);
                Process.Add(w);
            }
        }

        public void InsertSingleProcess(int ProcessId, int Num,int Groupid)
        {
            if (Process == null)
            {
                Process = new List<Model.P_ProcessList>();
            }
            Model.P_ProcessList w = new Model.P_ProcessList();
            Model.Process mp = DAL.Process.GetModel(ProcessId);
            w.GroupId = Groupid; 
            if (mp != null)
            {
                w.ProcessId = ProcessId;
                w.Num = Num;
                w.ProcessName = mp.ProcessName;
                w.ListCode = Cover.UnitName;
                w.Price = DAL.C_ProcessPrice.GetPrice(ProcessId, Num);
                Process.Add(w);
            }

        }
        private Model.P_ProcessList CheckProcess(Model.P_ProcessList w)
        {
            //检查某种工艺需要关联工艺；
            //折页超过克重后，压痕；
            ProductUnit p1 = null;
            Model.P_ProcessList result=null;
            if(w.ProcessName.IndexOf("折页")>=0)
            {
                int gp=w.GroupId;
                if (gp >0)
                {
                    if(Inner!=null)
                    {
                        if(Inner.Count<=gp)
                        {
                            p1=Inner[gp-1];
                        }
                    }

                }
                else
                {
                    p1 = Cover;
                }
                if (p1 != null)
                {
                    if (p1.UserPaper.kg > 157)
                    {
                        int id = 41;
                        result = new Model.P_ProcessList();
                        Model.Process p2 = DAL.Process.GetModel(id);
                        result.ProcessId = p2.ProcessId;
                        result.ProcessName = p2.ProcessName;
                        result.Num = w.Num;
                        result.Price = DAL.C_ProcessPrice.GetPrice(result.ProcessId, w.Num);
                        result.ListCode = w.ListCode;
                        result.GroupId = w.GroupId;
                    }
                }
            }
            return result;
        }
        /// <summary>
        /// 检查每一个构件的辅助工艺、隐含工艺
        /// </summary>
        /// <param name="p1"></param>
        public void CheckUnit(ProductUnit p1)
        {
            int PagePrePs = p1.PsKaidu / p1.Size.Kaidu;
            int FoldTimes = 1;
            //成品尺寸小于32开，超过折页次数，需要增加裁切工艺；
            if (PagePrePs > 8)
            {
                InsertSingleProcess(46, p1.weight);
                FoldTimes = 2;
                PagePrePs = PagePrePs / 2;
            }
            if (PagePrePs % 4 == 0)
            {
                //十字折2次
                FoldTimes = FoldTimes * PagePrePs / 4;
                if (FoldTimes > 0)
                {
                    InsertSingleProcess(8, ProductNum * FoldTimes, p1.GroupId);
                }
            }
            else
            {
                InsertSingleProcess(7, PagePrePs * ProductNum, p1.GroupId);
            }
        }
        /// <summary>
        /// 得到一个产品的结果
        /// </summary>
        /// <returns></returns>
        public void GetProductPrice()
        {
                int paperprice, psprice, processprice, printprice, materialprice, bindprice;
                paperprice = 0;
                psprice = 0;
                processprice = 0;
                printprice = 0;
                materialprice = 0;
                bindprice = 0;

                if (Process != null)
                {
                    List<Model.P_ProcessList> tp = new List<Model.P_ProcessList>();
                    foreach (Model.P_ProcessList w in Process)
                    {
                        Model.P_ProcessList p0 = CheckProcess(w);
                        if (p0 != null)
                        {
                            tp.Add(p0);
                        }
                    }
                    if (tp.Count > 0)
                    {
                        Process.AddRange(tp);
                    }

                    foreach (Model.P_ProcessList w in Process)
                    {
                        if (w.PType == 1)
                            printprice += w.Price;
                        if (w.PType == 2)
                            bindprice += w.Price;
                        if (w.PType != 1 && w.PType != 2)
                            processprice += w.Price;
                    }
                }
                if (AllMaterial != null)
                {
                    foreach (Model.P_MaterialList m in AllMaterial)
                    {
                        if (m.MType == 1)
                            paperprice += m.Price;
                        if (m.MType == 2)
                            psprice += m.Price;
                        if (m.MType != 1 && m.MType != 2)
                        {
                            materialprice += m.Price;
                        }
                    }
                }
                if (AllPrice == null)
                    AllPrice = new Model.ResultPrice();
                AllPrice.AddPrice(paperprice, psprice, materialprice, printprice, bindprice, processprice);
        }

        public int GetPrice(int PriceMode)
        {
            //计算封面的材料和工艺
            if (Cover != null)
            {
                Init(Cover);
                AllPrice = new Model.ResultPrice();

                //计算印刷列表
                if (PrintList == null)
                {
                    PrintList = GetPrintUnitByProduct(Cover);
                }
                //计算产品重量和纸张重量；
                AllWeight = Cover.weight;
                PaperWeight = GetPaperWeigh(Cover);
            }
            if (Inner != null&&BindType>0)
            {
                foreach (ProductUnit pu in Inner)
                {
                    Init(pu);

                    //计算印刷列表
                   
                        PrintList.InsertRange(0,GetPrintUnitByProduct(pu));
                    //计算产品重量和纸张重量；
                    AllWeight += pu.weight;
                    PaperWeight += GetPaperWeigh(pu);
 
                }
            }
            GetProductPrice();
            return AllPrice.CalPrice(PriceMode);
        }

        public List<Model.P_PrintList> GetPrintUnitByProduct(ProductUnit pu)
        {
            List<Model.P_PrintList> result = new List<Model.P_PrintList>();
            Model.P_PrintList All;
            Model.P_PrintList Half ;
            Model.P_PrintList Qur;
            PrintSheet ps=pu.PrintPs;
            int tie = ps.AllPsNum * 2 + ps.HalfPsNum + ps.QuarPsNum;
            if (ps.AllPsNum > 0)
            {
                All = new Model.P_PrintList();
                All.PsMode =(int) ConstantValue.Process.PsMode.大翻;
                All.PsModeName = ConstantValue.Process.PsMode.大翻.ToString();
                All.PrintHeight = pu.PrintPaper.Height;
                All.PsNum = ps.AllPsNum*2;
                All.PrintLength = pu.PrintPaper.Length;
                All.PaperId = pu.PrintPaper.Id;
                All.PaperName = pu.UserPaper.PaperName;
                All.PrintPaperNum = ps.AllPrintNum;
                All.ProductHeight = pu.Size.Height;
                All.ProductLength = pu.Size.Length;
                All.BigPaperNum = ps.AllPrintNum/ps.PsKaidu;
                All.Color = pu.Color;
                All.PaperSource = pu.PaperSource;
                All.ExtendNum = pu.ExtendNum * ps.AllPsNum * 2 / tie;
                if (pu.Size.Num > 1)
                    All.DoubleSide = 2;
                else
                    All.DoubleSide = 1;
                All.GroupId = pu.GroupId;
                if (All.GroupId == 0)
                    All.UnitName = ProductName;
                else
                    All.UnitName = ProductName + "第" + All.GroupId.ToString() + "个内页";
                result.Add(All);
            }
            if (ps.HalfPsNum > 0)
            {
                Half = new Model.P_PrintList();
                Half.PsMode = (int)ConstantValue.Process.PsMode.正反自翻;
                Half.PsModeName = ConstantValue.Process.PsMode.正反自翻.ToString();
                Half.PrintHeight = pu.PrintPaper.Height;
                Half.PrintLength = pu.PrintPaper.Length;
                Half.PaperId = pu.PrintPaper.Id;
                Half.PaperName = pu.UserPaper.PaperName;
                Half.PrintPaperNum = ps.HalfPrintNum * pu.PsKaidu;
                Half.BigPaperNum = ps.HalfPrintNum ;
                Half.Color = pu.Color;
                Half.PsNum = 1;
                Half.ProductHeight = pu.Size.Height;
                Half.ProductLength = pu.Size.Length;
                Half.PaperSource = pu.PaperSource;
                Half.ExtendNum = pu.ExtendNum * ps.HalfPsNum  / tie ;
                if (pu.Size.Num > 1)
                    Half.DoubleSide = 2;
                else
                    Half.DoubleSide = 1;
                Half.GroupId = pu.GroupId;
                if (Half.GroupId == 0)
                    Half.UnitName = ProductName;
                else
                    Half.UnitName = ProductName + "第" + Half.GroupId.ToString() + "个内页";
                result.Add(Half);
            }
            if (ps.QuarPsNum > 0)
            {
                Qur = new Model.P_PrintList();
                Qur.PsMode = (int)ConstantValue.Process.PsMode.双拼自翻;
                Qur.PsModeName = ConstantValue.Process.PsMode.双拼自翻.ToString();
                Qur.PrintHeight = pu.PrintPaper.Height;
                Qur.PrintLength = pu.PrintPaper.Length;
                Qur.PaperId = pu.UserPaper.Id;
                Qur.PaperName = pu.UserPaper.PaperName;
                Qur.PrintPaperNum = ps.QuarPrintNum * pu.PsKaidu;
                Qur.BigPaperNum = ps.QuarPrintNum ;
                Qur.Color = pu.Color;
                Qur.ProductHeight = pu.Size.Height;
                Qur.ProductLength = pu.Size.Length;
                Qur.PaperSource = pu.PaperSource;
                Qur.PsNum = 1;
                Qur.ExtendNum = pu.ExtendNum * ps.QuarPsNum  / tie;
                if (pu.Size.Num > 1)
                    Qur.DoubleSide = 2;
                else
                    Qur.DoubleSide = 1;
                Qur.GroupId = pu.GroupId;
                if (Qur.GroupId == 0)
                    Qur.UnitName = ProductName;
                else
                    Qur.UnitName = ProductName + "第" + Qur.GroupId.ToString() + "个内页";
                result.Add(Qur);
            }
            return result;
        }

        public string  GetOrder(string UserName,string UserNeed,string address,int deliverprice)
        {
            string result = "下单成功！订单总价：" + (AllPrice.DiscountPrice+deliverprice) .ToString();
            Model.P_Order order = new Model.P_Order();
            order.CostPrice = AllPrice.DiscountPrice+deliverprice;
            order.CustomerId = UserName;
            order.CustomerRequest = UserNeed;
            order.InsidePrice = AllPrice.Price;
            order.Price = AllPrice.DiscountPrice;
            order.AddressId = address;
            order.OrderTime = DateTime.Now;
            order.ProductionTime = DateTime.Now.AddDays(1);
            order.EndTime = DateTime.Now.AddDays(7);
            order.DeliverPrice = deliverprice;
            order.Remark = UserRequest;

            //如果是纸杯，产品表就没有这个产品；直接是按订单完成处理；
            //if (ProductId == 8)
            //    order.Status =(int) ConstantValue.Order.OrderStatus.订单完成;
            string OrderCode= DAL.P_Order.Add(order);

            if (true)
            {
                Model.P_ProductList pro = new Model.P_ProductList();
                pro.CostPrice = AllPrice.Price;
                pro.ProductId = ProductId;
                pro.CustomerRequest = UserNeed;
                pro.LastPrice = AllPrice.DiscountPrice;
                pro.PaperPrice = AllPrice.PaperPrice;
                pro.PrintPrice = AllPrice.PrintPrice;
                pro.ProcessPrice = AllPrice.ProcessPrice + AllPrice.BindPrince;
                pro.OtherPrice = AllPrice.OtherPrice;
                pro.PsPrice = AllPrice.PsPrince;
                pro.PaperWeight = PaperWeight;
                pro.ProductWeight = AllWeight;
                pro.ProducSizeId = ProductSize.Id;
                pro.productHeight = ProductSize.Height;
                pro.ProductLength = ProductSize.Length;
                pro.ProductNum = ProductNum;
                pro.ProductName = ProductName;
                pro.BindType = BindType;
                pro.StartTime = DateTime.Now;
                pro.EndTime = DateTime.Now.AddDays(7);
                pro.OrderOn = OrderCode;
                pro.AuditingTime = DateTime.Now.AddDays(1);
                pro.ProductionTime = DateTime.Now.AddDays(1);
                pro.Status = 1;
                pro.Remark = UserRequest;
                string ProCode = DAL.P_ProductList.Add(pro);
                if (ProCode != null)
                {
                    Cover.SaveUnit(ProCode);
                }
                this.ProductCode = ProCode;
                if (AllMaterial != null)
                    savematerial(ProCode);
                if (Process != null)
                {
                    saveprocess(ProCode);
                }
                if (PrintList != null)
                    saveprintunit(ProCode);
            }
            return  OrderCode;

        }
        private int  savematerial(string ProCode)
        {
           int codenum = 0;
           
           foreach (Model.P_MaterialList m in AllMaterial)
            {
                m.OrderOn = ProCode;
                m.Code = ProCode + codenum.ToString();
                DAL.P_MaterialList.Add(m);
                codenum++;
            }
           return codenum;
        }

        private int saveprocess(string ProCode)
        {
            int codenum = 0;
            foreach (Model.P_ProcessList w in Process)
            {
                w.OrderOn = ProCode;
                w.Code = ProCode + codenum.ToString();
              
                DAL.P_ProcessList.Add(w);
                codenum++;
            }
            return codenum;
        }

        private int saveprintunit(string ProCode)
        {
            int codenum = 0;
            foreach (Model.P_PrintList p in PrintList)
            {
                p.OrderOn = ProCode;
                p.ListCode = p.UnitName;
                p.Code = ProCode + codenum.ToString();
                DAL.P_PrintList.Add(p);
                codenum++;
            }
            return codenum;
        }


        public int SaveAsklist(int mode,string UserName,string IpAdd,string UserSource,int sourceType)
        {
            Model.P_AskList ask = new Model.P_AskList();
            int price =0;

            if (AllPrice != null)
            {
                price = AllPrice.DiscountPrice;
                ask.Request = UserRequest;
                ask.Request = ask.Request.Replace("\"", "");
                if (ask.Request.Length > 300)
                    ask.Request = ask.Request.Remove(298);
                ask.Price = price;
                ask.Result = AllPrice.ToString();
                ask.ProductName = ProductName;
                ask.IpAdress = IpAdd;
                ask.SourceType = sourceType;
                ask.Number = ProductNum;
                ask.AskResource = UserSource;
                ask.CustomerId = UserName;
                ProductCode = DAL.P_AskList.Add(ask);
            }
            return price;
        }


        /// <summary>
        /// 计算一个构件所有用纸的重量；
        /// </summary>
        /// <param name="pu"></param>
        /// <returns></returns>
        public int GetPaperWeigh(ProductUnit pu)
        {
            int weight = 0;
            if (pu.PageNum > 0)
            {
                decimal pw = (decimal)pu.weight / pu.PaperUserRatio;
                pw = pw / pu.PaperNum * (pu.PaperNum + pu.ExtendNum);
                weight = Convert.ToInt32(pw);
            }
            return weight;
        }

      
        /// <summary>
        /// 把MODEL下的矩形转化自己的类
        /// </summary>
        /// <param name="rect"></param>
        /// <returns></returns>
        public Model.recttange GetModleByRect(rectang rect)
        {
            Model.recttange r = new Model.recttange();
            r.Id = rect.Id;
            r.height = rect.Height;
            r.length = rect.Length;
            r.MId = rect.MId;
            r.Name = rect.Name;
            r.QuNum = rect.Num;
            return r;
        }

        public override string ToString()
        {
            string result = "";
            StringBuilder sb = new StringBuilder();
            JavaScriptSerializer jsson = new JavaScriptSerializer();
            jsson.Serialize(this, sb);
            result = sb.ToString();
            return result;
        }
        public string GetPriceTable()
        {
            MakeTable NeedTable = new MakeTable(4, ProductName+"计算结果");
            int p = 0;
            foreach (Model.P_MaterialList mp in AllMaterial)
            {
                NeedTable.InserCell(mp.ListCode, mp.StandName);
                NeedTable.InserCell(mp.Num.ToString()+"+"+mp.ExtendNum.ToString(), mp.Price.ToString());
                p += mp.Price;
            }
            foreach (Model.P_PrintList pr in PrintList)
            {
                NeedTable.InserCell(pr.UnitName, pr.PsModeName + "纸张尺寸" + pr.ProductHeight.ToString() + "x" + pr.ProductLength.ToString());
                NeedTable.InserCell("印张数：" + pr.PrintPaperNum.ToString(), "");
            }
            foreach (Model.P_ProcessList pp in Process)
            {
                NeedTable.InserCell(pp.ListCode, pp.ProcessName);
                NeedTable.InserCell(pp.Num.ToString(), pp.Price.ToString());
                p += pp.Price;
            }
            NeedTable.InserCell("总价：", p.ToString());
            decimal p1 = (decimal)p / ProductNum;
            NeedTable.InserCell("单价：", p1.ToString("f3"));
            string result = NeedTable.GetResult();
            return result;
        }
    }
}

