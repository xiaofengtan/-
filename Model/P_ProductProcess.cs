/**  版本信息模板在安装目录下，可自行修改。
* P_ProductProcess.cs
*
* 功 能： N/A
* 类 名： P_ProductProcess
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2017-05-02 16:31:17   N/A    初版
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
	/// P_ProductProcess:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class P_ProductProcess
	{
		public P_ProductProcess()
		{}
		#region Model
		private string _recordcode;
		private int _processid;
		private int  _processtype;
		private int  _combineid;
		private int  _lengthparameter;
		private int  _heightparameter;
		private int  _quantityparameter;
		private int  _materialid;
		private decimal  _singleprice;
		private int  _num;
		private string _unit;
		private int  _price;
		private int  _mode;
		private string _description;
		private int  _status;
		private string _remark;
		private int  _b1;
		/// <summary>
		/// 
		/// </summary>
		public string RecordCode
		{
			set{ _recordcode=value;}
			get{return _recordcode;}
		}
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
		public int  ProcessType
		{
			set{ _processtype=value;}
			get{return _processtype;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int  CombineId
		{
			set{ _combineid=value;}
			get{return _combineid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int  LengthParameter
		{
			set{ _lengthparameter=value;}
			get{return _lengthparameter;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int  HeightParameter
		{
			set{ _heightparameter=value;}
			get{return _heightparameter;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int  QuantityParameter
		{
			set{ _quantityparameter=value;}
			get{return _quantityparameter;}
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
		public decimal  SinglePrice
		{
			set{ _singleprice=value;}
			get{return _singleprice;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int  Num
		{
			set{ _num=value;}
			get{return _num;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Unit
		{
			set{ _unit=value;}
			get{return _unit;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int  Price
		{
			set{ _price=value;}
			get{return _price;}
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
		public string Description
		{
			set{ _description=value;}
			get{return _description;}
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

