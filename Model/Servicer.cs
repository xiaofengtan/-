/**  版本信息模板在安装目录下，可自行修改。
* Servicer.cs
*
* 功 能： N/A
* 类 名： Servicer
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2017-05-02 16:32:30   N/A    初版
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
	/// Servicer:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class Servicer
	{
		public Servicer()
		{}
		#region Model
		private int _id;
		private string _salecode;
		private string _salename;
		private string _loginname;
		private string _loginpass;
		private int  _salegroup;
		private string _salenum;
		private string _company;
		private string _mobiletel;
		private string _qqnum;
		private string _weixin;
		private DateTime  _entertime;
		private DateTime  _endtime;
		private string _adress;
		private string _idcard;
		private int  _status;
		private string _remark;
		/// <summary>
		/// 
		/// </summary>
		public int Id
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string SaleCode
		{
			set{ _salecode=value;}
			get{return _salecode;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string SaleName
		{
			set{ _salename=value;}
			get{return _salename;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string LoginName
		{
			set{ _loginname=value;}
			get{return _loginname;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string LoginPass
		{
			set{ _loginpass=value;}
			get{return _loginpass;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int  SaleGroup
		{
			set{ _salegroup=value;}
			get{return _salegroup;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string SaleNum
		{
			set{ _salenum=value;}
			get{return _salenum;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Company
		{
			set{ _company=value;}
			get{return _company;}
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
		public string QQnum
		{
			set{ _qqnum=value;}
			get{return _qqnum;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string weixin
		{
			set{ _weixin=value;}
			get{return _weixin;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime  EnterTime
		{
			set{ _entertime=value;}
			get{return _entertime;}
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
		public string Adress
		{
			set{ _adress=value;}
			get{return _adress;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string IdCard
		{
			set{ _idcard=value;}
			get{return _idcard;}
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
		#endregion Model

	}
}

