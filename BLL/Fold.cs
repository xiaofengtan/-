using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Web.Script.Serialization;

namespace JxPrint.BLL
{
    public class FoldSheet
    {
        public rectang OldSize, NewSize;  //原始尺寸，目标尺寸;
        //public int SheetId { set; get; }
        //public int FoldNum { set; get; }
        //public int H_Fold { set; get; }//纵向折页次数；
        //public int L_Fold { set; get; }//横向折页次数；
        public int RatioTag { set; get; }//纸张是否旋转；
        public float Ratio { set; get; } //纸张利用率是多少；

        //标记是从数据库读到的开纸方法，还是自己计算的开纸方法；0表示数据库方法，1表示自行计算,2表示需求尺寸
        //3为非标尺寸合成标准尺寸，4表示非标准尺寸自行计算；
        public int TransTag { set; get; }

        private int[] nouserk = {  7, 10, 11, 13, 14, 15, 17, 19, 21, 22, 23, 25, 26 };

        public FoldSheet(int l, int h)
        {
            OldSize = new rectang();
            NewSize = new rectang();
            OldSize.Length = l;
            OldSize.Height = h;
            //AdjustOldSize(l, h);
            Init();
        }
        public FoldSheet(int OldSizeId)
        {
            OldSize = new rectang();
            NewSize = new rectang();
            OldSize.Id = OldSizeId;
            Init();
        }

        public FoldSheet(rectang oldsize)
        {
            OldSize = new rectang();
            NewSize = new rectang();
            OldSize = oldsize;
            if (oldsize.Id < 1)
            {
                //AdjustOldSize(oldsize.Length,oldsize.Height);
            }
            Init();
        }

        private void Init()
        {
            if (OldSize.Id > 0)
            {
                Model.ProductSize s1 = DAL.ProductSize.GetModel(OldSize.Id);
                if (s1 != null)
                {
                    OldSize.Id = s1.Id;
                    OldSize.Length = s1.StandLength;
                    OldSize.Height = s1.StandHeight;
                    OldSize.Kaidu = s1.Kaidu;
                    //有原始尺寸ID，就去查找P_SHEET表，有开法就返回，没有开法继续找；
                    if (GetPsSheet())
                    {
                        Ratio = GetRatio(OldSize.Length, OldSize.Height, NewSize.Length, NewSize.Height)*OldSize.Kaidu/NewSize.Kaidu;
                        return;
                    }
                }
            }
            //g根据原始尺寸的大小，去P_SHEET表中查找如果不成功，则继续手动计算；
            if (!GetPsSheet(OldSize.Length, OldSize.Height))
            {
                NewSize = GetNewSize(OldSize.Length, OldSize.Height);
                if (NewSize == null)
                {
                    OldSize.Id = 0;
                    OldSize.Name = "非标尺寸";
                    OldSize.Kaidu = 2;
                    NewSize = OldSize;
                }
            }
            Ratio = GetRatio(OldSize.Length, OldSize.Height, NewSize.Length, NewSize.Height)*OldSize.Kaidu/NewSize.Kaidu;
            return;
        }
       

      
       /// <summary>
       /// 从SIZE表中得到2,开，3开纸的原始尺寸，并计算纸张利用率最高的开法；
       /// </summary>
       /// <returns></returns>
        public rectang GetNewSize(int l, int h)
        {

            rectang max =new rectang();
            bool sucess = false;
            float r0=0, rmax=0;
            DataTable dt = JxPrint.DAL.Size.GetList("Status='2' ").Tables[0];
            foreach (DataRow dr in dt.Rows)
            {
                rectang t = new rectang();
                Model.Size s = DAL.Size.DataRowToModel(dr);
                t.Id = s.Id;
                t.Kaidu = s.KaiShu;
                t.Length = s.Length;
                t.Height = s.Height;
                t.Name = s.SizeName;
               
                r0=GetRatio(l, h, t.Length, t.Height);
                int kaidu = GetKaidu(l, h, t);
                r0 = r0 * kaidu;
                if (r0 > rmax)
                {
                    rmax = r0;
                    max = t;
                    OldSize.Kaidu = max.Kaidu * kaidu;
                    string kd = max.Name.Remove(2);
                    OldSize.Name = kd + OldSize.Kaidu.ToString() + "开";
                    sucess = true;
                }
            }
            if (sucess)
            {
                return max;
            }
            else
            {
                return null;
            }
        }
        /// <summary>
        /// 计算一个开发的纸张利用率；
        /// </summary>
        /// <param name="oldsize"></param>
        /// <param name="newsize"></param>
        /// <returns></returns>
        private float GetRatio(int oldl,int oldh,int newl,int newh)
        {
            float r = 1;
            int maxold = Math.Max(oldl, oldh);
            int maxnew = Math.Max(newl, newh);
            if (maxold > maxnew)
                r = 0;
            int sold = oldl * oldh;
            int snew = newl * newh;
            if (sold > snew)
                r = 0;
            if (r > 0)
            {
                r = (float)sold / (float)snew;
            }
            return r;
        }

