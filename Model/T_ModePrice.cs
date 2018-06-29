/**  版本信息模板在安装目录下，可自行修改。
* T_ModePrice.cs
*
* 功 能： N/A
* 类 名： T_ModePrice
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2017-05-02 16:32:38   N/A    初版
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
	/// T_ModePrice:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class T_ModePrice
	{
		public T_ModePrice()
		{}
		#region Model
		private int _distanceid;
		private int _kgid;
		private int  _singleprice;
		private int  _fixedtprice;
		private int _stepid;
		private int  _status;
		private string _remark;
		private int  _b1;
		/// <summary>
		/// 
		/// </summary>
		public int DistanceId
		{
			set{ _distanceid=value;}
			get{return _distanceid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int KgId
		{
			set{ _kgid=value;}
			get{return _kgid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int  SinglePrice
		{
			set{ _singleprice=value;}
			get{return _singleprice;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int  FixedtPrice
		{
			set{ _fixedtprice=value;}
			get{return _fixedtprice;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int StepId
		{
			set{ _stepid=value;}
			get{return _stepid;}
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
		public int b1
		{
			set{ _b1=value;}
			get{return _b1;}
		}
		#endregion Model

	}
}

