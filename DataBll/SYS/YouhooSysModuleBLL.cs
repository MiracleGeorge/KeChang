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
    /// 业务逻辑类：YouhooSysModuleBLL
    /// 时间：2015/4/8 15:49:40
    /// </summary>
    public class YouhooSysModuleBLL
    {
        private readonly YouhooSysModuleDAL dal = new YouhooSysModuleDAL();
        public static string CacheName = "YouhooSysModuleDAL-";

        public YouhooSysModuleBLL()
        { }
        #region  成员方法
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        [RemarkAttribute(Remark = "是否存在该记录")]
        public bool Exists(int moduleId)
        {
            return dal.Exists(moduleId);
        }

        /// <summary>
        /// 添加/修改一条数据
        /// </summary>
        [RemarkAttribute(Remark = "添加/修改一条数据")]
        public int InsertUpdate(YouhooSysModuleModel model, int operatorId)
        {
            CacheHelper.RemoveSearchCache(CacheName);
            return dal.InsertUpdate(model, operatorId);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        [RemarkAttribute(Remark = "删除一条数据")]
        public int Delete(string arrayId, int operatorId)
        {
            CacheHelper.RemoveSearchCache(CacheName);
            return dal.Delete(arrayId, operatorId);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        [RemarkAttribute(Remark = "得到一个对象实体")]
        public YouhooSysModuleModel GetModel(int moduleId)
        {
            string strCache = string.Format(CacheName + "GetModel-{0}", moduleId);
            YouhooSysModuleModel model = CacheHelper.GetCache(strCache) as YouhooSysModuleModel;
            if (model == null)
            {
                model = dal.GetModel(moduleId);
                CacheHelper.SetCache(strCache, model);
            }
            return model;
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        [RemarkAttribute(Remark = "获得数据列表")]
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
        [RemarkAttribute(Remark = "获得数据列表")]
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
        #endregion  成员方法
    }
}
