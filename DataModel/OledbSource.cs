/*----------------------------------------------------------------
 * 作者：谭小峰
 * 时间：2010-10-29
 * ----------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.Text;
using System.Configuration;
using System.Data.OleDb;
using System.Data;

namespace DataSource
{
    /// <summary>
    /// OLEDB数据源
    /// </summary>
    public sealed class OledbSource : IDataSourceType, IDisposable
    {
        #region 字段
        /// <summary>
        /// 是否已开始数据库事务处理
        /// </summary>
        private bool _begin = false;
        /// <summary>
        /// IDbConnection对象（包装的SqlConnection对象）
        /// </summary>
        private OleDbConnection _connection;
        /// <summary>
        /// IDbTransaction对象（包装的SqlTransaction对象）
        /// </summary>
        private OleDbTransaction _transaction;
        /// <summary>
        /// 静态全局（SQLServerSource数据源）实例连接字符串对象；
        /// </summary>
        private static string _globalconnectionstring = string.Empty;

        #endregion

        #region 属性
        /// <summary>
        /// 获取，静态全局SQLServerSource数据源实例连接字符串对象；
        /// </summary>
        public static string GlobalConnectionString
        {
            get { return _globalconnectionstring; }
        }
        /// <summary>
        /// 获取或设置本次执行的数据源的连接字符串
        /// </summary>
        public string ConnectionString
        {
            get { return _connection.ConnectionString; }
            set { _connection.ConnectionString = value; }
        }
        /// <summary>
        /// 获取包装的SqlTransaction对象
        /// </summary>
        public OleDbTransaction SqlTransaction
        {
            get { return _transaction; }
        }
        #endregion

        #region 构造函数
        /// <summary>
        /// 静态构造函数。
        /// </summary>
        static OledbSource()
        {
            //设置全局（SQLServerSource实例）对象的默认连接字符串
            _globalconnectionstring = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        }
        /// <summary>
        ///默认实例构造函数
        /// </summary>
        public OledbSource()
        {
            _connection = new OleDbConnection(_globalconnectionstring);
        }
        /// <summary>
        /// 重载构造函数，使用指定连接字符串来初始化 CommandLib.Data.SQLServerSource  类的新实例。默认所有的SQLServerSource实例均使用
        /// 配置文件中的SQLServerConnectionString类型的连接字符串。
        /// </summary>
        /// <param name="connectionstring">连接字符串</param>
        public OledbSource(string connectionstring)
        {
            _connection = new OleDbConnection(connectionstring);
        }
        #endregion

        #region 实例方法
        /// <summary>
        /// 开始数据库事务。
        /// </summary>
        public void BeginTransaction()
        {
            _begin = true;
            _connection.Open();
            _transaction = _connection.BeginTransaction();//新建数据源的事务对象
        }
        /// <summary>
        /// 提交事务处理。
        /// </summary>
        public void Commit()
        {
            _begin = false;
            _transaction.Commit();
            _transaction = null;//事务执行完毕全部清除（事务不是很常用不需要一直保留）
            _connection.Close();
        }
        /// <summary>
        /// 从挂起状态回滚事务。
        /// </summary>
        public void Rollback()
        {
            _begin = false;
            _transaction.Rollback();
            _transaction = null;//事务执行完毕全部清除（事务不是很常用不需要一直保留）
            _connection.Close();
        }
        /// <summary>
        ///  执行查询，并返回查询所返回的结果集DataSet。
        /// </summary>
        /// <param name="commandtext">命令文本</param>
        /// <returns>DataSet</returns>
        public DataSet ExecuteDataSet(string commandtext)
        {
            return ExecuteDataSet(CommandType.Text, commandtext, null);
        }
        /// <summary>
        /// 执行查询，并返回查询所返回的结果集DataSet。
        /// </summary>
        /// <param name="commandtype">指定如何解释命令字符串</param>
        /// <param name="commandtext">命令文本</param>
        /// <param name="parameter">IDbDataParameter参数列表</param>
        /// <returns>DataSet</returns>
        public DataSet ExecuteDataSet(CommandType commandtype, string commandtext, params IDataParameter[] parameter)
        {
            if (_connection.State == ConnectionState.Closed)
                _connection.Open();
            OleDbCommand commmand = InitSqlCommand(commandtype, commandtext, parameter);
            OleDbDataAdapter adapter = new OleDbDataAdapter(commmand);
            DataSet ds = new DataSet();
            adapter.Fill(ds);
            return ds;
        }
        /// <summary>
        /// 对连接执行 Transact-SQL 语句并返回受影响的行数。
        /// </summary>
        /// <param name="cmdText">命令文本</param>
        /// <returns>受影响的行数</returns>
        public int ExecuteNonQuery(string cmdText)
        {
            return ExecuteNonQuery(CommandType.Text, cmdText, null);
        }
        /// <summary>
        /// 对连接执行 Transact-SQL 语句并返回受影响的行数。
        /// </summary>
        /// <param name="commandtype">IDbConnection对象</param>
        /// <param name="commandtext">指定如何解析命令字符串</param>
        /// <param name="parameter">命令文本</param>
        /// <returns>受影响的行数</returns>
        public int ExecuteNonQuery(CommandType commandtype, string commandtext, params IDataParameter[] parameter)
        {
            if (_connection.State == ConnectionState.Closed)
                _connection.Open();
            OleDbCommand command = InitSqlCommand(commandtype, commandtext, parameter);
            return command.ExecuteNonQuery();

        }
        /// <summary>
        /// 重载ExecuteNonQuery方法。
        /// </summary>
        /// <param name="conn">IDbConnection对象</param>
        /// <param name="cmdType">指定如何解析命令字符串</param>
        /// <param name="cmdText">命令文本</param>
        /// <param name="commandParameters">IDbDataParameter参数列表</param>
        /// <returns>受影响的行数</returns>
        public int ExecuteNonQuery(IDbConnection conn, CommandType cmdType, string cmdText, params IDataParameter[] parameter)
        {
            OleDbCommand command = InitSqlCommand(cmdType, cmdText, parameter);
            command.Connection = (conn as OleDbConnection);
            return command.ExecuteNonQuery();

        }
        /// <summary>
        /// 重载ExecuteNonQuery方法。以事务的方式执行
        /// </summary>
        /// <param name="trans">IDbTransaction对象。</param>
        /// <param name="cmdType">指定如何解析命令字符串。</param>
        /// <param name="cmdText">命令文本。</param>
        /// <param name="commandParameters">IDbDataParameter参数列表。</param>
        /// <returns>受影响的行数。</returns>
        public int ExecuteNonQuery(IDbTransaction trans, CommandType cmdType, string cmdText, params IDataParameter[] parameter)
        {
            OleDbCommand command = InitSqlCommand(cmdType, cmdText, parameter);
            command.Transaction = (trans as OleDbTransaction);
            return command.ExecuteNonQuery();
        }
        /// <summary>
        /// 将 System.Data.SqlClient.SqlCommand.CommandText 发送到
        /// System.Data.SqlClient.SqlCommand.Connection 并生成一个 System.Data.SqlClient.SqlDataReader。
        /// </summary>
        /// <param name="cmdText">执行的命令文本</param>
        /// <returns>IDataReader对象</returns>
        public IDataReader ExecuteReader(string cmdText)
        {
            return ExecuteReader(CommandType.Text, cmdText, null);
        }
        /// <summary>
        /// 将 System.Data.SqlClient.SqlCommand.CommandText 发送到
        /// System.Data.SqlClient.SqlCommand.Connection 并生成一个 System.Data.SqlClient.SqlDataReader。
        /// </summary>
        /// <param name="cmdType">指定如何解析命令字符串</param>
        /// <param name="cmdText">命令文本</param>
        /// <param name="commandParameters">IDataParameter参数列表</param>
        /// <returns>IDataReader对象</returns>
        public IDataReader ExecuteReader(CommandType cmdType, string cmdText, params IDataParameter[] parameter)
        {
            OleDbCommand command = InitSqlCommand(cmdType, cmdText, parameter);
            return command.ExecuteReader();
        }
        /// <summary>
        /// 执行查询，并返回查询所返回的结果集中第一行的第一列。忽略其他列或行。
        /// </summary>
        /// <param name="cmdText">命令文本</param>
        /// <returns>结果集中第一行的第一列；如果结果集为空，则为空引用（在 Visual Basic 中为 Nothing）</returns>
        public object ExecuteScalar(string cmdText)
        {
            return ExecuteScalar(CommandType.Text, cmdText, null);
        }
        /// <summary>
        ///  执行查询，并返回查询所返回的结果集中第一行的第一列。忽略其他列或行。
        /// </summary>
        /// <param name="cmdType">指定如何解析命令字符串</param>
        /// <param name="cmdText">命令文本</param>
        /// <param name="commandParameters">IDataParameter参数列表</param>
        /// <returns>结果集中第一行的第一列；如果结果集为空，则为空引用（在 Visual Basic 中为 Nothing）。</returns>
        public object ExecuteScalar(CommandType cmdType, string cmdText, params IDataParameter[] parameter)
        {
            OleDbCommand command = InitSqlCommand(cmdType, cmdText, parameter);
            return command.ExecuteScalar();
        }
        /// <summary>
        /// 执行查询，并返回查询所返回的结果集DataTable。
        /// </summary>
        /// <param name="cmdText">命令文本</param>
        /// <returns>DataTable</returns>
        public DataTable ExecuteTable(string cmdText)
        {
            return ExecuteTable(CommandType.Text, cmdText, null);
        }
        /// <summary>
        ///执行查询，并返回查询所返回的结果集DataTable。
        /// </summary>
        /// <param name="cmdType">指定如何解析命令字符串</param>
        /// <param name="cmdText">命令文本</param>
        /// <param name="commandParameters">IDataParameter参数列表</param>
        /// <returns>DataTable</returns>
        public DataTable ExecuteTable(CommandType cmdType, string cmdText, params IDataParameter[] parameter)
        {
            OleDbCommand command = InitSqlCommand(cmdType, cmdText, parameter);
            DataTable resulttb = new DataTable();
            OleDbDataAdapter adapter = new OleDbDataAdapter(command);
            adapter.Fill(resulttb);
            return resulttb;
        }
        /// <summary>
        /// 私有方法实现内部类的SqlCommand的初始化
        /// </summary>
        /// <param name="commandtype">IDbConnection对象</param>
        /// <param name="commandtext">指定如何解析命令字符串</param>
        /// <param name="parameter">命令文本</param>
        /// <returns>SqlCommand</returns>
        private OleDbCommand InitSqlCommand(CommandType commandtype, string commandtext, params IDataParameter[] parameter)
        {
            OleDbCommand command = new OleDbCommand(commandtext, _connection);
            command.CommandType = commandtype;
            if (_transaction != null)
                command.Transaction = _transaction;
            if (parameter != null)
                command.Parameters.AddRange(parameter);
            return command;
        }

        public int InserTable(string TableName, DataTable SourceData)
        {
            return 0;
        }
        /// <summary>
        /// 关闭数据库连接。
        /// </summary>
        public void Close()
        {
            _connection.Close();
        }
        /// <summary>
        /// 执行与释放或重置非托管资源相关的应用程序定义的任务。
        /// </summary>
        public void Dispose()
        {
            _connection.Dispose();
        }
        #endregion
    }
}
