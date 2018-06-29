using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JxPrint.BLL
{
    public class PrintSheet
    {
        public int PsId;
        public string PsName;
        public int PsKaidu;
        public int ProductKaidu;

        public int AllPsNum;
        public int HalfPsNum;
        public int QuarPsNum;

        public int GroupId;
        public int Color;

        public decimal UnitPrice;
        public int Price;
        public int PageNum;

        public int TotalPrintNum;
        public int TotalPsNum;
        public int TotalTieNum;

        public int AllPrintNum;
        public int HalfPrintNum;
        public int QuarPrintNum;

        public PrintSheet(int color,int productkaidu,int pskaidu,int pronum,int page,string psname)
        {
            float colorxs = 1;
            Color = color;
            if (Color > 3)
            {
                PsId = ConstantValue.Process.ColorPsid;
                PsName = "彩色PS";
                UnitPrice = ConstantValue.Process.Colorps;
                colorxs = color;
                colorxs = colorxs / 4;
                if (color != 4)
                    Color = Convert.ToInt32( color * colorxs);

            }
            else
            {
                PsId = ConstantValue.Process.BlackPsid;
                PsName = "黑白PS";
                UnitPrice = ConstantValue.Process.Blackps;
                if (color != 1)
                    colorxs = color / 1;
            }
            ProductKaidu = productkaidu;
            PsKaidu = pskaidu;
            int PagePrePs = ProductKaidu / pskaidu;
            TotalPrintNum = Convert.ToInt32( pronum*page/ProductKaidu*pskaidu/2*colorxs);
            PageNum = page;
            SetPrintPs();
            //SetPrintNum();
            TotalPsNum = AllPsNum * 2 + HalfPsNum + QuarPsNum;
            TotalTieNum = AllPsNum  + HalfPsNum + QuarPsNum;
            Price = Convert.ToInt32( TotalPsNum * Color * UnitPrice);

            AllPrintNum = (TotalPrintNum * AllPsNum * 2 * PagePrePs) / page;
            HalfPrintNum = (TotalPrintNum * HalfPsNum * PagePrePs) / page;
            QuarPrintNum = TotalPrintNum - AllPrintNum - HalfPrintNum;
            PsName = psname + PsName;
        }

        public override string ToString()
        {
            string s = PsName;
            if (AllPsNum > 0)
            {
                s += "  大翻:" + AllPsNum.ToString();
                s += "套，印数:" + AllPrintNum.ToString();
            }
            if (HalfPsNum > 0)
            {
                s += "  自翻:" + HalfPsNum.ToString();
                s += "套，印数:" + HalfPrintNum.ToString();
            }
            if (QuarPsNum > 0)
            {
                s += "  双拼:" + QuarPsNum.ToString();
                s += "套，印数:" + QuarPrintNum.ToString();
            }
            return s;
        }
        private void SetPrintNum()
        {
            int pnum = TotalPrintNum;
            if (AllPrintNum > 0)
                AllPrintNum = pnum / AllPrintNum * AllPsNum;
            if (HalfPsNum > 0)
                HalfPrintNum = pnum / HalfPrintNum;
            if (QuarPsNum > 0)
                QuarPrintNum = pnum / QuarPrintNum;
        }
        public void SetPrintPs()
        {
            int totalpage = PageNum;
            int lastpage = PageNum;
            int PagePrePs = ProductKaidu / PsKaidu;

            //如果一个版只能放下一个页面，就直接返回页面数等于整版数；
            if (PagePrePs < 2)
            {

                AllPsNum = PageNum/2;
                HalfPsNum = PageNum % 2;
                return;
            }
            int All = lastpage / PagePrePs;
            AllPsNum = All / 2;
            HalfPsNum = All % 2;
            lastpage = lastpage - AllPsNum * 2 * PagePrePs - HalfPsNum * PagePrePs;
            //整版和半版合完了，还有页面，基本上都是1/4版；
            if (lastpage < 1)
            {
                return;
            }
            //考虑在3开版的情况，和双拼自翻的情况；
            if (lastpage <= PagePrePs / 2)
            {
                QuarPsNum = 1;
                return;
            }
            AllPsNum++;
            return;

        }


        //public void SetPrintPs()
        //{
        //    int page = PageNum;
        //    int lastpage = PageNum;
        //    int PagePrePs = (ProductKaidu / PsKaidu) * 2;
        //    if (page > 2)
        //    {
        //        int psnum = lastpage / PagePrePs;
        //        lastpage = lastpage % PagePrePs;
        //        if (psnum > 0)
        //        {
        //            AllPsNum = psnum;
        //            AllPrintNum = psnum * PagePrePs;
        //        }
        //        if (ProductKaidu == 2 && lastpage == 0)
        //            return;
        //        PagePrePs = PagePrePs / 2;
        //        psnum = lastpage / PagePrePs;
        //        lastpage = lastpage % PagePrePs;
        //        if (psnum > 0)
        //        {
        //            HalfPsNum = psnum;
        //            HalfPrintNum = PagePrePs;
        //        }
                
        //        PagePrePs = PagePrePs / 2;
        //        psnum = lastpage / PagePrePs;
        //        if (psnum > 0)
        //        {
        //            QuarPsNum = psnum;
        //            QuarPrintNum = PagePrePs;
        //            lastpage = lastpage - PagePrePs;
        //        }
        //        if (lastpage > 0)
        //        {
        //            QuarPsNum += 1;
        //            QuarPrintNum += lastpage;
        //        }
        //    }
        //    else
        //    {
        //        if (lastpage == 1 )
        //        {
        //            if (PagePrePs == 1)
        //            {
        //                AllPsNum = 1;
        //                AllPrintNum = 1;
        //                return;
        //            }
        //            else
        //            {
        //                if (PagePrePs < 4)
        //                {
        //                    HalfPsNum = 1;
        //                    HalfPrintNum = 1;
        //                }
        //                else
        //                {
        //                    QuarPsNum = 1;
        //                    QuarPrintNum = 1;
        //                }
                        
        //            }
        //        }
        //        if (lastpage == 2)
        //        {
        //            if (PagePrePs >= 4)
        //            {
        //               QuarPsNum = 1;
        //               QuarPrintNum = 1;
        //               return;
        //            }
        //            if (PagePrePs == 3)
        //            {

        //                AllPsNum = 1;
        //                AllPrintNum = 1;
        //                return;
        //            }
        //            if (PagePrePs == 2)
        //            {
        //                HalfPsNum = 1;
        //                HalfPrintNum = 1;
        //                return;
        //            }
        //            AllPsNum = 1;
        //            AllPrintNum = 1;
        //            return;
        //        }
        //    }
        //}
    }
}
