using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace YouHoo.DataOperation
{
    public class DBSqlServer : IDisposable
    {
        //数据库连接字符串(web.config来配置)，可以动态更改connectionString支持多数据库.		
        private string connectionString;
        private SqlConnection conn;
        public DBSqlServer()
        {
            connectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        }

        public DBSqlServer(string str)
        {
            connectionString = str;
        }
        /// <summary>
        /// 创建连接数据库对象并打开数据库
        /// </summary>
        /// <returns></returns>
        public SqlConnection CreateConn()
        {
            return CreateConn(connectionString);
        }

        void IDisposable.Dispose()
        {
            if (conn != null && conn.State == ConnectionState.Open)
            {
                conn.Close();
                conn.Dispose();
                conn = null;
            }
        }

        /// <summary>
        /// 关闭联接
        /// </summary>
        public void Close()
        {
            if (conn != null && conn.State == ConnectionState.Open)
            {
                conn.Close();
            }
        }

        /// <summary>
        /// 创建连接数据库对象并打开数据库
        /// </summary>
        /// <returns></returns>
        public SqlConnection CreateConn(string connectionString)
        {
            conn = new SqlConnection(connectionString);
            conn.Open();
            return conn;
        }

        /// <summary>
        /// 输入参数
        /// </summary>
        /// <param name="ParamName">参数名</param>
        /// <param name="DbType">类型</param>
        /// <param name="Size">大小</param>
        /// <param name="Value">值</param>
        /// <returns>SqlParameter </returns>
        public SqlParameter MakeInParam(string ParamName, SqlDbType DbType, int Size, object Value)
        {
            return MakeParam(ParamName, DbType, Size, ParameterDirection.Input, Value);
        }

        /// <summary>
        /// 输出参数
        /// </summary>
        /// <param name="ParamName">参数名</param>
        /// <param name="DbType">类型</param>
        /// <param name="Size">大小</param>
        /// <returns>SqlParameter </returns>
        public SqlParameter MakeOutParam(string ParamName, SqlDbType DbType, int Size)
        {
            return MakeParam(ParamName, DbType, Size, ParameterDirection.Output, null);
        }

        /// <summary>
        /// 参数管理
        /// </summary>
        /// <param name="ParamName">参数名</param>
        /// <param name="DbType">类型</param>
        /// <param name="Size">大小</param>
        /// <param name="Direction">DataSet类型</param>
        /// <param name="Value">值</param>
        /// <returns>SqlParameter</returns>
        public SqlParameter MakeParam(string ParamName, SqlDbType DbType, int Size, ParameterDirection Direction, object Value)
        {
            SqlParameter parameter;
            if (Size > 0)
            {
                parameter = new SqlParameter(ParamName, DbType, Size);
            }
            else
            {
                parameter = new SqlParameter(ParamName, DbType);
            }
            parameter.Direction = Direction;
            if ((Direction != ParameterDirection.Output) || (Value != null))
            {
                parameter.Value = Value;
            }
            return parameter;
        }

        /// <summary>
        /// 执行增删改的操作
        /// </summary>
        /// <param name="sql">执行的SQL语句</param>
        /// <param name="para">参数（可不给）</param>
        /// <returns>受影响的行数</returns>
        public int ExectueNoQuery(string sql, params SqlParameter[] para)
        {
            return ExectueNoQuery(sql, CommandType.StoredProcedure, para);
        }

        public int ExectueNoQuery(string sql, CommandType type, params SqlParameter[] para)
        {
            SqlConnection conn = CreateConn();
            SqlCommand command = SetCommand(conn, sql, type, para);
            command.ExecuteNonQuery();
            return Convert.ToInt32(command.Parameters["ReturnValue"].Value);
        }

        /// <summary>
        /// 执行查询的操作
        /// </summary>
        /// <param name="sql">执行的SQL语句</param>
        /// <param name="type">执行的语句的类型</param>
        /// <param name="para">参数（可不给）</param>
        /// <returns>第一行</returns>
        public int ExecuteScalar(string sql, CommandType type, params SqlParameter[] para)
        {
            SqlConnection conn = CreateConn();
            return Convert.ToInt32(SetCommand(conn, sql, type, para).ExecuteScalar());
        }

        /// <summary>
        /// 执行读取数据的操作
        /// </summary>
        /// <param name="sql">执行的SQL语句</param>
        /// <param name="type">执行的语句的类型</param>
        /// <param name="para">参数（可不给）</param>
        /// <returns>SqlDataReader数据集</returns>
        public SqlDataReader ExecuteReader(string sql, params SqlParameter[] para)
        {
            return ExecuteReader(sql, CommandType.StoredProcedure, para);
        }

        /// <summary>
        /// 执行读取数据的操作
        /// </summary>
        /// <param name="sql">执行的SQL语句</param>
        /// <param name="type">执行的语句的类型</param>
        /// <param name="para">参数（可不给）</param>
        /// <returns>SqlDataReader数据集</returns>
        public SqlDataReader ExecuteReader(string sql, CommandType type, params SqlParameter[] para)
        {
            SqlConnection conn = CreateConn();
            return SetCommand(conn, sql, type, para).ExecuteReader(CommandBehavior.CloseConnection);
        }

        public DataTable Query(string sql, params SqlParameter[] para)
        {
            return Query(sql, CommandType.StoredProcedure, para);
        }

        /// <summary>
        /// 执行查询语句，返回DataTable
        /// </summary>
        /// <param name="SQLString">查询语句</param>
        /// <returns>DataTable</returns>
        public DataTable Query(string sql, CommandType type, params SqlParameter[] para)
        {
            SqlConnection conn = CreateConn();
            DataSet ds = new DataSet();
            try
            {
                conn.Close();
                conn.Open();
                SqlCommand comm = SetCommand(conn, sql, type, para);
                SqlDataAdapter command = new SqlDataAdapter(comm);
                command.Fill(ds, "ds");
            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                throw new Exception(ex.Message);
            }
            return ds.Tables[0];
        }

        /// <summary>
        /// 事务执行sql语句
        /// </summary>
        /// <param name="sql">sql语句</param>
        /// <returns></returns>
        public int Query(List<string> sqlList)
        {
            SqlConnection conn = CreateConn();
            SqlTransaction sqltra = conn.BeginTransaction();//开始事务
            SqlCommand cmd = new SqlCommand();//实例化
            cmd.Connection = conn;//获取数据连接
            cmd.Transaction = sqltra;//在执行SQL时
            try
            {
                int count = 0;
                for (int i = 0; i < sqlList.Count; i++)
                {
                    string strsql = sqlList[i].ToString();
                    if (strsql.Trim().Length > 1)
                    {
                        cmd.CommandText = strsql;
                        count += cmd.ExecuteNonQuery();
                    }
                }
                sqltra.Commit();
                return count;
            }
            catch (Exception ex)
            {
                sqltra.Rollback();
                return 0;
            }
        }

        /// <summary>
        /// 提取共同的部分，仅供内部调用
        /// </summary>
        /// <param name="conn">数据库连接对象</param>
        /// <param name="sql">执行的SQL语句</param>
        /// <param name="type">执行的语句的类型</param>
        /// <param name="para">参数（可不给）</param>
        /// <returns>SqlCommand对象</returns>
        public SqlCommand SetCommand(SqlConnection conn, string sql, CommandType type, params SqlParameter[] para)
        {
            SqlCommand command = new SqlCommand(sql, conn);
            command.CommandType = type;
            if (para != null)
            {
                foreach (SqlParameter s in para)
                {
                    command.Parameters.Add(s);
                }
            }
            command.Parameters.Add(new SqlParameter("ReturnValue", SqlDbType.Int, 4, ParameterDirection.ReturnValue, false, 0, 0, string.Empty, DataRowVersion.Default, null));
            return command;
        }

        /// <summary>
        /// 遍历参数，获取每个参数的值，以便录入日志
        /// </summary>
        /// <param name="parameters">参数集合</param>
        /// <returns></returns>
        public string FromatParameters(SqlParameter[] parameters)
        {
            string str = "";
            foreach (SqlParameter p in parameters)
            {
                str += p.ParameterName + ":" + p.Value + "; ";
            }
            return str;
        }

        /// <summary>
        /// 执行一条计算查询结果语句，返回查询结果（object）。
        /// </summary>
        /// <param name="SQLString">计算查询结果语句</param>
        /// <returns>查询结果（object）</returns>
        public object GetSingle(string SQLString, CommandType type, params SqlParameter[] cmdParms)
        {
            SqlConnection connection = CreateConn();
            try
            {
                object obj = SetCommand(connection, SQLString, type, cmdParms).ExecuteScalar();
                if ((Object.Equals(obj, null)) || (Object.Equals(obj, System.DBNull.Value)))
                {
                    return null;
                }
                else
                {
                    return obj;
                }
            }
            catch (System.Data.SqlClient.SqlException e)
            {
                throw e;
            }
        }
    }
}
