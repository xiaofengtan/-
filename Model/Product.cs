/**  版本信息模板在安装目录下，可自行修改。
* Product.cs
*
* 功 能： N/A
* 类 名： Product
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2017-05-02 16:31:51   N/A    初版
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
	/// Product:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
    [DataSource.Table(IsCahche = true, NickName = "产品类型", TableName = "Product")]
	public partial class Product
	{
		public Product()
		{}
		#region Model
		private int _productid;
		private int _typeid;
		private string _productname;
		private string _productcode;
		private string _unit;
		private bool _showmark;
		private int  _relationproduct;
		private string _quantitylist;
		private string _image1;
		private string _image2;
		private string _image3;
		private string _image4;
		private string _remark;
		private int  _b1;
		private string _b2;
		/// <summary>
		/// 
		/// </summary>
		public int ProductId
		{
			set{ _productid=value;}
			get{return _productid;}
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
		public string ProductName
		{
			set{ _productname=value;}
			get{return _productname;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string ProductCode
		{
			set{ _productcode=value;}
			get{return _productcode;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Unit
		{
			set{ _unit=value;}
			get{return _unit;}
		}
		/// <summary>
		/// 
		/// </summary>
		public bool ShowMark
		{
			set{ _showmark=value;}
			get{return _showmark;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int  RelationProduct
		{
			set{ _relationproduct=value;}
			get{return _relationproduct;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string QuantityList
		{
			set{ _quantitylist=value;}
			get{return _quantitylist;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Image1
		{
			set{ _image1=value;}
			get{return _image1;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Image2
		{
			set{ _image2=value;}
			get{return _image2;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Image3
		{
			set{ _image3=value;}
			get{return _image3;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Image4
		{
			set{ _image4=value;}
			get{return _image4;}
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

        public static List<Product> GetDataList(string where)
        {
            DataTable dt = GetDataTable(where);
            if (dt != null)
            {
                return DataSource.ORMHelper.TbToModelList<Product>(dt);
            }
            return null;
        }
        public static List<NameType> GetNameTypeList(string where)
        {
            List<Product> plist = GetDataList(where);
            List<NameType> Result = new List<NameType>();
            if (plist != null)
            {
                foreach (Product p in plist)
                {
                    NameType nt = new NameType();
                    nt.Name = p.ProductName;
                    nt.Id = p.ProductId;
                    Result.Add(nt);
                }
                return Result;
            }
            return null;
        }
        public static DataTable GetDataTable(string where)
        {
            return DataSource.ORMHelper.GetDataTable<Product>(where);
        }
		#endregion Model

	}
}

