﻿/**  版本信息模板在安装目录下，可自行修改。
* Message.cs
*
* 功 能： N/A
* 类 名： Message
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2017-05-02 16:31:02   N/A    初版
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
	/// Message:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class Message
	{
		public Message()
		{}
		#region Model
		private Guid _id;
		private long _customerid;
		private long  _servieid;
		private string _messages;
		private int  _messagegrade;
		private int  _reads;
		private int  _arrow;
		private string _mobiletel;
		private int  _status;
		private string _remark;
		/// <summary>
		/// 
		/// </summary>
		public Guid Id
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public long CustomerId
		{
			set{ _customerid=value;}
			get{return _customerid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public long  ServieId
		{
			set{ _servieid=value;}
			get{return _servieid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Messages
		{
			set{ _messages=value;}
			get{return _messages;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int  MessageGrade
		{
			set{ _messagegrade=value;}
			get{return _messagegrade;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int  Reads
		{
			set{ _reads=value;}
			get{return _reads;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int  Arrow
		{
			set{ _arrow=value;}
			get{return _arrow;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string MobileTel
		{
			set{ _mobiletel=value;}
			get{return _mobiletel;}
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
		#endregion Model

	}
}

