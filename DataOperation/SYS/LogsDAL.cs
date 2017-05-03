using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using YouHoo.DataModel;
using YouHoo.DataTools;
using System.Reflection;

namespace YouHoo.DataOperation
{
	/// <summary>
    /// 数据访问类：LogsDAL
	/// 时间：2015/3/27 11:10:22
	/// </summary>
    public class LogsDAL
	{
		private string _p = "";

        public LogsDAL()
		{}
		#region  成员方法
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataTable GetListByPage(int pageIndex, int pageSize, out int count)
		{
			try
			{
				using (DBSqlServer db = new DBSqlServer())
				{
					StringBuilder strSql = new StringBuilder();
					strSql.Append("sp_logs_getlistbypage");
					SqlParameter[] parameters = {
						db.MakeInParam("@pageIndex", SqlDbType.Int, 4, pageIndex),
						db.MakeInParam("@pageSize", SqlDbType.Int, 4, pageSize),
						db.MakeOutParam("@count", SqlDbType.Int, 4)
					};
					
					_p = db.FromatParameters(parameters);
					
					//记录操作日志
					Logger.Debug(GetType().FullName + "." + MethodBase.GetCurrentMethod().Name + ",输入参数：exec sp_logs_getlistbypage " + _p);
					
					DataTable dt = db.Query(strSql.ToString(), CommandType.StoredProcedure, parameters);
					count = Convert.ToInt32(parameters[parameters.Length - 1].Value);
                    return dt;
				}
			}
			catch (Exception ex)
			{
				//记录错误日志
				Logger.Error(GetType().FullName + "." + MethodBase.GetCurrentMethod().Name + ", 错误原因：" + ex.Message + ", 输入参数：exec sp_logs_getlistbypage " + _p);
				throw ex;
			}
		}
		#endregion  成员方法
	}
}
