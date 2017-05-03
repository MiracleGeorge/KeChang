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
	/// ���ݷ����ࣺYouhooSysSystemSetDAL
	/// ʱ�䣺2016/4/21 14:01:52
	/// </summary>
	public class YouhooSysSystemSetDAL
	{
		private string _p = "";

		public YouhooSysSystemSetDAL()
		{}
		#region  ��Ա����
		/// <summary>
		/// ���/�޸�һ������
		/// </summary>
		public int InsertUpdate(YouhooSysSystemSetModel model, int operatorId)
		{
			try
			{
				using (DBSqlServer db = new DBSqlServer())
				{
					StringBuilder strSql = new StringBuilder();
					strSql.Append("sp_youhoo_sys_system_set_insertupdate");
                    SqlParameter[] parameters = {
						db.MakeInParam("@system_set_id", SqlDbType.Int,4,model.SystemSetId),
						db.MakeInParam("@system_set_name", SqlDbType.NVarChar,50,model.SystemSetName),
						db.MakeInParam("@system_set_hou_logo", SqlDbType.NVarChar,200,model.SystemSetHouLogo),
						db.MakeInParam("@system_set_login_biaozhi", SqlDbType.NVarChar,200,model.SystemSetLoginBiaozhi),
						db.MakeInParam("@system_set_icon", SqlDbType.NVarChar,200,model.SystemSetIcon),
						db.MakeInParam("@initial_pwd", SqlDbType.NVarChar,16,model.InitialPwd),
						db.MakeInParam("@list_show_count", SqlDbType.Int,4,model.ListShowCount),
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
					
					//��¼������־
					Logger.Debug(GetType().FullName + "." + MethodBase.GetCurrentMethod().Name + ",���������exec sp_youhoo_sys_system_set_insertupdate " + _p);
					
					int rows = db.ExectueNoQuery(strSql.ToString(), CommandType.StoredProcedure, parameters);
					model.SystemSetId = DataConvert.ToInt32(parameters[parameters.Length - 2].Value);
					return rows;
				}
			}
			catch (Exception ex)
			{
				//��¼������־
				Logger.Error(GetType().FullName + "." + MethodBase.GetCurrentMethod().Name + ", ����ԭ��" + ex.Message + ", ���������exec sp_youhoo_sys_system_set_insertupdate " + _p);
				throw ex;
			}
		}

		/// <summary>
		/// �õ�һ������ʵ��
		/// </summary>
		public YouhooSysSystemSetModel GetModel()
		{
			try
			{
				using (DBSqlServer db = new DBSqlServer())
				{
					StringBuilder strSql = new StringBuilder();
					strSql.Append("sp_youhoo_sys_system_set_getmodel");
					SqlParameter[] parameters = {
						db.MakeInParam("@system_set_id", SqlDbType.Int,4,1)
					};
					
					_p = db.FromatParameters(parameters);
					
					//��¼������־
					Logger.Debug(GetType().FullName + "." + MethodBase.GetCurrentMethod().Name + ",���������exec sp_youhoo_sys_system_set_getmodel " + _p);
					
					DataTable dt = db.Query(strSql.ToString(), CommandType.StoredProcedure, parameters);
					if (dt != null && dt.Rows.Count != 0)
						return new YouhooSysSystemSetModel(dt.Rows[0]);
					return null;
				}
			}
			catch (Exception ex)
			{
				//��¼������־
				Logger.Error(GetType().FullName + "." + MethodBase.GetCurrentMethod().Name + ", ����ԭ��" + ex.Message + ", ���������exec sp_youhoo_sys_system_set_getmodel " + _p);
				throw ex;
			}
		}
		#endregion  ��Ա����
	}
}
