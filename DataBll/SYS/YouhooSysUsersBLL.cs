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
	/// ҵ���߼��ࣺYouhooSysUsersBLL
	/// ʱ�䣺2015/3/27 11:10:27
	/// </summary>
	public class YouhooSysUsersBLL
	{
		private readonly YouhooSysUsersDAL dal=new YouhooSysUsersDAL();
		public static string CacheName = "YouhooSysUsersDAL-";

		public YouhooSysUsersBLL()
		{}
		#region  ��Ա����
		/// <summary>
		/// �Ƿ���ڸü�¼
        /// </summary>
        [RemarkAttribute(Remark = "�Ƿ���ڸü�¼")]
        public bool Exists(string username)
		{
            return dal.Exists(username);
		}

        /// <summary>
        /// ���/�޸�һ������
        /// </summary>
        [RemarkAttribute(Remark = "���/�޸�һ������")]
        public int InsertUpdate(YouhooSysUsersModel model, int operatorId)
        {
            CacheHelper.RemoveSearchCache(CacheName);
            return dal.InsertUpdate(model, operatorId);
        }

        /// <summary>
        /// ɾ��һ������
        /// </summary>
        [RemarkAttribute(Remark = "ɾ��һ������")]
        public int Delete(string arrayId, int operatorId)
        {
            CacheHelper.RemoveSearchCache(CacheName);
            return dal.Delete(arrayId, operatorId);
        }

        /// <summary>
        /// ��������
        /// </summary>
        [RemarkAttribute(Remark = "��������")]
        public int PwdReset(string arrayId, string newPwd, int operatorId)
        {
            CacheHelper.RemoveSearchCache(CacheName);
            return dal.PwdReset(arrayId, newPwd, operatorId);
        }

        /// <summary>
        /// ����һ������
        /// </summary>
        [RemarkAttribute(Remark = "����һ������")]
        public int Freeze(string arrayId, int operatorId)
        {
            CacheHelper.RemoveSearchCache(CacheName);
            return dal.Freeze(arrayId, operatorId);
        }

        /// <summary>
        /// ȡ������һ������
        /// </summary>
        [RemarkAttribute(Remark = "ȡ������һ������")]
        public int CancelFreeze(string arrayId, int operatorId)
        {
            CacheHelper.RemoveSearchCache(CacheName);
            return dal.CancelFreeze(arrayId, operatorId);
        }

        /// <summary>
        /// �õ�һ������ʵ��
        /// </summary>
        [RemarkAttribute(Remark = "�õ�һ������ʵ��")]
        public YouhooSysUsersModel GetModel(int userId)
        {
            string strCache = string.Format(CacheName + "GetModel-{0}", userId);
            YouhooSysUsersModel model = CacheHelper.GetCache(strCache) as YouhooSysUsersModel;
            if (model == null)
            {
                model = dal.GetModel(userId);
                CacheHelper.SetCache(strCache, model);
            }
            return model;
        }

        /// <summary>
        /// �õ�һ������ʵ��
        /// </summary>
        [RemarkAttribute(Remark = "�õ�һ������ʵ��")]
        public YouhooSysUsersModel GetModelByLevel(int levelId)
        {
            string strCache = string.Format(CacheName + "GetModel-{0}", levelId);
            YouhooSysUsersModel model = CacheHelper.GetCache(strCache) as YouhooSysUsersModel;
            if (model == null)
            {
                model = dal.GetModelByLevel(levelId);
                CacheHelper.SetCache(strCache, model);
            }
            return model;
        }

        /// <summary>
        /// ����������û�������������û�
        /// </summary>
        [RemarkAttribute(Remark = "����������û�������������û�")]
        public YouhooSysUsersModel GetModelByUserNamePassWord(string username, string password)
        {
            YouhooSysUsersModel model = dal.GetModelByUserNamePassWord(username, password);
            return model;
        }

		/// <summary>
		/// ��������б�
        /// </summary>
        [RemarkAttribute(Remark = "��������б�")]
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
        public DataTable GetIsManList(string strWhere)
        {
            string strCache = string.Format(CacheName + "GetList-{0}", FormsAuthentication.HashPasswordForStoringInConfigFile(strWhere, "md5"));
            DataTable dt = CacheHelper.GetCache(strCache) as DataTable;
            if (dt == null)
            {
                dt = dal.GetIsManList(strWhere);
                CacheHelper.SetCache(strCache, dt);
            }
            return dt;
        }

        /// <summary>
        /// ���������Ϣ�����б�
        /// </summary>
        [RemarkAttribute(Remark = "��������б�")]
        public DataTable GetUserMainList(string strWhere)
        {
            string strCache = string.Format(CacheName + "GetList-{0}", FormsAuthentication.HashPasswordForStoringInConfigFile(strWhere, "md5"));
            DataTable dt = CacheHelper.GetCache(strCache) as DataTable;
            if (dt == null)
            {
                dt = dal.GetUserMainList(strWhere);
                CacheHelper.SetCache(strCache, dt);
            }
            return dt;
        }

		/// <summary>
		/// ��������б�
        /// </summary>
        [RemarkAttribute(Remark = "��������б�")]
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
