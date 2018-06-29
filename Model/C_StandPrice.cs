/**  版本信息模板在安装目录下，可自行修改。
* C_StandPrice.cs
*
* 功 能： N/A
* 类 名： C_StandPrice
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2017-05-02 16:30:50   N/A    初版
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
	/// C_StandPrice:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class C_StandPrice
	{
		public C_StandPrice()
		{}
		#region Model
		private int _priceid;
		private int _standid;
		private string _standcode;
		private decimal  _startprice;
		private decimal  _singleprice1;
		private decimal  _singleprice2;
		private int  _startnum1;
		private int  _startnum2;
		private int  _pricemode;
		private int  _laddermark;
		private int  _materialmark;
		private string _pricedescription;
		private int  _mode;
		private int  _status;
		private string _remark;
		private int  _b1;
		private string _b2;
		/// <summary>
		/// 
		/// </summary>
		public int PriceId
		{
			set{ _priceid=value;}
			get{return _priceid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int StandId
		{
			set{ _standid=value;}
			get{return _standid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string StandCode
		{
			set{ _standcode=value;}
			get{return _standcode;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal  StartPrice
		{
			set{ _startprice=value;}
			get{return _startprice;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal  SinglePrice1
		{
			set{ _singleprice1=value;}
			get{return _singleprice1;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal  SinglePrice2
		{
			set{ _singleprice2=value;}
			get{return _singleprice2;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int  StartNum1
		{
			set{ _startnum1=value;}
			get{return _startnum1;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int  StartNum2
		{
			set{ _startnum2=value;}
			get{return _startnum2;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int  PriceMode
		{
			set{ _pricemode=value;}
			get{return _pricemode;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int  LadderMark
		{
			set{ _laddermark=value;}
			get{return _laddermark;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int  MaterialMark
		{
			set{ _materialmark=value;}
			get{return _materialmark;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string PriceDescription
		{
			set{ _pricedescription=value;}
			get{return _pricedescription;}
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

