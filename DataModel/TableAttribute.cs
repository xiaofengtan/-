
using System;
using System.Collections.Generic;
using System.Text;

namespace DataSource
{
    /// <summary>
    /// 指定Model所对应的Table名称
    /// </summary>
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false, Inherited = false)]
    public class TableAttribute : Attribute
    {
        /// <summary>
        /// 表的名称
        /// </summary>
        private string _tablename = string.Empty;
        private bool _iscache = false;
        private string _nickname = string.Empty;
        private string _colname=string.Empty;
        /// <summary>
        /// 映射为表的名称
        /// </summary>
        public string TableName
        {
            get { return _tablename; }
            set { _tablename = value; }
        }

        public bool IsCahche
        {
            get { return _iscache; }
            set { _iscache = value; }
        }

        public string NickName
        {
            get { return _nickname; }
            set { _nickname = value; }
        }

        public string ColName
        {
            get
            {
                return _colname;
            }
            set
            {
                _colname = value;
            }
        }


        public TableAttribute()
        {
        }
    }
}
