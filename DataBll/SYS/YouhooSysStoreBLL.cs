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
	/// ҵ���߼��ࣺYouhooSysStoreBLL
	/// ʱ�䣺2017-03-02 9:52:28
	/// </summary>
	public class YouhooSysStoreBLL
	{
		private readonly YouhooSysStoreDAL dal=new YouhooSysStoreDAL();
		public static string CacheName = "YouhooSysStoreDAL-";

		public YouhooSysStoreBLL()
		{}
		#region  ��Ա����
		/// <summary>
		/// �Ƿ���ڸü�¼
		/// </summary>
		public bool Exists(int Id)
		{
			return dal.Exists(Id);
		}

		/// <summary>
		/// ���/�޸�һ������
		/// </summary>
		public int InsertUpdate(YouhooSysStoreModel model, int operatorId)
		{
			CacheHelper.RemoveSearchCache(CacheName);
			return dal.InsertUpdate(model, operatorId);
		}

		/// <summary>
		/// ɾ��һ������
		/// </summary>
		public int Delete(string arrayId, int operatorId)
		{
			CacheHelper.RemoveSearchCache(CacheName);
			return dal.Delete(arrayId, operatorId);
		}

		/// <summary>
		/// �õ�һ������ʵ��
		/// </summary>
		public YouhooSysStoreModel GetModel(int Id)
		{
			string strCache = string.Format(CacheName + "GetModel-{0}", Id);
			YouhooSysStoreModel model = CacheHelper.GetCache(strCache) as YouhooSysStoreModel;
			if (model == null)
			{
				model = dal.GetModel(Id);
				CacheHelper.SetCache(strCache, model);
			}
			return model;
		}

		/// <summary>
		/// ��������б�
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
		/// ��������б�
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
		#endregion  ��Ա����
	}
}
