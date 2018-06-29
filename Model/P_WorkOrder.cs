/**  版本信息模板在安装目录下，可自行修改。
* P_WorkOrder.cs
*
* 功 能： N/A
* 类 名： P_WorkOrder
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2017-05-02 16:31:23   N/A    初版
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
	/// P_WorkOrder:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class P_WorkOrder
	{
		public P_WorkOrder()
		{}
		#region Model
		private string _workordercode;
		private long _customerid;
		private int  _status;
		private string _printname;
		private string _productname;
		private string _productnum;
		private string _size;
		private string _bingstyle;
		private DateTime  _deliverytime;
		private string _address;
		private string _customerrequire;
		private string _materialdescription;
		private string _preprintdescription;
		private string _printdescription;
		private string _description1;
		private string _description2;
		private string _remark;
		private int  _b1;
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
		public long CustomerId
		{
			set{ _customerid=value;}
			get{return _customerid;}
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
		public string PrintName
		{
			set{ _printname=value;}
			get{return _printname;}
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
		public string ProductNum
		{
			set{ _productnum=value;}
			get{return _productnum;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Size
		{
			set{ _size=value;}
			get{return _size;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string BingStyle
		{
			set{ _bingstyle=value;}
			get{return _bingstyle;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime  DeliveryTime
		{
			set{ _deliverytime=value;}
			get{return _deliverytime;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Address
		{
			set{ _address=value;}
			get{return _address;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string CustomerRequire
		{
			set{ _customerrequire=value;}
			get{return _customerrequire;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string MaterialDescription
		{
			set{ _materialdescription=value;}
			get{return _materialdescription;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string PrePrintDescription
		{
			set{ _preprintdescription=value;}
			get{return _preprintdescription;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string PrintDescription
		{
			set{ _printdescription=value;}
			get{return _printdescription;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Description1
		{
			set{ _description1=value;}
			get{return _description1;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Description2
		{
			set{ _description2=value;}
			get{return _description2;}
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
		#endregion Model

	}
}

