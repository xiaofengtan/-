/**  版本信息模板在安装目录下，可自行修改。
* P_Sheet.cs
*
* 功 能： N/A
* 类 名： P_Sheet
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2017-05-02 16:31:19   N/A    初版
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
	/// P_Sheet:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class P_Sheet
	{
		public P_Sheet()
		{}
		#region Model
		private int _id;
		private int  _machineid;
		private int _sizeid;
		private int  _productsizeid;
		private int  _maxlength;
		private int  _minlength;
		private int  _maxheight;
		private int  _minheight;
		private int _paperkaishu;
		private int  _productkaidu;
		private int  _mark;
		private int  _psmode;
		private string _remark;
		private int  _status;
		private string _b2;
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
		public int  MachineId
		{
			set{ _machineid=value;}
			get{return _machineid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int SizeId
		{
			set{ _sizeid=value;}
			get{return _sizeid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int  ProductSizeId
		{
			set{ _productsizeid=value;}
			get{return _productsizeid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int  MaxLength
		{
			set{ _maxlength=value;}
			get{return _maxlength;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int  MinLength
		{
			set{ _minlength=value;}
			get{return _minlength;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int  MaxHeight
		{
			set{ _maxheight=value;}
			get{return _maxheight;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int  MinHeight
		{
			set{ _minheight=value;}
			get{return _minheight;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int PaperKaiShu
		{
			set{ _paperkaishu=value;}
			get{return _paperkaishu;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int  ProductKaidu
		{
			set{ _productkaidu=value;}
			get{return _productkaidu;}
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
		public int  PsMode
		{
			set{ _psmode=value;}
			get{return _psmode;}
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
		public int  Status
		{
			set{ _status=value;}
			get{return _status;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string b2
		{
			set{ _b2=value;}
			get{return _b2;}
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

