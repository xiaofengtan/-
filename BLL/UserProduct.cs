using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Script.Serialization;

namespace JxPrint.BLL
{
    public  class UserProduct
    {
        public string ProductName;
        public Model.P_ProductList product;

        //public Model.ResultPrice price;

        public List<Model.Working> AllProcess;

        public List<Model.material> AllMaterial;

        public List<Model.P_PsList> PsList;

        public List<Model.PsSheet> PsSheet;

        public UserProduct()
        {
            AllProcess = new List<Model.Working>();
            AllMaterial = new List<Model.material>();
            PsSheet = new List<Model.PsSheet>();
        }
        /// <summary>
        /// 使用一个画册得到一个产品
        /// </summary>
        /// <param name="userbook"></param>
        public UserProduct(book userbook)
        {
           
        }
        /// <summary>
        /// 使用一个单页得到一个产品
        /// </summary>
        /// <param name="userpaper"></param>
        public UserProduct(papersheet userpaper)
        {
           
        }
        /// <summary>
        /// 计算价格，1为成本价，2为高级客户价，3为外部报价
        /// </summary>
        /// <param name="rp"></param>
        /// <param name="mode"></param>
        /// <returns></returns>
        public int MakePrice(Model.ResultPrice rp,int mode)
        {
            return 0;
          
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
    }
}
