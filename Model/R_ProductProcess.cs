/**  版本信息模板在安装目录下，可自行修改。
* R_ProductProcess.cs
*
* 功 能： N/A
* 类 名： R_ProductProcess
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2017-05-02 16:32:12   N/A    初版
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
	/// R_ProductProcess:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class R_ProductProcess
	{
		public R_ProductProcess()
		{}
		#region Model
		private int _productid;
		private int  _processid;
		private int  _freprocess;
		private int  _nextprocess;
		private int  _mustmark;
		private int  _no;
		private int  _processtype;
		private int  _mode;
		private int  _mustnext;
		private int  _groupid;
		private int  _materialid;
		private int  _status;
		private string _remark;
		private int  _b1;
		private string _b2;
		/// <summary>
		/// 
		/// </summary>
		public int ProductId
		{
			set{ _productid=value;}
			get{return _productid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int  ProcessId
		{
			set{ _processid=value;}
			get{return _processid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int  FreProcess
		{
			set{ _freprocess=value;}
			get{return _freprocess;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int  NextProcess
		{
			set{ _nextprocess=value;}
			get{return _nextprocess;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int  MustMark
		{
			set{ _mustmark=value;}
			get{return _mustmark;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int  NO
		{
			set{ _no=value;}
			get{return _no;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int  ProcessType
		{
			set{ _processtype=value;}
			get{return _processtype;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int  Mode
		{
			set{ _mode=value;}
			get{return _mode;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int  MustNext
		{
			set{ _mustnext=value;}
			get{return _mustnext;}
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
		public int  MaterialId
		{
			set{ _materialid=value;}
			get{return _materialid;}
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

