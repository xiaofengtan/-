/**  版本信息模板在安装目录下，可自行修改。
* P_ConstructionAudit.cs
*
* 功 能： N/A
* 类 名： P_ConstructionAudit
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2017-05-02 16:31:06   N/A    初版
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
	/// P_ConstructionAudit:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class P_ConstructionAudit
	{
		public P_ConstructionAudit()
		{}
		#region Model
		private string _constructioncode;
		private string _detailcode;
		private string _orderon;
		private int  _productid;
		private int  _productnum;
		private decimal  _productweight;
		private string _paperrequirestr;
		private int  _producsizeid;
		private int  _productlength;
		private int  _productheight;
		private int  _productsizeremark;
		private int  _paperstandid;
		private int  _machineid;
		private int  _pagenum;
		private int  _samepage;
		private int  _tienum;
		private int  _bigpapernum;
		private int  _psnum;
		private int  _sheetid;
		private int  _sizeid;
		private string _papername;
		private int  _papersource;
		private int  _color;
		private int  _doubleside;
		private int  _printnum;
		private int  _c_printnum;
		private int  _allpapernum;
		private int  _c_allpapernum;
		private decimal  _sellprice;
		private DateTime  _starttime;
		private DateTime  _endtime;
		private int  _status;
		private string _remark;
		private int  _b1;
		private string _b2;
		/// <summary>
		/// 
		/// </summary>
		public string ConstructionCode
		{
			set{ _constructioncode=value;}
			get{return _constructioncode;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string DetailCode
		{
			set{ _detailcode=value;}
			get{return _detailcode;}
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
		public int  ProductId
		{
			set{ _productid=value;}
			get{return _productid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int  ProductNum
		{
			set{ _productnum=value;}
			get{return _productnum;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal  ProductWeight
		{
			set{ _productweight=value;}
			get{return _productweight;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string PaperRequireStr
		{
			set{ _paperrequirestr=value;}
			get{return _paperrequirestr;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int  ProducSizeId
		{
			set{ _producsizeid=value;}
			get{return _producsizeid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int  ProductLength
		{
			set{ _productlength=value;}
			get{return _productlength;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int  productHeight
		{
			set{ _productheight=value;}
			get{return _productheight;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int  ProductSizeRemark
		{
			set{ _productsizeremark=value;}
			get{return _productsizeremark;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int  PaperStandId
		{
			set{ _paperstandid=value;}
			get{return _paperstandid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int  MachineId
		{
			set{ _machineid=value;}
			get{return _machineid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int  PageNum
		{
			set{ _pagenum=value;}
			get{return _pagenum;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int  SamePage
		{
			set{ _samepage=value;}
			get{return _samepage;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int  TieNum
		{
			set{ _tienum=value;}
			get{return _tienum;}
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
		public int  PsNum
		{
			set{ _psnum=value;}
			get{return _psnum;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int  SheetId
		{
			set{ _sheetid=value;}
			get{return _sheetid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int  SizeId
		{
			set{ _sizeid=value;}
			get{return _sizeid;}
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
		public int  PaperSource
		{
			set{ _papersource=value;}
			get{return _papersource;}
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
		public int  DoubleSide
		{
			set{ _doubleside=value;}
			get{return _doubleside;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int  PrintNum
		{
			set{ _printnum=value;}
			get{return _printnum;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int  C_PrintNum
		{
			set{ _c_printnum=value;}
			get{return _c_printnum;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int  AllPaperNum
		{
			set{ _allpapernum=value;}
			get{return _allpapernum;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int  C_AllPaperNum
		{
			set{ _c_allpapernum=value;}
			get{return _c_allpapernum;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal  SellPrice
		{
			set{ _sellprice=value;}
			get{return _sellprice;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime  StartTime
		{
			set{ _starttime=value;}
			get{return _starttime;}
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

