/**  版本信息模板在安装目录下，可自行修改。
* News.cs
*
* 功 能： N/A
* 类 名： News
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2017-05-02 16:31:03   N/A    初版
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
	/// News:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class News
	{
		public News()
		{}
		#region Model
		private int _id;
		private string _newscode;
		private string _newstitle;
		private string _newstwotitle;
		private string _newsauthor;
		private string _newssource;
		private string _newscontent;
		private DateTime  _newstime;
		private int  _newsclick;
		private string _newspicurl;
		private int  _newstype;
		private int  _auditing;
		private int  _userid;
		private string _keyword;
		private string _intro;
		private int  _eid;
		private int  _status;
		private string _remark;
		private int  _b1;
		private string _b2;
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
		public string NewsCode
		{
			set{ _newscode=value;}
			get{return _newscode;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string NewsTitle
		{
			set{ _newstitle=value;}
			get{return _newstitle;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string NewsTwoTitle
		{
			set{ _newstwotitle=value;}
			get{return _newstwotitle;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string NewsAuthor
		{
			set{ _newsauthor=value;}
			get{return _newsauthor;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string NewsSource
		{
			set{ _newssource=value;}
			get{return _newssource;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string NewsContent
		{
			set{ _newscontent=value;}
			get{return _newscontent;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime  NewsTime
		{
			set{ _newstime=value;}
			get{return _newstime;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int  NewsClick
		{
			set{ _newsclick=value;}
			get{return _newsclick;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string NewsPicUrl
		{
			set{ _newspicurl=value;}
			get{return _newspicurl;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int  NewsType
		{
			set{ _newstype=value;}
			get{return _newstype;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int  Auditing
		{
			set{ _auditing=value;}
			get{return _auditing;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int  UserId
		{
			set{ _userid=value;}
			get{return _userid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string KeyWord
		{
			set{ _keyword=value;}
			get{return _keyword;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Intro
		{
			set{ _intro=value;}
			get{return _intro;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int  Eid
		{
			set{ _eid=value;}
			get{return _eid;}
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

