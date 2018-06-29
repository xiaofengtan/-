/*----------------------------------------------------------------
 * 作者：谭小峰
 * 时间：2010-10-29
 * 描述：ORM模型的实现类，该类的主要目的实现方便的数据库表的增、删、该、查与实体之间的映射关系
 * 将对表的操作利用统一的Model实体对象来操作
 * ----------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Data.OracleClient;
using System.Data.OleDb;
using System.Reflection;

namespace DataSource
{
    /// <summary>
    /// ORM模型静态帮助类
    /// </summary>
    public static class ORMHelper
    {
        #region 静态字段
        /// <summary>
        /// Model主键字典缓存
        /// </summary>
        private static Dictionary<string, List<string>> _pkcache = new Dictionary<string, List<string>>();

        private static Dictionary<string, List<string>> _columns = new Dictionary<string, List<string>>();

        public static int TimeOut = 3600;

       
        #endregion

        #region 静态属性
        /// <summary> 
        /// 获取，Model主键字段缓存
        /// </summary>
        public static Dictionary<string, List<string>> PKCache
        {
            get { return _pkcache; }
        }

        public static Dictionary<string, List<string>> ColumsName
        {
            get 
            {
                return _columns;
            }
        }
        private static List<TableAttribute> _alltable;
        public static List<TableAttribute> AllTableArrribute
        {
            get
            {
                if(_alltable==null)
                    _alltable=new List<TableAttribute>();
                return _alltable;
            }
        }

       
        #endregion

        #region 数据缓存

        private static List<DataTable> _cache;
        public static List<DataTable> Cache
        {
            get
            {
                if (_cache == null)
                {
                    _cache = new List<DataTable>();
                }
                return _cache;
            }
        }



        public static TableAttribute GetTableAttribute<T>()
        {
            Type type = typeof(T);
            TableAttribute tba;
            for (int i = 0; i < AllTableArrribute.Count; i++)
            {
                tba = AllTableArrribute[i];
                if (tba.TableName == type.Name)
                    return tba;
            }
            tba = type.GetCustomAttributes(false)[0] as TableAttribute;
            AllTableArrribute.Add(tba);
            return tba;
        }


        /// <summary>
        /// 获取某一个类型的所有记录；
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static DataTable GetAllDataTable<T>()
        {
            TableAttribute tba = GetTableAttribute<T>();
            string sqlcmd = "select * from [";
            string tablename = tba.TableName;
            sqlcmd += tablename+"]";
            bool iscache = tba.IsCahche;
            DataTable dt = GetTableByName(tablename);
            if (dt != null)
                return dt;
            else
            {
                dt = IDataSourceTypeFactory.Create().ExecuteTable(sqlcmd);
                if (dt != null && tba.IsCahche)
                {
                    dt.TableName = tablename;
                    Cache.Add(dt);
                    return dt;
                }
                return null;

            }
        }

        public static DataTable GetAllDataTableNew<T>()
        {
            TableAttribute tba = GetTableAttribute<T>();
            string sqlcmd = "select * from [";
            string tablename = tba.TableName;
            sqlcmd += tablename+"]";
            bool iscache = tba.IsCahche;
            DataTable dt = IDataSourceTypeFactory.Create().ExecuteTable(sqlcmd);
            if (dt != null && tba.IsCahche)
            {
                dt.TableName = tablename;
                DataTable dt1 = GetTableByName(tablename);
                if (dt1 != null)
                {
                    Cache.Remove(dt1);
                }
                Cache.Add(dt);
                return dt;
            }
            return null;
        }

        /// <summary>
        /// 获取某一个类型部分符合条件的所有记录；
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="Where">查询条件</param>
        /// <returns></returns>
        public static DataTable GetDataTable<T>(string Where)
        {
            TableAttribute tba = GetTableAttribute<T>();
            string sqlcmd = "select * from [";
            string tablename = tba.TableName;

            sqlcmd += tablename+"] where ";
           // sqlcmd += " where ";
            sqlcmd += Where;


            DataTable dt = new DataTable();
           
            dt = IDataSourceTypeFactory.Create().ExecuteTable(sqlcmd);
            if (dt != null)
            {
                return dt;
            }
            return null;
        }

        public static DataTable GetNumDataTable<T>(string Where,int num)
        {
            TableAttribute tba = GetTableAttribute<T>();
            string sqlcmd = "select TOP "+num.ToString()+" * from [";
            string tablename = tba.TableName;

            sqlcmd += tablename + "] where ";
            // sqlcmd += " where ";
            sqlcmd += Where;


            DataTable dt = new DataTable();

            dt = IDataSourceTypeFactory.Create().ExecuteTable(sqlcmd);
            if (dt != null)
            {
                return dt;
            }
            return null;
        }
        
        #endregion

        #region 静态方法
        /// <summary>
        /// 根据主键的值，获取单个对象；
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="id"></param>
        /// <returns></returns>
        public static T CreatModelById<T>(int id) where T : new()
        {
            Type resulttype = typeof(T);//获取实体的Type类型信息
            PropertyInfo[] propertycoll = resulttype.GetProperties();//获取所有属性列表
            string sqlwhere = "";
            foreach (var item in propertycoll)
            {
                object[] obj=item.GetCustomAttributes(false);
                 if (obj == null||obj.Length<=0)
                 {
                    throw new Exception("来自DataSource.ORMHelper错误:没有主键的实体无法进行初始化操作");
                 }
                
                ColumnAttribute crt = obj[0] as ColumnAttribute;
                if (crt.IsPrimary && item.PropertyType == typeof(int))
                {
                    sqlwhere += item.Name + "='";
                    sqlwhere += id.ToString() + "'";
                    break;
                }
            }
            if (sqlwhere.Length > 1)
            {
                
                DataTable dt = GetTableByName(resulttype.Name);
                DataRow dr = null;
                if (dt == null)
                {
                    //sqlwhere =  sqlwhere;
                    dt = GetDataTable<T>(sqlwhere);
                    if (dt != null)
                    {
                        if (dt.Rows.Count > 0)
                        {
                           dr = dt.Rows[0];
                            
                        }
                    }
                }
                else
                {
                    DataRow[] AllRows=dt.Select(sqlwhere);
                    dr = AllRows[0];
                }
                if (dr != null)
                {
                    return RowToModel<T>(dr);
                }
                
            }
            return default(T);
        }
       

        private static DataTable GetTableByName(string tablename)
        {
            for (int i = 0; i < Cache.Count-1; i++)
            {
                if (Cache[i].TableName == tablename)
                    return Cache[i];
            }
            return null;
 
        }
        /// <summary>
        /// 根据主键的值，获取单个对象；
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="id"></param>
        /// <returns></returns>
        public static T CreatModelById<T>(string id) where T : new()
        {
            Type resulttype = typeof(T);//获取实体的Type类型信息
            PropertyInfo[] propertycoll = resulttype.GetProperties();//获取所有属性列表
            string sqlwhere = "where ";
            foreach (var item in propertycoll)
            {
                ColumnAttribute crt = item.GetCustomAttributes(false)[0] as ColumnAttribute;
                if (crt.IsPrimary && item.PropertyType == typeof(string))
                {
                    sqlwhere += item.Name + "='";
                    sqlwhere += id + "'";
                    break;
                }
            }
            if (sqlwhere.Length > 6)
            {
                DataRow dr = GetDataTable<T>(sqlwhere).Rows[0];
                if (dr != null)
                {
                    return RowToModel<T>(dr);
                }
            }
            return default(T);
        }

        /// <summary>
        /// 根据数据行构造泛型实体
        /// </summary>
        /// <typeparam name="T">返回的实体类型</typeparam>
        /// <param name="row">数据行</param>
        /// <returns>已赋值的Model实体对象</returns>
        public static T RowToModel<T>(DataRow row) where T : new()
        {
            T result = new T();//实例化要返回的泛型实体
            Type resulttype = typeof(T);//获取实体的Type类型信息
            PropertyInfo[] propertycoll = resulttype.GetProperties();//获取所有属性列表
           
            foreach (var item in propertycoll)
            {
                //如果当前ROW中不存在于该MODEL实体对应的列名称
                if (!row.Table.Columns.Contains(item.Name))
                    continue;
                //判断属性是否可以为空类型
                //字符串类型
                if (item.PropertyType == typeof(string))
                    item.SetValue(result, row[item.Name] == DBNull.Value ? string.Empty : row[item.Name], null);
                //整型(不可空)
                else if (item.PropertyType == typeof(int))
                    item.SetValue(result, row[item.Name] == DBNull.Value ? 0 : int.Parse(row[item.Name].ToString()), null);
                //整型(可空)
                else if (item.PropertyType == typeof(int?))
                    item.SetValue(result, row[item.Name], null);
                //长整型(不可空)
                else if (item.PropertyType == typeof(long))
                    item.SetValue(result, row[item.Name] == DBNull.Value ? 0 : long.Parse(row[item.Name].ToString()), null);
                //长整型(可空)
                else if (item.PropertyType == typeof(long?))
                    item.SetValue(result, row[item.Name], null);
                //布尔值(不可空)
                else if (item.PropertyType == typeof(bool))
                    item.SetValue(result, row[item.Name] == DBNull.Value ? false : bool.Parse(row[item.Name].ToString()), null);
                //布尔值(可空)
                else if (item.PropertyType == typeof(bool?))
                    item.SetValue(result, row[item.Name], null);
                //时间(不可空)
                else if (item.PropertyType == typeof(DateTime))
                {
                    DateTime outtime;
                    string datetime = row[item.Name] != DBNull.Value ? row[item.Name].ToString() : string.Empty;
                    if (datetime.Length > 0)
                    {
                        DateTime.TryParse(datetime, out outtime);
                        item.SetValue(result, outtime, null);
                    }
                    else
                    {
                        item.SetValue(result, new DateTime(), null);
                    }
                }
                //时间(可空)
                else if (item.PropertyType == typeof(DateTime?))
                {
                    DateTime outtime;
                    string datetime = row[item.Name] != DBNull.Value ? row[item.Name].ToString() : string.Empty;
                    if (datetime.Length > 0)
                    {
                        DateTime.TryParse(datetime, out outtime);
                        item.SetValue(result, outtime, null);
                    }
                }
                //双精度(不可空)
                else if (item.PropertyType == typeof(double?))
                    item.SetValue(result, row[item.Name] == DBNull.Value ? 0 : row[item.Name], null);
                //双精度(可空)
                else if (item.PropertyType == typeof(double))
                    item.SetValue(result, row[item.Name], null);
                //十进制实数(不可空)
                else if (item.PropertyType == typeof(decimal?))
                    item.SetValue(result, row[item.Name] == DBNull.Value ? 0 : row[item.Name], null);
                //十进制实数(可空)
                else if (item.PropertyType == typeof(decimal))
                    item.SetValue(result,row[item.Name]==DBNull.Value?0:Convert.ToDecimal( row[item.Name].ToString()),null);
                else if (item.PropertyType == typeof(byte[]))
                {
                    if (row[item.Name] == DBNull.Value)
                    {
                        item.SetValue(result,null,null);
                    }
                    else
                    {
                        item.SetValue(result, row[item.Name],null);
                    }
                }
                else if(item.PropertyType==typeof(Guid))
                {
                    if (row[item.Name] == DBNull.Value)
                    {
                        row[item.Name] = Guid.NewGuid();
                    }
                    item.SetValue(result, row[item.Name], null);
                }
            }
            return result;
        }

        public static string GetColumnsName(Type t,string AttribName)
        {
            List<string> col = GetColumnsName(t);
            if (col != null)
            {
                Type resulttype = t;
                PropertyInfo[] propertycoll = resulttype.GetProperties();//获取所有属性列表
                List<string> colname = new List<string>();
                int index = 0;
                foreach (var item in propertycoll)
                {
                    object[] ca = item.GetCustomAttributes(false);
                    if (ca != null && ca.Length > 0)
                    {
                        ColumnAttribute ctr = ca[0] as ColumnAttribute;
                        string cn = item.Name;
                        if (cn == AttribName)
                            return col[index];
                    }
                    index++;
                    if (index > col.Count)
                    {
                        break;
                    }
                }
            }
            return string.Empty;
        }

        public static List<string> GetColumnsName(Type t)
        {
            List<string> NameList=new List<string>();
            if (ColumsName.TryGetValue(t.Name, out NameList))
                return NameList;
            else
            {
                Type resulttype = t;
                PropertyInfo[] propertycoll = resulttype.GetProperties();//获取所有属性列表
                List<string> colname = new List<string>();
                foreach (var item in propertycoll)
                {
                    object[] ca= item.GetCustomAttributes(false);
                    if (ca != null && ca.Length > 0)
                    {
                        ColumnAttribute ctr = ca[0] as ColumnAttribute;
                        string cn = item.Name;
                        if (ctr.NickName != string.Empty)
                            cn = ctr.NickName;
                        colname.Add(cn);
                    }
                    else
                    {
                        colname.Add(item.Name);
                    }
                }
                ColumsName.Add(resulttype.Name, colname);
                return colname;
            }
               
        }
        
        /// <summary>
        /// 根据数据表构造泛型实体集合
        /// </summary>
        /// <typeparam name="T">返回的实体类型</typeparam>
        /// <param name="tb">数据表</param>
        /// <returns>已赋值Model实体对象集合</returns>
        public static List<T> TbToModelList<T>(DataTable tb) where T : new()
        {
            List<T> resultlist = new List<T>(tb.Rows.Count);
            foreach (DataRow tr in tb.Rows)
            {
                resultlist.Add(RowToModel<T>(tr));
            }
            return resultlist;
        }
        /// <summary>
        /// 根据Model构造等价DataRow，该DataRow属于动态生成的DataTable架构
        /// </summary>
        /// <typeparam name="T">待构造的实体类型</typeparam>
        /// <param name="t">实体对象</param>
        /// <returns>已构造的DataRow</returns>
        public static DataRow ModelToRow<T>(T t) where T : new()
        {
            List<T> list = new List<T>();
            list.Add(t);
            return ModelListToTb<T>(list).Rows[0];
        }
        /// <summary>
        /// 根据Model集合构造等价的DataTable
        /// </summary>
        /// <typeparam name="T">待构造的实体类型</typeparam>
        /// <param name="t">实体对象集合</param>
        /// <returns>已构造的DataTable</returns>
        public static DataTable ModelListToTb<T>(IList<T> t) where T : new()
        {
            DataTable resulttb = new DataTable();
            Type type = typeof(T);
            //构造表的列
            foreach (PropertyInfo info in type.GetProperties())
            {
                resulttb.Columns.Add(info.Name, typeof(System.String));
            }
            //赋值
            foreach (T child in t)
            {
                DataRow row = resulttb.NewRow();
                foreach (PropertyInfo info in type.GetProperties())
                {
                    object v=info.GetValue(child, null);
                    if (v == null)
                    {
                        row[info.Name] = string.Empty;
                    }
                    else
                        row[info.Name] = v.ToString();
                }
                resulttb.Rows.Add(row);
            }
            return resulttb;
        }
        /// <summary>
        /// 根据Model实体添加一条表记录，
        /// </summary>
        /// <typeparam name="T">泛型实体类型</typeparam>
        /// <param name="t">实例</param>
        /// <returns>插入是否成功1：成功，0失败</returns>
        public static int InsertModel<T>(T t) where T : new()
        {
            return InsertModel<T>(t, null);
        }
        /// <summary>
        /// 根据Model实体IDataSourceType对象添加一条表记录
        /// </summary>
        /// <typeparam name="T">泛型实体类型</typeparam>
        /// <param name="t">实例</param>
        /// <param name="idatasource">IDataSourceType接口实例</param>
        /// <returns>插入是否成功1：成功，0失败</returns>
        public static int InsertModel<T>(T t, IDataSourceType idatasource) where T : new()
        {
            string sqlstring = string.Empty;
            List<IDataParameter> parame = (List<IDataParameter>)GetInsertModelParameterT_SQL<T>(t, out sqlstring);
            if (idatasource != null)
                return idatasource.ExecuteNonQuery(CommandType.Text, sqlstring, parame.ToArray());
            return IDataSourceTypeFactory.Create().ExecuteNonQuery(CommandType.Text, sqlstring, parame.ToArray());
        }

        public static int InsertModelId<T>(T t) where T : new()
        {
            return InsertModelId(t, null);
        }

        public static int InsertModelId<T>(T t, IDataSourceType idatasource) where T : new()
        {
            string sqlstring = string.Empty;
            List<IDataParameter> parame = (List<IDataParameter>)GetInsertModelParameterT_SQL<T>(t, out sqlstring);
            if (idatasource != null)
                return (int)idatasource.ExecuteScalar(CommandType.Text, sqlstring, parame.ToArray());
            return (int)IDataSourceTypeFactory.Create().ExecuteScalar(CommandType.Text, sqlstring, parame.ToArray());
        }
        /// <summary>
        /// 根据实体对象删除一条记录，该实体必须明确主键值才能删除记录；
        /// 如果该实体没有主键可自己编写SQL代码删除
        /// </summary>
        /// <typeparam name="T">要删除的表对应的实体对象</typeparam>
        /// <param name="t">Model实体</param>
        /// <returns>删除是否成功；1成功，0失败</returns>
        public static int DeleteModelById<T>(T t) where T : new()
        {
            return DeleteModelById<T>(t, null);
        }
        /// <summary>
        ///  根据实体对象和IDataSourceType对象删除一条记录，
        ///  该实体必须明确主键值才能删除记录；如果该实体没有主键可自己编写SQL代码删除；
        /// </summary>
        /// <typeparam name="T">要删除的表对应的实体对象</typeparam>
        /// <param name="t">Model实体</param>
        /// <param name="idatasource">IDataSourceType数据源类型对象</param>
        /// <returns>删除是否成功；1成功，0失败</returns>
        public static int DeleteModelById<T>(T t, IDataSourceType idatasource) where T : new()
        {
            string sqlstring;//保存要执行的T-SQL语句
            List<IDataParameter> paramlist = (List<IDataParameter>)GetDeleteModelParameterT_SQL<T>(t, out sqlstring);//获取利用Model删除时的语句和参数列表
            if (idatasource != null)
                return IDataSourceTypeFactory.Create().ExecuteNonQuery(CommandType.Text, sqlstring, paramlist.ToArray());
            return IDataSourceTypeFactory.Create().ExecuteNonQuery(CommandType.Text, sqlstring, paramlist.ToArray());
        }
        /// <summary>
        /// 获取实体执行删除时的T-SQL语句
        /// </summary>
        /// <typeparam name="T">泛型类型</typeparam>
        /// <param name="t">实体对象</param>
        /// <returns>生成的T-SQL语句</returns>
        public static string GetDeleteModelByIdT_SQL<T>(T t) where T : new()
        {
            Type type = typeof(T);
            string tbname = (type.GetCustomAttributes(typeof(DataSource.TableAttribute), false)[0] as DataSource.TableAttribute).TableName;
            StringBuilder sqlbuilder = new StringBuilder();
            sqlbuilder.AppendFormat("DELETE FROM {0} WHERE ", tbname);
            List<string> pklist = GetPKCache<T>(t);//获取该实体的主键
            PropertyInfo[] property = type.GetProperties();
            foreach (PropertyInfo info in property)
            {
                if ((info.GetValue(t, null) != null) && (pklist.Contains(info.Name)))
                {
                    sqlbuilder.AppendFormat("{0}='{1}'", info.Name, info.GetValue(t, null));
                }
            }
            return sqlbuilder.ToString();
        }
        /// <summary>
        /// 根据实体对象更新一条记录，该实体必须明确主键值才能更新记录
        /// </summary>
        /// <typeparam name="T">要更新的表对应的实体对象类型</typeparam>
        /// <param name="t">Model实体</param>
        /// <returns>更新是否成功；1成功，0失败</returns>
        public static int UpdateModelById<T>(T t) where T : new()
        {
            return UpdateModelById<T>(t, null);
        }


        
        /// <summary>
        /// 根据实体对象和IDataSourceType对象更新一条记录
        /// </summary>
        /// <typeparam name="T">要更新的表对应的实体对象类型</typeparam>
        /// <param name="t">Model实体</param>
        /// <param name="idatasource">IDataSourceType接口实例</param>
        /// <returns>更新是否成功；1成功，0失败</returns>
        public static int UpdateModelById<T>(T t, IDataSourceType idatasource) where T : new()
        {
            string sqlstring = string.Empty;
            List<IDataParameter> paramlist = (List<IDataParameter>)(GetUpdateModelParameterT_SQL<T>(t, out sqlstring));
            if (idatasource != null)
                return idatasource.ExecuteNonQuery(CommandType.Text, sqlstring, paramlist.ToArray());
            return DataSource.IDataSourceTypeFactory.Create().ExecuteNonQuery(CommandType.Text, sqlstring, paramlist.ToArray());
        }
        /// <summary>
        /// 根据实体主键获取实体全部信息，如果没有主键返回最上面一条记录实体
        /// </summary>
        /// <typeparam name="T">要构造的泛型实体类型</typeparam>
        /// <param name="t">Model类实体</param>
        /// <returns>填充完的实体对象</returns>
        public static T GetModelById<T>(T t) where T : new()
        {
            return GetModelById<T>(t, null);
        }
        /// <summary>
        /// 根据实体主键和IDataSourceType对象获取实体全部信息，如果没有主键返回最上面一条记录实体
        /// </summary>
        /// <typeparam name="T">要构造的泛型实体类型</typeparam>
        /// <param name="t">Model类实体</param>
        /// <param name="idatasource">IDataSourceType数据源类型对象</param>
        /// <returns>填充完的实体对象</returns>
        public static T GetModelById<T>(T t, IDataSourceType idatasource) where T : new()
        {
            Type type = typeof(T);
            object[] objattribute = type.GetCustomAttributes(typeof(DataSource.TableAttribute), false);
            string tablename = string.Empty;
            if (objattribute.Length > 0)
                tablename = (objattribute[0] as DataSource.TableAttribute).TableName;//根据表名称特性类获取表名称
            else
                tablename = type.Name;//否则默认以Model类的名称为表名
            List<string> pklist = GetPKCache<T>(t);//获取主键集合
            Dictionary<string, string> pkproperty = new Dictionary<string, string>(pklist.Count);//主键与主键的值字典
            //构建主键的参数字典用作生成主键参数使用
            foreach (var item in type.GetProperties())
            {
                if (pklist.Contains(item.Name))
                    pkproperty.Add(item.Name, item.GetValue(t, null).ToString());//主键属性不能为空，如果为空直接抛出异常
            }
            SqlParameter[] parameter = new SqlParameter[pklist.Count];//主键查询参数
            //构建主键参数
            for (int i = 0; i < pklist.Count; i++)
            {
                parameter[i] = new SqlParameter(string.Format("@{0}", pklist[i]), pkproperty[pklist[i]]);//自动生成主键与主键值的对应参数
            }
            StringBuilder Appsql = new StringBuilder();//封装SQL语句
            tablename = " [" + tablename + "] ";
            Appsql.AppendFormat("select top 1 *from {0} where 1=1", tablename);//如果不存在主键就默认选择第一条记录作为Model实体返回
            for (int i = 0; i < pklist.Count; i++)
            {
                Appsql.AppendFormat(" and {0} = @{0}", pklist[i]);//动态填充所有主键属性列
            }
            DataTable tb;
            if (idatasource == null)
            {
                tb = DataSource.IDataSourceTypeFactory.Create().ExecuteTable(CommandType.Text, Appsql.ToString(), parameter);
            }
            else
            {
                tb = idatasource.ExecuteTable(CommandType.Text, Appsql.ToString(), parameter);
            }
            if (tb.Rows.Count > 0)
                return RowToModel<T>(tb.Rows[0]);//生成实例
            return default(T);//返回指定类型的初始化对象
        }
        public static int ExeSql(string SqlCmd)
        {
            return IDataSourceTypeFactory.Create().ExecuteNonQuery(SqlCmd);
        }
        public static int InserTable(string TableName, DataTable dt)
        {
            return DataSource.IDataSourceTypeFactory.Create().InserTable(TableName, dt);
        }
        #endregion

        #region 静态内部方法
        /// <summary>
        /// 私有方法，获取利用实体删除表记录时的SQL语句和参数列表
        /// </summary>
        /// <typeparam name="T">要删除的表对应的实体类型</typeparam>
        /// <param name="t">Model实体</param>
        /// <param name="sql">需要保存生成后的SQL语句</param>
        /// <returns>参数列表</returns>
        private static IList<IDataParameter> GetDeleteModelParameterT_SQL<T>(T t, out string sql) where T : new()
        {
            StringBuilder sqlbuilder = new StringBuilder();//保存SQL语句
            string tablename = string.Empty;
            Type type = typeof(T);//获取类型信息
            object[] attribute = type.GetCustomAttributes(typeof(DataSource.TableAttribute), false);
            if (attribute.Length > 0)
            {
                tablename = (attribute[0] as DataSource.TableAttribute).TableName;//获取特性的表名
            }
            else
            {
                //如果没有用特性标记为表名称，默认用实体的名称作为表的名称
                tablename = type.Name;
            }
            tablename = " [" + tablename + "] ";
            List<string> Pklist = GetPKCache<T>(t);//获取该实体的所有主键列表
            if (Pklist.Count <= 0)
                throw new Exception("来自DataSource.ORMHelper错误:没有主键的实体无法进行删除操作");
            bool isand = true;//控制语句拼接的and条件
            //根据主键生成SQL语句
            foreach (string sub in Pklist)
            {
                if (isand)
                {
                    sqlbuilder.AppendFormat("{0}=@{0}", sub);
                }
                else
                {
                    sqlbuilder.AppendFormat("and {0}=@{0}", sub);
                }
            }
            sql = string.Format("DELETE FROM {0} WHERE {1}", tablename, sqlbuilder.ToString());
            return GetActionParameter<T>(t, TableActionType.Delete);
        }
        /// <summary>
        /// 私有方法，获取利用实体插入表记录时的SQL语句和参数列表
        /// </summary>
        /// <typeparam name="T">要插入的表对应的实体类型</typeparam>
        /// <param name="t">Model实体</param>
        /// <param name="sql">需要保存生成后的SQL语句</param>
        /// <returns>参数列表</returns>
        private static IList<IDataParameter> GetInsertModelParameterT_SQL<T>(T t, out string sql) where T : new()
        {
            string tablename = string.Empty;//要插入的表的名称
            StringBuilder fieldbuilder = new StringBuilder();//要插入的字段列表
            StringBuilder valuebuilder = new StringBuilder();//要插入的字段值
            Type type = typeof(T);
            bool flag = true;//分割拼接的T-SQL语句
            foreach (PropertyInfo info in type.GetProperties())
            {
                object[] columbute = info.GetCustomAttributes(typeof(DataSource.ColumnAttribute), false);
                if (columbute.Length > 0)
                {
                    if ((columbute[0] as DataSource.ColumnAttribute).IsIdentity)
                    {
                        continue;//如果是自增长就不处理这个属性
                    }
                }
                if (info.GetValue(t, null) != null)
                {
                    if (flag)
                    {
                        fieldbuilder.Append(info.Name);
                        valuebuilder.AppendFormat("@{0}", info.Name);
                        flag = false;
                    }
                    else
                    {
                        fieldbuilder.AppendFormat(",{0}", info.Name);
                        valuebuilder.AppendFormat(",@{0}", info.Name);
                    }
                }
            }
            object[] tbattribute = type.GetCustomAttributes(typeof(DataSource.TableAttribute), false);
            if (tbattribute.Length > 0)
            {
                tablename = (tbattribute[0] as DataSource.TableAttribute).TableName;//获取特性的表名
            }
            else
            {
                //如果没有用特性标记为表名称，默认用实体的名称作为表的名称
                tablename = type.Name;
            }
            tablename = " [" + tablename + "] ";
            sql = string.Format("INSERT INTO {0} ({1}) VALUES ({2})", tablename, fieldbuilder.ToString(), valuebuilder.ToString());
            return GetActionParameter<T>(t, TableActionType.Insert);
        }
        /// <summary>
        /// 私有方法，获取利用实体更新表记录时的SQL语句和参数列表
        /// </summary>
        /// <typeparam name="T">要更新的表对应的实体类型</typeparam>
        /// <param name="t">Model实体</param>
        /// <param name="sql">需要保存生成后的SQL语句</param>
        /// <returns>参数列表</returns>
        private static IList<IDataParameter> GetUpdateModelParameterT_SQL<T>(T t, out string sql) where T : new()
        {
            string tablename = string.Empty;
            StringBuilder pkbuilder = new StringBuilder();
            StringBuilder fieldbuilder = new StringBuilder();
            Type type = typeof(T);
            object[] attibute = type.GetCustomAttributes(typeof(DataSource.TableAttribute), false);
            if (attibute.Length > 0)
            {
                tablename = (attibute[0] as DataSource.TableAttribute).TableName;
            }
            else
            {
                tablename = type.Name;
            }
            tablename = " [" + tablename + "] ";
            foreach (PropertyInfo info in type.GetProperties())
            {
                if (info.GetValue(t, null) != null)
                {
                    object[] pkattibute = info.GetCustomAttributes(typeof(DataSource.ColumnAttribute), false);
                    if (pkattibute.Length > 0 && (pkattibute[0] as DataSource.ColumnAttribute).IsPrimary)
                    {
                        //主键特性标记该属性为表的主键
                        pkbuilder.AppendFormat("AND {0}=@{0}", info.Name);//主键列于占位符
                    }
                    else
                    {
                        fieldbuilder.AppendFormat("{0}=@{0},", info.Name);//设置列的赋值
                    }
                }
            }
            if (pkbuilder.Length <= 0)
                throw new Exception("来自DataSource.ORMHelper错误:没有主键的实体无法进行更新操作");
            sql = string.Format("UPDATE {0} SET {1} WHERE 1=1{2}", tablename, fieldbuilder.ToString().Substring(0, fieldbuilder.ToString().Length - 1), pkbuilder.ToString());
            return GetActionParameter<T>(t, TableActionType.Update);
        }
        /// <summary>
        /// 私有方法，用来提供以用Model实体来增加、删除、修改表记录时的参数列表
        /// </summary>
        /// <typeparam name="T">要执行的实体类型</typeparam>
        /// <param name="t">Model实体</param>
        /// <returns> 参数列表</returns>
        private static IList<IDataParameter> GetActionParameter<T>(T t, TableActionType action) where T : new()
        {
            Type type = typeof(T);
            List<IDataParameter> parlist = new List<IDataParameter>();
            foreach (PropertyInfo info in type.GetProperties())
            {
                if (action == TableActionType.Insert)
                {
                    object[] columbute = info.GetCustomAttributes(typeof(DataSource.ColumnAttribute), false);
                    if (columbute.Length > 0)
                    {
                        if ((columbute[0] as DataSource.ColumnAttribute).IsIdentity)
                        {
                            continue;//如果是自增长就不处理这个属性
                        }
                    }
                }
                object param = info.GetValue(t, null);
                if (param == null)
                    param = DBNull.Value;
                switch (IDataSourceTypeFactory.DataSourceType)
                {
                    case DataSourceType.SqlServer: parlist.Add(IDataParameterFactory.CreateParameterSingle(info.Name, param));
                        break;
                    case DataSourceType.Oracl: parlist.Add(IDataParameterFactory.CreateParameterSingle(info.Name, param));
                        break;
                    case DataSourceType.Access: parlist.Add(IDataParameterFactory.CreateParameterSingle(info.Name, param));
                        break;
                }
            }
            return parlist;
        }
        /// <summary>
        /// 私有方法，设置泛型实体类的主键字典
        /// </summary>
        /// <typeparam name="T">泛型实体类型</typeparam>
        /// <param name="t">实体</param>
        private static void SetPKCache<T>(T t) where T : new()
        {
            List<string> pklist = new List<string>();
            PropertyInfo[] propcoll = t.GetType().GetProperties();//获取该类型的所有属性
            foreach (var item in propcoll)
            {
                object[] objattribute = item.GetCustomAttributes(typeof(DataSource.ColumnAttribute), false);
                if (objattribute.Length > 0)
                    if ((objattribute[0] as DataSource.ColumnAttribute).IsPrimary)//如果该属性是用主键特性标记为主键的则添加为该类型的主键
                        pklist.Add(item.Name);
            }
            if (PKCache.ContainsKey(t.GetType().FullName))
                PKCache[t.GetType().FullName] = pklist;//设置新的主键集合
            else
                PKCache.Add(t.GetType().FullName, pklist);
        }
        /// <summary>
        /// 私有方法，获取泛型实体类的主键集合
        /// </summary>
        /// <typeparam name="T">泛型实体类型</typeparam>
        /// <param name="t">实体</param>
        /// <returns>字典集合</returns>
        private static List<string> GetPKCache<T>(T t) where T : new()
        {
            if (PKCache.Count <= 0)
                SetPKCache<T>(t);
            if (PKCache.ContainsKey(t.GetType().FullName))
                return PKCache[t.GetType().FullName];//直接返回
            SetPKCache<T>(t);
            if (PKCache.ContainsKey(t.GetType().FullName))
                return PKCache[t.GetType().FullName];//再次返回，如没有则说明该Model没有定义主键特性
            return null;
        }
        #endregion
       
    }
}
