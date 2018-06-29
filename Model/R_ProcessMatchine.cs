/**  版本信息模板在安装目录下，可自行修改。
* R_ProcessMatchine.cs
*
* 功 能： N/A
* 类 名： R_ProcessMatchine
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2017-05-02 16:32:03   N/A    初版
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
	/// R_ProcessMatchine:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class R_ProcessMatchine
	{
		public R_ProcessMatchine()
		{}
		#region Model
		private int _processid;
		private int _matchine;
		private int  _status;
		private string _remark;
		private int  _b1;
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
		public int Matchine
		{
			set{ _matchine=value;}
			get{return _matchine;}
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

