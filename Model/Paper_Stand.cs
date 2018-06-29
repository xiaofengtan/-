/**  版本信息模板在安装目录下，可自行修改。
* Paper_Stand.cs
*
* 功 能： N/A
* 类 名： Paper_Stand
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2017-05-02 16:31:39   N/A    初版
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
	/// Paper_Stand:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
    [DataSource.Table(IsCahche = true, NickName = "纸张标准表", TableName = "Paper_Stand")]
	public partial class Paper_Stand
	{
		public Paper_Stand()
		{}
		#region Model
		private int _id;
		private string _standcode;
		private string _standname;
		private int _kg;
		private int _typeid;
		private int  _sizeid;
		private int  _colorid;
		private int  _rankid;
		private decimal  _thick;
		private int  _salestonprice;
		private decimal  _salesunitprice;
		private int  _startprice;
		private decimal  _singleprice1;
		private decimal  _singleprice2;
		private int  _startnum1;
		private int  _startnum2;
		private int _ordernumber;
		private int  _status;
		private string _remark;
		private int  _b1;
		private string _b2;
		/// <summary>
		/// 
		/// </summary>
        [DataSource.Column(IsIdentity = true, IsPrimary = true, NickName = "纸张类型编号")]
		public int Id
		{
			set{ _id=value;}
			get{return _id;}
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
		public string StandName
		{
			set{ _standname=value;}
			get{return _standname;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int KG
		{
			set{ _kg=value;}
			get{return _kg;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int TypeId
		{
			set{ _typeid=value;}
			get{return _typeid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int  SizeId
		{
			set{ _sizeid=value;}
			get{return _sizeid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int  ColorId
		{
			set{ _colorid=value;}
			get{return _colorid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int  RankId
		{
			set{ _rankid=value;}
			get{return _rankid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal  Thick
		{
			set{ _thick=value;}
			get{return _thick;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int  SalesTonPrice
		{
			set{ _salestonprice=value;}
			get{return _salestonprice;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal  SalesUnitPrice
		{
			set{ _salesunitprice=value;}
			get{return _salesunitprice;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int  StartPrice
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
		public int OrderNumber
		{
			set{ _ordernumber=value;}
			get{return _ordernumber;}
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



        public static DataTable GetDataTable(string where)
        {
            return DataSource.ORMHelper.GetDataTable<Paper_Stand>(where);
        }

        public static List<Paper_Stand> GetDataList(string where)
        {
            DataTable dt = GetDataTable(where);
            if (dt != null)
            {
                return DataSource.ORMHelper.TbToModelList<Paper_Stand>(dt);
            }
            return null;
        }
	}
}

