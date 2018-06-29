/**  版本信息模板在安装目录下，可自行修改。
* Size.cs
*
* 功 能： N/A
* 类 名： Size
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2017-05-02 16:32:31   N/A    初版
*
* Copyright (c) 2012 Maticsoft Corporation. All rights reserved.
*┌──────────────────────────────────┐
*│　此技术信息为本公司机密信息，未经本公司书面同意禁止向第三方披露．　│
*│　版权所有：山西四元信息科技有限公司　　　　　　　　　　　│
*└──────────────────────────────────┘
*/
using System;
using System.Data;
using System.Collections.Generic;

namespace Model
{
	/// <summary>
	/// Size:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
    [DataSource.Table(IsCahche = false, NickName = "尺寸表", TableName = "Size")]
	public partial class Size
	{
		public Size()
		{}
		#region Model
		private int _id;
		private string _sizename;
		private int  _length;
		private int  _height;
		private int  _kaishu;
		private int  _mark;
		private int  _paperlength;
		private int  _paperheight;
		private int  _ordernumber;
		private int  _status;
		private string _remark;
		private int  _b1;
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
		public string SizeName
		{
			set{ _sizename=value;}
			get{return _sizename;}
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
		public int  KaiShu
		{
			set{ _kaishu=value;}
			get{return _kaishu;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int  Mark
		{
			set{ _mark=value;}
			get{return _mark;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int  PaperLength
		{
			set{ _paperlength=value;}
			get{return _paperlength;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int  PaperHeight
		{
			set{ _paperheight=value;}
			get{return _paperheight;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int  OrderNumber
		{
			set{ _ordernumber=value;}
			get{return _ordernumber;}
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

