/**  版本信息模板在安装目录下，可自行修改。
* Paper_Color.cs
*
* 功 能： N/A
* 类 名： Paper_Color
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2017-05-02 16:31:33   N/A    初版
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
	/// Paper_Color:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class Paper_Color
	{
		public Paper_Color()
		{}
		#region Model
		private int _id;
		private string _colorname;
		private string _colorcode;
		private int _ordernumber;
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
		public string ColorName
		{
			set{ _colorname=value;}
			get{return _colorname;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string ColorCode
		{
			set{ _colorcode=value;}
			get{return _colorcode;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int OrderNumber
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

