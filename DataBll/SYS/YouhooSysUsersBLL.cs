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
	/// 业务逻辑类：YouhooSysUsersBLL
	/// 时间：2015/3/27 11:10:27
	/// </summary>
	public class YouhooSysUsersBLL
	{
		private readonly YouhooSysUsersDAL dal=new YouhooSysUsersDAL();
		public static string CacheName = "YouhooSysUsersDAL-";

		public YouhooSysUsersBLL()
		{}
		#region  成员方法
		/// <summary>
		/// 是否存在该记录
        /// </summary>
        [RemarkAttribute(Remark = "是否存在该记录")]
        public bool Exists(string username)
		{
            return dal.Exists(username);
		}

        /// <summary>
        /// 添加/修改一条数据
        /// </summary>
        [RemarkAttribute(Remark = "添加/修改一条数据")]
        public int InsertUpdate(YouhooSysUsersModel model, int operatorId)
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
        /// 密码重置
        /// </summary>
        [RemarkAttribute(Remark = "密码重置")]
        public int PwdReset(string arrayId, string newPwd, int operatorId)
        {
            CacheHelper.RemoveSearchCache(CacheName);
            return dal.PwdReset(arrayId, newPwd, operatorId);
        }

        /// <summary>
        /// 冻结一条数据
        /// </summary>
        [RemarkAttribute(Remark = "冻结一条数据")]
        public int Freeze(string arrayId, int operatorId)
        {
            CacheHelper.RemoveSearchCache(CacheName);
            return dal.Freeze(arrayId, operatorId);
        }

        /// <summary>
        /// 取消冻结一条数据
        /// </summary>
        [RemarkAttribute(Remark = "取消冻结一条数据")]
        public int CancelFreeze(string arrayId, int operatorId)
        {
            CacheHelper.RemoveSearchCache(CacheName);
            return dal.CancelFreeze(arrayId, operatorId);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        [RemarkAttribute(Remark = "得到一个对象实体")]
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
        /// 得到一个对象实体
        /// </summary>
        [RemarkAttribute(Remark = "得到一个对象实体")]
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
        /// 根据输入的用户名和密码查找用户
        /// </summary>
        [RemarkAttribute(Remark = "根据输入的用户名和密码查找用户")]
        public YouhooSysUsersModel GetModelByUserNamePassWord(string username, string password)
        {
            YouhooSysUsersModel model = dal.GetModelByUserNamePassWord(username, password);
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
        /// 获得主管信息数据列表
        /// </summary>
        [RemarkAttribute(Remark = "获得数据列表")]
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
				dt = dal.GetListByPage(pageIndex,pageSize,strWhere,orderBy,out count);
				CacheHelper.SetCache(strCache, dt);
				CacheHelper.SetCache(strCacheCount, count);
			}
			return dt;
		}
		#endregion  成员方法
	}
}
