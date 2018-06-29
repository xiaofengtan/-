/**  版本信息模板在安装目录下，可自行修改。
* P_ProductList.cs
*
* 功 能： N/A
* 类 名： P_ProductList
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2017-05-02 16:31:16   N/A    初版
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
	/// P_ProductList:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
    [DataSource.Table(IsCahche = true, NickName = "产品清单", TableName = "P_ProductList")]
	public partial class P_ProductList
	{
		public P_ProductList()
		{}
		#region Model
		private string _listcode;
		private string _orderon;
		private int _productid;
		private int _productnum;
		private string _productname;
		private decimal  _productweight;
		private int  _paperweight;
		private int  _producsizeid;
		private int  _productlength;
		private int  _productheight;
		private int  _productsizeremark;
		private int  _sheetid;
		private string _printrequire;
		private string _customerrequest;
		private int  _bindtype;
		private int  _printprice;
		private int  _psprice;
		private int  _paperprice;
		private int  _processprice;
		private int  _otherprice;
		private int  _price;
		private int  _costprice;
		private int  _insideprice;
		private int  _lastprice;
		private DateTime  _starttime;
		private DateTime  _auditingtime;
		private DateTime  _productiontime;
		private DateTime  _endtime;
		private int  _status;
		private string _remark;
		private int  _b1;
		private string _b2;
		/// <summary>
		/// 
		/// </summary>
		public string ListCode
		{
			set{ _listcode=value;}
			get{return _listcode;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string OrderOn
		{
			set{ _orderon=value;}
			get{return _orderon;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int ProductId
		{
			set{ _productid=value;}
			get{return _productid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int ProductNum
		{
			set{ _productnum=value;}
			get{return _productnum;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string ProductName
		{
			set{ _productname=value;}
			get{return _productname;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal  ProductWeight
		{
			set{ _productweight=value;}
			get{return _productweight;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int  PaperWeight
		{
			set{ _paperweight=value;}
			get{return _paperweight;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int  ProducSizeId
		{
			set{ _producsizeid=value;}
			get{return _producsizeid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int  ProductLength
		{
			set{ _productlength=value;}
			get{return _productlength;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int  productHeight
		{
			set{ _productheight=value;}
			get{return _productheight;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int  ProductSizeRemark
		{
			set{ _productsizeremark=value;}
			get{return _productsizeremark;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int  SheetId
		{
			set{ _sheetid=value;}
			get{return _sheetid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string PrintRequire
		{
			set{ _printrequire=value;}
			get{return _printrequire;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string CustomerRequest
		{
			set{ _customerrequest=value;}
			get{return _customerrequest;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int  BindType
		{
			set{ _bindtype=value;}
			get{return _bindtype;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int  PrintPrice
		{
			set{ _printprice=value;}
			get{return _printprice;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int  PsPrice
		{
			set{ _psprice=value;}
			get{return _psprice;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int  PaperPrice
		{
			set{ _paperprice=value;}
			get{return _paperprice;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int  ProcessPrice
		{
			set{ _processprice=value;}
			get{return _processprice;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int  OtherPrice
		{
			set{ _otherprice=value;}
			get{return _otherprice;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int  Price
		{
			set{ _price=value;}
			get{return _price;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int  CostPrice
		{
			set{ _costprice=value;}
			get{return _costprice;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int  InsidePrice
		{
			set{ _insideprice=value;}
			get{return _insideprice;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int  LastPrice
		{
			set{ _lastprice=value;}
			get{return _lastprice;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime  StartTime
		{
			set{ _starttime=value;}
			get{return _starttime;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime  AuditingTime
		{
			set{ _auditingtime=value;}
			get{return _auditingtime;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime  ProductionTime
		{
			set{ _productiontime=value;}
			get{return _productiontime;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime  EndTime
		{
			set{ _endtime=value;}
			get{return _endtime;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int  Status
		{
			set{ _status=value;}
			get{return _status;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Remark
		{
			set{ _remark=value;}
			get{return _remark;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int  b1
		{
			set{ _b1=value;}
			get{return _b1;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string b2
		{
			set{ _b2=value;}
			get{return _b2;}
		}
		#endregion Model

        public static DataTable GetDataTable(string where)
        {
            return DataSource.ORMHelper.GetDataTable<P_ProductList>(where);
        }

        public static List<P_ProductList> GetDataList(string where)
        {
            DataTable dt = GetDataTable(where);
            if (dt != null)
            {
                return DataSource.ORMHelper.TbToModelList<P_ProductList>(dt);
            }
            return null;
        }

	}
}

