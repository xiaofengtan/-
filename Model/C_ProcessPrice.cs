/**  版本信息模板在安装目录下，可自行修改。
* C_ProcessPrice.cs
*
* 功 能： N/A
* 类 名： C_ProcessPrice
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
using System.Data;
namespace Model
{
    /// <summary>
    /// C_ProcessPrice:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    [DataSource.Table(IsCahche = true, NickName = "工艺价格表", TableName = "C_ProcessPrice")]
    public partial class C_ProcessPrice
    {
        private static DataTable _alldata;

        private static DataTable AllData
        {
            get
            {
                if (_alldata == null || LastTime.AddSeconds(Common.DataTimeOut) < DateTime.Now)
                {
                    _alldata = DataSource.ORMHelper.GetDataTable<C_ProcessPrice>("1=1");
                    LastTime = DateTime.Now;
                }
                return _alldata;
            }
        }
        private static  DateTime LastTime;
    

        public C_ProcessPrice()
		{}
		#region Model
		private int _priceid;
		private int _processid;
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
		public int ProcessId
		{
			set{ _processid=value;}
			get{return _processid;}
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
        public static decimal GetProcessPrice(int ProcessId, int num)
        {
            decimal result = 0;

            DataRow[] drs = AllData.Select("ProcessId='" + ProcessId.ToString() + "'");
            C_ProcessPrice cp = null;
            if (drs.Length > 0)
            {
                cp = DataSource.ORMHelper.RowToModel<C_ProcessPrice>(drs[0]);
            }
            if (cp != null)
            {
                decimal r1 = cp.SinglePrice1 * num;
                if (cp.StartPrice > 0)
                {
                    if (r1 < cp.StartPrice)
                        r1 = cp.StartPrice;
                }
                result = r1;
                return result;
            }
            return -1;
        }

        public static C_ProcessPrice GetById(int processid)
        {
            DataRow[] drs = AllData.Select("ProcessId='" + processid.ToString() + "'");
            C_ProcessPrice cp = null;
            if (drs.Length > 0)
            {
                cp = DataSource.ORMHelper.RowToModel<C_ProcessPrice>(drs[0]);
            }
            if (cp != null)
            {
                return cp;
            }
            else
                return null;
        }

        public static int GetProcessPriceInt(int ProcessId, int num)
        {
            decimal result = GetProcessPrice(ProcessId, num);
            int r =(int) Math.Round(result, 0);
            return r;
        }
	}
}

