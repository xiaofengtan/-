/**  版本信息模板在安装目录下，可自行修改。
* P_PsList.cs
*
* 功 能： N/A
* 类 名： P_PsList
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2017-05-02 16:31:18   N/A    初版
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
	/// P_PsList:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class P_PsList
	{
		public P_PsList()
		{}
		#region Model
		private string _pslistcode;
		private string _orderon;
		private string _listcode;
		private string _paperlistcode;
		private int _sheetid;
		private int  _psmode;
		private string _psstr;
		private int  _startpage;
		private int  _endpage;
		private int  _machineid;
		private int  _status;
		private string _remark;
		private int  _b1;
		/// <summary>
		/// 
		/// </summary>
		public string PsListCode
		{
			set{ _pslistcode=value;}
			get{return _pslistcode;}
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
		public string PaperListCode
		{
			set{ _paperlistcode=value;}
			get{return _paperlistcode;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int SheetId
		{
			set{ _sheetid=value;}
			get{return _sheetid;}
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
		public string PsStr
		{
			set{ _psstr=value;}
			get{return _psstr;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int  StartPage
		{
			set{ _startpage=value;}
			get{return _startpage;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int  EndPage
		{
			set{ _endpage=value;}
			get{return _endpage;}
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
		#endregion Model

	}
}

