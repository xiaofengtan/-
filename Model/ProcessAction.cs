/**  版本信息模板在安装目录下，可自行修改。
* ProcessAction.cs
*
* 功 能： N/A
* 类 名： ProcessAction
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2017-05-02 16:31:48   N/A    初版
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
	/// ProcessAction:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class ProcessAction
	{
		public ProcessAction()
		{}
		#region Model
		private int _id;
		private string _actionname;
		private string _actioncode;
		private int _parentprocessid;
		private decimal _payprice;
		private int _no;
		private int  _nextactionid;
		private int  _beforeactionid;
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
		public string ActionName
		{
			set{ _actionname=value;}
			get{return _actionname;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string ActionCode
		{
			set{ _actioncode=value;}
			get{return _actioncode;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int ParentProcessId
		{
			set{ _parentprocessid=value;}
			get{return _parentprocessid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal PayPrice
		{
			set{ _payprice=value;}
			get{return _payprice;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int NO
		{
			set{ _no=value;}
			get{return _no;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int  NextActionId
		{
			set{ _nextactionid=value;}
			get{return _nextactionid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int  BeforeActionId
		{
			set{ _beforeactionid=value;}
			get{return _beforeactionid;}
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

