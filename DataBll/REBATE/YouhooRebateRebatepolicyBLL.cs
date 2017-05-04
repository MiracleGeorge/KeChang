using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using YouHoo.DataModel;
using YouHoo.DataOperation;
using YouHoo.DataTools;
using System.Web.Security;
using System.Configuration;
using System.Linq;
using YouHoo.DataBll.REBATE;

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
		public int Delete(string arrayId, int operatorId,string connectStr)
		{
			CacheHelper.RemoveSearchCache(CacheName);
            try
            {
                var strArry = arrayId.Split(',');
                List<int> intMainId = new List<int>();
                foreach (var item in strArry)
                {
                    intMainId.Add(DataConvert.ToInt32(item));
                }
                new DataBll.YouhooRebateRebatepolicyBLL().DeletePolicy(intMainId.ToArray(), connectStr, operatorId);
                return 1;

            }
            catch (Exception e)
            {
                return 0;

                throw new Exception("删除数据失败"+"错误信息:"+e.Message);
            }

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


        public v_RebatePolicy_Relation GetModelRetrunIQ(int id)
        {
            string strCache = string.Format(CacheName + "GetList-{0}","");
            DataBll.REBATE.KechangDataContext kc = new REBATE.KechangDataContext();
            var ret = kc.v_RebatePolicy_Relation.FirstOrDefault(x => x.id==id);
            if (ret!=null)
            {
                CacheHelper.SetCache(strCache, ret);
            }

            return ret;
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

        public REBATE.v_RebatePolicy_Relation GetPolicyArchiveName(int id,string ConnectStr)
        {
            using (REBATE.KechangDataContext kc=new REBATE.KechangDataContext(ConnectStr))
            {
                var ret = kc.v_RebatePolicy_Relation.FirstOrDefault(x=>x.id==id);
                return ret == null ? null : ret;
            }
        }

        public IQueryable GetBrandNameList(string ConnectStr)
        {
            using (REBATE.KechangDataContext kc = new REBATE.KechangDataContext(ConnectStr))
            {
                var ret = kc.youhoo_BasicArchive_brand.Select(x=>new {id=x.id,name=x.Name});

                if (ret.Count() < 1)
                {
                    return null;
                }
                else
                {
                    return ret ;
                }
            }
        }


        /// <summary>
        /// 插入一个新的价格政策（表头表体）
        /// </summary>
        public int InsertNewPolicy(string connectString, REBATE.youhoo_rebate_RebatePolicy tableMain)
        {
            CacheHelper.RemoveSearchCache(CacheName);
            try
            {
                using (REBATE.KechangDataContext kc = new REBATE.KechangDataContext(connectString))
                {
                    //tableMain对象中包含字表信息，主表字表id相关联插入
                    kc.youhoo_rebate_RebatePolicy.InsertOnSubmit(tableMain);
                    //提交
                    kc.SubmitChanges();
                    return 1;
                }
            }
            catch (Exception e)
            {
                return 0;
                throw new Exception("插入价格政策失败"+e.Message);
            }
        }
        /// <summary>
        ///  更新一个新的价格政策（表头+表体）
        /// </summary>
        /// <param name="MainId">主表id</param>
        /// <param name="connectString"></param>
        /// <param name="tableMain"></param>
        public int UpdatePolicy(int MainId, REBATE.youhoo_rebate_RebatePolicy tableMain,string connectString, List<REBATE.youhoo_rebate_RebatePolicys> tableDetails)
        {

            CacheHelper.RemoveSearchCache(CacheName);
            try
            {
                using (REBATE.KechangDataContext kc = new REBATE.KechangDataContext(connectString))
                {
                    //查出表头并更新
                    var mainRet = kc.youhoo_rebate_RebatePolicy.FirstOrDefault(x => x.id == MainId);
                    if (mainRet == null)
                    {
                        throw new Exception("价格政策不存在或已被删除");
                    }
                    else
                    {
                        mainRet.channel_id = tableMain.channel_id;
                        mainRet.Code = tableMain.Code;
                        mainRet.sort_id_id = tableMain.sort_id_id;
                        mainRet.Name = tableMain.Name;
                        mainRet.RebateType_id = tableMain.RebateType_id;
                        mainRet.region_id = tableMain.region_id;
                    }

                    //根据id查出字表并删除.
                    var ret = kc.youhoo_rebate_RebatePolicys.Where(x => x.Policy_id == MainId);
                    if (ret.Count() != 0)
                    {
                        kc.youhoo_rebate_RebatePolicys.DeleteAllOnSubmit(ret);
                    }
                    //重新写入更新数据
                    kc.youhoo_rebate_RebatePolicys.InsertAllOnSubmit(tableDetails);
                    //提交
                    kc.SubmitChanges();
                    return 1;
                }
            }
            catch (Exception e)
            {
                return 0;
                throw new Exception("修改价格政策失败" + e.Message);
            }
        }
        /// <summary>
        ///  更新一个新的价格政策（表体）
        /// </summary>
        /// <param name="MainId">主表id</param>
        public int DeletePolicy(int[] MainId,string connectString, int operatorId)
        {
            try
            {

                using (REBATE.KechangDataContext kc = new REBATE.KechangDataContext(connectString))
                {
                    //根据id查出字表并删除.
                    var ret = kc.youhoo_rebate_RebatePolicys.Where(x => MainId.Contains(x.Policy_id));
                    if (ret.Count() != 0)
                    {
                        foreach (var item in ret)
                        {
                            item.flag = 0;
                        }
                    }
                    //刪除主表信息
                    var retMain = kc.youhoo_rebate_RebatePolicy.Where(x => MainId.Contains(x.id));
                    if (retMain.Count() > 0)
                    {
                        foreach (var item in retMain)
                        {
                            item.flag = 0;
                        }
                    }
                    //提交
                    kc.SubmitChanges();
                    return 1;
                }
            }
            catch (Exception e)
            {
                return 0;
                throw new Exception("删除价格政策失败"+e.Message);
            }
        }

        

        #endregion  成员方法
    }
}
