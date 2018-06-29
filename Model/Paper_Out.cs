/**  版本信息模板在安装目录下，可自行修改。
* Paper_Out.cs
*
* 功 能： N/A
* 类 名： Paper_Out
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2017-05-02 16:31:37   N/A    初版
*
* Copyright (c) 2012 Maticsoft Corporation. All rights reserved.
*┌──────────────────────────────────┐
*│　此技术信息为本公司机密信息，未经本公司书面同意禁止向第三方披露．　│
*│　版权所有：动软卓越（北京）科技有限公司　　　　　　　　　　　　　　│
*└──────────────────────────────────┘
*/
using System;
using System.Data;
using System.Collections.Generic;

namespace Model
{
    public enum OutStoreCode {生产出库,盘亏出库,其他出库};
	/// <summary>
	/// Paper_Out:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
    [DataSource.Table(IsCahche = true, NickName = "出库记录表", TableName = "Paper_Out")]
	public partial class Paper_Out
	{
		public Paper_Out()
		{
            Active = true;
        }
		#region Model
		private int _id;
		private int  _paperid;
		private string _papername;
		private string _orderno;
		private DateTime  _outtime;
		private DateTime _realtime;
		private int  _num;
		private decimal  _price;
		private decimal  _money;
		private string _sourcecode;
		private bool _active;
		private string _remark;
		private string _b1;
		private int  _b2;
		/// <summary>
		/// 
		/// </summary>
        [DataSource.Column(IsIdentity = true, IsPrimary = true, NickName = "编号")]
        public int Id
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// 
		/// </summary>
         [DataSource.Column(NickName = "纸张编号")]
        public int  PaperId
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
         [DataSource.Column(NickName = "订单编号")]
        public string OrderNo
		{
			set{ _orderno=value;}
			get{return _orderno;}
		}
		/// <summary>
		/// 
		/// </summary>
         [DataSource.Column(NickName = "订单时间")]
        public DateTime  OutTime
		{
			set{ _outtime=value;}
			get{return _outtime;}
		}
		/// <summary>
		/// 
		/// </summary>
         [DataSource.Column(NickName = "操作时间")]
        public DateTime RealTime
		{
			set{ _realtime=value;}
			get{return _realtime;}
		}
		/// <summary>
		/// 
		/// </summary>
        [DataSource.Column(NickName = "出库数量")]
        public int  Num
		{
			set{ _num=value;}
			get{return _num;}
		}
		/// <summary>
		/// 
		/// </summary>
        [DataSource.Column(NickName = "出库单价")]
        public decimal  Price
		{
			set{ _price=value;}
			get{return _price;}
		}
		/// <summary>
		/// 
		/// </summary>
        [DataSource.Column(NickName = "出库金额")]
        public decimal  Money
		{
			set{ _money=value;}
			get{return _money;}
		}
		/// <summary>
		/// 
		/// </summary>
        [DataSource.Column(NickName = "出库类型")]
        public string SourceCode
		{
			set{ _sourcecode=value;}
			get{return _sourcecode;}
		}
		/// <summary>
		/// 
		/// </summary>
        [DataSource.Column(NickName = "有效")]
        public bool Active
		{
			set{ _active=value;}
			get{return _active;}
		}
		/// <summary>
		/// 
		/// </summary>
        [DataSource.Column(NickName = "客户")]
        public string Remark
		{
			set{ _remark=value;}
			get{return _remark;}
		}
		/// <summary>
		/// 
		/// </summary>
        [DataSource.Column(NickName = "原凭单号")]
        public string b1
		{
			set{ _b1=value;}
			get{return _b1;}
		}
		/// <summary>
		/// 
		/// </summary>
        [DataSource.Column(NickName = "辅助2")]
        public int  b2
		{
			set{ _b2=value;}
			get{return _b2;}
		}
		#endregion Model


        public static DataTable GetDataTable(string where)
        {
            if (where.Length > 1)
            {
                where = where.Insert(0, " Active = 1 and ");
            }
            return DataSource.ORMHelper.GetDataTable<Paper_Out>(where);
        }


        public static int Update(Paper_Out paperout)
        {
            return DataSource.ORMHelper.UpdateModelById<Paper_Out>(paperout);
        }
        public static List<Paper_Out> GetDataList(string where)
        {
            DataTable dt = GetDataTable(where);
            if (dt != null)
            {
                return DataSource.ORMHelper.TbToModelList<Paper_Out>(dt);
            }
            return null;
        }
        public static DataTable GetYearMonth(int year, int month)
        {
            string where = "Month(OutTime) = '" + month.ToString() + "' and YEAR(OutTime) = '" + year.ToString() + "' Order By OutTime";
            return GetDataTable(where);
        }
        public static DataTable GetYearMonth(DateTime dt)
        {
            int y = dt.Year;
            int m = dt.Month;
            return GetYearMonth(y, m);
        }
        public static List<Paper_Out> GetYearMonthList(int year, int month)
        {
            string where = "Month(OutTime) = '" + month.ToString() + "' and YEAR(OutTime) = '" + year.ToString() + "' Order By OutTime";
            return PaperoutTabletoList( GetDataTable(where));
        }
        public static List<Paper_Out> GetYearMonthList(DateTime dt)
        {
            int y = dt.Year;
            int m = dt.Month;
            return GetYearMonthList(y, m);
        }

        public static int InsertData(Paper_Out po)
         {
             if (po != null)
             {
                 return DataSource.ORMHelper.InsertModel<Paper_Out>(po);
             }
             return 0;
         }
        public static int InsertData(DataTable dt)
        {
            if (dt != null)
            {
                return DataSource.ORMHelper.InserTable("Paper_Out", dt);
            }
            return 0;
        }

