/**  版本信息模板在安装目录下，可自行修改。
* P_AskList.cs
*
* 功 能： N/A
* 类 名： P_AskList
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2017-05-02 16:31:05   N/A    初版
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
	/// P_AskList:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class P_AskList
	{
		public P_AskList()
		{}
		#region Model
		private string _asklistcode;
		private string _customerid;
		private int  _productid;
		private string _productname;
		private int _number;
		private int _price;
		private DateTime  _asktime;
		private string _askresource;
		private string _ipadress;
		private int  _sourcetype;
		private int  _status;
		private string _remark;
		private string _request;
		private string _result;
		private string _resultprice;
		private int  _b1;
		private string _b2;
		/// <summary>
		/// 
		/// </summary>
		public string AskListCode
		{
			set{ _asklistcode=value;}
			get{return _asklistcode;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string CustomerId
		{
			set{ _customerid=value;}
			get{return _customerid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int  ProductId
		{
			set{ _productid=value;}
			get{return _productid;}
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
		public int Number
		{
			set{ _number=value;}
			get{return _number;}
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
		public DateTime  AskTime
		{
			set{ _asktime=value;}
			get{return _asktime;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string AskResource
		{
			set{ _askresource=value;}
			get{return _askresource;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string IpAdress
		{
			set{ _ipadress=value;}
			get{return _ipadress;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int  SourceType
		{
			set{ _sourcetype=value;}
			get{return _sourcetype;}
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
		public string ResultPrice
		{
			set{ _resultprice=value;}
			get{return _resultprice;}
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

