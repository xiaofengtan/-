using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{

    public class PsSheet
    {
       
        public int PsKaidu;
       // public PsMode PrintMode;

        public int ProductKaidu;
        public int PrintNum;
        public int PsNum;

        public PsSheet Next;
        public PsSheet(int pskaidu, int pagekaidu)
        {
            PsKaidu = pskaidu;
            ProductKaidu = pagekaidu;
            PrintNum = 0;
            PsNum = 1;
            Next = null;
        }

        public PsSheet(int pskaidu, int pagekaidu,int psnum,int printnum)
        {
            PsKaidu = pskaidu;
            ProductKaidu = pagekaidu;
            PrintNum = printnum;
            PsNum = psnum;
            Next = null;
        }

        public PsSheet(int pskaidu, int pagekaidu, int pagenum) : this(pskaidu, pagekaidu)
        {
            int PagePrePs = ProductKaidu / PsKaidu;
            
            int nextnum = pagenum;
             
            List<PsSheet> lastps = new List<PsSheet>();
            int big = pagenum / PagePrePs;
            if (big > 0)
            {
                if (big % 2 != 0)
                {
                    PsSheet p1 = new PsSheet(PsKaidu, ProductKaidu, 1, 1);
                    lastps.Add(p1);
                    big = big - 1;
                }
                if (big > 0)
                {
                    PsSheet p1 = new PsSheet(PsKaidu, ProductKaidu, big, 0);
                    lastps.Add(p1);
                }
                nextnum = pagenum - (pagenum / PagePrePs * PagePrePs);
            }

            if (nextnum >= 0)
                {
                for (int m = 1; m <= PagePrePs; m = m * 2)
                {
                    if (nextnum>=PagePrePs/m)
                    {
                        PsSheet p1 = new PsSheet(PsKaidu, ProductKaidu, 1, m);
                        lastps.Add(p1);
                        nextnum = nextnum - PagePrePs / m;
                    }
                    if (nextnum <=2 &&nextnum>0)
                    {
                        PsSheet p1 = new PsSheet(PsKaidu, ProductKaidu, 1, PagePrePs/2);
                        lastps.Add(p1);
                        break;
                    }
                }
                if (lastps.Count > 0)
                {

                    PsNum = lastps[0].PsNum;
                    PrintNum = lastps[0].PrintNum;
                    if (lastps.Count > 1)
                    {
                        Next = lastps[1];
                        for (int i = 1; i < lastps.Count; i++)
                        {
                            lastps[i - 1].Next = lastps[i];
                        }
                    }
                }
            }
          
        }
        public List<PsSheet> MakePs(int PageNum)
        {
            List<PsSheet> Resutlt = new List<PsSheet>();

            int PagePrePs = ProductKaidu / PsKaidu;
            int LastPageNum = PageNum;
            int BigPageNum = PageNum / (PagePrePs);

            LastPageNum = LastPageNum - PagePrePs * BigPageNum;
           
            int userful = PagePrePs / 2;
            int[] userlist = new int[userful];  
            for (int i = 0; i < userful; i++)
            {
            }
          
            return Resutlt;

        }




    }
}
