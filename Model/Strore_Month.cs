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
    /// 月度结存数量:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    [DataSource.Table(IsCahche = false, NickName = "库存月结表", TableName = "Store_month")]
    public partial class Store_month
    {
        public Store_month()
        { }
        #region Model
        private int _id;
        private int _paperid;
        private string _papername;
        private int _year;
        private int _month;
        private int _last_num;
        private decimal _price;
        private decimal _last_money;
        private int _in_num;
        private decimal _in_money;
        private int _out_num;
        private decimal _out_money;

        private int _current_num;
        private decimal _current_price;
        private decimal _current_money;
        private DateTime _caltime;
        private int _orderno;

        /// <summary>
        /// 
        /// </summary>
        [DataSource.Column(IsIdentity = true, IsPrimary = true, NickName = "编号")]

        public int Id
        {
            set { _id = value; }
            get { return _id; }
        }
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

        [DataSource.Column(NickName = "年")]
        public int Year
        {
            set { _year = value; }
            get { return _year; }
        }

        [DataSource.Column(NickName = "月")]
        public int Month
        {
            set { _month = value; }
            get { return _month; }
        }


        [DataSource.Column(NickName = "结存数量")]
        public int LastNum
        {
            set { _last_num = value; }
            get { return _last_num; }
        }

        [DataSource.Column(NickName = "结存单价")]
        public decimal Price
        {
            set { _price = value; }
            get { return _price; }
        }
        [DataSource.Column(NickName = "结存金额")]
        public decimal LastMoney
        {
            set { _last_money = value; }
            get { return _last_money; }
        }


        [DataSource.Column(NickName = "入库数量")]
        public int InNum
        {
            set { _in_num = value; }
            get { return _in_num; }
        }
        [DataSource.Column(NickName = "入库金额")]
        public decimal InMoney
        {
            set { _in_money = value; }
            get { return _in_money; }
        }

        [DataSource.Column(NickName = "出库数量")]
        public int OutNum
        {
            set { _out_num = value; }
            get { return _out_num; }
        }
        [DataSource.Column(NickName = "出库金额")]
        public decimal OutMoney
        {
            set { _out_money = value; }
            get { return _out_money; }
        }

        [DataSource.Column(NickName = "当前数量")]
        public int CurrentNum
        {
            set { _current_num = value; }
            get { return _current_num; }
        }

        [DataSource.Column(NickName = "当前单价")]
        public decimal CurrentPrice
        {
            set { _current_price = value; }
            get { return _current_price; }
        }
        [DataSource.Column(NickName = "当前金额")]
        public decimal CurrentMoney
        {
            set { _current_money = value; }
            get { return _current_money; }
        }
        [DataSource.Column(NickName = "操作时间")]
        public DateTime CalTime
        {
            set { _caltime = value; }
            get { return _caltime; }
        }

        [DataSource.Column(NickName = "操作序号")]
        public int OrderNo
        {
            set { _orderno = value; }
            get { return _orderno; }
        }

        #endregion Model

        public static int Update(Store_month paper)
        {
            return DataSource.ORMHelper.UpdateModelById<Store_month>(paper);
        }
        public int GetLastNo()
        {
            int result = 0;
            string where = "PaperId=(select MAX(OrderNo) from Store_month)";
            List<Store_month> dt = GetDataList(where);
            if (dt != null)
            {
                result = dt[0].OrderNo;
            }
            return result;
        }
        public static DataTable GetDataTable(string where)
        {
            return DataSource.ORMHelper.GetDataTable<Store_month>(where);
        }

        public static List<Store_month> GetDataList(string where)
        {
            DataTable dt = GetDataTable(where);
            if (dt != null)
            {
                return DataSource.ORMHelper.TbToModelList<Store_month>(dt);
            }
            return null;
        }
        public static List<string> GetColumNikeName()
        {
            return DataSource.ORMHelper.GetColumnsName(typeof(Store_month));
        }
        public static int InsertData(DataTable dt)
        {
            if (dt != null)
            {
                return DataSource.ORMHelper.InserTable("Store_month", dt);
            }
            return 0;
        }
        public static DataTable GetMonthStore(int year, int month)
        {
            string where = " Year='" + year.ToString() + "' and Month='" + month.ToString() + "' order by PaperId";
            return GetDataTable(where);
        }

        public static Store_month GetPaperMonthStore(int year, int month,int PaperId)
        {
            string where = " Year='" + year.ToString() + "' and Month='" + month.ToString() + "' and PaperId='"+PaperId.ToString()+"'";
            DataTable dt= GetDataTable(where);
            if (dt != null&& dt.Rows.Count > 0)
            {
                Store_month result = DataSource.ORMHelper.RowToModel<Store_month>(dt.Rows[0]);
                if (result != null)
                    return result;
            }
            return null;
        }

        public static DataTable GetMonthStore(DateTime time)
        {
            string where = " Year='" + time.Year.ToString() + "' and Month='" + time.Month.ToString() + "' order by PaperId";
            return GetDataTable(where);
        }
        /// <summary>
        /// 获取当月所有订单；
        /// </summary>
        /// <param name="month"></param>
        /// <returns></returns>
        public static List<Store_month> GetMonthStoreList(int year, int month)
        {
            DataTable dt = GetMonthStore(year, month);
            if (dt != null)
            {
                return DataSource.ORMHelper.TbToModelList<Store_month>(dt);
            }
            return null;
        }
        public static List<Store_month> GetMonthStoreList(DateTime time)
        {
            DataTable dt = GetMonthStore(time);
            if (dt != null)
            {
                return DataSource.ORMHelper.TbToModelList<Store_month>(dt);
            }
            return null;
        }

        public static DataTable MakeNewStore(int year, int month)
        {
            List<Store_month> StoreList = new List<Store_month>();
            List<Paper_Store> PaperList = Paper_Store.GetAllPaperList();
          
            List<Paper_In> InList = Paper_In.GetYearMonthList(year, month);
            List<Paper_Out> OutList = Paper_Out.GetYearMonthList(year, month);

            List<Store_month> Lastlist;

            Store_month total = new Store_month();

            if (month == 1)
            {
                Lastlist = GetMonthStoreList(year - 1, 12);
            }
            else
            {
                Lastlist = GetMonthStoreList(year, month-1);
            }
            for (int i = 0; i < PaperList.Count; i++)
            {
                Store_month st = new Store_month();
                st.PaperId = PaperList[i].PaperId;
                st.PaperName = PaperList[i].PaperName;
                int index = -1;
                if (InList != null)
                {
                    for (int j = 0; j < InList.Count; j++)
                    {
                        if (InList[j].PaperId == PaperList[i].PaperId)
                        {
                            index = j;
                            st.InNum += InList[index].Num;
                            st.InMoney += InList[index].Money;
                        }
                    }
                }
                if (OutList != null)
                {
                    for (int j = 0; j < OutList.Count; j++)
                    {
                        if (OutList[j].PaperId == PaperList[i].PaperId)
                        {
                            index = j;
                            st.OutNum += OutList[index].Num;
                            st.OutMoney += OutList[index].Money;
                        }
                    }
                }
                if (Lastlist != null)
                {
                    for (int j = 0; j < Lastlist.Count; j++)
                    {
                        if (Lastlist[j].PaperId == PaperList[i].PaperId)
                        {
                            index = j;
                            st.LastNum = Lastlist[index].CurrentNum;
                            st.LastMoney = Lastlist[index].CurrentMoney;
                        }
                    }
                }
                st.Year = year;
                st.Month = month;
                st.OrderNo = year * 100 + month;
                st.CalTime = DateTime.Now;
                st.CurrentNum = PaperList[i].Num;
                st.CurrentPrice = PaperList[i].TaxiPrice;
                st.CurrentMoney = PaperList[i].TaxiMoney;
                StoreList.Add(st);
                total.LastNum += st.LastNum;
                total.LastMoney += st.LastMoney;
                total.InNum += st.InNum;
                total.InMoney += st.InMoney;
                total.OutNum += st.OutNum;
                total.OutMoney += st.OutMoney;
                total.CurrentNum += st.CurrentNum;
                total.CurrentMoney += st.CurrentMoney;
            }
            total.PaperName = "汇总";
            StoreList.Add(total);
            return DataSource.ORMHelper.ModelListToTb<Store_month>(StoreList);
        }
        /// <summary>
        /// 根据一批入库记录作为初始化的库存
        /// </summary>
        /// <param name="PaperInData"></param>
        /// <returns></returns>
        public static DataTable InitStoreList(DataTable PaperInData, int year, int month)
        {
            if (PaperInData != null)
            {
                List<Store_month> StoreList = new List<Store_month>();
                List<Paper_Store> PaperList = Paper_Store.GetAllPaperList();
                //List<Paper_Store> NeedSavePaperList = new List<Paper_Store>();
                List<Paper_In> DataList = DataSource.ORMHelper.TbToModelList<Paper_In>(PaperInData);

                for (int i = 0; i < PaperList.Count; i++)
                {
                    Store_month st = new Store_month();
                    st.PaperId = PaperList[i].PaperId;
                    st.PaperName = PaperList[i].PaperName;
                    int index = -1;
                    for (int j = 0; j < DataList.Count; j++)
                    {
                        if (DataList[j].PaperId == PaperList[i].PaperId)
                        {
                            index = j;
                            st.LastNum += DataList[index].Num;
                            st.LastMoney += DataList[index].Money;
                        }
                    }
                    st.Year = year;
                    st.Month = month;
                    st.OrderNo = year * 100 + month;
                    st.CalTime = DateTime.Now;
                    st.CurrentMoney = st.LastMoney;
                    st.CurrentNum = st.LastNum;
                    if (st.CurrentNum != 0)
                        st.CurrentPrice = Math.Abs(Math.Round(st.LastMoney / st.LastNum, 2));
                    else
                        st.CurrentPrice = 0;
                    //清除原来所有的当前库存；
                    //if (PaperList[i].Num != 0 || PaperList[i].TaxiMoney != 0 || PaperList[i].TaxiPrice != 0)
                    //{
                    //    PaperList[i].Num = 0;
                    //    PaperList[i].TaxiMoney = 0;
                    //    PaperList[i].TaxiPrice = 0;
                    //    NeedSavePaperList.Add(PaperList[i]);
                    //}
                    StoreList.Add(st);
                }
                return DataSource.ORMHelper.ModelListToTb<Store_month>(StoreList);

            }
            return null;
        }
        //        //插入所有的纸张的初始化库存；
        //        result = InsertData(DataSource.ORMHelper.ModelListToTb<Store_month>(StoreList));
        //        //如果成功，修改纸张当时库存为0；
        //        if (result == PaperInData.Rows.Count)
        //        {
        //            int count = 0;
        //            for (int i = 0; i < NeedSavePaperList.Count; i++)
        //            {
        //                if (Paper_Store.Update(NeedSavePaperList[i]) > 0)
        //                {
        //                    count++;
        //                }
        //                if (count == NeedSavePaperList.Count)
        //                    return result;
        //                else
        //                    return result * -1;
        //            }
        //        }
        //        else
        //            return 0;
        //    }
        //    return 0;
        //}
            }
}

