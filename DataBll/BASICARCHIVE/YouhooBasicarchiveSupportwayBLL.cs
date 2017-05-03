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
	/// ҵ���߼��ࣺYouhooBasicarchiveSupportwayBLL
	/// ʱ�䣺2017/4/5 12:59:39
	/// </summary>
	public class YouhooBasicarchiveSupportwayBLL
	{
		private readonly YouhooBasicarchiveSupportwayDAL dal=new YouhooBasicarchiveSupportwayDAL();
		public static string CacheName = "YouhooBasicarchiveSupportwayDAL-";

		public YouhooBasicarchiveSupportwayBLL()
		{}
		#region  ��Ա����
		/// <summary>
		/// �Ƿ���ڸü�¼
		/// </summary>
		public bool Exists(int id)
		{
			return dal.Exists(id);
		}

		/// <summary>
		/// ����/�޸�һ������
		/// </summary>
		public int InsertUpdate(YouhooBasicarchiveSupportwayModel model, int operatorId)
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
		public YouhooBasicarchiveSupportwayModel GetModel(int id)
		{
			string strCache = string.Format(CacheName + "GetModel-{0}", id);
			YouhooBasicarchiveSupportwayModel model = CacheHelper.GetCache(strCache) as YouhooBasicarchiveSupportwayModel;
			if (model == null)
			{
				model = dal.GetModel(id);
				CacheHelper.SetCache(strCache, model);
			}
			return model;
		}

		/// <summary>
		/// ��������б�
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
		/// ��������б�
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
		#endregion  ��Ա����
	}
}