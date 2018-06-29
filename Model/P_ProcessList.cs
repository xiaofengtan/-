﻿/**  版本信息模板在安装目录下，可自行修改。
* P_ProcessList.cs
*
* 功 能： N/A
* 类 名： P_ProcessList
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2017-05-02 16:31:15   N/A    初版
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
	/// P_ProcessList:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class P_ProcessList
	{
		public P_ProcessList()
		{}
		#region Model
		private string _code;
		private string _orderon;
		private string _listcode;
		private int _processid;
		private string _processname;
		private int  _num;
		private int  _groupid;
		private int  _ptype;
		private int  _price;
		private int  _extendpaper;
		private decimal  _extendratio;
		private int  _arlength;
		private int  _arheight;
		private int  _qunum;
		private int  _status;
		private string _remark;
		private int  _b1;
		private string _b2;
		/// <summary>
		/// 
		/// </summary>
		public string Code
		{
			set{ _code=value;}
			get{return _code;}
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
		public string ListCode
		{
			set{ _listcode=value;}
			get{return _listcode;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int ProcessId
		{
			set{ _processid=value;}
			get{return _processid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string ProcessName
		{
			set{ _processname=value;}
			get{return _processname;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int  Num
		{
			set{ _num=value;}
			get{return _num;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int  GroupId
		{
			set{ _groupid=value;}
			get{return _groupid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int  PType
		{
			set{ _ptype=value;}
			get{return _ptype;}
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
		public int  ExtendPaper
		{
			set{ _extendpaper=value;}
			get{return _extendpaper;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal  ExtendRatio
		{
			set{ _extendratio=value;}
			get{return _extendratio;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int  ArLength
		{
			set{ _arlength=value;}
			get{return _arlength;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int  ArHeight
		{
			set{ _arheight=value;}
			get{return _arheight;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int  QuNum
		{
			set{ _qunum=value;}
			get{return _qunum;}
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

