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
    /// ҵ���߼��ࣺYouhooSysPowergroupBLL
    /// ʱ�䣺2015/4/8 15:49:42
    /// </summary>
    public class YouhooSysPowergroupBLL
    {
        private readonly YouhooSysPowergroupDAL dal = new YouhooSysPowergroupDAL();
        public static string CacheName = "YouhooSysPowergroupDAL-";

        public YouhooSysPowergroupBLL()
        { }
        #region  ��Ա����
        /// <summary>
        /// �Ƿ���ڸü�¼
        /// </summary>
        [RemarkAttribute(Remark = "�Ƿ���ڸü�¼")]
        public bool Exists(int powergroupId)
        {
            return dal.Exists(powergroupId);
        }

        /// <summary>
        /// ���/�޸�һ������
        /// </summary>
        [RemarkAttribute(Remark = "���/�޸�һ������")]
        public int InsertUpdate(YouhooSysPowergroupModel model, int operatorId)
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
        /// �õ�һ������ʵ��
        /// </summary>
        [RemarkAttribute(Remark = "�õ�һ������ʵ��")]
        public YouhooSysPowergroupModel GetModel(int powergroupId)
        {
            string strCache = string.Format(CacheName + "GetModel-{0}", powergroupId);
            YouhooSysPowergroupModel model = CacheHelper.GetCache(strCache) as YouhooSysPowergroupModel;
            if (model == null)
            {
                model = dal.GetModel(powergroupId);
                CacheHelper.SetCache(strCache, model);
            }
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
        [RemarkAttribute(Remark = "��������б�")]
        public DataTable GetListByPage(int pageIndex, int pageSize, string strWhere, string orderBy, out int count)
        {
            string strCache = string.Format(CacheName + "GetListByPage-{0}-{1}-{2}-{3}", pageIndex, pageSize, FormsAuthentication.HashPasswordForStoringInConfigFile(strWhere, "md5"), FormsAuthentication.HashPasswordForStoringInConfigFile(orderBy, "md5"));
            string strCacheCount = strCache + "GetListByPage-Count";
            DataTable dt = CacheHelper.GetCache(strCache) as DataTable;
            count = Converts.ToInt32(CacheHelper.GetCache(strCacheCount));
            if (dt == null)
            {
                dt = dal.GetListByPage(pageIndex, pageSize, strWhere, orderBy, out count);
                CacheHelper.SetCache(strCache, dt);
                CacheHelper.SetCache(strCacheCount, count);
            }
            return dt;
        }
        #endregion  ��Ա����
    }
}
