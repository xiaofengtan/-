/**  版本信息模板在安装目录下，可自行修改。
* Process.cs
*
* 功 能： N/A
* 类 名： Process
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2017-05-02 16:31:45   N/A    初版
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
    /// Process:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    [DataSource.Table(TableName = "Process", NickName = "工艺表", IsCahche = false)]
    public partial class Process
    {
        public Process()
        { }
        #region Model
        private int _processid;
        private string _processname;
        private int _typeid;
        private string _processcode;
        private int _helpmark;
        private int _ordernumber;
        private int _areamarking;
        private int _quantitymarking;
        private int _detailedinformation;
        private decimal _extendratio;
        private int _minextendpaper;
        private int _maxparameter;
        private int _minparameter;
        private string _strparamerter;
        private int _mustnext;
        private int _materialmark;
        private int _parentid;
        private int _mode;
        private int _status;
        private string _remark;
        private int _b1;
        private string _b2;
        /// <summary>
        /// 
        /// </summary>
        [DataSource.Column(NickName = "编号")]
        public int ProcessId
        {
            set { _processid = value; }
            get { return _processid; }
        }
        /// <summary>
        /// 
        /// </summary>
        [DataSource.Column(NickName = "名称")]
        public string ProcessName
        {
            set { _processname = value; }
            get { return _processname; }
        }
        /// <summary>
        /// 
        /// </summary>
        [DataSource.Column(NickName = "类型ID")]
        public int TypeId
        {
            set { _typeid = value; }
            get { return _typeid; }
        }
        /// <summary>
        /// 
        /// </summary>
        [DataSource.Column(NickName = "编码")]
        public string ProcessCode
        {
            set { _processcode = value; }
            get { return _processcode; }
        }
        /// <summary>
        /// 
        /// </summary>
        [DataSource.Column(NickName = "助记码")]
        public int HelpMark
        {
            set { _helpmark = value; }
            get { return _helpmark; }
        }
        /// <summary>
        /// 
        /// </summary>
        [DataSource.Column(NickName = "序号")]
        public int OrderNumber
        {
            set { _ordernumber = value; }
            get { return _ordernumber; }
        }
        /// <summary>
        /// 
        /// </summary>
        [DataSource.Column(NickName = "面积标识")]
        public int AreaMarking
        {
            set { _areamarking = value; }
            get { return _areamarking; }
        }
        /// <summary>
        /// 
        /// </summary>
        [DataSource.Column(NickName = "数量标识")]
        public int QuantityMarking
        {
            set { _quantitymarking = value; }
            get { return _quantitymarking; }
        }
        /// <summary>
        /// 
        /// </summary>
        [DataSource.Column(NickName = "详细信息")]
        public int DetailedInformation
        {
            set { _detailedinformation = value; }
            get { return _detailedinformation; }
        }
        /// <summary>
        /// 
        /// </summary>
        [DataSource.Column(NickName = "放张率")]
        public decimal ExtendRatio
        {
            set { _extendratio = value; }
            get { return _extendratio; }
        }
        /// <summary>
        /// 
        /// </summary>
        [DataSource.Column(NickName = "最小放张数")]
        public int MinExtendPaper
        {
            set { _minextendpaper = value; }
            get { return _minextendpaper; }
        }
        /// <summary>
        /// 
        /// </summary>
        [DataSource.Column(NickName = "最大参数")]
        public int MaxParameter
        {
            set { _maxparameter = value; }
            get { return _maxparameter; }
        }
        /// <summary>
        /// 
        /// </summary>
        [DataSource.Column(NickName = "最小参数")]
        public int MinParameter
        {
            set { _minparameter = value; }
            get { return _minparameter; }
        }
        /// <summary>
        /// 
        /// </summary>
        [DataSource.Column(NickName = "参数串")]
        public string StrParamerter
        {
            set { _strparamerter = value; }
            get { return _strparamerter; }
        }
        /// <summary>
        /// 
        /// </summary>
        [DataSource.Column(NickName = "连带工艺")]
        public int MustNext
        {
            set { _mustnext = value; }
            get { return _mustnext; }
        }
        /// <summary>
        /// 
        /// </summary>
        [DataSource.Column(NickName = "材料标识")]
        public int MaterialMark
        {
            set { _materialmark = value; }
            get { return _materialmark; }
        }
        /// <summary>
        /// 
        /// </summary>
        [DataSource.Column(NickName = "父类型")]
        public int ParentId
        {
            set { _parentid = value; }
            get { return _parentid; }
        }
        /// <summary>
        /// 
        /// </summary>

        [DataSource.Column(NickName = "计量模式")]
        public int Mode
        {
            set { _mode = value; }
            get { return _mode; }
        }
        /// <summary>
        /// 
        /// </summary>
        [DataSource.Column(NickName = "状态")]
        public int Status
        {
            set { _status = value; }
            get { return _status; }
        }
        /// <summary>
        /// 
        /// </summary>
        [DataSource.Column(NickName = "备注")]
        public string Remark
        {
            set { _remark = value; }
            get { return _remark; }
        }
        /// <summary>
        /// 
        /// </summary>
        [DataSource.Column(NickName = "数字备注")]
        public int b1
        {
            set { _b1 = value; }
            get { return _b1; }
        }
        /// <summary>
        /// 
        /// </summary>
        [DataSource.Column(NickName = "文字备注")]
        public string b2
        {
            set { _b2 = value; }
            get { return _b2; }
        }
        #endregion Model

        private static int[,] Product_ProcessId = { { 0, 0, 0, 0, 0 }, { 0, 0, 0, 0, 0 }, { 0, 0, 0, 0, 0 }, { 0, 0, 0, 0, 0 }, { 27, 0, 0, 0, 0 }, { 28, 0, 0, 0, 0 }, { 0, 0, 0, 0, 0 } };
        private static DataTable _alldata;
        private static DataTable AllData
        {
            get
            {
                if (_alldata == null || LastTime.AddSeconds(Common.DataTimeOut) < DateTime.Now)
                {
                    _alldata = DataSource.ORMHelper.GetDataTable<Process>("1=1");
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

        public static List<Process> GetDataList()
        {
            DataTable dt = GetDataTable();
            if (dt != null)
            {
                return DataSource.ORMHelper.TbToModelList<Process>(dt);
            }
            return null;
        }
        public static List<NameType> GetProductProcess(int productid)
        {
            if (productid > 6)
                productid = 6;
            List<Process> Allprocess = GetDataList();
            List<NameType> result = new List<NameType>();
            for (int i = 0; i < 5; i++)
            {
                int pid = Product_ProcessId[productid , i];
                if (pid > 0)
                {
                    for (int j = 0; j < Allprocess.Count; j++)
                        if (Allprocess[j].ProcessId == pid)
                        {
                            NameType nt = new NameType(Allprocess[j].ProcessId, Allprocess[j].ProcessName);
                            result.Add(nt);
                            break;
                        }
                }
            }
            if (result.Count > 0)
                return result;
            return null;
        }
        public static Process GetDataById(int id)
        {
            DataRow[] drs = AllData.Select("ProcessId='" + id.ToString() + "'");
            if (drs.Length > 0)
            {
                return DataSource.ORMHelper.RowToModel<Process>(drs[0]);
            }
            return null;
        }
        public static List<Process> GetDataByType(int Typeid)
        {
            DataRow[] drs = AllData.Select("TypeId='" + Typeid.ToString() + "'");
            if (drs.Length > 0)
            {
                DataTable dt=AllData.Clone();
                for(int i=0;i<drs.Length;i++)
                    dt.ImportRow(drs[i]);
                return DataSource.ORMHelper.TbToModelList<Process>(dt);
            }
            return null;
        }

        public static List<NameType> GetNameListByTable(DataTable dt)
        {
            List<NameType> list=NameType.GetNameTypeListDataTable(dt, 0, 1);
            return list;
        }
        public static List<NameType> GetNameListByTypeId(int processtype)
        {
            List<Process> list = GetDataList();
            List<NameType> result = new List<NameType>();
            foreach (Process p in list)
            {
               
                if (p.TypeId == processtype&&p.Status>0)
                {
                    NameType nt = new NameType();
                    nt.Id = p.ProcessId;
                    nt.Name = p.ProcessName;
                    result.Add(nt);
                }
            }
            if (result.Count > 0)
                return result;
            else
                return null;
        }
    }
}

