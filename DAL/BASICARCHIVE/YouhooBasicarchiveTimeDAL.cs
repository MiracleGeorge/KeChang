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
	/// ���ݷ����ࣺYouhooBasicarchiveTimeDAL
	/// ʱ�䣺2017/4/5 12:59:39
	/// </summary>
	public class YouhooBasicarchiveTimeDAL
	{
		private string _p = "";

		public YouhooBasicarchiveTimeDAL()
		{}
		#region  ��Ա����
		/// <summary>
		/// �Ƿ���ڸü�¼
		/// </summary>
		public bool Exists(int id)
		{
			try
			{
				using (DBSqlServer db = new DBSqlServer())
				{
					StringBuilder strSql = new StringBuilder();
					strSql.Append("sp_youhoo_BasicArchive_time_exists");
					SqlParameter[] parameters = {
						db.MakeInParam("@id", SqlDbType.Int,4,id)
					};
					
					_p = db.FromatParameters(parameters);
					
					//��¼������־
					Logger.Debug(GetType().FullName + "." + MethodBase.GetCurrentMethod().Name + ",���������exec sp_youhoo_BasicArchive_time_exists " + _p);
					
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
				//��¼������־
				Logger.Error(GetType().FullName + "." + MethodBase.GetCurrentMethod().Name + ", ����ԭ��" + ex.Message + ", ���������exec sp_youhoo_BasicArchive_time_exists " + _p);
				throw ex;
			}
		}

		/// <summary>
		/// ���/�޸�һ������
		/// </summary>
		public int InsertUpdate(YouhooBasicarchiveTimeModel model, int operatorId)
		{
			try
			{
				using (DBSqlServer db = new DBSqlServer())
				{
					StringBuilder strSql = new StringBuilder();
					strSql.Append("sp_youhoo_BasicArchive_time_insertupdate");
					SqlParameter[] parameters = {
						db.MakeInParam("@id", SqlDbType.Int,4,model.Id),
						db.MakeInParam("@Code", SqlDbType.VarChar,50,model.Code),
						db.MakeInParam("@Name", SqlDbType.NVarChar,50,model.Name),
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
					Logger.Debug(GetType().FullName + "." + MethodBase.GetCurrentMethod().Name + ",���������exec sp_youhoo_BasicArchive_time_insertupdate " + _p);
					
					int rows = db.ExectueNoQuery(strSql.ToString(), CommandType.StoredProcedure, parameters);
					model.Id = DataConvert.ToInt32(parameters[parameters.Length - 2].Value);
					return rows;
				}
			}
			catch (Exception ex)
			{
				//��¼������־
				Logger.Error(GetType().FullName + "." + MethodBase.GetCurrentMethod().Name + ", ����ԭ��" + ex.Message + ", ���������exec sp_youhoo_BasicArchive_time_insertupdate " + _p);
				throw ex;
			}
		}

		/// <summary>
		/// ɾ��һ������
		/// </summary>
		public int Delete(string arrayId, int operatorId)
		{
			try
			{
				using (DBSqlServer db = new DBSqlServer())
				{
					StringBuilder strSql = new StringBuilder();
					strSql.Append("sp_youhoo_BasicArchive_time_delete");
					SqlParameter[] parameters = {
						db.MakeInParam("@array_id", SqlDbType.NVarChar, 500, arrayId),
						db.MakeInParam("@operator_id", SqlDbType.Int, 4, operatorId)
					};
					
					_p = db.FromatParameters(parameters);
					
					//��¼������־
					Logger.Debug(GetType().FullName + "." + MethodBase.GetCurrentMethod().Name + ",���������exec sp_youhoo_BasicArchive_time_delete " + _p);
					
					return db.ExectueNoQuery(strSql.ToString(), CommandType.StoredProcedure, parameters);
				}
			}
			catch (Exception ex)
			{
				//��¼������־
				Logger.Error(GetType().FullName + "." + MethodBase.GetCurrentMethod().Name + ", ����ԭ��" + ex.Message + ", ���������exec sp_youhoo_BasicArchive_time_delete " + _p);
				throw ex;
			}
		}

		/// <summary>
		/// �õ�һ������ʵ��
		/// </summary>
		public YouhooBasicarchiveTimeModel GetModel(int id)
		{
			try
			{
				using (DBSqlServer db = new DBSqlServer())
				{
					StringBuilder strSql = new StringBuilder();
					strSql.Append("sp_youhoo_BasicArchive_time_getmodel");
					SqlParameter[] parameters = {
						db.MakeInParam("@id", SqlDbType.Int,4,id)
					};
					
					_p = db.FromatParameters(parameters);
					
					//��¼������־
					Logger.Debug(GetType().FullName + "." + MethodBase.GetCurrentMethod().Name + ",���������exec sp_youhoo_BasicArchive_time_getmodel " + _p);
					
					DataTable dt = db.Query(strSql.ToString(), CommandType.StoredProcedure, parameters);
					if (dt != null && dt.Rows.Count != 0)
						return new YouhooBasicarchiveTimeModel(dt.Rows[0]);
					return null;
				}
			}
			catch (Exception ex)
			{
				//��¼������־
				Logger.Error(GetType().FullName + "." + MethodBase.GetCurrentMethod().Name + ", ����ԭ��" + ex.Message + ", ���������exec sp_youhoo_BasicArchive_time_getmodel " + _p);
				throw ex;
			}
		}

		/// <summary>
		/// ��������б�
		/// </summary>
		public DataTable GetList(string strWhere)
		{
			try
			{
				using (DBSqlServer db = new DBSqlServer())
				{
					StringBuilder strSql = new StringBuilder();
					strSql.Append("sp_youhoo_BasicArchive_time_getlist");
					SqlParameter[] parameters = {
						db.MakeInParam("@strWhere", SqlDbType.NVarChar, 500, strWhere)
					};
					
					_p = db.FromatParameters(parameters);
					
					//��¼������־
					Logger.Debug(GetType().FullName + "." + MethodBase.GetCurrentMethod().Name + ",���������exec sp_youhoo_BasicArchive_time_getlist " + _p);
					
					DataTable dt = db.Query(strSql.ToString(), CommandType.StoredProcedure, parameters);
					return dt;
				}
			}
			catch (Exception ex)
			{
				//��¼������־
				Logger.Error(GetType().FullName + "." + MethodBase.GetCurrentMethod().Name + ", ����ԭ��" + ex.Message + ", ���������exec sp_youhoo_BasicArchive_time_getlist " + _p);
				throw ex;
			}
		}

		/// <summary>
		/// ��������б�
		/// </summary>
		public DataTable GetListByPage(int pageIndex, int pageSize, string strWhere, string orderBy, out int count)
		{
			try
			{
				using (DBSqlServer db = new DBSqlServer())
				{
					StringBuilder strSql = new StringBuilder();
					strSql.Append("sp_youhoo_BasicArchive_time_getlistbypage");
					SqlParameter[] parameters = {
						db.MakeInParam("@pageIndex", SqlDbType.Int, 4, pageIndex),
						db.MakeInParam("@pageSize", SqlDbType.Int, 4, pageSize),
						db.MakeInParam("@strWhere", SqlDbType.NVarChar, 500, strWhere),
						db.MakeInParam("@orderBy", SqlDbType.NVarChar, 500, orderBy),
						db.MakeOutParam("@count", SqlDbType.Int, 4)
					};
					
					_p = db.FromatParameters(parameters);
					
					//��¼������־
					Logger.Debug(GetType().FullName + "." + MethodBase.GetCurrentMethod().Name + ",���������exec sp_youhoo_BasicArchive_time_getlistbypage " + _p);
					
					DataTable dt = db.Query(strSql.ToString(), CommandType.StoredProcedure, parameters);
					count = Convert.ToInt32(parameters[parameters.Length - 1].Value);
					return dt;
				}
			}
			catch (Exception ex)
			{
				//��¼������־
				Logger.Error(GetType().FullName + "." + MethodBase.GetCurrentMethod().Name + ", ����ԭ��" + ex.Message + ", ���������exec sp_youhoo_BasicArchive_time_getlistbypage " + _p);
				throw ex;
			}
		}
		#endregion  ��Ա����
	}
}