        public static int RemoveOut(List<string> OrderList)
        {
            string allorderno = "UPDATE Paper_Out SET Active = '0' WHERE Id in (";
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
        public static List<Paper_Out> PaperoutTabletoList(DataTable dt)
        {
            return DataSource.ORMHelper.TbToModelList<Paper_Out>(dt);
        }
         public static List<Paper_Out> TransMaterListToOutList(List<P_Order> allorder)
         {
             List<Paper_Out> Plist = new List<Paper_Out>();
             List<Paper_Store> Papers = Paper_Store.GetAllPaperList();
          
            List<P_MaterialList2> M2List;
            string orderlist = "";
            foreach (P_Order order in allorder)
            {
                string oderno = order.OrderOn;
                oderno = oderno.Replace("O", "PUB");
                oderno = "'" + oderno + "',";
                orderlist += oderno;
                //List<P_MaterialList2> mlist = P_MaterialList2.GetDataList("OrderOn='" + oderno + "'");
            }
            orderlist=orderlist.Remove(orderlist.Length - 1, 1);
            M2List = P_MaterialList2.GetDataList("OrderOn in (" + orderlist + ") and Status=0");
            foreach (P_Order order in allorder)
             {

                 string oderno = order.OrderOn;
                 oderno = oderno.Replace("O", "PUB");
                List<P_MaterialList2> mlist = new List<P_MaterialList2>();
                for (int j = 0; j < M2List.Count; j++)
                {
                    if (M2List[j].OrderOn == oderno)
                    {
                        mlist.Add(M2List[j]);
                    }
                }
                // List<P_MaterialList2> mlist = P_MaterialList2.GetDataList("OrderOn='" + oderno + "'");
                 if (mlist != null)
                 {
                     for (int i = 0; i < mlist.Count; i++)
                     {
                         Paper_Out po = new Paper_Out();
                         po.OrderNo = order.OrderOn;
                         po.OutTime = order.OrderTime;
                         po.Remark = order.Receiver;
                         po.RealTime = DateTime.Now;
                         po.b1 = order.b2;

                         po.Num = mlist[i].Num + mlist[i].ExtendNum;
                         po.PaperId = mlist[i].b1;
                         Paper_Store ps = null;
                         foreach (Paper_Store p1 in Papers)
                         {
                             if (p1.PaperId == po.PaperId)
                             {
                                 ps = p1;
                                 break;
                             }
                         }
                         if (ps != null)
                         {
                             po.PaperName = mlist[i].b2;
                             po.Price = ps.TaxiPrice;
                             po.Money = po.Num * po.Price;
                            po.Money = Math.Round(po.Money, 2);
                             po.SourceCode = OutStoreCode.生产出库.ToString();
                             po.Active = true;
                             po.b2 = mlist[i].Id;
                             Plist.Add(po);
                         }
                     }

                 }
             }
             if (Plist.Count > 0)
                 return Plist;
             else
                 return null;
         }

        public static DataTable TransMaterListToDataTable(List<P_Order> allorder)
        {
            List<Paper_Out> p = TransMaterListToOutList(allorder);
            if (p == null)
                return null;
            return DataSource.ORMHelper.ModelListToTb<Paper_Out>(p);
        }

        public static List<string> GetColumNikeName()
        {
            return DataSource.ORMHelper.GetColumnsName(typeof(Paper_Out));
        }
        public static  int paperout(DataTable OutPaper,bool NeedWritePaperOut,bool NeedUpdateStore,bool NeedUpdateMaterial)
        {
            int count = 0;
            if (OutPaper != null && OutPaper.Rows.Count > 0)
            {
                List<Paper_Out> paper = DataSource.ORMHelper.TbToModelList<Paper_Out>(OutPaper);
                List<string> AllorderList = new List<string>();
                List<Model.Paper_Store> WaitOutPaer = new List<Model.Paper_Store>();
                for (int i = 0; i < paper.Count; i++)
                {
                    Model.Paper_Store ps = Model.Paper_Store.GetPaperById(paper[i].PaperId);
                    string numno = paper[i].OrderNo;
                    numno = numno.Replace("O", "PUB");
                    AllorderList.Add(numno);
                    if (ps != null)
                    {
                        bool HadInsert = false;
                        for (int k = 0; k < WaitOutPaer.Count; k++)
                        {
                            if (ps.PaperId == WaitOutPaer[k].PaperId)
                            {
                                WaitOutPaer[k].Num = WaitOutPaer[k].Num - paper[i].Num;
                                WaitOutPaer[k].TaxiMoney -= paper[i].Money;
                                HadInsert = true;
                                break;
                            }
                        }
                        if (!HadInsert)
                        {
                            ps.Num = ps.Num - paper[i].Num;
                            //减去库存总金额；
                            ps.TaxiMoney = ps.TaxiMoney - paper[i].Money;
                            WaitOutPaer.Add(ps);
                        }
                        count++;
                    }
                }
                //添加出库记录
                if (NeedWritePaperOut)
                {
                    Model.Paper_Out.InsertData(OutPaper);
                }
                //修改库存数量。PAPERSTROE里的数量更新；
                if (NeedUpdateStore)
                {
                    foreach (Model.Paper_Store p1 in WaitOutPaer)
                    {
                        Model.Paper_Store.Update(p1);
                    }
                }
                //修改材料表，表示已经出库；状态为1；
                if (NeedUpdateMaterial)
                {
                    Model.P_MaterialList2.UpdateOut(AllorderList);
                }
            }
            return count;
        }
    }
}

