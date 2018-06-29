/**  版本信息模板在安装目录下，可自行修改。
* Customer_Address.cs
*
* 功 能： N/A
* 类 名： Customer_Address
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2017-05-02 16:30:52   N/A    初版
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
	/// Customer_Address:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class Customer_Address
	{
		public Customer_Address()
		{}
		#region Model
		private string _id;
		private string _customerid;
		private string _addresscode;
		private string _recivename;
		private string _address;
		private string _postnum;
		private string _mobiletel;
		private string _orthertel;
		private int  _status;
		private string _remark;
		private int  _b1;
		private string _b2;
		/// <summary>
		/// 
		/// </summary>
		public string Id
		{
			set{ _id=value;}
			get{return _id;}
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
		public string AddressCode
		{
			set{ _addresscode=value;}
			get{return _addresscode;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string ReciveName
		{
			set{ _recivename=value;}
			get{return _recivename;}
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
		public string PostNum
		{
			set{ _postnum=value;}
			get{return _postnum;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string MobileTel
		{
			set{ _mobiletel=value;}
			get{return _mobiletel;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string OrtherTel
		{
			set{ _orthertel=value;}
			get{return _orthertel;}
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

