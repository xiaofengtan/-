/**  版本信息模板在安装目录下，可自行修改。
* MachineType.cs
*
* 功 能： N/A
* 类 名： MachineType
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
	/// MachineType:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class MachineType
	{
		public MachineType()
		{}
		#region Model
		private int _id;
		private string _typename;
		private string _typecode;
		private int _ordernumber;
		private int  _status;
		private int  _sizeparameter1;
		private int  _sizeparameter2;
		private int  _sizeparameter3;
		private string _sizeparameterstr1;
		private string _sizeparameterstr2;
		private string _description;
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
		public string TypeName
		{
			set{ _typename=value;}
			get{return _typename;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string TypeCode
		{
			set{ _typecode=value;}
			get{return _typecode;}
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
		public int  SizeParameter1
		{
			set{ _sizeparameter1=value;}
			get{return _sizeparameter1;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int  SizeParameter2
		{
			set{ _sizeparameter2=value;}
			get{return _sizeparameter2;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int  SizeParameter3
		{
			set{ _sizeparameter3=value;}
			get{return _sizeparameter3;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string SizeParameterStr1
		{
			set{ _sizeparameterstr1=value;}
			get{return _sizeparameterstr1;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string SizeParameterStr2
		{
			set{ _sizeparameterstr2=value;}
			get{return _sizeparameterstr2;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Description
		{
			set{ _description=value;}
			get{return _description;}
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

