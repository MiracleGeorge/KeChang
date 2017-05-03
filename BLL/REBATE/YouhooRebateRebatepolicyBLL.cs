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
	/// 业务逻辑类：YouhooRebateRebatepolicyBLL
	/// 时间：2017/4/5 23:45:03
	/// </summary>
	public class YouhooRebateRebatepolicyBLL
	{
		private readonly YouhooRebateRebatepolicyDAL dal=new YouhooRebateRebatepolicyDAL();
		public static string CacheName = "YouhooRebateRebatepolicyDAL-";

		public YouhooRebateRebatepolicyBLL()
		{}
		#region  成员方法
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int id)
		{
			return dal.Exists(id);
		}

		/// <summary>
		/// 添加/修改一条数据
		/// </summary>
		public int InsertUpdate(YouhooRebateRebatepolicyModel model, int operatorId)
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
		public YouhooRebateRebatepolicyModel GetModel(int id)
		{
			string strCache = string.Format(CacheName + "GetModel-{0}", id);
			YouhooRebateRebatepolicyModel model = CacheHelper.GetCache(strCache) as YouhooRebateRebatepolicyModel;
			if (model == null)
			{
				model = dal.GetModel(id);
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
