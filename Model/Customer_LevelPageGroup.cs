﻿/**  版本信息模板在安装目录下，可自行修改。
* Customer_LevelPageGroup.cs
*
* 功 能： N/A
* 类 名： Customer_LevelPageGroup
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2017-05-02 16:30:58   N/A    初版
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
	/// Customer_LevelPageGroup:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class Customer_LevelPageGroup
	{
		public Customer_LevelPageGroup()
		{}
		#region Model
		private int _levelid;
		private int _pagegroupid;
		private int  _status;
		private string _remark;
		/// <summary>
		/// 
		/// </summary>
		public int LevelId
		{
			set{ _levelid=value;}
			get{return _levelid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int PageGroupId
		{
			set{ _pagegroupid=value;}
			get{return _pagegroupid;}
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

