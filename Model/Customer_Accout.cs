/**  版本信息模板在安装目录下，可自行修改。
* Customer_Accout.cs
*
* 功 能： N/A
* 类 名： Customer_Accout
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
	/// Customer_Accout:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class Customer_Accout
	{
		public Customer_Accout()
		{}
		#region Model
		private byte[] _id;
		private string _customerid;
		private string _accountcode;
		private string _accoutname;
		private decimal  _money;
		private decimal  _accmoney;
		private DateTime  _buidtime;
		private int  _credit;
		private decimal  _usercredit;
		private string _secretmoney;
		private int  _status;
		private string _remark;
		/// <summary>
		/// 
		/// </summary>
		public byte[] Id
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
		public string AccountCode
		{
			set{ _accountcode=value;}
			get{return _accountcode;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string AccoutName
		{
			set{ _accoutname=value;}
			get{return _accoutname;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal  Money
		{
			set{ _money=value;}
			get{return _money;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal  AccMoney
		{
			set{ _accmoney=value;}
			get{return _accmoney;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime  BuidTime
		{
			set{ _buidtime=value;}
			get{return _buidtime;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int  Credit
		{
			set{ _credit=value;}
			get{return _credit;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal  UserCredit
		{
			set{ _usercredit=value;}
			get{return _usercredit;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string SecretMoney
		{
			set{ _secretmoney=value;}
			get{return _secretmoney;}
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

