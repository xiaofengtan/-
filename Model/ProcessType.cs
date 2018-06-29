/**  版本信息模板在安装目录下，可自行修改。
* ProcessType.cs
*
* 功 能： N/A
* 类 名： ProcessType
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2017-05-02 16:31:50   N/A    初版
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
	/// ProcessType:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
    [DataSource.Table(IsCahche = true, NickName = "工艺类型表", TableName = "ProcessType")]
	public partial class ProcessType
	{
        private static int[,] Product_ProcessType = { { 0, 0, 0, 0, 4, 5, 6, 7, 8, 9 }, { 0, 0, 0, 0, 4, 5, 6, 0, 0, 0 }, { 0, 0, 0, 3, 4, 5, 6, 0, 0, 9 } };
        public ProcessType()
		{}
		#region Model
		private int _typeid;
		private string _typename;
		private int  _mark;
		private int  _status;
		private string _remark;
		private int  _b1;
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
		public string TypeName
		{
			set{ _typename=value;}
			get{return _typename;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int  Mark
		{
			set{ _mark=value;}
			get{return _mark;}
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
        private static DataTable _alldata;
        private static DataTable AllData
        {
            get
            {
                if (_alldata == null|| LastTime.AddSeconds(Common.DataTimeOut)<DateTime.Now)
                {
                    _alldata= DataSource.ORMHelper.GetDataTable<ProcessType>("Status='1'");
                    LastTime = DateTime.Now;
                }
                return _alldata;
            }
        }
        private static DateTime LastTime;
        public static DataTable GetDataTable()
        {
            return AllData;
        }

        public static List<ProcessType> GetDataList()
        {
            DataTable dt = GetDataTable();
            if (dt != null)
            {
                return DataSource.ORMHelper.TbToModelList<ProcessType>(dt);
            }
            return null;
        }

        public static List<NameType> GetNameList()
        {
           return  Model.NameType.GetNameTypeListDataTable(GetDataTable(), 0, 1);
        }
        public static List<NameType> GetNameList(int productid)
        {
            int pid = productid;
            if (pid > 2)
                pid = 2;
            List<NameType> result = new List<NameType>();
            for (int i = 1; i < 10; i++)
            {
                int id = Product_ProcessType[pid, i];
                if (id > 0)
                {
                    NameType nt = new NameType();
                    ProcessType pt = GetDataById(id);
                    if (pt != null)
                    {
                        nt.Id = pt.TypeId;
                        nt.Name = pt.TypeName;
                        result.Add(nt);
                    }
                }
            }
            if (result.Count > 0)
                return result;
            return null;
        }


        public static ProcessType GetDataById(int id)
        {
            DataRow[] drs = AllData.Select("TypeId='" + id.ToString() + "'");
            if (drs.Length > 0)
            {
                return DataSource.ORMHelper.RowToModel<ProcessType>(drs[0]);
            }
            return null;
        }

	}
}

