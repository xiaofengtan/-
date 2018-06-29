/**  版本信息模板在安装目录下，可自行修改。
* PageLog.cs
*
* 功 能： N/A
* 类 名： PageLog
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2017-05-02 16:31:27   N/A    初版
*
* Copyright (c) 2012 Maticsoft Corporation. All rights reserved.
*┌──────────────────────────────────┐
*│　此技术信息为本公司机密信息，未经本公司书面同意禁止向第三方披露．　│
*│　版权所有：动软卓越（北京）科技有限公司　　　　　　　　　　　　　　│
*└──────────────────────────────────┘
*/
using System;
namespace Maticsoft.Model
{
	/// <summary>
	/// PageLog:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class PageLog
	{
		public PageLog()
		{}
		#region Model
		private string _code;
		private DateTime _datetime;
		private string _customerid;
		private string _loginfo;
		private string _particular;
		private int? _status;
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
		public DateTime DateTime
		{
			set{ _datetime=value;}
			get{return _datetime;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string CustomerId
		{
			set{ _customerid=value;}
			get{return _customerid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string LoginFo
		{
			set{ _loginfo=value;}
			get{return _loginfo;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Particular
		{
			set{ _particular=value;}
			get{return _particular;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? Status
		{
			set{ _status=value;}
			get{return _status;}
		}
		#endregion Model

	}
}

