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
	/// 数据访问类：YouhooBasicarchiveTownDAL
	/// 时间：2017/5/3 15:49:25
	/// </summary>
	public class YouhooBasicarchiveTownDAL
	{
		private string _p = "";

		public YouhooBasicarchiveTownDAL()
		{}
		#region  成员方法
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int id)
		{
			try
			{
				using (DBSqlServer db = new DBSqlServer())
				{
					StringBuilder strSql = new StringBuilder();
					strSql.Append("sp_youhoo_BasicArchive_town_exists");
					SqlParameter[] parameters = {
						db.MakeInParam("@id", SqlDbType.Int,4,id)
					};
					
					_p = db.FromatParameters(parameters);
					
					//记录操作日志
					Logger.Debug(GetType().FullName + "." + MethodBase.GetCurrentMethod().Name + ",输入参数：exec sp_youhoo_BasicArchive_town_exists " + _p);
					
					object obj = db.GetSingle(strSql.ToString(), CommandType.StoredProcedure, parameters);
					if ((Object.Equals(obj, null)) || (Object.Equals(obj, System.DBNull.Value)) || (Object.Equals(obj, 0)))
					{
						return false;
					}
					else
					{
						return true;
					}
				}
			}
			catch (Exception ex)
			{
				//记录错误日志
				Logger.Error(GetType().FullName + "." + MethodBase.GetCurrentMethod().Name + ", 错误原因：" + ex.Message + ", 输入参数：exec sp_youhoo_BasicArchive_town_exists " + _p);
				throw ex;
			}
		}

		/// <summary>
		/// 添加/修改一条数据
		/// </summary>
		public int InsertUpdate(YouhooBasicarchiveTownModel model, int operatorId)
		{
			try
			{
				using (DBSqlServer db = new DBSqlServer())
				{
					StringBuilder strSql = new StringBuilder();
					strSql.Append("sp_youhoo_BasicArchive_town_insertupdate");
					SqlParameter[] parameters = {
						db.MakeInParam("@id", SqlDbType.Int,4,model.Id),
						db.MakeInParam("@Code", SqlDbType.NVarChar,50,model.Code),
						db.MakeInParam("@Name", SqlDbType.NVarChar,50,model.Name),
						db.MakeOutParam("@v_id", SqlDbType.Int, 4),
						db.MakeInParam("@operator_id", SqlDbType.Int, 4, operatorId)
					};
					
					_p = db.FromatParameters(parameters);
					
					//记录操作日志
					Logger.Debug(GetType().FullName + "." + MethodBase.GetCurrentMethod().Name + ",输入参数：exec sp_youhoo_BasicArchive_town_insertupdate " + _p);
					
					int rows = db.ExectueNoQuery(strSql.ToString(), CommandType.StoredProcedure, parameters);
					model.Id = DataConvert.ToInt32(parameters[parameters.Length - 2].Value);
					return rows;
				}
			}
			catch (Exception ex)
			{
				//记录错误日志
				Logger.Error(GetType().FullName + "." + MethodBase.GetCurrentMethod().Name + ", 错误原因：" + ex.Message + ", 输入参数：exec sp_youhoo_BasicArchive_town_insertupdate " + _p);
				throw ex;
			}
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public int Delete(string arrayId, int operatorId)
		{
			try
			{
				using (DBSqlServer db = new DBSqlServer())
				{
					StringBuilder strSql = new StringBuilder();
					strSql.Append("sp_youhoo_BasicArchive_town_delete");
					SqlParameter[] parameters = {
						db.MakeInParam("@array_id", SqlDbType.NVarChar, 500, arrayId),
						db.MakeInParam("@operator_id", SqlDbType.Int, 4, operatorId)
					};
					
					_p = db.FromatParameters(parameters);
					
					//记录操作日志
					Logger.Debug(GetType().FullName + "." + MethodBase.GetCurrentMethod().Name + ",输入参数：exec sp_youhoo_BasicArchive_town_delete " + _p);
					
					return db.ExectueNoQuery(strSql.ToString(), CommandType.StoredProcedure, parameters);
				}
			}
			catch (Exception ex)
			{
				//记录错误日志
				Logger.Error(GetType().FullName + "." + MethodBase.GetCurrentMethod().Name + ", 错误原因：" + ex.Message + ", 输入参数：exec sp_youhoo_BasicArchive_town_delete " + _p);
				throw ex;
			}
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public YouhooBasicarchiveTownModel GetModel(int id)
		{
			try
			{
				using (DBSqlServer db = new DBSqlServer())
				{
					StringBuilder strSql = new StringBuilder();
					strSql.Append("sp_youhoo_BasicArchive_town_getmodel");
					SqlParameter[] parameters = {
						db.MakeInParam("@id", SqlDbType.Int,4,id)
					};
					
					_p = db.FromatParameters(parameters);
					
					//记录操作日志
					Logger.Debug(GetType().FullName + "." + MethodBase.GetCurrentMethod().Name + ",输入参数：exec sp_youhoo_BasicArchive_town_getmodel " + _p);
					
					DataTable dt = db.Query(strSql.ToString(), CommandType.StoredProcedure, parameters);
					if (dt != null && dt.Rows.Count != 0)
						return new YouhooBasicarchiveTownModel(dt.Rows[0]);
					return null;
				}
			}
			catch (Exception ex)
			{
				//记录错误日志
				Logger.Error(GetType().FullName + "." + MethodBase.GetCurrentMethod().Name + ", 错误原因：" + ex.Message + ", 输入参数：exec sp_youhoo_BasicArchive_town_getmodel " + _p);
				throw ex;
			}
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataTable GetList(string strWhere)
		{
			try
			{
				using (DBSqlServer db = new DBSqlServer())
				{
					StringBuilder strSql = new StringBuilder();
					strSql.Append("sp_youhoo_BasicArchive_town_getlist");
					SqlParameter[] parameters = {
						db.MakeInParam("@strWhere", SqlDbType.NVarChar, 500, strWhere)
					};
					
					_p = db.FromatParameters(parameters);
					
					//记录操作日志
					Logger.Debug(GetType().FullName + "." + MethodBase.GetCurrentMethod().Name + ",输入参数：exec sp_youhoo_BasicArchive_town_getlist " + _p);
					
					DataTable dt = db.Query(strSql.ToString(), CommandType.StoredProcedure, parameters);
					return dt;
				}
			}
			catch (Exception ex)
			{
				//记录错误日志
				Logger.Error(GetType().FullName + "." + MethodBase.GetCurrentMethod().Name + ", 错误原因：" + ex.Message + ", 输入参数：exec sp_youhoo_BasicArchive_town_getlist " + _p);
				throw ex;
			}
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataTable GetListByPage(int pageIndex, int pageSize, string strWhere, string orderBy, out int count)
		{
			try
			{
				using (DBSqlServer db = new DBSqlServer())
				{
					StringBuilder strSql = new StringBuilder();
					strSql.Append("sp_youhoo_BasicArchive_town_getlistbypage");
					SqlParameter[] parameters = {
						db.MakeInParam("@pageIndex", SqlDbType.Int, 4, pageIndex),
						db.MakeInParam("@pageSize", SqlDbType.Int, 4, pageSize),
						db.MakeInParam("@strWhere", SqlDbType.NVarChar, 500, strWhere),
						db.MakeInParam("@orderBy", SqlDbType.NVarChar, 500, orderBy),
						db.MakeOutParam("@count", SqlDbType.Int, 4)
					};
					
					_p = db.FromatParameters(parameters);
					
					//记录操作日志
					Logger.Debug(GetType().FullName + "." + MethodBase.GetCurrentMethod().Name + ",输入参数：exec sp_youhoo_BasicArchive_town_getlistbypage " + _p);
					
					DataTable dt = db.Query(strSql.ToString(), CommandType.StoredProcedure, parameters);
					count = Convert.ToInt32(parameters[parameters.Length - 1].Value);
					return dt;
				}
			}
			catch (Exception ex)
			{
				//记录错误日志
				Logger.Error(GetType().FullName + "." + MethodBase.GetCurrentMethod().Name + ", 错误原因：" + ex.Message + ", 输入参数：exec sp_youhoo_BasicArchive_town_getlistbypage " + _p);
				throw ex;
			}
		}
		#endregion  成员方法
	}
}
