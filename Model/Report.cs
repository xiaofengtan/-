using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace Model
{
    public  class reportitem
    {
        [DataSource.Column(NickName = "序号")]
        public int No { set; get; }
        [DataSource.Column(NickName = "日期")]
        public int Days { set; get; }
        [DataSource.Column(NickName = "凭单号")]
        public string P_order { set; get; }
         [DataSource.Column(NickName = "客户名称")]
        public string Customer { set; get; }
         [DataSource.Column(NickName = "产品名称")]
         public string ProductName { set; get; }
         [DataSource.Column(NickName = "销售价")]
        public decimal SalePrice { set; get; }
         [DataSource.Column(NickName = "基准价")]
        public decimal CaltPrice { set; get; }
         [DataSource.Column(NickName = "溢价率")]
         public string Ratio { set; get; }
         [DataSource.Column(NickName = "无CTP印工")]
         public decimal NoCtp { set; get; }
         [DataSource.Column(NickName = "纯印工")]
         public decimal PrintPrcie { set; get; }
         
       
         [DataSource.Column(NickName = "数量")]
        public decimal Num { set; get; }
         [DataSource.Column(NickName = "纸张")]
        public decimal PaperPrice { set; get; }
         [DataSource.Column(NickName = "CTP")]
        public decimal CtpPrice { set; get; }
         [DataSource.Column(NickName = "后道装订")]
        public decimal ProcessPrice { set; get; }
        
        
        
         [DataSource.Column(NickName = "对开张")]
         public decimal DoubleCount { set; get; }

         [DataSource.Column(NickName = "彩版")]
         public decimal ColorCtp { set; get; }
         [DataSource.Column(NickName = "黑白版")]
         public decimal BlackCtp { set; get; }

         [DataSource.Column(NickName = "材料说明")]
        public string Remark { set; get; }
    }

    public class reportitem2
    {
        [DataSource.Column(NickName = "序号")]
        public int No { set; get; }

        [DataSource.Column(NickName = "日期")]
        public int Days { set; get; }

        [DataSource.Column(NickName = "凭单号")]
        public string P_order { set; get; }

        [DataSource.Column(NickName = "客户名称")]
        public string Customer { set; get; }

        [DataSource.Column(NickName = "产品名称")]
        public string ProductName { set; get; }

        [DataSource.Column(NickName = "销售价")]
        public decimal SalePrice { set; get; }

        [DataSource.Column(NickName = "基准价")]
        public decimal CaltPrice { set; get; }

        [DataSource.Column(NickName = "溢价率")]
        public string Ratio { set; get; }

        [DataSource.Column(NickName = "无CTP印工")]
        public decimal NoCtp { set; get; }

        [DataSource.Column(NickName = "数量")]
        public decimal Num { set; get; }

        [DataSource.Column(NickName = "对开张")]
        public decimal DoubleCount { set; get; }

        [DataSource.Column(NickName = "纸张成本")]
        public decimal PaperPrice { set; get; }

        [DataSource.Column(NickName = "彩版")]
        public decimal ColorCtp { set; get; }

        [DataSource.Column(NickName = "黑白版")]
        public decimal BlackCtp { set; get; }

        [DataSource.Column(NickName = "CTP成本")]
        public decimal CtpPrice { set; get; }
     
        [DataSource.Column(NickName = "无CTP黑白印工")]
        public decimal BlackPrint { set; get; }

        [DataSource.Column(NickName = "无CTP彩印工")]
        public decimal ColorPrint { set; get; }

        [DataSource.Column(NickName = "后道装订")]
        public decimal ProcessPrice { set; get; }

        [DataSource.Column(NickName = "结算价")]
        public decimal Money { set; get; }

        [DataSource.Column(NickName = "材料说明")]
        public string Remark { set; get; }
    }
}
