/**  版本信息模板在安装目录下，可自行修改。
* Machine.cs
*
* 功 能： N/A
* 类 名： Machine
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2017-05-02 16:31:00   N/A    初版
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
	/// Machine:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class Machine
	{
		public Machine()
		{}
		#region Model
		private int _id;
		private string _machinename;
		private int  _typeid;
		private int  _kaishu;
		private int  _materiallength;
		private int  _materialheight;
		private int  _bite;
		private int  _maximumarea;
		private int  _minimumarea;
		private int  _otherarea;
		private int  _sizeremark1;
		private int  _sizeremark2;
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
		public string MachineName
		{
			set{ _machinename=value;}
			get{return _machinename;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int  TypeId
		{
			set{ _typeid=value;}
			get{return _typeid;}
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
		public int  MaterialLength
		{
			set{ _materiallength=value;}
			get{return _materiallength;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int  MaterialHeight
		{
			set{ _materialheight=value;}
			get{return _materialheight;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int  Bite
		{
			set{ _bite=value;}
			get{return _bite;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int  MaximumArea
		{
			set{ _maximumarea=value;}
			get{return _maximumarea;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int  MinimumArea
		{
			set{ _minimumarea=value;}
			get{return _minimumarea;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int  OtherArea
		{
			set{ _otherarea=value;}
			get{return _otherarea;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int  SizeRemark1
		{
			set{ _sizeremark1=value;}
			get{return _sizeremark1;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int  SizeRemark2
		{
			set{ _sizeremark2=value;}
			get{return _sizeremark2;}
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

