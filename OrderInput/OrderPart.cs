using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OrderInput
{
    public class OrderPart
    {
        public int ProductType;
        
        public Model.Rectange Paper;
        public Model.Rectange Ps;
        public Model.Rectange CutPaper;
        public Model.Rectange Product;

        public Model.NameType PaperName;

        public bool PaperSource;
        public int ColorNum;
        public int ProductNum;
        public int PageNum;

        public List<Model.PartItem> AllItem;
        public List<int> AllNum;
        private Model.OrderPart Part;

        Model.PsSheet Sheet;

        public List<string> NumUnit;

        public int AllPSnum, AllPrintNum, AllExtendPaper,AllPsSet;
      
        public OrderPart(int id, int len, int width, int num)
        {
            Product = new Model.Rectange(len, width);
            ProductNum = num;
            ProductType = id;
            AllItem = new List<Model.PartItem>();
            Part = new Model.OrderPart();
            Part.Num = num;
        }
        private bool CheckPart()
        {
            string result = null;
            if (Product.Length <= 0)
            {
                result = "成品长度不能小于0";
            }
            if (Product.Width <= 0)
            {
                result = "产品宽度不能小于0";
            }
            if (ProductNum <= 0)
            {
                result = "产品数量不能小于0";
            }
            if (result == null)
                return true;
            else
                return false;
        }

        public Model.OrderPart GetOrderPart()
        {
            //Part = new Model.OrderPart();
            Part.ColorNum = ColorNum;
            Part.PageNum = PageNum;
            Part.Num = ProductNum;
            if (PaperSource)
            {
                Part.PaperSource = 0;
                Part.PaperName = "来料加工";
                Part.PaperId = 0;
            }
            else
            {
                Part.PaperSource = 1;
                Part.PaperId = PaperName.Id;
                Part.PaperName = PaperName.Name;
            }
            Part.PartName = Model.Common.ProductType[ProductType-1].Name;
            Part.PSLength = Ps.Length;
            Part.PSWidth = Ps.Width;
            Part.Width = Product.Width;
            Part.Length = Product.Length;
            Part.PaperLength = Paper.Length;
            Part.PaperWidth = Paper.Width;

            foreach(Model.PartItem pi in AllItem)
            {
                if (pi.PartType == 0)
                {
                    Part.PaperNum = pi.Num;
                }
                if (pi.PartType == 2)
                {
                    Part.PSNum += pi.Num;
                }
            }
            return Part;

        }
        public bool MakePart()
        {
            #region 基础计算；
            bool result = true;
           

            if (!CheckPart())
            {
                ProductType = -1;
                return false;
            }
           
         
            Model.Tree cutree = Model.Common.PaperCut;

            Paper = cutree.GetPaper(Product.Length, Product.Width);
            Ps = cutree.GetPs(Product.Length, Product.Width);
            CutPaper = cutree.GetCutSize(Product.Length, Product.Width);

            int NumPrePage = 1;
            int calpage = PageNum;
            #region 计算用纸数量；

            if (PageNum % 2 == 1)
            {
                calpage = PageNum + 1;
                if (PageNum > 2)
                {
                    PageNum = calpage;
                }
            }

            NumPrePage = calpage / 2;
            Part.PaperNum = NumPrePage * ProductNum / CutPaper.Kaidu;
            if (!PaperSource)
            {

                Model.PartItem pi = new Model.PartItem();
                pi.PartType = 0;
                pi.PartName = "纸张";
                pi.Id = PaperName.Id;
                pi.Name = PaperName.Name;
                pi.Price = Model.Paper_Store.GetPaperById(PaperName.Id).UnitPrice;
               
                pi.Num = Part.PaperNum;
                pi.Money = pi.Price * pi.Num;
                pi.Remark = PaperName.Name.Substring(0, 2) + CutPaper.Kaidu.ToString() + "开";
                AllItem.Add(pi);
            }
            else
            {
                Part.PaperName = "来料加工";
                Part.PaperId = 0;
            }
           
            #endregion

            if (ColorNum <= 0)
                return true;
            if (Ps.Kaidu > 2 && CutPaper.Kaidu >= 12)
                Ps.Kaidu = 2;
            //计算2开印刷的情况；
            Model.PsSheet Sheet2 = new Model.PsSheet(Ps.Kaidu, CutPaper.Kaidu, PageNum);
            Model.PsSheet pstemp = Sheet2;
            decimal totalprice2 = 0;
            while (pstemp != null)
            {
                Model.PartItem pips = MakePs(pstemp);
                Model.PartItem piprint = MakePrint(pstemp);
                Model.PartItem piopen = MakeOpen(pstemp);
                totalprice2 += pips.Money;
                totalprice2 += piprint.Money;
                totalprice2 += piopen.Money;
                pips.Id += 20;
                piopen.Id += 20;
                piprint.Id += 20;
                AllItem.Add(pips);
                AllItem.Add(piprint);
                AllItem.Add(piopen);
                pstemp = pstemp.Next;
            }
            //如果可以三开印，也计算下三开的。
            decimal totalprice3 = 0;
            bool Needchange = false;
            if (CutPaper.Kaidu % 3 == 0)
            {
                Model.PsSheet Sheet3 = new Model.PsSheet(3, CutPaper.Kaidu, PageNum);
                Model.PsSheet ps11 = Sheet3;
                while (ps11 != null)
                {
                    Model.PartItem pips = MakePs(ps11);
                    Model.PartItem piprint = MakePrint(ps11);
                    Model.PartItem piopen = MakeOpen(ps11);
                    totalprice3 += pips.Money;
                    totalprice3 += piprint.Money;
                    totalprice3 += piopen.Money;

                    pips.Id += 30;
                    piopen.Id += 30;
                    piprint.Id += 30;

                    AllItem.Add(pips);
                    AllItem.Add(piprint);
                    AllItem.Add(piopen);
                    ps11 = ps11.Next;
                }
                if (totalprice3 < totalprice2)
                {
                    Needchange = true;
                }
                else
                {
                    List<Model.PartItem> Newlist = new List<Model.PartItem>();
                    foreach (Model.PartItem pi in AllItem)
                    {
                        if (!(pi.Id >= 30 && pi.Id < 40))
                        {
                            if (pi.Id >= 20 && pi.Id < 30)
                            {
                                pi.Id = pi.Id - 20;
                            }
                            Newlist.Add(pi);
                        }
                       
                    }
                    AllItem = Newlist;
                    Sheet = Sheet3;
                    Ps.Kaidu = 2;
                    Ps.Length = Paper.Length / 2;
                    Ps.Width = Paper.Width;
                }
            }
            if (Needchange)
            {
                List<Model.PartItem> Newlist = new List<Model.PartItem>();
                foreach (Model.PartItem pi in AllItem)
                {
                    if (!(pi.Id >= 20 && pi.Id < 30))
                    {
                        if (pi.Id >= 30 && pi.Id < 40)
                        {
                            pi.Id = pi.Id - 30;
                        }
                        Newlist.Add(pi);
                    }
                   
                }
                AllItem = Newlist;
                Sheet = Sheet2;
                Ps.Kaidu = 3;
                Ps.Length = Paper.Length / 3;
                Ps.Width = Paper.Width;
            }
            CalTotalNum();
            AllExtendPaper += AllPsSet * 50;
            Part.PaperExtend = AllExtendPaper;
            CalAllNum();
            return result;
            #endregion
        }

        private void CalTotalNum()
        {
            AllExtendPaper = 0;
            AllPrintNum = 0;
            AllPSnum = 0;
            AllPsSet = 0;
            foreach (Model.PartItem pi in AllItem)
            {

                if (pi.PartType == 0)
                {
                    AllExtendPaper = pi.Num / 20;
                }
                if (pi.PartType == 2)
                {
                    AllPSnum += pi.Num;
                }
                if (pi.PartType == 3)
                {
                    AllPsSet += pi.Num;
                }
                if (pi.PartType == 4)
                {
                    AllPrintNum += pi.Num;
                }
            }
        }

        #region 计算版纸
        private Model.PartItem MakePs(Model.PsSheet ps)
        {
            int colornum = ColorNum;
            Model.PartItem pips = new Model.PartItem();
            pips.PartType = 2;
            string psname = "";
            decimal psprice = 0;
            pips.Num = colornum * ps.PsNum;
            if (colornum == 1)
            {
                psname = "黑白版纸";
                psprice = (decimal)14.1;
                pips.PartType = 1;
            }
            if (colornum == 2)
            {
                psname = "双套色版纸";
                psprice = (decimal)14.1;
                pips.PartType = 1;

            }
            if (colornum == 4)
            {
                psname = "彩色版纸";
                psprice = (decimal)13.3;
                pips.PartType = 2;
            }
            pips.PartName = psname;
            pips.Name =ps.PsKaidu.ToString() + "开" + psname;
            pips.Id = colornum;
            pips.Price = psprice;
            pips.Money = pips.Num * pips.Price;
            pips.Remark = ((Model.PsMode)ps.PrintNum).ToString() ;
            return pips;
        }
        #endregion
        #region 计算开机费
        private Model.PartItem MakeOpen(Model.PsSheet ps)
        {
            int colornum = ColorNum;
            Model.PartItem pips = new Model.PartItem();
            pips.PartType = 3;
            string psname = "";
            int pid = 3;
            decimal psprice = 0;
            pips.Num = 1;
            if (colornum == 1)
            {
                psname = "黑白开机";
                pid = 33;
            }
            if (colornum == 2)
            {
                psname = "黑白开机";
                pips.Num = 2;
                pid = 33;
            }
            if (colornum == 4)
            {
                psname = "彩色开机";
            }
            pips.Num = pips.Num * ps.PsNum;
            psprice = Model.C_ProcessPrice.GetProcessPrice(pid, 1);
            pips.PartName = psname;
            pips.Name = psname;
            pips.Id = pid;
            pips.Price = psprice;
            pips.Money = pips.Num * pips.Price;
            pips.Remark = ps.PrintNum.ToString() + "拼";
            return pips;
        }
        #endregion
        #region 计算印工费
        private Model.PartItem MakePrint(Model.PsSheet ps)
        {
            int num = 0;
            if (ps.PrintNum > 0)
            {
                num = ps.PsNum * ProductNum / (ps.PrintNum);
            }
            else
            {
                num = ps.PsNum * ProductNum;
            }
            int colornum = ColorNum;
            Model.PartItem pips = new Model.PartItem();
            pips.PartType = 4;
            string psname = "";
            int pid = 4;
            decimal psprice = 0;
            if (colornum == 1)
            {
                psname = "黑白印工";
                pid = 34;
            }
            if (colornum == 2)
            {
                psname = "黑白印工";
                pid = 34;
                num = num * 2;
            }
            if (colornum == 4)
            {
                psname = "彩色印工";
            }
            psprice = Model.C_ProcessPrice.GetProcessPrice(pid, num);
            Model.C_ProcessPrice cp = Model.C_ProcessPrice.GetById(pid);
            pips.Price = cp.SinglePrice1;
            pips.PartName = psname;
            pips.Name = psname;
            pips.Id = pid;
            pips.Num = num;
            pips.Money = psprice;
            pips.Remark = ps.PrintNum.ToString() + "拼";
            return pips;
        }
        #endregion

        private void CalAllNum()
        {
            AllNum = new List<int>();
            NumUnit = new List<string>();
            AllNum.Add(0);
            NumUnit.Add("无");
            AllNum.Add(ProductNum*AllPsSet);
            NumUnit.Add("对开张");
            AllNum.Add(ProductNum);//无对应，产品数量；
            NumUnit.Add("本");
            int papernum = Part.PaperNum + Part.PaperExtend;
            AllNum.Add(papernum * Ps.Kaidu);//对开张，上机张数,折页工艺
            NumUnit.Add("张");
            AllNum.Add(papernum * 8);//8开张；压切工艺
            NumUnit.Add("八开张");
            decimal area = Paper.Length * Paper.Width;
            area = area * papernum / 1000 / 1000;
            int surface = (int)area;
            AllNum.Add(surface);//所有的表面积；覆膜
            NumUnit.Add("平方米");
            AllNum.Add(papernum * 8);//8开张数，表面工艺；
            NumUnit.Add("八开张");
            AllNum.Add(ProductNum);//本书；
            NumUnit.Add("本");
            AllNum.Add(ProductNum * 2);//加拉页和勒口的数量；
            NumUnit.Add("边");
            decimal w = area * Model.Paper_Store.GetPaperById(PaperName.Id).Kg / 1000;
            int PaperWeight = (int)w;
            AllNum.Add(PaperWeight);
            NumUnit.Add("公斤");
            decimal wp = Product.Length * Product.Width * CutPaper.Kaidu * papernum / 1000 / 1000 * Model.Paper_Store.GetPaperById(PaperName.Id).Kg / 1000;
            int ProductWeight = (int)wp;
            AllNum.Add(ProductWeight);
            NumUnit.Add("公斤");
        }

        public int GetProcessNum(int processid)
        {

            if (AllNum == null)
            {
                CalAllNum();
            }
            Model.Process pro = Model.Process.GetDataById(processid);
            if (pro == null)
            {
                return 0;
            }
            int num = 0;
            int ptype = pro.TypeId;
            num = AllNum[ptype];
            return num;
        }

        public string GetProcessNumUnit(int Processid)
        {
            string reslut = "";
            if (AllNum == null)
            {
                CalAllNum();
            }
            Model.Process pro = Model.Process.GetDataById(Processid);
            if (pro != null)
            {
                int ptype = pro.TypeId;
                reslut = NumUnit[ptype];
            }
            return reslut;
        }
        public bool AddProcess(int processid)
        {
            int num = GetProcessNum(processid);
            return AddProcess(processid, num);
        }

        public bool AddProcess(int processid, int num)
        {
            Model.PartItem pi = new Model.PartItem();
            pi.PartType = 8;
            pi.PartName = "后道工艺";
            pi.Id = processid;
            Model.Process pro = Model.Process.GetDataById(processid);
            int extend= (int) (Part.PaperNum*10*pro.ExtendRatio);
            Part.PaperExtend += extend;
            AllExtendPaper += extend;
            pi.Name = pro.ProcessName;
            pi.Num = num;
            pi.Money = Model.C_ProcessPrice.GetProcessPrice(processid, num);
            Model.C_ProcessPrice cp = Model.C_ProcessPrice.GetById(processid);
            pi.Price =cp.SinglePrice1;
            pi.Remark = "放张数:" + extend.ToString();
            AllItem.Add(pi);
            return true;
        }

        public bool ReCalPaper()
        {
            if (AllItem != null)
            {
                foreach (Model.PartItem pi in AllItem)
                {
                    if (pi.PartType == 0)
                    {
                        pi.Num += Part.PaperExtend;
                        pi.Money = pi.Price * pi.Num;
                        return true;
                    }
                }
            }
            return false;
        }
        public bool ReCalPrint()
        {
            if (AllItem != null)
            {
                foreach (Model.PartItem pi in AllItem)
                {
                    if (pi.PartType == 4)
                    {
                        pi.Num = pi.Num * (Part.PaperExtend + Part.PaperNum) / Part.PaperNum;
                        pi.Money = Model.C_ProcessPrice.GetProcessPrice(pi.Id, pi.Num);
                        return true;
                    }
                }
            }
            return false;
        }
    }
}
