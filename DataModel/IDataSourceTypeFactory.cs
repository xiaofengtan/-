
using System;
using System.Collections.Generic;
using System.Text;
using System.Configuration;

namespace DataSource
{
    /// <summary>
    /// 数据源类型（IDataSourceType），静态类工厂（该工厂根据App.config中appSettings配置节中DataSourceType节点定义的默认数据源类型），
    /// 新的数据源（IDataSourceType）对象是根据配置文件来建立的；
    /// </summary>
    public static class IDataSourceTypeFactory
    {
        /// <summary>
        /// 数据源类型，全局数据源类型
        /// </summary>
        private static DataSourceType _datasourcetype;
        /// <summary>
        /// 获取数据源类型，该类型确定应用程序上下文是用的什么类型的数据源（SqlServer,Oracl,Oledb）
        /// </summary>
        public static DataSourceType DataSourceType
        {
            get { return _datasourcetype; }
        }
        /// <summary>
        /// 静态构造函数，初始化应用程序上下文数据源
        /// </summary>
        static IDataSourceTypeFactory()
        {
            string typestring = ConfigurationManager.AppSettings["DataSourceType"];//数据源类型字符串
            switch (typestring)
            {
                case "SqlServer": _datasourcetype = DataSourceType.SqlServer;//SqlServer数据源
                    break;
                case "Oracl": _datasourcetype = DataSourceType.Oracl;//Oracl数据源
                    break;
                case "Access": _datasourcetype = DataSourceType.Access; //OLEDB数据源
                    break;
            }
        }
        /// <summary>
        /// 获取默认数据源操作对象，没有指定任何连接字符串
        /// </summary>
        /// <returns>IDataSourceType</returns>
        public static IDataSourceType Create()
        {
            if (_datasourcetype == DataSourceType.SqlServer)
                return new SQLServerSource();
            else if (_datasourcetype == DataSourceType.Oracl)
                return new OraclSource();
            else if (_datasourcetype == DataSourceType.Access)
                return new OledbSource();
            throw new Exception("来自DataSource.DataSourceTypeFactory错误:配置文件中的数据源类型不存在");
        }
        /// <summary>
        /// 用指定的数据库连接字符串，获取默认数据源操作对象
        /// </summary>
        /// <param name="connectionstring">数据库连接字符串</param>
        /// <returns>IDataSourceType</returns>
        public static IDataSourceType Create(string connectionstring)
        {
            if (_datasourcetype == DataSourceType.SqlServer)
                return new SQLServerSource(connectionstring);
            else if (_datasourcetype == DataSourceType.Oracl)
                return new OraclSource(connectionstring);
            else if (_datasourcetype == DataSourceType.Access)
                return new OledbSource(connectionstring);
            throw new Exception("来自DataSource.DataSourceTypeFactory错误:配置文件中的数据源类型不存在");
        }
        /// <summary>
        /// 根据数据源类型枚举，获取数据源操作对象
        /// </summary>
        /// <param name="type">数据源类型DataSourceType枚举值</param>
        /// <returns>IDataSourceType</returns>
        public static IDataSourceType Create(DataSourceType type)
        {
            switch (type)
            {
                case DataSourceType.SqlServer: return new SQLServerSource();
                case DataSourceType.Access: return new OledbSource();
                case DataSourceType.Oracl: return new OledbSource();
            }
            throw new Exception("来自DataSource.DataSourceTypeFactory错误:没有该数据源操作对象");
        }
        /// <summary>
        /// 根据数据源类型枚举和指定数据库连接字符串，获取数据源操作对象
        /// </summary>
        /// <param name="type">数据源类型DataSourceType枚举值</param>
        /// <param name="connectionstring">数据库连接字符串</param>
        /// <returns>IDataSourceType</returns>
        public static IDataSourceType Create(DataSourceType type, string connectionstring)
        {
            switch (type)
            {
                case DataSourceType.SqlServer: return new SQLServerSource(connectionstring);
                case DataSourceType.Access: return new OledbSource(connectionstring);
                case DataSourceType.Oracl: return new OraclSource(connectionstring);
            }
            throw new Exception("来自DataSource.DataSourceTypeFactory错误:没有该数据源操作对象");
        }
    }
}
