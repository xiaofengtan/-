/**  版本信息模板在安装目录下，可自行修改。
* P_PayList.cs
*
* 功 能： N/A
* 类 名： P_PayList
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
	/// P_PayList:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class P_PayList
	{
		public P_PayList()
		{}
		#region Model
		private string _paycode;
		private int  _moneynum;
		private int  _paytimes;
		private string _orderon;
		private string _customername;
		private string _servicername;
		private DateTime  _paytime;
		private string _remark;
		private int  _b1;
		private string _b2;
		/// <summary>
		/// 
		/// </summary>
		public string PayCode
		{
			set{ _paycode=value;}
			get{return _paycode;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int  MoneyNum
		{
			set{ _moneynum=value;}
			get{return _moneynum;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int  PayTimes
		{
			set{ _paytimes=value;}
			get{return _paytimes;}
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
		public string CustomerName
		{
			set{ _customername=value;}
			get{return _customername;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string ServicerName
		{
			set{ _servicername=value;}
			get{return _servicername;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime  PayTime
		{
			set{ _paytime=value;}
			get{return _paytime;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string ReMark
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

