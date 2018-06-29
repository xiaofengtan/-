/**  版本信息模板在安装目录下，可自行修改。
* P_Order.cs
*
* 功 能： N/A
* 类 名： P_Order
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2017-05-02 16:31:08   N/A    初版
*
* Copyright (c) 2012 Maticsoft Corporation. All rights reserved.
*┌──────────────────────────────────┐
*│　此技术信息为本公司机密信息，未经本公司书面同意禁止向第三方披露．　│
*│　版权所有：山西四元信息科技有限公司　　　　　　　　　　　│
*└──────────────────────────────────┘
*/
using System;
using System.Data;
using System.Collections.Generic;

namespace Model
{
	/// <summary>
	/// P_Order:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
    [DataSource.Table(IsCahche = true, NickName = "订单统计表", TableName = "P_Order")]
	public partial class P_Order
	{
		public P_Order()
		{
            ProductionTime = DateTime.Now;
        }
		#region Model
		private string _orderon;
		private string _customerid;
		private int _status;
		private int  _orderweight;
		private int  _delivetype;
		private int  _deliverprice;
		private int _price;
		private int  _insideprice;
		private int  _costprice;
		private int  _collectmoney;
		private DateTime  _productiontime;
		private DateTime _ordertime;
		private DateTime  _endtime;
		private int  _paymode;
		private int  _paystatus;
		private string _addressid;
		private string _customerrequest;
		private string _remark;
		private int  _b1;
		private string _b2;
		private string _adminprice;
		private string _adminproduct;
		private string _receiver;
		private string _address;
		private string _telphone;
        private int _orderid;
        /// <summary>
        /// 
        /// </summary>
        [DataSource.Column(NickName = "订单ID", IsIdentity = true, IsPrimary = true)]
        public int OrderId
        {
            set { _orderid = value; }
            get { return _orderid; }
        }


        [DataSource.Column(NickName="订单编号")]
        public string OrderOn
		{
			set{ _orderon=value;}
			get{return _orderon;}
		}
		/// <summary>
		/// 
		/// </summary>
        [DataSource.Column(NickName = "客户编号")]
        public string CustomerId
		{
			set{ _customerid=value;}
			get{return _customerid;}
		}
		/// <summary>
		/// 
		/// </summary>
        [DataSource.Column(NickName = "状态")]
        public int Status
		{
			set{ _status=value;}
			get{return _status;}
		}
		/// <summary>
		/// 
		/// </summary>
        [DataSource.Column(NickName = "重量")]
        public int  OrderWeight
		{
			set{ _orderweight=value;}
			get{return _orderweight;}
		}
		/// <summary>
		/// 
		/// </summary>
        [DataSource.Column(NickName = "派送方式")]
        public int  DeliveType
		{
			set{ _delivetype=value;}
			get{return _delivetype;}
		}
		/// <summary>
		/// 
		/// </summary>
        [DataSource.Column(NickName = "派送价格")]
        public int  DeliverPrice
		{
			set{ _deliverprice=value;}
			get{return _deliverprice;}
		}
		/// <summary>
		/// 
		/// </summary>
        [DataSource.Column(NickName = "成交价格")]
        public int Price
		{
			set{ _price=value;}
			get{return _price;}
		}
		/// <summary>
		/// 
		/// </summary>
         [DataSource.Column(NickName = "内部价格")]
        public int  InsidePrice
		{
			set{ _insideprice=value;}
			get{return _insideprice;}
		}
		/// <summary>
		/// 
		/// </summary>
         [DataSource.Column(NickName = "成本价格")]
        public int  CostPrice
		{
			set{ _costprice=value;}
			get{return _costprice;}
		}
		/// <summary>
		/// 
		/// </summary>
         [DataSource.Column(NickName = "已收金额")]
        public int  CollectMoney
		{
			set{ _collectmoney=value;}
			get{return _collectmoney;}
		}
        /// <summary>
        /// 
        /// </summary>
        [DataSource.Column(NickName = "生产时间")]
        public DateTime  ProductionTime
		{
			set{ _productiontime=value;}
			get{return _productiontime;}
		}
		/// <summary>
		/// 
		/// </summary>
         [DataSource.Column(NickName = "订单时间")]
        public DateTime OrderTime
		{
			set{ _ordertime=value;}
			get{return _ordertime;}
		}
		/// <summary>
		/// 
		/// </summary>
         [DataSource.Column(NickName = "完成时间")]
        public DateTime  EndTime
		{
			set{ _endtime=value;}
			get{return _endtime;}
		}
		/// <summary>
		/// 
		/// </summary>
         [DataSource.Column(NickName = "支付方式")]
        public int  PayMode
		{
			set{ _paymode=value;}
			get{return _paymode;}
		}
		/// <summary>
		/// 
		/// </summary>
         [DataSource.Column(NickName = "支付状态")]
        public int  PayStatus
		{
			set{ _paystatus=value;}
			get{return _paystatus;}
		}
		/// <summary>
		/// 
		/// </summary>
         [DataSource.Column(NickName = "派送地址编号")]
        public string AddressId
		{
			set{ _addressid=value;}
			get{return _addressid;}
		}
		/// <summary>
		/// 
		/// </summary>
         [DataSource.Column(NickName = "客户要求")]
        public string CustomerRequest
		{
			set{ _customerrequest=value;}
			get{return _customerrequest;}
		}
		/// <summary>
		/// 
		/// </summary>
         [DataSource.Column(NickName = "备注")]
        public string Remark
		{
			set{ _remark=value;}
			get{return _remark;}
		}
		/// <summary>
		/// 
		/// </summary>
         [DataSource.Column(NickName = "备注1")]
        public int  b1
		{
			set{ _b1=value;}
			get{return _b1;}
		}
		/// <summary>
		/// 
		/// </summary>
         [DataSource.Column(NickName = "备注2")]
        public string b2
		{
			set{ _b2=value;}
			get{return _b2;}
		}
		/// <summary>
		/// 
		/// </summary>
         [DataSource.Column(NickName = "控制价格")]
        public string AdminPrice
		{
			set{ _adminprice=value;}
			get{return _adminprice;}
		}
		/// <summary>
		/// 
		/// </summary>
         [DataSource.Column(NickName = "主要产品")]
        public string AdminProduct
		{
			set{ _adminproduct=value;}
			get{return _adminproduct;}
		}
		/// <summary>
		/// 
		/// </summary>
        [DataSource.Column(NickName = "收货人")]
        public string Receiver
		{
			set{ _receiver=value;}
			get{return _receiver;}
		}
		/// <summary>
		/// 
		/// </summary>
        [DataSource.Column(NickName = "收货地址")]
        public string Address
		{
			set{ _address=value;}
			get{return _address;}
		}
		/// <summary>
		/// 
		/// </summary>
        [DataSource.Column(NickName = "收货电话")]
        public string TelPhone
		{
			set{ _telphone=value;}
			get{return _telphone;}
		}

       
        #endregion Model