        /// <summary>
        /// 如果原始尺寸不是非标尺寸，得到一个开数；
        /// </summary>
        /// <param name="oldsize"></param>
        /// <param name="newsize"></param>
        /// <returns></returns>
        private int GetKaidu(int l,int h, rectang newsize)
        {
            int kaidu=0;
            int chuxue = ConstantValue.Paper.ChuXue;
            int yaokou = ConstantValue.Paper.Yaokou;

             h +=  chuxue;
             l +=  chuxue;

            int maxh = newsize.Height - yaokou;
            int maxl = newsize.Length - yaokou;

            int rl = check( maxh / h);
            int ud = check(maxl / l);

            int rl1 =check( maxl / h);
            int ud1 = check(maxh / l);
            if (rl * ud > rl1 * ud1)
            {
                kaidu = rl * ud;
            }
            else
            {
                RatioTag = 1;
                kaidu = rl1 * ud1;
            }
            return kaidu;
        }


        private bool GetPsSheet(int l, int h)
        {
            bool sucess = false;

            Model.P_Sheet ps = DAL.P_Sheet.GetModelByLH(l, h);
            if (ps != null)
            {
                sucess = true;
                Model.Size st = DAL.Size.GetModel(ps.SizeId);//得到目标尺寸的数据，存入目标尺寸表
                if (st != null)
                {
                    NewSize.Id = st.Id;
                    NewSize.Height = st.Height;
                    NewSize.Length = st.Length;
                    NewSize.Kaidu = st.KaiShu;
                    NewSize.Name = st.SizeName;
                    OldSize.Kaidu = ps.ProductKaidu;
                    if(NewSize.Name.IndexOf("大")>0)
                    {
                        OldSize.Name = "大度" + ps.ProductKaidu.ToString();
                    }
                    else
                    {
                        OldSize.Name = "正度" + ps.ProductKaidu.ToString();

                    }
                    
                    
                }
                else
                {
                    NewSize.Height = ps.MaxHeight;
                    NewSize.Length = ps.MaxLength;
                    NewSize.Kaidu = ps.PaperKaiShu;
                    NewSize.Name = "自适应" + ps.PaperKaiShu.ToString();
                    OldSize.Kaidu = ps.ProductKaidu;
                    OldSize.Name = "自适应" + ps.ProductKaidu.ToString();
                }
            }
            return sucess;
        }
        /// <summary>
        /// 根据OldSize的尺寸ID，去得到一个标准的开纸方法；
        /// </summary>
        /// <returns></returns>
        private bool GetPsSheet()
        {
            bool sucess = false;
            if (OldSize.Id > 0)
            {
                Model.P_Sheet ps = DAL.P_Sheet.GetModelBySize(OldSize.Id);
                if (ps != null)
                {
                    Model.Size st = DAL.Size.GetModel(ps.SizeId);//得到目标尺寸的数据，存入目标尺寸表
                    if (st != null)
                    {
                        NewSize.Id = st.Id;
                        NewSize.Height = st.Height;
                        NewSize.Length = st.Length;
                        NewSize.Kaidu = st.KaiShu;
                        NewSize.Name = st.SizeName;
                        sucess = true;
                        TransTag = 0;
                    }
                }
            }
            return sucess;
        }

        /// <summary>
        /// 调整小幅度的非标尺寸到标准尺寸，用户原始输入的尺寸保存在UserSize,数据保存的标准尺寸保存到OldSize;
        /// </summary>
        /// <returns></returns>
        private bool AdjustOldSize(int l, int h)
        {
            bool sucess = false;
            Model.ProductSize psize = DAL.ProductSize.GetModel(l, h);
            if (psize != null)
            {
                OldSize.Id = psize.Id;
                OldSize.Height = psize.StandHeight;
                OldSize.Length = psize.StandLength;
                OldSize.Kaidu = psize.Kaidu;
                OldSize.Name = psize.NickName;
                sucess = true;
            }
            return sucess;
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
        private void RPaper()
        {
            int t;
            t = OldSize.Length;
            OldSize.Length = OldSize.Height;
            OldSize.Height = t;
            Ratio++;
            if (Ratio > 3)
                Ratio = 0;
        }

        private int check(int x)
        {
            for (int i = 0; i < nouserk.Length; i++)
            {
                if (x == nouserk[i])
                    return x - 1;
            }
            return x;
        }
       
    }
}
