/**  版本信息模板在安装目录下，可自行修改。
* P_MaterialList2.cs
*
* 功 能： N/A
* 类 名： P_MaterialList2
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2017-05-02 16:31:07   N/A    初版
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
	/// P_MaterialList2:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
    [DataSource.Table(IsCahche = true, NickName = "审核材料记录表", TableName = "P_MaterialList2")]
	public partial class P_MaterialList2
	{
		public P_MaterialList2()
		{}
        #region Model
        private int _id;
        private int _orderid;
        private int _partid;
		private string _code;
		private string _orderon;
		private string _listcode;
		private int _standid;
		private string _standname;
		private int _num;
		private decimal?  _unitprice;
		private int  _minprice;
		private int  _price;
		private int  _mtype;
		private int  _groupid;
		private int  _extendnum;
		private decimal  _extendratio;
		private int  _status;
		private string _request;
		private string _remark;
		private int  _b1;
		private string _b2;

        [DataSource.Column(IsIdentity = true, IsPrimary = true, NickName = "编号")]
        public int Id
        { set { _id = value; }
            get { return _id; }
        }

        public int OrderId
        {
            set { _orderid = value; }
            get { return _orderid; }
        }

        public int PartId
        {
            set { _partid = value; }
            get { return _partid; }
        }
            
		/// <summary>
		/// 
		/// </summary>
		public string Code
		{
			set{ _code=value;}
			get{return _code;}
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
		/// 
		/// </summary>
		public string ListCode
		{
			set{ _listcode=value;}
			get{return _listcode;}
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
		public string StandName
		{
			set{ _standname=value;}
			get{return _standname;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int Num
		{
			set{ _num=value;}
			get{return _num;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal  UnitPrice
		{
			set{ _unitprice=value;}
			get{
                if (_unitprice == null)
                    return 0;
                else
                    return (decimal)_unitprice;
            }
		}
		/// <summary>
		/// 
		/// </summary>
		public int  MinPrice
		{
			set{ _minprice=value;}
			get{return _minprice;}
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
		public int  MType
		{
			set{ _mtype=value;}
			get{return _mtype;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int  GroupId
		{
			set{ _groupid=value;}
			get{return _groupid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int  ExtendNum
		{
			set{ _extendnum=value;}
			get{return _extendnum;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal  ExtendRatio
		{
			set{ _extendratio=value;}
			get{return _extendratio;}
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
		public string Request
		{
			set{ _request=value;}
			get{return _request;}
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

        public static DataTable GetDataTable(string where)
        {
            return DataSource.ORMHelper.GetDataTable<P_MaterialList2>(where);
        }

         public static List<P_MaterialList2> GetDataList(string where)
        {
            DataTable dt = GetDataTable(where);
            if (dt != null)
            {
                return DataSource.ORMHelper.TbToModelList<P_MaterialList2>(dt);
            }
            return null;
        }

         public static List<P_MaterialList2> GetAllNoInputList()
         {
             return GetDataList("Status=0 and b1>0");
         }

         public static int Update(P_MaterialList2 pm2)
         {
             return DataSource.ORMHelper.UpdateModelById<P_MaterialList2>(pm2);
         }
        public static int UpdateOut(List<string> OrderList)
        {
            string allorderno = "UPDATE P_MaterialList2 SET Status = '1' WHERE OrderOn in (";
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
         public static P_MaterialList2 GetModelById(int pmid)
         {
             DataTable dt = GetDataTable("Id='" + pmid.ToString() + "'");
             if (dt != null)
             {
                 if (dt.Rows.Count > 0)
                     return DataSource.ORMHelper.TbToModelList<P_MaterialList2>(dt)[0];
             }
             return null;
         }

	}
}

