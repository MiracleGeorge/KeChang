using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using YouHoo.DataModel;
using YouHoo.DataOperation;
using YouHoo.DataTools;
using System.Web.Security;

namespace YouHoo.DataBll
{
	/// <summary>
	/// 业务逻辑类：YouhooSysNodeBLL
	/// 时间：2017-03-02 16:08:48
	/// </summary>
	public class YouhooSysNodeBLL
	{
		private readonly YouhooSysNodeDAL dal=new YouhooSysNodeDAL();
		public static string CacheName = "YouhooSysNodeDAL-";

		public YouhooSysNodeBLL()
		{}
		#region  成员方法
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int ID)
		{
			return dal.Exists(ID);
		}

		/// <summary>
		/// 添加/修改一条数据
		/// </summary>
		public int InsertUpdate(YouhooSysNodeModel model, int operatorId)
		{
			CacheHelper.RemoveSearchCache(CacheName);
			return dal.InsertUpdate(model, operatorId);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public int Delete(string arrayId, int operatorId)
		{
			CacheHelper.RemoveSearchCache(CacheName);
			return dal.Delete(arrayId, operatorId);
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public YouhooSysNodeModel GetModel(int ID)
		{
			string strCache = string.Format(CacheName + "GetModel-{0}", ID);
			YouhooSysNodeModel model = CacheHelper.GetCache(strCache) as YouhooSysNodeModel;
			if (model == null)
			{
				model = dal.GetModel(ID);
				CacheHelper.SetCache(strCache, model);
			}
			return model;
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataTable GetList(string strWhere)
		{
			string strCache = string.Format(CacheName + "GetList-{0}", FormsAuthentication.HashPasswordForStoringInConfigFile(strWhere, "md5"));
			DataTable dt = CacheHelper.GetCache(strCache) as DataTable;
			if (dt == null)
			{
				dt = dal.GetList(strWhere);
				CacheHelper.SetCache(strCache, dt);
			}
			return dt;
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataTable GetListByPage(int pageIndex, int pageSize, string strWhere, string orderBy, out int count)
		{
			string strCache = string.Format(CacheName + "GetListByPage-{0}-{1}-{2}-{3}", pageIndex, pageSize, FormsAuthentication.HashPasswordForStoringInConfigFile(strWhere, "md5"), FormsAuthentication.HashPasswordForStoringInConfigFile(orderBy, "md5"));
			string strCacheCount = strCache + "GetListByPage-Count";
			DataTable dt = CacheHelper.GetCache(strCache) as DataTable;
			count = Converts.ToInt32(CacheHelper.GetCache(strCacheCount));
			if (dt == null)
			{
				dt = dal.GetListByPage(pageIndex,pageSize,strWhere,orderBy,out count);
				CacheHelper.SetCache(strCache, dt);
				CacheHelper.SetCache(strCacheCount, count);
			}
			return dt;
		}
		#endregion  成员方法
	}
}
