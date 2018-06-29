
using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data.OleDb;
using System.Data;
using System.Data.OracleClient;

namespace DataSource
{
    /// <summary>
    /// 通用数据源对象（IDataSourceType）参数化类型工厂，统一生成当前数据源对象参数类型对象；
    /// </summary>
    public static class IDataParameterFactory
    {
        /// <summary>
        /// 用参数名称和参数的值新建单个IDataParameter接口对象
        /// </summary>
        /// <param name="parametername">要映射的参数的名称</param>
        /// <param name="parametervalue"> 一个 System.Object，它是 System.Data.IDataParameter实例的值。</param>
        /// <returns>IDataParameter</returns>
        public static IDataParameter CreateParameterSingle(string parametername, object parametervalue)
        {
            switch (IDataSourceTypeFactory.DataSourceType)
            {
                case DataSourceType.Access: OleDbParameter oledbparam = new OleDbParameter(parametername, parametervalue);
                    return oledbparam;
                case DataSourceType.Oracl: OracleParameter oracleparam = new OracleParameter(parametername, parametervalue);
                    return oracleparam;
                case DataSourceType.SqlServer: SqlParameter sqlparam = new SqlParameter(parametername, parametervalue);
                    return sqlparam;
                default: throw new Exception("来自DataSource.IDataParameterFactory错误:构建IDataParameter时发生错误");
            }
        }
        /// <summary>
        /// 参数名称与参数值键值对新建IDataParameter集合List
        /// </summary>
        /// <param name="parametername">参数名称集合</param>
        /// <param name="parametervalue">参数值集合</param>
        /// <returns>IDataParameter集合</returns>
        public static List<IDataParameter> CreateParameterMore(List<string> parametername, List<object> parametervalue)
        {
            List<IDataParameter> resultlist = new List<IDataParameter>();
            if (parametername.Count != parametervalue.Count)
                throw new Exception("来自DataSource.IDataParameterFactory错误:构建IDataParameter集合时，参数名称与参数值的集合必须成对");
            for (int i = 0; i < parametername.Count; i++)
            {
                if (parametername[i] != null)
                {
                    resultlist.Add(CreateParameterSingle(parametername[i], parametervalue[i]));
                }
                else
                {
                    resultlist.Add(CreateParameterSingle(parametername[i],DBNull.Value));
                }
            }
            return resultlist;
        }
    }
}
