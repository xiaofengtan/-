using System;
using System.Data;
using System.Collections.Generic;

namespace Model
{
    public enum InStoreCode { 正常采购, 临时采购, 盘亏出库, 其他入库 };
    /// <summary>
    /// Paper_In:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    [DataSource.Table(IsCahche = true, NickName = "入库记录表", TableName = "Paper_In")]
    public partial class Paper_In
    {
        public Paper_In()
        {
            Active = true;
        }
        #region Model
        private int _id;
        private int _paperid;
        private string _papername;
        private int _factorid;
        private string _factorname;
        private int _num;
        private DateTime _intime;
        private DateTime _realtime = DateTime.Now;
        private string _incode;
        private decimal _price;
        private decimal _money;
        private bool _active;
        private string _remark;
        private string _b1;
        private int _b2;
        /// <summary>
        /// 
        /// </summary>
        [DataSource.Column(IsIdentity = true, IsPrimary = true, NickName = "编号")]
        public int Id
        {
            set { _id = value; }
            get { return _id; }
        }
        /// <summary>
        /// 
        /// </summary>
        [DataSource.Column(NickName = "纸张编号")]
        public int PaperId
        {
            set { _paperid = value; }
            get { return _paperid; }
        }
        /// <summary>
        /// 
        /// </summary>
        [DataSource.Column(NickName = "纸张名称")]
        public string PaperName
        {
            set { _papername = value; }
            get { return _papername; }
        }
        /// <summary>
        /// 
        /// </summary>
        [DataSource.Column(NickName = "供货商")]
        public int FactorId
        {
            set { _factorid = value; }
            get { return _factorid; }
        }
        /// <summary>
        /// 
        /// </summary>
        [DataSource.Column(NickName = "供货商名称")]
        public string FactorName
        {
            set { _factorname = value; }
            get { return _factorname; }
        }
        /// <summary>
        /// 
        /// </summary>
        [DataSource.Column(NickName = "入库数量")]
        public int Num
        {
            set { _num = value; }
            get { return _num; }
        }
        /// <summary>
        /// 
        /// </summary>
        [DataSource.Column(NickName = "入库时间")]
        public DateTime InTime
        {
            set { _intime = value; }
            get { return _intime; }
        }
        /// <summary>
        /// 
        /// </summary>
        [DataSource.Column(NickName = "操作时间")]
        public DateTime RealTime
        {
            set { _realtime = value; }
            get { return _realtime; }
        }
        /// <summary>
        /// 
        /// </summary>

        [DataSource.Column(NickName = "入库类型")]
        public string InCode
        {
            set { _incode = value; }
            get { return _incode; }
        }
        /// <summary>
        /// 
        /// </summary>
        [DataSource.Column(NickName = "入库价格")]
        public decimal Price
        {
            set { _price = value; }
            get { return _price; }
        }
        [DataSource.Column(NickName = "入库金额")]
        public decimal Money
        {
            set
            {
                _money = value;
            }
            get { return _money; }
        }
        /// <summary>
        /// 
        /// </summary>
        [DataSource.Column(NickName = "有效")]
        public bool Active
        {
            set { _active = value; }
            get { return _active; }
        }
        /// <summary>
        /// 
        /// </summary>
        [DataSource.Column(NickName = "发票号")]
        public string Remark
        {
            set { _remark = value; }
            get { return _remark; }
        }

        /// <summary>
        /// 
        /// </summary>
        [DataSource.Column(NickName = "备注说明")]
        public string B1
        {
            set { _b1 = value; }
            get { return _b1; }
        }
        /// <summary>
        /// 
        /// </summary>
        [DataSource.Column(NickName = "辅助")]
        public int B2
        {
            set { _b2 = value; }
            get { return _b2; }
        }
        #endregion Model


        public static DataTable GetDataTable(string where)
        {
            if (where.Length > 1)
            {
                where = where.Insert(0, " Active = 1 and ");
            }
            return DataSource.ORMHelper.GetDataTable<Paper_In>(where);
        }

        public static DataTable GetYearMonth(int year, int month)
        {
            string where = "Month(InTime) = '" + month.ToString() + "' and YEAR(InTime) = '" + year.ToString() + "'";
            return GetDataTable(where);
        }
        public static DataTable GetYearMonth(DateTime dt)
        {
            int y = dt.Year;
            int m = dt.Month;
            return GetYearMonth(y, m);
        }

