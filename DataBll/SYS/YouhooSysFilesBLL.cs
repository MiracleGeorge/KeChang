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
    /// 业务逻辑类：YouhooSysFilesBLL
    /// 时间：2015/4/8 15:49:40
    /// </summary>
    public class YouhooSysFilesBLL
    {
        private readonly YouhooSysFilesDAL dal = new YouhooSysFilesDAL();
        public static string CacheName = "YouhooSysFilesDAL-";

        public YouhooSysFilesBLL()
        { }
        #region  成员方法
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        [RemarkAttribute(Remark = "是否存在该记录")]
        public bool Exists(int fileId)
        {
            return dal.Exists(fileId);
        }

        /// <summary>
        /// 添加/修改一条数据
        /// </summary>
        [RemarkAttribute(Remark = "添加/修改一条数据")]
        public int InsertUpdate(YouhooSysFilesModel model, int operatorId)
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
        public YouhooSysFilesModel GetModel(int fileId)
        {
            string strCache = string.Format(CacheName + "GetModel-{0}", fileId);
            YouhooSysFilesModel model = CacheHelper.GetCache(strCache) as YouhooSysFilesModel;
            if (model == null)
            {
                model = dal.GetModel(fileId);
                CacheHelper.SetCache(strCache, model);
            }
            return model;
        }

        /// <summary>
        /// 根据合同ID得到对应实体
        /// </summary>
        [RemarkAttribute(Remark = "得到一个对象实体")]
        public YouhooSysFilesModel GetModelbyContractid(int table_file_id)
        {
            string strCache = string.Format(CacheName + "GetModelbyContractid-{0}", table_file_id);
            YouhooSysFilesModel model = CacheHelper.GetCache(strCache) as YouhooSysFilesModel;
            if (model == null)
            {
                model = dal.GetModelbyContractid(table_file_id);
                CacheHelper.SetCache(strCache, model);
            }
            return model;
        }

        /// <summary>
        /// 获取图片路径
        /// </summary>
        [RemarkAttribute(Remark = "获取图片路径")]
        public string GetFilePath(int tableId, int tableFileId)
        {
            string strCache = string.Format(CacheName + "GetFilePath-{0}-{1}", tableId, tableFileId);
            string filePath = CacheHelper.GetCache(strCache) as string;
            if (filePath == null)
            {
                filePath = dal.GetFilePath(tableId, tableFileId);
                CacheHelper.SetCache(strCache, filePath);
            }
            return filePath;
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        [RemarkAttribute(Remark = "获得数据列表")]
        public DataTable GetList(int tableId, int tableFileId)
        {
            string strCache = string.Format(CacheName + "GetList-{0}-{1}", tableId, tableFileId);
            DataTable dt = CacheHelper.GetCache(strCache) as DataTable;
            if (dt == null)
            {
                dt = dal.GetList(tableId, tableFileId);
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
