/**  版本信息模板在安装目录下，可自行修改。
* Service_Customer.cs
*
* 功 能： N/A
* 类 名： Service_Customer
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2017-05-02 16:32:29   N/A    初版
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
	/// Service_Customer:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class Service_Customer
	{
		public Service_Customer()
		{}
		#region Model
		private Guid _id;
		private int  _serviceid;
		private Guid _customerid;
		private DateTime  _developtime;
		private DateTime  _tradetime;
		private int  _tradeprice;
		private int  _flag;
		private string _remark;
		/// <summary>
		/// 
		/// </summary>
		public Guid Id
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int  ServiceId
		{
			set{ _serviceid=value;}
			get{return _serviceid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public Guid CustomerId
		{
			set{ _customerid=value;}
			get{return _customerid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime  DevelopTime
		{
			set{ _developtime=value;}
			get{return _developtime;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime  TradeTime
		{
			set{ _tradetime=value;}
			get{return _tradetime;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int  TradePrice
		{
			set{ _tradeprice=value;}
			get{return _tradeprice;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int  Flag
		{
			set{ _flag=value;}
			get{return _flag;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Remark
		{
			set{ _remark=value;}
			get{return _remark;}
		}
		#endregion Model

	}
}

