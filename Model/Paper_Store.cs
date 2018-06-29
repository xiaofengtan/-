/**  版本信息模板在安装目录下，可自行修改。
* Paper_Store.cs
*
* 功 能： N/A
* 类 名： Paper_Store
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2017-05-02 16:31:41   N/A    初版
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
	/// Paper_Store:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
    [DataSource.Table(IsCahche = true, NickName = "库存纸张表", TableName = "Paper_Store")]
	public partial class Paper_Store
	{
        private static DataTable _alldata;

        private static DataTable AllData
        {
            get
            {
                if (_alldata == null || LastTime.AddSeconds(Common.DataTimeOut) < DateTime.Now)
                {
                    _alldata = DataSource.ORMHelper.GetDataTable<Paper_Store>("Status='1'");
                    LastTime = DateTime.Now;
                }
                return _alldata;
            }
        }
        private static List<Paper_Store> _allpaper;
        public static List<Paper_Store> AllPaper
        {
            get
            {
                if (_allpaper == null || NeedRead || LastTime.AddSeconds(Common.DataTimeOut) < DateTime.Now)
                {
                    _allpaper = DataSource.ORMHelper.TbToModelList<Paper_Store>(AllData);
                }
                return _allpaper;
            }
        }
        private static DateTime LastTime;
        private static bool NeedRead = true;

        public Paper_Store()
		{}
		#region Model
		private int _paperid;
		private string _papername;
		private string _papercode;
		private int _typeid;
		private int _standid;
		private int  _length;
		private int  _height;
		private int  _kg;
		private int  _num;
		private int  _tonprice;
		private decimal  _unitprice;
		private decimal  _thick;
		private string _paperfactory;
		private int _ordernumber;
		private int  _status;
		private string _remark;
		private int  _b1;
		private string _b2;
		/// <summary>
		/// 
		/// </summary>
        [DataSource.Column(IsIdentity = true, IsPrimary = true, NickName = "纸张编号")]
		public int PaperId
		{
			set{ _paperid=value;}
			get{return _paperid;}
		}
		/// <summary>
		/// 
		/// </summary>
        [DataSource.Column(NickName = "纸张名称")]
        public string PaperName
		{
			set{ _papername=value;}
			get{return _papername;}
		}
		/// <summary>
		/// 
		/// </summary>
        [DataSource.Column(NickName = "纸张编号")]
        public string PaperCode
		{
			set{ _papercode=value;}
			get{return _papercode;}
		}
		/// <summary>
		/// 
		/// </summary>
         [DataSource.Column(NickName = "类型编号")]
        public int TypeId
		{
			set{ _typeid=value;}
			get{return _typeid;}
		}
		/// <summary>
		/// 
		/// </summary>
        [DataSource.Column(NickName = "标准编号")]
        public int StandId
		{
			set{ _standid=value;}
			get{return _standid;}
		}
		/// <summary>
		/// 
		/// </summary>
        [DataSource.Column(NickName = "纸张长度")]
        public int  Length
		{
			set{ _length=value;}
			get{return _length;}
		}
		/// <summary>
		/// 
		/// </summary>
        [DataSource.Column(NickName = "纸张宽度")]
        public int  Height
		{
			set{ _height=value;}
			get{return _height;}
		}
		/// <summary>
		/// 
		/// </summary>
        [DataSource.Column(NickName = "纸张克重")]
        public int  Kg
		{
			set{ _kg=value;}
			get{return _kg;}
		}
		/// <summary>
		/// 
		/// </summary>
        [DataSource.Column(NickName = "当前数量")]
        public int  Num
		{
			set{ _num=value;}
			get{return _num;}
		}
        [DataSource.Column(NickName = "吨价")]
        public int TonPrice
        {
            set { _tonprice = value; }
            get { return _tonprice; }
        }
        [DataSource.Column(NickName = "成本单价")]
        public decimal UnitPrice
        {
            set { _unitprice = value; }
            get { return _unitprice; }
        }
        [DataSource.Column(NickName = "财务单价")]
        public decimal TaxiPrice
        {
            set;
            get;
        }
        [DataSource.Column(NickName = "市场价金额")]
        public decimal Money
        {
            set;
            get;
        }
        [DataSource.Column(NickName = "财务价金额")]
        public decimal TaxiMoney
        {
            set;
            get;
        }
        [DataSource.Column(NickName = "上月结余")]
        public int LastNum
        {
            set;
            get;
        }

      
        [DataSource.Column(NickName = "厚度")]
        public decimal  Thick
		{
			set{ _thick=value;}
			get{return _thick;}
		}
		/// <summary>
		/// 
		/// </summary>
        [DataSource.Column(NickName = "品牌")]
        public string PaperFactory
		{
			set{ _paperfactory=value;}
			get{return _paperfactory;}
		}
		/// <summary>
		/// 
		/// </summary>
        [DataSource.Column(NickName = "序号")]
        public int OrderNumber
		{
			set{ _ordernumber=value;}
			get{return _ordernumber;}
		}
		/// <summary>
		/// 
		/// </summary>
        [DataSource.Column(NickName = "有效")]
        public int  Status
		{
			set{ _status=value;}
			get{return _status;}
		}
		/// <summary>
		/// 
		/// </summary>
        [DataSource.Column(NickName = "备注")]
        public string Remark
		{
			set{ _remark=value;}
			get{return _remark;}
		}
		/// <summary>
		/// 
		/// </summary>
        [DataSource.Column(NickName = "辅助1")]
        public int  b1
		{
			set{ _b1=value;}
			get{return _b1;}
		}
		/// <summary>
		/// 
		/// </summary>
        [DataSource.Column(NickName = "辅助2")]
        public string b2
		{
			set{ _b2=value;}
			get{return _b2;}
		}
        #endregion Model

        public static int Update(Paper_Store paper)
        {
            NeedRead = true;
            return DataSource.ORMHelper.UpdateModelById<Paper_Store>(paper);
        }

        public static Paper_Store GetPaperById(int id)
        {
            foreach (Paper_Store ps in AllPaper)
            {
                if (ps.PaperId == id)
                    return ps;
            }
            return null;
        }
        public static List<Paper_Store> GetAllPaperList()
        {
            return AllPaper;
        }

        public static DataTable GetAllPaperTable()
        {
            return AllData;
        }

        public static List<Paper_Store> GetPaperTypeList(int typeid)
        {
            int count = 0;
            List<Paper_Store> result = new List<Paper_Store>();
            foreach (Paper_Store ps in AllPaper)
            {
                if (ps.TypeId == typeid)
                {
                    result.Add(ps);
                    count++;
                }
            }
            if (count > 0)
                return result;
            else
                return null;
        }

        public static List<Paper_Store> GetDataListPY(string py)
        {
            int count = 0;
            List<Paper_Store> result = new List<Paper_Store>();
            foreach (Paper_Store ps in AllPaper)
            {
                string pysource = ps.PaperCode;
                if (pysource.IndexOf(py) > 0)
                {
                    result.Add(ps);
                    count++;
                }
            }
            if (count > 0)
                return result;
            else
                return null;
        }

        public static int InserData(Paper_Store pi)
        {
            NeedRead = true;
            
            return DataSource.ORMHelper.InsertModel<Paper_Store>(pi);
        }
        public static List<NameType> GetListByType(int typeid)
        {
            List<NameType> result=new List<NameType>();
            List<Paper_Store> plist = GetPaperTypeList(typeid);
            if (plist != null)
            {
                foreach (Paper_Store ps in plist)
                {
                    NameType nt = new NameType() { Id = ps.PaperId, Name = ps.PaperName, CodeId=ps.Kg };
                    result.Add(nt);
                }
                return result;
            }
            return null;
        }
        public static List<string> GetColumNikeName()
        {
            return DataSource.ORMHelper.GetColumnsName(typeof(Paper_Store));
        }
        public static int Delete(Paper_Store ps)
        {
            NeedRead = true;
            return DataSource.ORMHelper.DeleteModelById<Paper_Store>(ps);
        }
       
	}
}

