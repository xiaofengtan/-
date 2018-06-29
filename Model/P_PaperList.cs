using System;
namespace Model
{
	/// <summary>
	/// P_PaperList:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class P_PaperList
	{
		public P_PaperList()
		{}
		#region Model
		private string _paperlistcode;
		private string _orderon;
		private string _listcode;
		private int  _sheetid;
		private int _standid;
		private string _papername;
		private int  _color;
		private bool _doubleside;
		private int  _papersource;
		private int _printnum;
		private int  _bigpaperwast;
		private int  _bigpapernum;
		private decimal _costprice;
		private decimal _sellingprice;
		private int  _machineid;
		private int  _status;
		private string _remark;
		private int  _b1;
		private string _b2;
		private int  _allpsnum;
		private int  _halfpsnum;
		private int  _quarpsnum;
		/// <summary>
		/// 
		/// </summary>
		public string PaperListCode
		{
			set{ _paperlistcode=value;}
			get{return _paperlistcode;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string OrderOn
		{
			set{ _orderon=value;}
			get{return _orderon;}
		}
		/// <summary>
		/// Productlist 编号
		/// </summary>
		public string ListCode
		{
			set{ _listcode=value;}
			get{return _listcode;}
		}
		/// <summary>
		/// 拼版方式
		/// </summary>
		public int  SheetId
		{
			set{ _sheetid=value;}
			get{return _sheetid;}
		}
		/// <summary>
		/// 纸张类型Id
		/// </summary>
		public int StandId
		{
			set{ _standid=value;}
			get{return _standid;}
		}
		/// <summary>
		/// 纸张显示名称
		/// </summary>
		public string PaperName
		{
			set{ _papername=value;}
			get{return _papername;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int  Color
		{
			set{ _color=value;}
			get{return _color;}
		}
		/// <summary>
		/// 
		/// </summary>
		public bool DoubleSide
		{
			set{ _doubleside=value;}
			get{return _doubleside;}
		}
		/// <summary>
		/// 来源
		/// </summary>
		public int  PaperSource
		{
			set{ _papersource=value;}
			get{return _papersource;}
		}
		/// <summary>
		/// 印数
		/// </summary>
		public int PrintNum
		{
			set{ _printnum=value;}
			get{return _printnum;}
		}
		/// <summary>
		/// 大张损耗
		/// </summary>
		public int  BigPaperWast
		{
			set{ _bigpaperwast=value;}
			get{return _bigpaperwast;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int  BigPaperNum
		{
			set{ _bigpapernum=value;}
			get{return _bigpapernum;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal CostPrice
		{
			set{ _costprice=value;}
			get{return _costprice;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal SellingPrice
		{
			set{ _sellingprice=value;}
			get{return _sellingprice;}
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
		/// <summary>
		/// 
		/// </summary>
		public int  AllPsNum
		{
			set{ _allpsnum=value;}
			get{return _allpsnum;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int  HalfPsNum
		{
			set{ _halfpsnum=value;}
			get{return _halfpsnum;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int  QuarPsNum
		{
			set{ _quarpsnum=value;}
			get{return _quarpsnum;}
		}
		#endregion Model

	}
}

