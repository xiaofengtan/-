/**  版本信息模板在安装目录下，可自行修改。
* ProductSize.cs
*
* 功 能： N/A
* 类 名： ProductSize
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2017-05-02 16:31:53   N/A    初版
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
	/// ProductSize:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
    [DataSource.Table(IsCahche = false, NickName = "尺寸表", TableName = "ProductSize")]
	public partial class ProductSize
	{
        private static DataTable _alldata;

        private static DataTable AllData
        {
            get
            {
                if (_alldata == null || LastTime.AddSeconds(Common.DataTimeOut) < DateTime.Now)
                {
                    _alldata = DataSource.ORMHelper.GetDataTable<ProductSize>("Status='1'");
                    LastTime = DateTime.Now;
                }
                return _alldata;
            }
        }
        private static List<ProductSize> _allSize;
        public static List<ProductSize> AllSize
        {
            get
            {
                if (_allSize == null || NeedRead || LastTime.AddSeconds(Common.DataTimeOut) < DateTime.Now)
                {
                    _allSize = DataSource.ORMHelper.TbToModelList<ProductSize>(AllData);
                }
                return _allSize;
            }
        }
        private static DateTime LastTime;
        private static bool NeedRead = true;
        public ProductSize()
		{}
		#region Model
		private int _id;
		private string _sizename;
		private string _nickname;
		private int  _productid;
		private int  _standlength;
		private int  _standheight;
		private int  _maxlength;
		private int  _maxheight;
		private int  _kaidu;
		private int  _minlength;
		private int  _minheight;
		private int  _serialnumber;
		private int  _sizeid;
		private int  _showmark;
		private int  _status;
		private string _remark;
		private int  _b1;
		private string _b2;
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
		public string SizeName
		{
			set{ _sizename=value;}
			get{return _sizename;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string NickName
		{
			set{ _nickname=value;}
			get{return _nickname;}
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
		public int  StandLength
		{
			set{ _standlength=value;}
			get{return _standlength;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int  StandHeight
		{
			set{ _standheight=value;}
			get{return _standheight;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int  MaxLength
		{
			set{ _maxlength=value;}
			get{return _maxlength;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int  MaxHeight
		{
			set{ _maxheight=value;}
			get{return _maxheight;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int  Kaidu
		{
			set{ _kaidu=value;}
			get{return _kaidu;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int  MinLength
		{
			set{ _minlength=value;}
			get{return _minlength;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int  MinHeight
		{
			set{ _minheight=value;}
			get{return _minheight;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int  SerialNumber
		{
			set{ _serialnumber=value;}
			get{return _serialnumber;}
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
		public int  ShowMark
		{
			set{ _showmark=value;}
			get{return _showmark;}
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


        public static List<string> GetColumNikeName()
        {
            return DataSource.ORMHelper.GetColumnsName(typeof(ProductSize));
        }

        public static ProductSize GetSizeById(int id)
        {
            ProductSize ps = null;
            for (int i = 0; i < AllSize.Count; i++)
            {
                if (AllSize[i].Id == id)
                {
                    ps = AllSize[i];
                    break;
                }
            }
            return ps;
        }

        public static List<ProductSize> GetSizeById(List<int> id)
        {
            List<ProductSize> pslist = new List<ProductSize>();
            for (int i = 0; i < id.Count; i++)
            {
                ProductSize ps = GetSizeById(id[i]);
                if (ps != null)
                {
                    pslist.Add(ps);
                }
            }
            return pslist;
        }

        public static List<NameType> SizeListToNameList(List<ProductSize> plist)
        {
            List<NameType> Result = new List<NameType>();
            if (plist != null)
            {
                foreach (ProductSize ps in plist)
                {
                    NameType nt = new NameType();
                    nt.Id = ps.Id;
                    nt.Name = ps.NickName;
                    Result.Add(nt);
                }
                return Result;
            }
            return null;
        }

        public static List<ProductSize> GetSizeKaidu(int kaidu)
        {
            List<ProductSize> pslist = new List<ProductSize>();
            for (int i = 0; i < AllSize.Count; i++)
            {
               
                if (AllSize[i].Kaidu==kaidu)
                {
                    ProductSize ps = (ProductSize)AllSize[i].MemberwiseClone();
                    pslist.Add(ps);
                }
            }
            if (pslist.Count > 0)
                return pslist;
            else
                return null;
        }

        public static ProductSize GetLHSize(int L, int H)
        {
            int l, h;
            if (L < H)
            {
                l = H;
                h = L;
            }
            else
            {
                l = L;
                h = H;
            }
            List<ProductSize> pslist = new List<ProductSize>();
            foreach (ProductSize ps in AllSize)
            {
                if (ps.StandHeight ==l  && ps.StandLength == h)
                {
                    return ps;
                }
                if (ps.StandHeight == h && ps.StandLength == l)
                {
                    return ps;
                }
            }
            foreach (ProductSize ps in AllSize)
            {
                if ((ps.MaxHeight >= h && ps.MaxLength >= l)&&(ps.MinHeight <= h && ps.MinLength <= l))
                {
                    pslist.Add(ps);
                }
                if ((ps.MaxHeight >= l && ps.MaxLength >= h) && (ps.MinHeight <=l && ps.MinLength <= h))
                {
                    pslist.Add(ps);
                }
            }

            if (pslist.Count > 0)
            {
                decimal s1, s2;
                decimal r = 0;
                ProductSize result = null;
                foreach (ProductSize ps in pslist)
                {
                    s1 = l * h;
                    s2 = ps.StandHeight * ps.StandLength;
                    decimal r1 = s1 / s2;
                    if (r1 > r)
                    {
                        result = ps;
                        r = r1;
                    }
                }
                return result;
            }
            else
                return null;
        }


        public static DataTable GetDataTable(string where)
        {
            return DataSource.ORMHelper.GetDataTable<ProductSize>(where);
        }

        public static List<ProductSize> GetDataList(string where)
        {
            DataTable dt = GetDataTable(where);
            if (dt != null)
            {
                return DataSource.ORMHelper.TbToModelList<ProductSize>(dt);
            }
            return null;
        }

        public static int InsertData(ProductSize po)
        {
            if (po != null)
            {
                return DataSource.ORMHelper.InsertModel<ProductSize>(po);
            }
            return 0;
        }

        public static int Update(ProductSize ps)
        {
            return DataSource.ORMHelper.UpdateModelById<ProductSize>(ps);
        }

	}
}

