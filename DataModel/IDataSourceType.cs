/*----------------------------------------------------------------
 * 作者：谭小峰
 * 时间：2010-10-29
 * ----------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace DataSource
{
    /// <summary>
    /// 通用数据源类型接口，
    /// 确定每种数据源必须实现基本的对IDbConnection，IDbCommand，IDbTransaction 三者的包装；
    /// </summary>
    public interface IDataSourceType
    {
        #region 属性
        /// <summary>
        /// 获取或设置数据源连接字符串。
        /// </summary>
        string ConnectionString { get; set; }
        #endregion
        /// <summary>
        /// 开始数据库事务。
        /// </summary>
        void BeginTransaction();
        /// <summary>
        /// 提交事务处理。
        /// </summary>
        void Commit();
        /// <summary>
        /// 从挂起状态回滚事务。
        /// </summary>
        void Rollback();
        /// <summary>
        /// 执行查询，并返回查询所返回的结果集DataSet。
        /// </summary>
        /// <param name="cmdText">要执行的命令文本</param>
        /// <returns>DataSet</returns>
        DataSet ExecuteDataSet(string commandtext);
        /// <summary>
        /// 执行查询，并返回查询所返回的结果集DataSet。
        /// </summary>
        /// <param name="commandtype"> 指定如何解释命令字符串。</param>
        /// <param name="commandtext">命令文本</param>
        /// <param name="parameter">IDbDataParameter参数列表</param>
        /// <returns>DataSet</returns>
        DataSet ExecuteDataSet(CommandType commandtype, string commandtext, params IDataParameter[] parameter);
        /// <summary>
        /// 对连接执行 Transact-SQL 语句并返回受影响的行数。
        /// </summary>
        /// <param name="cmdText">命令文本</param>
        /// <returns>受影响的行数</returns>
        int ExecuteNonQuery(string cmdText);
        /// <summary>
        /// 对连接执行 Transact-SQL 语句并返回受影响的行数。
        /// </summary>
        /// <param name="commandtype">指定如何解析命令字符串</param>
        /// <param name="commandtext">命令文本</param>
        /// <param name="parameter">IDbDataParameter参数列表</param>
        /// <returns>受影响的行数</returns>
        int ExecuteNonQuery(CommandType commandtype, string commandtext, params IDataParameter[] parameter);
        /// <summary>
        /// 对连接执行 Transact-SQL 语句并返回受影响的行数。
        /// </summary>
        /// <param name="conn">IDbConnection对象</param>
        /// <param name="cmdType">指定如何解析命令字符串</param>
        /// <param name="cmdText">命令文本</param>
        /// <param name="commandParameters">IDbDataParameter参数列表</param>
        /// <returns>受影响的行数</returns>
        int ExecuteNonQuery(IDbConnection conn, CommandType cmdType, string cmdText, params IDataParameter[] parameter);
        /// <summary>
        ///对连接执行 Transact-SQL 语句并返回受影响的行数。已事务的方式执行
        /// </summary>
        /// <param name="trans">IDbTransaction对象。</param>
        /// <param name="cmdType">指定如何解析命令字符串。</param>
        /// <param name="cmdText">命令文本。</param>
        /// <param name="commandParameters">IDbDataParameter参数列表。</param>
        /// <returns>受影响的行数。</returns>
        int ExecuteNonQuery(IDbTransaction trans, CommandType cmdType, string cmdText, params IDataParameter[] parameter);
        /// <summary>
        /// 将 System.Data.SqlClient.SqlCommand.CommandText 发送到
        /// System.Data.SqlClient.SqlCommand.Connection 并生成一个 System.Data.SqlClient.SqlDataReader。
        /// </summary>
        /// <param name="cmdText">执行的命令文本</param>
        /// <returns>IDataReader对象</returns>
        IDataReader ExecuteReader(string cmdText);
        /// <summary>
        /// 将 System.Data.SqlClient.SqlCommand.CommandText 发送到
        /// System.Data.SqlClient.SqlCommand.Connection 并生成一个 System.Data.SqlClient.SqlDataReader。
        /// </summary>
        /// <param name="cmdType">指定如何解析命令字符串</param>
        /// <param name="cmdText">命令文本</param>
        /// <param name="commandParameters">IDataParameter参数列表</param>
        /// <returns>IDataReader对象</returns>
        IDataReader ExecuteReader(CommandType cmdType, string cmdText, params IDataParameter[] parameter);
        /// <summary>
        /// 执行查询，并返回查询所返回的结果集中第一行的第一列。忽略其他列或行。
        /// </summary>
        /// <param name="cmdText">命令文本</param>
        /// <returns>结果集中第一行的第一列；如果结果集为空，则为空引用（在 Visual Basic 中为 Nothing）</returns>
        object ExecuteScalar(string cmdText);
        /// <summary>
        ///  执行查询，并返回查询所返回的结果集中第一行的第一列。忽略其他列或行。
        /// </summary>
        /// <param name="cmdType">指定如何解析命令字符串</param>
        /// <param name="cmdText">命令文本</param>
        /// <param name="commandParameters">IDataParameter参数列表</param>
        /// <returns>结果集中第一行的第一列；如果结果集为空，则为空引用（在 Visual Basic 中为 Nothing）。</returns>
        object ExecuteScalar(CommandType cmdType, string cmdText, params IDataParameter[] parameter);
        /// <summary>
        /// 执行查询，并返回查询所返回的结果集DataTable。
        /// </summary>
        /// <param name="cmdText">命令文本</param>
        /// <returns>DataTable</returns>
        DataTable ExecuteTable(string cmdText);
        /// <summary>
        ///执行查询，并返回查询所返回的结果集DataTable。
        /// </summary>
        /// <param name="cmdType">指定如何解析命令字符串</param>
        /// <param name="cmdText">命令文本</param>
        /// <param name="commandParameters">IDataParameter参数列表</param>
        /// <returns>DataTable</returns>
        DataTable ExecuteTable(CommandType cmdType, string cmdText, params IDataParameter[] parameter);

        int InserTable(string TableName, DataTable SourceData);
        /// <summary>
        /// 关闭数据库连接。
        /// </summary>
        void Close();
        /// <summary>
        /// 执行与释放或重置非托管资源相关的应用程序定义的任务。
        /// </summary>
        void Dispose();
    }
}