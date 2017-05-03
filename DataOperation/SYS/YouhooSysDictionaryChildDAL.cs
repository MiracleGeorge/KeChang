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
    /// 数据访问类：YouhooSysDictionaryChildDAL
    /// 时间：2015/4/8 10:49:20
    /// </summary>
    public class YouhooSysDictionaryChildDAL
    {
        private string _p = "";

        public YouhooSysDictionaryChildDAL()
        { }
        #region  成员方法
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int dictionaryChildId)
        {
            try
            {
                using (DBSqlServer db = new DBSqlServer())
                {
                    StringBuilder strSql = new StringBuilder();
                    strSql.Append("sp_youhoo_sys_dictionary_child_exists");
                    SqlParameter[] parameters = {
						db.MakeInParam("@dictionary_child_id", SqlDbType.Int,4,dictionaryChildId)
					};

                    _p = db.FromatParameters(parameters);

                    //记录操作日志
                    Logger.Debug(GetType().FullName + "." + MethodBase.GetCurrentMethod().Name + ",输入参数：exec sp_youhoo_sys_dictionary_child_exists " + _p);

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
                Logger.Error(GetType().FullName + "." + MethodBase.GetCurrentMethod().Name + ", 错误原因：" + ex.Message + ", 输入参数：exec sp_youhoo_sys_dictionary_child_exists " + _p);
                throw ex;
            }
        }

        /// <summary>
        /// 根据选项ID获取选项名称
        /// </summary>
        public string GetDictionaryChildName(int dictionaryChildId)
        {
            try
            {
                using (DBSqlServer db = new DBSqlServer())
                {
                    StringBuilder strSql = new StringBuilder();
                    strSql.Append("sp_youhoo_sys_dictionary_child_getdictionarychildname");
                    SqlParameter[] parameters = {
						db.MakeInParam("@dictionary_child_id", SqlDbType.Int,4,dictionaryChildId)
					};

                    _p = db.FromatParameters(parameters);

                    //记录操作日志
                    Logger.Debug(GetType().FullName + "." + MethodBase.GetCurrentMethod().Name + ",输入参数：exec sp_youhoo_sys_dictionary_child_getdictionarychildname " + _p);

                    object obj = db.GetSingle(strSql.ToString(), CommandType.StoredProcedure, parameters);
                    if ((Object.Equals(obj, null)) || (Object.Equals(obj, System.DBNull.Value)) || (Object.Equals(obj, 0)))
                    {
                        return "";
                    }
                    else
                    {
                        return obj.ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                //记录错误日志
                Logger.Error(GetType().FullName + "." + MethodBase.GetCurrentMethod().Name + ", 错误原因：" + ex.Message + ", 输入参数：exec sp_youhoo_sys_dictionary_child_getdictionarychildname " + _p);
                throw ex;
            }
        }

        /// <summary>
        ///  添加/修改一条数据
        /// </summary>
        public int InsertUpdate(YouhooSysDictionaryChildModel model, int operatorId)
        {
            try
            {
                using (DBSqlServer db = new DBSqlServer())
                {
                    StringBuilder strSql = new StringBuilder();
                    strSql.Append("sp_youhoo_sys_dictionary_child_insertupdate");
                    SqlParameter[] parameters = {
						db.MakeInParam("@dictionary_child_id", SqlDbType.Int,4,model.DictionaryChildId),
						db.MakeInParam("@dictionary_child_name", SqlDbType.NVarChar,500,model.DictionaryChildName),
						db.MakeInParam("@dictionary_id", SqlDbType.Int,4,model.DictionaryId),
						db.MakeInParam("@parent_dictionary_child_id", SqlDbType.Int,4,model.ParentDictionaryChildId),
						db.MakeInParam("@is_start", SqlDbType.Int,4,model.IsStart),
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
                    Logger.Debug(GetType().FullName + "." + MethodBase.GetCurrentMethod().Name + ",输入参数：exec sp_youhoo_sys_dictionary_child_insertupdate " + _p);

                    int rows = db.ExectueNoQuery(strSql.ToString(), CommandType.StoredProcedure, parameters);
                    model.DictionaryChildId = DataConvert.ToInt32(parameters[parameters.Length - 2].Value);
                    return rows;
                }
            }
            catch (Exception ex)
            {
                //记录错误日志
                Logger.Error(GetType().FullName + "." + MethodBase.GetCurrentMethod().Name + ", 错误原因：" + ex.Message + ", 输入参数：exec sp_youhoo_sys_dictionary_child_insertupdate " + _p);
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
                    strSql.Append("sp_youhoo_sys_dictionary_child_delete");
                    SqlParameter[] parameters = {
						db.MakeInParam("@array_id", SqlDbType.NVarChar, 500, arrayId),
						db.MakeInParam("@operator_id", SqlDbType.Int, 4, operatorId)
					};

                    _p = db.FromatParameters(parameters);

                    //记录操作日志
                    Logger.Debug(GetType().FullName + "." + MethodBase.GetCurrentMethod().Name + ",输入参数：exec sp_youhoo_sys_dictionary_child_delete " + _p);

                    return db.ExectueNoQuery(strSql.ToString(), CommandType.StoredProcedure, parameters);
                }
            }
            catch (Exception ex)
            {
                //记录错误日志
                Logger.Error(GetType().FullName + "." + MethodBase.GetCurrentMethod().Name + ", 错误原因：" + ex.Message + ", 输入参数：exec sp_youhoo_sys_dictionary_child_delete " + _p);
                throw ex;
            }
        }

        /// <summary>
        /// 启用一条数据
        /// </summary>
        public int Start(string arrayId, int operatorId)
        {
            try
            {
                using (DBSqlServer db = new DBSqlServer())
                {
                    StringBuilder strSql = new StringBuilder();
                    strSql.Append("sp_youhoo_sys_dictionary_child_start");
                    SqlParameter[] parameters = {
						db.MakeInParam("@array_id", SqlDbType.NVarChar, 500, arrayId),
						db.MakeInParam("@operator_id", SqlDbType.Int, 4, operatorId)
					};

                    _p = db.FromatParameters(parameters);

                    //记录操作日志
                    Logger.Debug(GetType().FullName + "." + MethodBase.GetCurrentMethod().Name + ",输入参数：exec sp_youhoo_sys_dictionary_child_start " + _p);

                    return db.ExectueNoQuery(strSql.ToString(), CommandType.StoredProcedure, parameters);
                }
            }
            catch (Exception ex)
            {
                //记录错误日志
                Logger.Error(GetType().FullName + "." + MethodBase.GetCurrentMethod().Name + ", 错误原因：" + ex.Message + ", 输入参数：exec sp_youhoo_sys_dictionary_child_start " + _p);
                throw ex;
            }
        }

        /// <summary>
        /// 不启用一条数据
        /// </summary>
        public int Disabled(string arrayId, int operatorId)
        {
            try
            {
                using (DBSqlServer db = new DBSqlServer())
                {
                    StringBuilder strSql = new StringBuilder();
                    strSql.Append("sp_youhoo_sys_dictionary_child_disabled");
                    SqlParameter[] parameters = {
						db.MakeInParam("@array_id", SqlDbType.NVarChar, 500, arrayId),
						db.MakeInParam("@operator_id", SqlDbType.Int, 4, operatorId)
					};

                    _p = db.FromatParameters(parameters);

                    //记录操作日志
                    Logger.Debug(GetType().FullName + "." + MethodBase.GetCurrentMethod().Name + ",输入参数：exec sp_youhoo_sys_dictionary_child_disabled " + _p);

                    return db.ExectueNoQuery(strSql.ToString(), CommandType.StoredProcedure, parameters);
                }
            }
            catch (Exception ex)
            {
                //记录错误日志
                Logger.Error(GetType().FullName + "." + MethodBase.GetCurrentMethod().Name + ", 错误原因：" + ex.Message + ", 输入参数：exec sp_youhoo_sys_dictionary_child_disabled " + _p);
                throw ex;
            }
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public YouhooSysDictionaryChildModel GetModel(int dictionaryChildId)
        {
            try
            {
                using (DBSqlServer db = new DBSqlServer())
                {
                    StringBuilder strSql = new StringBuilder();
                    strSql.Append("sp_youhoo_sys_dictionary_child_getmodel");
                    SqlParameter[] parameters = {
						db.MakeInParam("@dictionary_child_id", SqlDbType.Int,4,dictionaryChildId)
					};

                    _p = db.FromatParameters(parameters);

                    //记录操作日志
                    Logger.Debug(GetType().FullName + "." + MethodBase.GetCurrentMethod().Name + ",输入参数：exec sp_youhoo_sys_dictionary_child_getmodel " + _p);

                    DataTable dt = db.Query(strSql.ToString(), CommandType.StoredProcedure, parameters);
                    if (dt != null && dt.Rows.Count != 0)
                        return new YouhooSysDictionaryChildModel(dt.Rows[0]);
                    return null;
                }
            }
            catch (Exception ex)
            {
                //记录错误日志
                Logger.Error(GetType().FullName + "." + MethodBase.GetCurrentMethod().Name + ", 错误原因：" + ex.Message + ", 输入参数：exec sp_youhoo_sys_dictionary_child_getmodel " + _p);
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
                    strSql.Append("sp_youhoo_sys_dictionary_child_getlist");
                    SqlParameter[] parameters = {
						db.MakeInParam("@strWhere", SqlDbType.NVarChar, 500, strWhere)
					};

                    _p = db.FromatParameters(parameters);

                    //记录操作日志
                    Logger.Debug(GetType().FullName + "." + MethodBase.GetCurrentMethod().Name + ",输入参数：exec sp_youhoo_sys_dictionary_child_getlist " + _p);

                    DataTable dt = db.Query(strSql.ToString(), CommandType.StoredProcedure, parameters);
                    return dt;
                }
            }
            catch (Exception ex)
            {
                //记录错误日志
                Logger.Error(GetType().FullName + "." + MethodBase.GetCurrentMethod().Name + ", 错误原因：" + ex.Message + ", 输入参数：exec sp_youhoo_sys_dictionary_child_getlist " + _p);
                throw ex;
            }
        }

        /// <summary>
        /// 根据字典ID获得数据列表
        /// </summary>
        public DataTable GetListByDictionaryId(int dictionaryId)
        {
            try
            {
                using (DBSqlServer db = new DBSqlServer())
                {
                    StringBuilder strSql = new StringBuilder();
                    strSql.Append("sp_youhoo_sys_dictionary_child_getlistbydictionaryid");
                    SqlParameter[] parameters = {
						db.MakeInParam("@dictionary_id", SqlDbType.Int, 4, dictionaryId)
					};

                    _p = db.FromatParameters(parameters);

                    //记录操作日志
                    Logger.Debug(GetType().FullName + "." + MethodBase.GetCurrentMethod().Name + ",输入参数：exec sp_youhoo_sys_dictionary_child_getlistbydictionaryid " + _p);

                    DataTable dt = db.Query(strSql.ToString(), CommandType.StoredProcedure, parameters);
                    return dt;
                }
            }
            catch (Exception ex)
            {
                //记录错误日志
                Logger.Error(GetType().FullName + "." + MethodBase.GetCurrentMethod().Name + ", 错误原因：" + ex.Message + ", 输入参数：exec sp_youhoo_sys_dictionary_child_getlistbydictionaryid " + _p);
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
                    strSql.Append("sp_youhoo_sys_dictionary_child_getlistbypage");
                    SqlParameter[] parameters = {
						db.MakeInParam("@pageIndex", SqlDbType.Int, 4, pageIndex),
						db.MakeInParam("@pageSize", SqlDbType.Int, 4, pageSize),
						db.MakeInParam("@strWhere", SqlDbType.NVarChar, 500, strWhere),
						db.MakeInParam("@orderBy", SqlDbType.NVarChar, 500, orderBy),
						db.MakeOutParam("@count", SqlDbType.Int, 4)
					};

                    _p = db.FromatParameters(parameters);

                    //记录操作日志
                    Logger.Debug(GetType().FullName + "." + MethodBase.GetCurrentMethod().Name + ",输入参数：exec sp_youhoo_sys_dictionary_child_getlistbypage " + _p);

                    DataTable dt = db.Query(strSql.ToString(), CommandType.StoredProcedure, parameters);
                    count = Convert.ToInt32(parameters[parameters.Length - 1].Value);
                    return dt;
                }
            }
            catch (Exception ex)
            {
                //记录错误日志
                Logger.Error(GetType().FullName + "." + MethodBase.GetCurrentMethod().Name + ", 错误原因：" + ex.Message + ", 输入参数：exec sp_youhoo_sys_dictionary_child_getlistbypage " + _p);
                throw ex;
            }
        }
        #endregion  成员方法
    }
}
