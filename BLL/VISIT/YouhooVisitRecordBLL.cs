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
	/// 业务逻辑类：YouhooVisitRecordBLL
	/// 时间：2017/4/24 12:00:53
	/// </summary>
	public class YouhooVisitRecordBLL
	{
		private readonly YouhooVisitRecordDAL dal=new YouhooVisitRecordDAL();
		public static string CacheName = "YouhooVisitRecordDAL-";

		public YouhooVisitRecordBLL()
		{}
		#region  成员方法
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int visitId)
		{
			return dal.Exists(visitId);
		}

		/// <summary>
		/// 添加/修改一条数据
		/// </summary>
		public int InsertUpdate(YouhooVisitRecordModel model, int operatorId)
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
		public YouhooVisitRecordModel GetModel(int visitId)
		{
			string strCache = string.Format(CacheName + "GetModel-{0}", visitId);
			YouhooVisitRecordModel model = CacheHelper.GetCache(strCache) as YouhooVisitRecordModel;
			if (model == null)
			{
				model = dal.GetModel(visitId);
				CacheHelper.SetCache(strCache, model);
			}
			return model;
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataTable GetList(string strWhere)
		{
			string strCache = string.Format(CacheName + "GetList-{0}", StringHelper.Md5(strWhere));
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
			string strCache = string.Format(CacheName + "GetListByPage-{0}-{1}-{2}-{3}", pageIndex, pageSize, StringHelper.Md5(strWhere), StringHelper.Md5(orderBy));
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