        //public static string LastNo=string.Empty;

        public static DataTable GetDataTable(string where)
        {
            return DataSource.ORMHelper.GetDataTable<P_Order>(where);
        }
        public static int Insert(P_Order order)
        {
            return DataSource.ORMHelper.InsertModelId<P_Order>(order);
        }
         public static List<P_Order> GetDataList(string where)
        {
            DataTable dt = GetDataTable(where);
            if (dt != null)
            {
                return DataSource.ORMHelper.TbToModelList<P_Order>(dt);
            }
            return null;
        }

         public static P_Order GetOrderByOrderNo(string no)
         {
             List<P_Order> list = GetDataList("OrderOn='" + no + "'");
             if (list != null)
             {
                 if (list.Count > 0)
                     return list[0];
             }
             return null;
         }

        public static P_Order GetOrderByOrder(string no)
        {
            List<P_Order> list = GetDataList("b2='" + no + "'");
            if (list != null)
            {
                if (list.Count > 0)
                    return list[list.Count-1];
            }
            return null;
        }
        /// <summary>
        /// 获取当月所有订单；
        /// </summary>
        /// <param name="month"></param>
        /// <returns></returns>
        public static List<P_Order> GetMonthOrder(int year,int month)
         {
             string t = "YEAR(OrderTime)='"+year.ToString()+"' and month(OrderTime)='" + month.ToString() + "' order by OrderOn ";
             return GetDataList(t);
         }

        public static List<P_Order> GetMonthOrder(DateTime time)
        {
            int year = time.Year;
            int month = time.Month;
            return GetMonthOrder(year,month);
        }
        private static string GetMaxOrderNo()
         {
             DataSource.SQLServerSource sql = new DataSource.SQLServerSource();
             var max = sql.ExecuteScalar("select MAX(OrderOn) from dbo.P_Order");
             return max.ToString();
         }

         public static bool AddNewOrder(P_Order order)
         {
            string LastNo=GetMaxOrderNo();
            DateTime now = DateTime.Now;
            string num = LastNo.Substring(9, 4);
            string lastday = LastNo.Substring(1, 8);
            string nowday = now.Year.ToString() + now.Month.ToString("00") + now.Day.ToString("00");
            if (lastday == nowday)
            {
                int n = int.Parse(num);
                n = n + 1;
                num = n.ToString("0000");
            }
            else
            {
                num = "0001";
            }
            string  LastNoTemp = "O" + nowday + num;
            order.OrderOn = LastNoTemp;
            order.ProductionTime = DateTime.Now;
            if (DataSource.ORMHelper.InsertModel<P_Order>(order) > 0)
                return true;
            else
                return false;
         }
	}
}

