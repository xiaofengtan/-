using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    [Serializable]
    public class Rectange
    {
        public int Id{set;get;}
        public int Length { set; get; }
        public int Width { set; get; }
        public string Name { set; get; }
        public int Kaidu { set; get; }
        public Rectange()
        {
            Length = 0;
            Width = 0;
            Id = 0;
            Name = "无";
        }
        public Rectange(int l,int h)
        {
            if (l > h)
            {
                Length = l;
                Width = h;
            }
            else
            {
                Length = h;
                Width = l;

            }
            Id = 0;
          
            Name = "无";
        }
        public Rectange(int l, int h,string name)
        {
            if (l > h)
            {
                Length = l;
                Width = h;
            }
            else
            {
                Length = h;
                Width = l;

            }
            Id = 0;

            Name = name;
            Kaidu = 1;
        }
        public Rectange(int l, int h, string name,int k)
        {
            if (l > h)
            {
                Length = l;
                Width = h;
            }
            else
            {
                Length = h;
                Width = l;

            }
            Id = 0;

            Name = name;
            Kaidu = k;
        }
        public Rectange(int id)
        {
            ProductSize ps = ProductSize.GetSizeById(id);
            int l, h;
            l = ps.StandLength;
            h = ps.StandHeight;
            if (l > h)
            {
                Length = l;
                Width = h;
            }
            else
            {
                Length = h;
                Width = l;

            }
            Id = id;
            Name = ps.NickName;
            Kaidu = ps.Kaidu;
        }
        public override string ToString()
        {
            string result = "";
            result = this.Name + " 长:" + Length.ToString() + " 宽: " + Width.ToString();
            return result;
        }
        public static bool operator ==(Rectange a1, Rectange a2)
        {
            return (a1.Length == a2.Length && a1.Width == a2.Width);
        }
        public static bool operator !=(Rectange a1, Rectange a2)
        {
            return (a1.Length != a2.Length || a1.Width != a2.Width);
        }
       
        public decimal GetRatio(Rectange Big)
        {
            decimal s1, s2;
            s1 = Width * Length*Kaidu;
            s2 = Big.Length * Big.Width;
            return decimal.Round(s1 / s2, 4);
        }
    }
}
