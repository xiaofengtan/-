/**  版本信息模板在安装目录下，可自行修改。
* R_ProductSize.cs
*
* 功 能： N/A
* 类 名： R_ProductSize
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2017-05-02 16:32:13   N/A    初版
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
	/// R_ProductSize:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
    [DataSource.Table(IsCahche = true, NickName = "产品尺寸对应表", TableName = "R_ProductSize")]
    public partial class R_ProductSize
	{
		public R_ProductSize()
		{}
		#region Model
		private int _productid;
		private int  _productsizeid;
		private int  _status;
		private string _remark;
		private int  _b1;
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
		public int  ProductSizeId
		{
			set{ _productsizeid=value;}
			get{return _productsizeid;}
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
        #endregion Model

        public static List<ProductSize> GetSizeListByProductId(int ProductId)
        {
            List<ProductSize> Result = new List<ProductSize>();
            DataTable dt = DataSource.ORMHelper.GetDataTable<R_ProductSize>("ProductId='" + ProductId.ToString() + "'");
            List<int> SizeId = new List<int>();
            if (dt != null)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    int id = int.Parse(dt.Rows[i][1].ToString());
                    SizeId.Add(id);
                }
                string where = Common.IntListToSql(SizeId);
                if (where.Length > 4)
                {
                    where = "Id " + where;
                    List<Model.ProductSize> ps = ProductSize.GetDataList("Id " + Common.IntListToSql(SizeId));
                    return ps;
                }
            }
            return null;
        }
	}
}

