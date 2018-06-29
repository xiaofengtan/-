/**  版本信息模板在安装目录下，可自行修改。
* R_ProductPaper.cs
*
* 功 能： N/A
* 类 名： R_ProductPaper
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2017-05-02 16:32:04   N/A    初版
*
* Copyright (c) 2012 Maticsoft Corporation. All rights reserved.
*┌──────────────────────────────────┐
*│　此技术信息为本公司机密信息，未经本公司书面同意禁止向第三方披露．　│
*│　版权所有：山西四元信息科技有限公司　　　　　　　　　　　│
*└──────────────────────────────────┘
*/
using System;
namespace Model
{
	/// <summary>
	/// R_ProductPaper:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class R_ProductPaper
	{
		public R_ProductPaper()
		{}
		#region Model
		private int _standid;
		private string _standcode;
		private int _productid;
		private int  _ordernumber;
		private int  _status;
		private string _remark;
		private int  _b1;
		private int  _b2;
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
		public string StandCode
		{
			set{ _standcode=value;}
			get{return _standcode;}
		}
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
		public int  OrderNumber
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
		public int  b2
		{
			set{ _b2=value;}
			get{return _b2;}
		}

        public static int InserData(R_ProductPaper rpp)
        {
            if (rpp != null)
            {
                return DataSource.ORMHelper.InsertModel<R_ProductPaper>(rpp);
            }
            return 0;
        }
		#endregion Model

	}
}

