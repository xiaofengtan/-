/**  版本信息模板在安装目录下，可自行修改。
* ProductPaperUnit.cs
*
* 功 能： N/A
* 类 名： ProductPaperUnit
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2017-05-02 16:31:52   N/A    初版
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
	/// ProductPaperUnit:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class ProductPaperUnit
	{
		public ProductPaperUnit()
		{}
		#region Model
		private string _id;
		private string _prodcutcode;
		private string _unitname;
		private int  _groupid;
		private int  _sizeid;
		private int  _length;
		private int  _height;
		private string _sizename;
		private int  _paperid;
		private string _papername;
		private int  _pagenum;
		private int  _color;
		private int  _papersource;
		private int  _productnum;
		private int  _contextreapet;
		private string _reamrk;
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
		public string ProdcutCode
		{
			set{ _prodcutcode=value;}
			get{return _prodcutcode;}
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
		public int  GroupId
		{
			set{ _groupid=value;}
			get{return _groupid;}
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
		public int  Length
		{
			set{ _length=value;}
			get{return _length;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int  Height
		{
			set{ _height=value;}
			get{return _height;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string SizeName
		{
			set{ _sizename=value;}
			get{return _sizename;}
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
		public int  PageNum
		{
			set{ _pagenum=value;}
			get{return _pagenum;}
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
		public int  PaperSource
		{
			set{ _papersource=value;}
			get{return _papersource;}
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
		public int  ContextReapet
		{
			set{ _contextreapet=value;}
			get{return _contextreapet;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Reamrk
		{
			set{ _reamrk=value;}
			get{return _reamrk;}
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

