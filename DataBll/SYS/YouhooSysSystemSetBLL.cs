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
    /// ҵ���߼��ࣺYouhooSysSystemSetBLL
    /// ʱ�䣺2016/1/25 15:53:12
    /// </summary>
    public class YouhooSysSystemSetBLL
    {
        private readonly YouhooSysSystemSetDAL dal = new YouhooSysSystemSetDAL();
        public static string CacheName = "YouhooSysSystemSetDAL-";

        public YouhooSysSystemSetBLL()
        { }
        #region  ��Ա����
        /// <summary>
        /// ���/�޸�һ������
        /// </summary>
        [RemarkAttribute(Remark = "���/�޸�һ������")]
        public int InsertUpdate(YouhooSysSystemSetModel model, int operatorId)
        {
            CacheHelper.RemoveSearchCache(CacheName);
            return dal.InsertUpdate(model, operatorId);
        }

        /// <summary>
        /// �õ�һ������ʵ��
        /// </summary>
        [RemarkAttribute(Remark = "�õ�һ������ʵ��")]
        public YouhooSysSystemSetModel GetModel()
        {
            string strCache = string.Format(CacheName + "GetModel");
            YouhooSysSystemSetModel model = CacheHelper.GetCache(strCache) as YouhooSysSystemSetModel;
            if (model == null)
            {
                model = dal.GetModel();
                CacheHelper.SetCache(strCache, model);
            }
            return model;
        }
        #endregion  ��Ա����
    }
}
