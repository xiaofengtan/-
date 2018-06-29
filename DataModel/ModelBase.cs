using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace DataSource
{
    [Serializable]
    public class EntityBase<T>
        where T :class
    {
        public string TableName = "";

        public static  DataTable GetAllData()
        {
            DataTable dt = null;
            dt= ORMHelper.GetAllDataTable<T>();
            return dt;
        }
    }
}