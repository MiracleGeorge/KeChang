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
    /// 数据访问类：YouhooSysModuleDAL
    /// 时间：2015/4/8 10:49:20
    /// </summary>
    public class YouhooSysModuleDAL
    {
        private string _p = "";

        public YouhooSysModuleDAL()
        { }
        #region  成员方法
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int moduleId)
        {
            try
            {
                using (DBSqlServer db = new DBSqlServer())
                {
                    StringBuilder strSql = new StringBuilder();
                    strSql.Append("sp_youhoo_sys_module_exists");
                    SqlParameter[] parameters = {
						db.MakeInParam("@module_id", SqlDbType.Int,4,moduleId)
					};

                    _p = db.FromatParameters(parameters);

                    //记录操作日志
                    Logger.Debug(GetType().FullName + "." + MethodBase.GetCurrentMethod().Name + ",输入参数：exec sp_youhoo_sys_module_exists " + _p);

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
                Logger.Error(GetType().FullName + "." + MethodBase.GetCurrentMethod().Name + ", 错误原因：" + ex.Message + ", 输入参数：exec sp_youhoo_sys_module_exists " + _p);
                throw ex;
            }
        }

        /// <summary>
        ///  添加/修改一条数据
        /// </summary>
        public int InsertUpdate(YouhooSysModuleModel model, int operatorId)
        {
            try
            {
                using (DBSqlServer db = new DBSqlServer())
                {
                    StringBuilder strSql = new StringBuilder();
                    strSql.Append("sp_youhoo_sys_module_insertupdate");
                    SqlParameter[] parameters = {
						db.MakeInParam("@module_id", SqlDbType.Int,4,model.ModuleId),
						db.MakeInParam("@module_name", SqlDbType.NVarChar,400,model.ModuleName),
						db.MakeInParam("@parentmodule_id", SqlDbType.Int,4,model.ParentmoduleId),
						db.MakeInParam("@module_url", SqlDbType.NVarChar,400,model.ModuleUrl),
						db.MakeInParam("@module_value", SqlDbType.NVarChar,50,model.ModuleValue),
						db.MakeInParam("@sort", SqlDbType.Int,4,model.Sort),
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
                    Logger.Debug(GetType().FullName + "." + MethodBase.GetCurrentMethod().Name + ",输入参数：exec sp_youhoo_sys_module_insertupdate " + _p);

                    int rows = db.ExectueNoQuery(strSql.ToString(), CommandType.StoredProcedure, parameters);
                    model.ModuleId = DataConvert.ToInt32(parameters[parameters.Length - 2].Value);
                    return rows;
                }
            }
            catch (Exception ex)
            {
                //记录错误日志
                Logger.Error(GetType().FullName + "." + MethodBase.GetCurrentMethod().Name + ", 错误原因：" + ex.Message + ", 输入参数：exec sp_youhoo_sys_module_insertupdate " + _p);
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
                    strSql.Append("sp_youhoo_sys_module_delete");
                    SqlParameter[] parameters = {
						db.MakeInParam("@array_id", SqlDbType.NVarChar, 500, arrayId),
						db.MakeInParam("@operator_id", SqlDbType.Int, 4, operatorId)
					};

                    _p = db.FromatParameters(parameters);

                    //记录操作日志
                    Logger.Debug(GetType().FullName + "." + MethodBase.GetCurrentMethod().Name + ",输入参数：exec sp_youhoo_sys_module_delete " + _p);

                    return db.ExectueNoQuery(strSql.ToString(), CommandType.StoredProcedure, parameters);
                }
            }
            catch (Exception ex)
            {
                //记录错误日志
                Logger.Error(GetType().FullName + "." + MethodBase.GetCurrentMethod().Name + ", 错误原因：" + ex.Message + ", 输入参数：exec sp_youhoo_sys_module_delete " + _p);
                throw ex;
            }
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public YouhooSysModuleModel GetModel(int moduleId)
        {
            try
            {
                using (DBSqlServer db = new DBSqlServer())
                {
                    StringBuilder strSql = new StringBuilder();
                    strSql.Append("sp_youhoo_sys_module_getmodel");
                    SqlParameter[] parameters = {
						db.MakeInParam("@module_id", SqlDbType.Int,4,moduleId)
					};

                    _p = db.FromatParameters(parameters);

                    //记录操作日志
                    Logger.Debug(GetType().FullName + "." + MethodBase.GetCurrentMethod().Name + ",输入参数：exec sp_youhoo_sys_module_getmodel " + _p);

                    DataTable dt = db.Query(strSql.ToString(), CommandType.StoredProcedure, parameters);
                    if (dt != null && dt.Rows.Count != 0)
                        return new YouhooSysModuleModel(dt.Rows[0]);
                    return null;
                }
            }
            catch (Exception ex)
            {
                //记录错误日志
                Logger.Error(GetType().FullName + "." + MethodBase.GetCurrentMethod().Name + ", 错误原因：" + ex.Message + ", 输入参数：exec sp_youhoo_sys_module_getmodel " + _p);
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
                    strSql.Append("sp_youhoo_sys_module_getlist");
                    SqlParameter[] parameters = {
						db.MakeInParam("@strWhere", SqlDbType.NVarChar, 500, strWhere)
					};

                    _p = db.FromatParameters(parameters);

                    //记录操作日志
                    Logger.Debug(GetType().FullName + "." + MethodBase.GetCurrentMethod().Name + ",输入参数：exec sp_youhoo_sys_module_getlist " + _p);

                    DataTable dt = db.Query(strSql.ToString(), CommandType.StoredProcedure, parameters);
                    return dt;
                }
            }
            catch (Exception ex)
            {
                //记录错误日志
                Logger.Error(GetType().FullName + "." + MethodBase.GetCurrentMethod().Name + ", 错误原因：" + ex.Message + ", 输入参数：exec sp_youhoo_sys_module_getlist " + _p);
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
                    strSql.Append("sp_youhoo_sys_module_getlistbypage");
                    SqlParameter[] parameters = {
						db.MakeInParam("@pageIndex", SqlDbType.Int, 4, pageIndex),
						db.MakeInParam("@pageSize", SqlDbType.Int, 4, pageSize),
						db.MakeInParam("@strWhere", SqlDbType.NVarChar, 500, strWhere),
						db.MakeInParam("@orderBy", SqlDbType.NVarChar, 500, orderBy),
						db.MakeOutParam("@count", SqlDbType.Int, 4)
					};

                    _p = db.FromatParameters(parameters);

                    //记录操作日志
                    Logger.Debug(GetType().FullName + "." + MethodBase.GetCurrentMethod().Name + ",输入参数：exec sp_youhoo_sys_module_getlistbypage " + _p);

                    DataTable dt = db.Query(strSql.ToString(), CommandType.StoredProcedure, parameters);
                    count = Convert.ToInt32(parameters[parameters.Length - 1].Value);
                    return dt;
                }
            }
            catch (Exception ex)
            {
                //记录错误日志
                Logger.Error(GetType().FullName + "." + MethodBase.GetCurrentMethod().Name + ", 错误原因：" + ex.Message + ", 输入参数：exec sp_youhoo_sys_module_getlistbypage " + _p);
                throw ex;
            }
        }

        /// <summary>
        /// 获得数据列表（权限）
        /// </summary>
        public DataTable GetListByPagePower(int pageIndex, int pageSize, string strWhere, string orderBy, out int count)
        {
            try
            {
                using (DBSqlServer db = new DBSqlServer())
                {
                    StringBuilder strSql = new StringBuilder();
                    strSql.Append("sp_youhoo_sys_module_getlistbypagepower");
                    SqlParameter[] parameters = {
						db.MakeInParam("@pageIndex", SqlDbType.Int, 4, pageIndex),
						db.MakeInParam("@pageSize", SqlDbType.Int, 4, pageSize),
						db.MakeInParam("@strWhere", SqlDbType.NVarChar, 500, strWhere),
						db.MakeInParam("@orderBy", SqlDbType.NVarChar, 500, orderBy),
						db.MakeOutParam("@count", SqlDbType.Int, 4)
					};

                    _p = db.FromatParameters(parameters);

                    //记录操作日志
                    Logger.Debug(GetType().FullName + "." + MethodBase.GetCurrentMethod().Name + ",输入参数：exec sp_youhoo_sys_module_getlistbypagepower " + _p);

                    DataTable dt = db.Query(strSql.ToString(), CommandType.StoredProcedure, parameters);
                    count = Convert.ToInt32(parameters[parameters.Length - 1].Value);
                    return dt;
                }
            }
            catch (Exception ex)
            {
                //记录错误日志
                Logger.Error(GetType().FullName + "." + MethodBase.GetCurrentMethod().Name + ", 错误原因：" + ex.Message + ", 输入参数：exec sp_youhoo_sys_module_getlistbypagepower " + _p);
                throw ex;
            }
        }
        #endregion  成员方法
    }
}
