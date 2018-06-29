/**  版本信息模板在安装目录下，可自行修改。
* Paper_Type.cs
*
* 功 能： N/A
* 类 名： Paper_Type
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2017-05-02 16:31:43   N/A    初版
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
	/// Paper_Type:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
    [DataSource.Table(IsCahche = true, NickName = "纸张类型表", TableName = "Paper_Type")]
	public partial class Paper_Type
	{
		public Paper_Type()
		{}
		#region Model
		private int _id;
		private string _typecode;
		private string _typename;
		private int _ordernnumber;
		private int  _status;
		private string _remark;
		private int  _b1;
		private string _b2;
		/// <summary>
		/// 
		/// </summary>
		public int Id
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string TypeCode
		{
			set{ _typecode=value;}
			get{return _typecode;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string TypeName
		{
			set{ _typename=value;}
			get{return _typename;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int OrderNnumber
		{
			set{ _ordernnumber=value;}
			get{return _ordernnumber;}
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
            return DataSource.ORMHelper.GetDataTable<Paper_Type>(where);
        }

        public static List<Paper_Type> GetDataList(string where)
        {
            DataTable dt = GetDataTable(where);
            if (dt != null)
            {
                return DataSource.ORMHelper.TbToModelList<Paper_Type>(dt);
            }
            return null;
        }

        public static List<NameType> GetDataNameList()
        {
            DataTable dt = GetDataTable("1=1");
            return NameType.GetNameTypeListDataTable(dt, 0, 2);

        }

	}
}

