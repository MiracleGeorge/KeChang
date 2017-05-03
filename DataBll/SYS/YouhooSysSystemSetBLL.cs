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
    /// 业务逻辑类：YouhooSysSystemSetBLL
    /// 时间：2016/1/25 15:53:12
    /// </summary>
    public class YouhooSysSystemSetBLL
    {
        private readonly YouhooSysSystemSetDAL dal = new YouhooSysSystemSetDAL();
        public static string CacheName = "YouhooSysSystemSetDAL-";

        public YouhooSysSystemSetBLL()
        { }
        #region  成员方法
        /// <summary>
        /// 添加/修改一条数据
        /// </summary>
        [RemarkAttribute(Remark = "添加/修改一条数据")]
        public int InsertUpdate(YouhooSysSystemSetModel model, int operatorId)
        {
            CacheHelper.RemoveSearchCache(CacheName);
            return dal.InsertUpdate(model, operatorId);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        [RemarkAttribute(Remark = "得到一个对象实体")]
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
        #endregion  成员方法
    }
}
