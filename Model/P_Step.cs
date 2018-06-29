/**  版本信息模板在安装目录下，可自行修改。
* P_Step.cs
*
* 功 能： N/A
* 类 名： P_Step
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2017-05-02 16:31:21   N/A    初版
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
	/// P_Step:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class P_Step
	{
		public P_Step()
		{}
		#region Model
		private string _stepcode;
		private string _productlistcode;
		private string _workordercode;
		private int  _productid;
		private int _processid;
		private decimal  _singleprice;
		private int  _num;
		private int  _price;
		private int  _payprice;
		private int  _arlength;
		private int  _arheight;
		private int  _qunum;
		private int  _processnum;
		private int _ordernumber;
		private string _prestepcode;
		private string _nextstepcode;
		private int  _personid;
		private int  _workunitid;
		private bool _helpmark;
		private int  _helpfactory;
		private int  _status;
		private string _remark;
		private int  _b1;
		private string _b2;
		/// <summary>
		/// 
		/// </summary>
		public string StepCode
		{
			set{ _stepcode=value;}
			get{return _stepcode;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string ProductListCode
		{
			set{ _productlistcode=value;}
			get{return _productlistcode;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string WorkOrderCode
		{
			set{ _workordercode=value;}
			get{return _workordercode;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int  ProductId
		{
			set{ _productid=value;}
			get{return _productid;}
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
		public int  Price
		{
			set{ _price=value;}
			get{return _price;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int  PayPrice
		{
			set{ _payprice=value;}
			get{return _payprice;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int  ArLength
		{
			set{ _arlength=value;}
			get{return _arlength;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int  ArHeight
		{
			set{ _arheight=value;}
			get{return _arheight;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int  QuNum
		{
			set{ _qunum=value;}
			get{return _qunum;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int  ProcessNum
		{
			set{ _processnum=value;}
			get{return _processnum;}
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
		public string PreStepCode
		{
			set{ _prestepcode=value;}
			get{return _prestepcode;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string NextStepCode
		{
			set{ _nextstepcode=value;}
			get{return _nextstepcode;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int  PersonId
		{
			set{ _personid=value;}
			get{return _personid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int  WorkUnitId
		{
			set{ _workunitid=value;}
			get{return _workunitid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public bool HelpMark
		{
			set{ _helpmark=value;}
			get{return _helpmark;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int  HelpFactory
		{
			set{ _helpfactory=value;}
			get{return _helpfactory;}
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

