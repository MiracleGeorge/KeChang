using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace YouHoo.DataOperation
{
    public class DBSqlServer : IDisposable
    {
        //���ݿ������ַ���(web.config������)�����Զ�̬����connectionString֧�ֶ����ݿ�.		
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
        /// �����������ݿ���󲢴����ݿ�
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
        /// �ر�����
        /// </summary>
        public void Close()
        {
            if (conn != null && conn.State == ConnectionState.Open)
            {
                conn.Close();
            }
        }

        /// <summary>
        /// �����������ݿ���󲢴����ݿ�
        /// </summary>
        /// <returns></returns>
        public SqlConnection CreateConn(string connectionString)
        {
            conn = new SqlConnection(connectionString);
            conn.Open();
            return conn;
        }

        /// <summary>
        /// �������
        /// </summary>
        /// <param name="ParamName">������</param>
        /// <param name="DbType">����</param>
        /// <param name="Size">��С</param>
        /// <param name="Value">ֵ</param>
        /// <returns>SqlParameter </returns>
        public SqlParameter MakeInParam(string ParamName, SqlDbType DbType, int Size, object Value)
        {
            return MakeParam(ParamName, DbType, Size, ParameterDirection.Input, Value);
        }

        /// <summary>
        /// �������
        /// </summary>
        /// <param name="ParamName">������</param>
        /// <param name="DbType">����</param>
        /// <param name="Size">��С</param>
        /// <returns>SqlParameter </returns>
        public SqlParameter MakeOutParam(string ParamName, SqlDbType DbType, int Size)
        {
            return MakeParam(ParamName, DbType, Size, ParameterDirection.Output, null);
        }

        /// <summary>
        /// ��������
        /// </summary>
        /// <param name="ParamName">������</param>
        /// <param name="DbType">����</param>
        /// <param name="Size">��С</param>
        /// <param name="Direction">DataSet����</param>
        /// <param name="Value">ֵ</param>
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
        /// ִ����ɾ�ĵĲ���
        /// </summary>
        /// <param name="sql">ִ�е�SQL���</param>
        /// <param name="para">�������ɲ�����</param>
        /// <returns>��Ӱ�������</returns>
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
        /// ִ�в�ѯ�Ĳ���
        /// </summary>
        /// <param name="sql">ִ�е�SQL���</param>
        /// <param name="type">ִ�е���������</param>
        /// <param name="para">�������ɲ�����</param>
        /// <returns>��һ��</returns>
        public int ExecuteScalar(string sql, CommandType type, params SqlParameter[] para)
        {
            SqlConnection conn = CreateConn();
            return Convert.ToInt32(SetCommand(conn, sql, type, para).ExecuteScalar());
        }

        /// <summary>
        /// ִ�ж�ȡ���ݵĲ���
        /// </summary>
        /// <param name="sql">ִ�е�SQL���</param>
        /// <param name="type">ִ�е���������</param>
        /// <param name="para">�������ɲ�����</param>
        /// <returns>SqlDataReader���ݼ�</returns>
        public SqlDataReader ExecuteReader(string sql, params SqlParameter[] para)
        {
            return ExecuteReader(sql, CommandType.StoredProcedure, para);
        }

        /// <summary>
        /// ִ�ж�ȡ���ݵĲ���
        /// </summary>
        /// <param name="sql">ִ�е�SQL���</param>
        /// <param name="type">ִ�е���������</param>
        /// <param name="para">�������ɲ�����</param>
        /// <returns>SqlDataReader���ݼ�</returns>
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
        /// ִ�в�ѯ��䣬����DataTable
        /// </summary>
        /// <param name="SQLString">��ѯ���</param>
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
        /// ����ִ��sql���
        /// </summary>
        /// <param name="sql">sql���</param>
        /// <returns></returns>
        public int Query(List<string> sqlList)
        {
            SqlConnection conn = CreateConn();
            SqlTransaction sqltra = conn.BeginTransaction();//��ʼ����
            SqlCommand cmd = new SqlCommand();//ʵ����
            cmd.Connection = conn;//��ȡ��������
            cmd.Transaction = sqltra;//��ִ��SQLʱ
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
        /// ��ȡ��ͬ�Ĳ��֣������ڲ�����
        /// </summary>
        /// <param name="conn">���ݿ����Ӷ���</param>
        /// <param name="sql">ִ�е�SQL���</param>
        /// <param name="type">ִ�е���������</param>
        /// <param name="para">�������ɲ�����</param>
        /// <returns>SqlCommand����</returns>
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
        /// ������������ȡÿ��������ֵ���Ա�¼����־
        /// </summary>
        /// <param name="parameters">��������</param>
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
        /// ִ��һ�������ѯ�����䣬���ز�ѯ�����object����
        /// </summary>
        /// <param name="SQLString">�����ѯ������</param>
        /// <returns>��ѯ�����object��</returns>
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
