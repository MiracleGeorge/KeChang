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
	/// 数据访问类：YouhooVisitRecordDAL
	/// 时间：2017/4/24 12:00:53
	/// </summary>
	public class YouhooVisitRecordDAL
	{
		private string _p = "";

		public YouhooVisitRecordDAL()
		{}
		#region  成员方法
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int visitId)
		{
			try
			{
				using (DBSqlServer db = new DBSqlServer())
				{
					StringBuilder strSql = new StringBuilder();
					strSql.Append("sp_youhoo_Visit_Record_exists");
					SqlParameter[] parameters = {
						db.MakeInParam("@visit_id", SqlDbType.Int,4,visitId)
					};
					
					_p = db.FromatParameters(parameters);
					
					//记录操作日志
					Logger.Debug(GetType().FullName + "." + MethodBase.GetCurrentMethod().Name + ",输入参数：exec sp_youhoo_Visit_Record_exists " + _p);
					
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
				Logger.Error(GetType().FullName + "." + MethodBase.GetCurrentMethod().Name + ", 错误原因：" + ex.Message + ", 输入参数：exec sp_youhoo_Visit_Record_exists " + _p);
				throw ex;
			}
		}

		/// <summary>
		/// 添加/修改一条数据
		/// </summary>
		public int InsertUpdate(YouhooVisitRecordModel model, int operatorId)
		{
			try
			{
				using (DBSqlServer db = new DBSqlServer())
				{
					StringBuilder strSql = new StringBuilder();
					strSql.Append("sp_youhoo_Visit_Record_insertupdate");
					SqlParameter[] parameters = {
						db.MakeInParam("@visit_id", SqlDbType.Int,4,model.VisitId),
						db.MakeInParam("@cCusName", SqlDbType.NVarChar,98,model.Ccusname),
						db.MakeInParam("@cCusAbbName", SqlDbType.NVarChar,60,model.Ccusabbname),
						db.MakeInParam("@cCusCode", SqlDbType.NVarChar,20,model.Ccuscode),
						db.MakeInParam("@phoneNumber", SqlDbType.NVarChar,100,model.Phonenumber),
						db.MakeInParam("@cCusPerson", SqlDbType.NVarChar,50,model.Ccusperson),
						db.MakeInParam("@visit_date", SqlDbType.DateTime,0,model.VisitDate),
						db.MakeInParam("@visit_location", SqlDbType.NVarChar,100,model.VisitLocation),
						db.MakeInParam("@visit_person", SqlDbType.NVarChar,50,model.VisitPerson),
						db.MakeInParam("@visit_startTime", SqlDbType.DateTime,0,model.VisitStarttime),
						db.MakeInParam("@visit_endTime", SqlDbType.DateTime,0,model.VisitEndtime),
						db.MakeInParam("@visit_way_id", SqlDbType.Int,4,model.VisitWayId),
						db.MakeInParam("@visit_content", SqlDbType.NVarChar,400,model.VisitContent),
						db.MakeInParam("@visit_NextPlan", SqlDbType.NVarChar,300,model.VisitNextplan),
						db.MakeInParam("@visit_ManagerOpinion", SqlDbType.NChar,10,model.VisitManageropinion),
						db.MakeInParam("@verifi_state", SqlDbType.Int,4,model.VerifiState),
						db.MakeInParam("@remark", SqlDbType.NText,0,model.Remark),
						db.MakeInParam("@flag", SqlDbType.Int,4,model.Flag),
						db.MakeInParam("@user_id", SqlDbType.Int,4,model.UserId),
						db.MakeInParam("@createoperator", SqlDbType.NVarChar,50,model.Createoperator),
						db.MakeInParam("@createdate", SqlDbType.DateTime,0,model.Createdate),
						db.MakeInParam("@updateoperator", SqlDbType.NVarChar,50,model.Updateoperator),
						db.MakeInParam("@updatedate", SqlDbType.DateTime,0,model.Updatedate),
						db.MakeOutParam("@v_id", SqlDbType.Int, 4),
						db.MakeInParam("@operator_id", SqlDbType.Int, 4, operatorId)
					};
					
					_p = db.FromatParameters(parameters);
					
					//记录操作日志
					Logger.Debug(GetType().FullName + "." + MethodBase.GetCurrentMethod().Name + ",输入参数：exec sp_youhoo_Visit_Record_insertupdate " + _p);
					
					int rows = db.ExectueNoQuery(strSql.ToString(), CommandType.StoredProcedure, parameters);
					model.VisitId = DataConvert.ToInt32(parameters[parameters.Length - 2].Value);
					return rows;
				}
			}
			catch (Exception ex)
			{
				//记录错误日志
				Logger.Error(GetType().FullName + "." + MethodBase.GetCurrentMethod().Name + ", 错误原因：" + ex.Message + ", 输入参数：exec sp_youhoo_Visit_Record_insertupdate " + _p);
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
					strSql.Append("sp_youhoo_Visit_Record_delete");
					SqlParameter[] parameters = {
						db.MakeInParam("@array_id", SqlDbType.NVarChar, 500, arrayId),
						db.MakeInParam("@operator_id", SqlDbType.Int, 4, operatorId)
					};
					
					_p = db.FromatParameters(parameters);
					
					//记录操作日志
					Logger.Debug(GetType().FullName + "." + MethodBase.GetCurrentMethod().Name + ",输入参数：exec sp_youhoo_Visit_Record_delete " + _p);
					
					return db.ExectueNoQuery(strSql.ToString(), CommandType.StoredProcedure, parameters);
				}
			}
			catch (Exception ex)
			{
				//记录错误日志
				Logger.Error(GetType().FullName + "." + MethodBase.GetCurrentMethod().Name + ", 错误原因：" + ex.Message + ", 输入参数：exec sp_youhoo_Visit_Record_delete " + _p);
				throw ex;
			}
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public YouhooVisitRecordModel GetModel(int visitId)
		{
			try
			{
				using (DBSqlServer db = new DBSqlServer())
				{
					StringBuilder strSql = new StringBuilder();
					strSql.Append("sp_youhoo_Visit_Record_getmodel");
					SqlParameter[] parameters = {
						db.MakeInParam("@visit_id", SqlDbType.Int,4,visitId)
					};
					
					_p = db.FromatParameters(parameters);
					
					//记录操作日志
					Logger.Debug(GetType().FullName + "." + MethodBase.GetCurrentMethod().Name + ",输入参数：exec sp_youhoo_Visit_Record_getmodel " + _p);
					
					DataTable dt = db.Query(strSql.ToString(), CommandType.StoredProcedure, parameters);
					if (dt != null && dt.Rows.Count != 0)
						return new YouhooVisitRecordModel(dt.Rows[0]);
					return null;
				}
			}
			catch (Exception ex)
			{
				//记录错误日志
				Logger.Error(GetType().FullName + "." + MethodBase.GetCurrentMethod().Name + ", 错误原因：" + ex.Message + ", 输入参数：exec sp_youhoo_Visit_Record_getmodel " + _p);
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
					strSql.Append("sp_youhoo_Visit_Record_getlist");
					SqlParameter[] parameters = {
						db.MakeInParam("@strWhere", SqlDbType.NVarChar, 500, strWhere)
					};
					
					_p = db.FromatParameters(parameters);
					
					//记录操作日志
					Logger.Debug(GetType().FullName + "." + MethodBase.GetCurrentMethod().Name + ",输入参数：exec sp_youhoo_Visit_Record_getlist " + _p);
					
					DataTable dt = db.Query(strSql.ToString(), CommandType.StoredProcedure, parameters);
					return dt;
				}
			}
			catch (Exception ex)
			{
				//记录错误日志
				Logger.Error(GetType().FullName + "." + MethodBase.GetCurrentMethod().Name + ", 错误原因：" + ex.Message + ", 输入参数：exec sp_youhoo_Visit_Record_getlist " + _p);
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
					strSql.Append("sp_youhoo_Visit_Record_getlistbypage");
					SqlParameter[] parameters = {
						db.MakeInParam("@pageIndex", SqlDbType.Int, 4, pageIndex),
						db.MakeInParam("@pageSize", SqlDbType.Int, 4, pageSize),
						db.MakeInParam("@strWhere", SqlDbType.NVarChar, 500, strWhere),
						db.MakeInParam("@orderBy", SqlDbType.NVarChar, 500, orderBy),
						db.MakeOutParam("@count", SqlDbType.Int, 4)
					};
					
					_p = db.FromatParameters(parameters);
					
					//记录操作日志
					Logger.Debug(GetType().FullName + "." + MethodBase.GetCurrentMethod().Name + ",输入参数：exec sp_youhoo_Visit_Record_getlistbypage " + _p);
					
					DataTable dt = db.Query(strSql.ToString(), CommandType.StoredProcedure, parameters);
					count = Convert.ToInt32(parameters[parameters.Length - 1].Value);
					return dt;
				}
			}
			catch (Exception ex)
			{
				//记录错误日志
				Logger.Error(GetType().FullName + "." + MethodBase.GetCurrentMethod().Name + ", 错误原因：" + ex.Message + ", 输入参数：exec sp_youhoo_Visit_Record_getlistbypage " + _p);
				throw ex;
			}
		}

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataTable GetCusListByPage(int pageIndex, int pageSize, string strWhere, string orderBy, out int count)
        {
            try
            {
                using (DBSqlServer db = new DBSqlServer())
                {
                    StringBuilder strSql = new StringBuilder();
                    strSql.Append("sp_youhoo_Visit_Record_getcuslistbypage");
                    SqlParameter[] parameters = {
                        db.MakeInParam("@pageIndex", SqlDbType.Int, 4, pageIndex),
                        db.MakeInParam("@pageSize", SqlDbType.Int, 4, pageSize),
                        db.MakeInParam("@strWhere", SqlDbType.NVarChar, 500, strWhere),
                        db.MakeInParam("@orderBy", SqlDbType.NVarChar, 500, orderBy),
                        db.MakeOutParam("@count", SqlDbType.Int, 4)
                    };

                    _p = db.FromatParameters(parameters);

                    //记录操作日志
                    Logger.Debug(GetType().FullName + "." + MethodBase.GetCurrentMethod().Name + ",输入参数：exec sp_youhoo_Visit_Record_getlistbypage " + _p);

                    DataTable dt = db.Query(strSql.ToString(), CommandType.StoredProcedure, parameters);
                    count = Convert.ToInt32(parameters[parameters.Length - 1].Value);
                    return dt;
                }
            }
            catch (Exception ex)
            {
                //记录错误日志
                Logger.Error(GetType().FullName + "." + MethodBase.GetCurrentMethod().Name + ", 错误原因：" + ex.Message + ", 输入参数：exec sp_youhoo_Visit_Record_getlistbypage " + _p);
                throw ex;
            }
        }
        #endregion  成员方法
    }
}