        public static List<Paper_In> GetYearMonthList(int year, int month)
        {
            string where = "Month(InTime) = '" + month.ToString() + "' and YEAR(InTime) = '" + year.ToString() + "'";
            return DataSource.ORMHelper.TbToModelList < Paper_In > (GetDataTable(where));
        }
        public static List<Paper_In> GetYearMonthList(DateTime dt)
        {
            int y = dt.Year;
            int m = dt.Month;
            return GetYearMonthList(y, m);
        }

        public static List<Paper_In> GetDataList(string where)
        {
            DataTable dt = GetDataTable(where);
            if (dt != null)
            {
                return DataSource.ORMHelper.TbToModelList<Paper_In>(dt);
            }
            return null;
        }

        public static int InserData(Paper_In pi)
        {
            if (pi != null)
            {
                return DataSource.ORMHelper.InsertModel<Paper_In>(pi);
            }
            return 0;
        }
        public static int InsertData(DataTable dt)
        {
            int result = 0;
            if (dt != null)
            {
                result=DataSource.ORMHelper.InserTable("Paper_In", dt);
            }
            return result;
        }
        public static List<string> GetColumNikeName()
        {
            return DataSource.ORMHelper.GetColumnsName(typeof(Paper_In));
        }
        public static int RemoveOut(List<string> OrderList)
        {
            string allorderno = "UPDATE Paper_In SET Active = '0' WHERE Id in (";
            for (int i = 0; i < OrderList.Count; i++)
            {
                allorderno += "'" + OrderList[i] + "',";
            }
            allorderno = allorderno.Remove(allorderno.Length - 1, 1);
            allorderno += ")";
            int result = 0;
            result = DataSource.ORMHelper.ExeSql(allorderno);
            return OrderList.Count;
        }
        public static int Paper_StroeIn(DataTable InPaper,bool NeedWritePaperIn,bool NeedUpdatePaperStroe)
        {
            List<Model.Paper_In> Ins = DataSource.ORMHelper.TbToModelList<Model.Paper_In>(InPaper);
            List<Model.Paper_Store> NeedUpdatePaper=new List<Paper_Store>();
            int count = 0;
            foreach (Model.Paper_In pi in Ins)
            {
                if (pi.Num != 0)
                {
                    Model.Paper_Store ps = Model.Paper_Store.GetPaperById(pi.PaperId);
                    if (ps != null)
                    {
                        bool HadInsert = false;
                        for (int k = 0; k < NeedUpdatePaper.Count; k++)
                        {
                            if (ps.PaperId == NeedUpdatePaper[k].PaperId)
                            {
                                NeedUpdatePaper[k].Num = NeedUpdatePaper[k].Num +pi.Num;
                                NeedUpdatePaper[k].TaxiMoney = NeedUpdatePaper[k].TaxiMoney+pi.Money;
                                HadInsert = true;
                                break;
                            }
                        }
                        if (!HadInsert)
                        {
                            //修改库存总数量；
                            ps.Num= ps.Num +pi.Num;
                            //修改库存总金额；
                            ps.TaxiMoney += pi.Money;
                            ps.TaxiPrice = Math.Abs(Math.Round(ps.TaxiMoney / ps.Num, 2));
                            //原基准价格的计算方法
                            //ps.UnitPrice = Math.Abs(Math.Round(ps.TaxiPrice * (decimal)1.16, 2));

                            //新基准价
                            ps.UnitPrice = pi.Price *(decimal) 1.16;
                            NeedUpdatePaper.Add(ps);
                        }
                        count++;
                    }
                }
            }
            if (count == InPaper.Rows.Count)
            {
                int result1 = 0;
                int reulst2 = 0;
                //判断存入库表是否成功；
                if (NeedWritePaperIn)
                {
                    result1=InsertData(InPaper);
                }
                //判断存纸张表是否成功；
                
                if (NeedUpdatePaperStroe&&result1>0)
                {
                    foreach (Model.Paper_Store psu in NeedUpdatePaper)
                    {
                        if (Model.Paper_Store.Update(psu) > 0)
                        {
                            reulst2++;
                        }
                    }
                    return reulst2;
                }
            }
            return 0;
        }
    }
}

