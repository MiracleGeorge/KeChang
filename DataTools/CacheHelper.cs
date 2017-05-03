using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Caching;
using System.Web;
using System.Collections;
using System.Configuration;

namespace YouHoo.DataTools
{
    /// <summary>
    /// 缓存公共方法
    /// </summary>
    public class CacheHelper
    {
        private static volatile Cache _Cache; 
        private static readonly int _Times = 30;

        public static Cache GetCacheObj
        {
            get
            {
                if (_Cache == null) _Cache = HttpRuntime.Cache;
                return _Cache;
            }
        }


        /// <summary>
        /// 获取数据缓存
        /// </summary>
        /// <param name="CacheKey">键</param>
        public static object GetCache(string CacheKey)
        {
            return GetCacheObj[CacheKey];
        }

        /// <summary>
        /// 设置数据缓存
        /// </summary>
        public static void SetCache(string CacheKey, object objObject)
        {
            SetCache(CacheKey, objObject, DateTime.Now.AddMinutes(_Times), TimeSpan.Zero);
        }

        /// <summary>
        /// 设置数据缓存
        /// </summary>
        public static void SetCache(string CacheKey, object objObject, TimeSpan Timeout)
        {
            SetCache(CacheKey, objObject, DateTime.Now.AddMinutes(_Times), Timeout);
        }

        /// <summary>
        /// 设置数据缓存
        /// </summary>
        public static void SetCache(string CacheKey, object objObject, DateTime absoluteExpiration, TimeSpan slidingExpiration)
        {
            if (objObject!=null)
                GetCacheObj.Insert(CacheKey, objObject, null, absoluteExpiration, slidingExpiration);
        }

        /// <summary>
        /// 移除指定数据缓存
        /// </summary>
        public static void RemoveCache(string CacheKey)
        {
            GetCacheObj.Remove(CacheKey);
        }
        /// <summary>
        /// 移除指定数据缓存
        /// </summary>
        public static void RemoveSearchCache(string CacheKey)
        {
            lock (GetCacheObj)
            {
                IDictionaryEnumerator CacheEnum = GetCacheObj.GetEnumerator();
                ArrayList al = new ArrayList();
                while (CacheEnum.MoveNext())
                {
                    if (CacheEnum.Key.ToString().IndexOf(CacheKey) != -1)
                        al.Add(CacheEnum.Key.ToString());
                }
                foreach (string key in al)
                {
                    _Cache.Remove(key);
                }
            }
        }
        /// <summary>
        /// 移除全部缓存
        /// </summary>
        public static void RemoveAllCache()
        {
            lock (GetCacheObj)
            {
                IDictionaryEnumerator CacheEnum = GetCacheObj.GetEnumerator();
                ArrayList al = new ArrayList();
                while (CacheEnum.MoveNext())
                {
                    al.Add(CacheEnum.Key.ToString());
                }
                foreach (string key in al)
                {
                    _Cache.Remove(key);
                }
            }
        }
    }
}
