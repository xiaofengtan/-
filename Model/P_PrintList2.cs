/**  版本信息模板在安装目录下，可自行修改。
* P_PrintList2.cs
*
* 功 能： N/A
* 类 名： P_PrintList2
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2017-05-02 16:31:14   N/A    初版
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
	/// P_PrintList2:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class P_PrintList2
	{
		public P_PrintList2()
		{}
		#region Model
		private string _code;
		private string _orderon;
		private string _listcode;
		private int  _groupid;
		private string _unitname;
		private int  _psnum;
		private int  _paperid;
		private string _papername;
		private int  _printlength;
		private int  _printheight;
		private int  _bigpapernum;
		private int  _extendnum;
		private int  _printpapernum;
		private int  _color;
		private int  _psmode;
		private string _psmodename;
		private int  _doubleside;
		private int  _papersource;
		private int  _status;
		private string _request;
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
		public int  GroupId
		{
			set{ _groupid=value;}
			get{return _groupid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string UnitName
		{
			set{ _unitname=value;}
			get{return _unitname;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int  PsNum
		{
			set{ _psnum=value;}
			get{return _psnum;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int  PaperId
		{
			set{ _paperid=value;}
			get{return _paperid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string PaperName
		{
			set{ _papername=value;}
			get{return _papername;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int  PrintLength
		{
			set{ _printlength=value;}
			get{return _printlength;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int  PrintHeight
		{
			set{ _printheight=value;}
			get{return _printheight;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int  BigPaperNum
		{
			set{ _bigpapernum=value;}
			get{return _bigpapernum;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int  ExtendNum
		{
			set{ _extendnum=value;}
			get{return _extendnum;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int  PrintPaperNum
		{
			set{ _printpapernum=value;}
			get{return _printpapernum;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int  Color
		{
			set{ _color=value;}
			get{return _color;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int  PsMode
		{
			set{ _psmode=value;}
			get{return _psmode;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string PsModeName
		{
			set{ _psmodename=value;}
			get{return _psmodename;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int  DoubleSide
		{
			set{ _doubleside=value;}
			get{return _doubleside;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int  PaperSource
		{
			set{ _papersource=value;}
			get{return _papersource;}
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
		public string Request
		{
			set{ _request=value;}
			get{return _request;}
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

