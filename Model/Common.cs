using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    public class Common
    {
     
        static public Rectange BigPaper = new Rectange(1194, 889,"大规");
        static public Rectange SmallPaper = new Rectange(1092, 787,"正规");
        static public Rectange PsBase = new Rectange(890, 620, "上机尺寸",2);


        public static Tree PaperCut = new Tree();
        private static List<NameType> producttype;
        public static int DataTimeOut = 7200;
        
        public static List<NameType> ProductType
        {
            get
            {
                if (producttype == null)
                {
                    NameType nt1 = new NameType(1, "画册封面");
                    NameType nt2 = new NameType(2, "画册内页");
                    NameType nt3 = new NameType(3, "无折单页");
                    NameType nt4 = new NameType(4, "折页展开");
                    NameType nt5 = new NameType(5, "手提袋展开");
                    NameType nt6 = new NameType(6, "信封展开");
                    NameType nt7 = new NameType(7, "其他展开");
                    producttype = new List<NameType>();
                    producttype.Add(nt1);
                    producttype.Add(nt2);
                    producttype.Add(nt3);
                    producttype.Add(nt4);
                    producttype.Add(nt5);
                    producttype.Add(nt6);
                    producttype.Add(nt7);
                }
                return producttype;
            }
        }

        static public string GetChineseSpell(string strText)
        {
            int len = strText.Length;
            string myStr = "";
            for (int i = 0; i < len; i++)
            {
                myStr += getSpell(strText.Substring(i, 1));
            }
            return myStr;
        }

        static public string IntListToSql(List<int> dataset)
        {
            string result = "";
            if (dataset != null)
            {
                if (dataset.Count > 0)
                {
                    if (dataset.Count > 1)
                    {
                        result = " in (";
                        for (int i = 0; i < dataset.Count; i++)
                        {
                            result += dataset[i].ToString() + ",";
                        }
                        result = result.Remove(result.Length-1, 1);
                        result += ")";
                    }
                    else
                    {
                        result = "='" + dataset[0].ToString() + "'";
                    }
                }
            }
            return result;
        }

        static private string getSpell(string cnChar)
        {
            byte[] arrCN = Encoding.Default.GetBytes(cnChar);
            if (arrCN.Length > 1)
            {
                int area = (short)arrCN[0];
                int pos = (short)arrCN[1];
                int code = (area << 8) + pos;
                int[] areacode = { 45217, 45253, 45761, 46318, 46826, 47010, 47297, 47614, 48119, 48119, 49062, 49324, 49896, 50371, 50614, 50622, 50906, 51387, 51446, 52218, 52698, 52698, 52698, 52980, 53689, 54481 };
                for (int i = 0; i < 26; i++)
                {
                    int max = 55290;
                    if (i != 25) max = areacode[i + 1];
                    if (areacode[i] <= code && code < max)
                    {
                        return Encoding.Default.GetString(new byte[] { (byte)(65 + i) });
                    }
                }
                return "*";
            }
            else return cnChar;
        }
    }
}
