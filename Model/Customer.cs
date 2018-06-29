/**  版本信息模板在安装目录下，可自行修改。
* Customer.cs
*
* 功 能： N/A
* 类 名： Customer
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2017-05-02 16:30:51   N/A    初版
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
	/// Customer:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class Customer
	{
		public Customer()
		{}
		#region Model
		private int _id;
		private string _accountid;
		private string _username;
		private string _userpassword;
		private string _customname;
		private string _relaname;
		private DateTime _regtime;
		private DateTime  _joindate;
		private string _mobiletel;
		private int  _integral;
		private string _e_mail;
		private string _qqnum;
		private string _weixin;
		private string _filepath;
		private string _tel;
		private string _company;
		private string _adressstring;
		private int  _accountuserid;
		private int  _source;
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
		public string AccountId
		{
			set{ _accountid=value;}
			get{return _accountid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string UserName
		{
			set{ _username=value;}
			get{return _username;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string UserPassWord
		{
			set{ _userpassword=value;}
			get{return _userpassword;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string CustomName
		{
			set{ _customname=value;}
			get{return _customname;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string RelaName
		{
			set{ _relaname=value;}
			get{return _relaname;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime RegTime
		{
			set{ _regtime=value;}
			get{return _regtime;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime  JoinDate
		{
			set{ _joindate=value;}
			get{return _joindate;}
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
		public int  Integral
		{
			set{ _integral=value;}
			get{return _integral;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string E_mail
		{
			set{ _e_mail=value;}
			get{return _e_mail;}
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
		public string Weixin
		{
			set{ _weixin=value;}
			get{return _weixin;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string FilePath
		{
			set{ _filepath=value;}
			get{return _filepath;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Tel
		{
			set{ _tel=value;}
			get{return _tel;}
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
		public string AdressString
		{
			set{ _adressstring=value;}
			get{return _adressstring;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int  AccountUserId
		{
			set{ _accountuserid=value;}
			get{return _accountuserid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int  Source
		{
			set{ _source=value;}
			get{return _source;}
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

