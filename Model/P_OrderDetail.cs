/**  版本信息模板在安装目录下，可自行修改。
* P_OrderDetail.cs
*
* 功 能： N/A
* 类 名： P_OrderDetail
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2017-05-02 16:31:09   N/A    初版
*
* Copyright (c) 2012 Maticsoft Corporation. All rights reserved.
*┌──────────────────────────────────┐
*│　此技术信息为本公司机密信息，未经本公司书面同意禁止向第三方披露．　│
*│　版权所有：山西四元信息科技有限公司　　　　　　　　　　　│
*└──────────────────────────────────┘
*/
using System;
namespace Model
{
	/// <summary>
	/// P_OrderDetail:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class P_OrderDetail
	{
		public P_OrderDetail()
		{}
		#region Model
		private string _detailcode;
		private string _orderon;
		private int _productid;
		private string _workordercode;
		private int  _no;
		private int _productnum;
		private int  _paperprice;
		private int  _processprice;
		private int  _bindingprice;
		private int  _printprice;
		private int  _transportprice;
		private int  _psprice;
		private string _pricelist;
		private string _disountlist;
		private int _price;
		private int  _discountprice;
		private int  _productweight;
		private int  _productsizeid;
		private int  _productlength;
		private int  _productheight;
		private int  _productsizeremark;
		private string _request;
		private string _result;
		private int  _status;
		private string _remark;
		private int  _b1;
		private string _b2;
		/// <summary>
		/// 
		/// </summary>
		public string DetailCode
		{
			set{ _detailcode=value;}
			get{return _detailcode;}
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
		public string WorkOrderCode
		{
			set{ _workordercode=value;}
			get{return _workordercode;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int  NO
		{
			set{ _no=value;}
			get{return _no;}
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
		public int  BindingPrice
		{
			set{ _bindingprice=value;}
			get{return _bindingprice;}
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
		public int  TransportPrice
		{
			set{ _transportprice=value;}
			get{return _transportprice;}
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
		public string PriceList
		{
			set{ _pricelist=value;}
			get{return _pricelist;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string DisountList
		{
			set{ _disountlist=value;}
			get{return _disountlist;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int Price
		{
			set{ _price=value;}
			get{return _price;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int  DiscountPrice
		{
			set{ _discountprice=value;}
			get{return _discountprice;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int  ProductWeight
		{
			set{ _productweight=value;}
			get{return _productweight;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int  ProductSizeId
		{
			set{ _productsizeid=value;}
			get{return _productsizeid;}
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
		public int  ProductHeight
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
		public string Request
		{
			set{ _request=value;}
			get{return _request;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Result
		{
			set{ _result=value;}
			get{return _result;}
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

	}
}

