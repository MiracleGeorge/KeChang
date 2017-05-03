using System;
using System.Collections.Generic;
using System.Web;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.Configuration;
using System.Text.RegularExpressions;
using System.Data;
using System.Collections;
using System.Web.UI;
using System.Security.Cryptography;
using System.IO;

namespace YouHoo.DataTools
{
    public class DataRequest
    {
        #region POST获取
        /// <summary>
        /// POST获取
        /// </summary>
        /// <param name="Key">获取的KEY值</param>
        /// <returns></returns>
        public static object Form(string key)
        {
            object o = HttpContext.Current.Request.Form[key];
            if (!o.Equals(null))
            {
                return o;
            }
            return null;
        }

        /// <summary>
        /// POST获取
        /// </summary>
        /// <param name="Key">获取的KEY值</param>
        /// <returns></returns>
        public static bool FormExists(string key)
        {
            return !string.IsNullOrEmpty(HttpContext.Current.Request.Form[key]);
        }

        /// <summary>
        /// POST获取
        /// </summary>
        /// <param name="Key">获取的KEY值</param>
        /// <returns></returns>
        public static string FormString(string key)
        {
            object o = HttpContext.Current.Request.Form[key];
            if (o == null)
            {
                return "";
            }
            else
            {
                return o.ToString().Trim();
            }
        }

        /// <summary>
        /// POST获取
        /// </summary>
        /// <param name="Key">获取的KEY值</param>
        /// <returns></returns>
        public static int FormInt(string key)
        {
            object o = HttpContext.Current.Request.Form[key];
            if (o == null)
            {
                return 0;
            }
            try
            {
                return Convert.ToInt32(o.ToString().Trim());
            }
            catch
            {
                return 0;
            }
        }

        /// <summary>
        /// POST获取
        /// </summary>
        /// <param name="Key">获取的KEY值</param>
        /// <returns></returns>
        public static decimal FormDecimal(string key)
        {
            object o = HttpContext.Current.Request.Form[key];
            if (o == null)
            {
                return 0;
            }
            try
            {
                return Convert.ToDecimal(o.ToString().Trim());
            }
            catch
            {
                return 0;
            }
        }
        #endregion

        #region GET获取
        /// <summary>
        /// GET获取
        /// </summary>
        /// <param name="Key">获取的KEY值</param>
        /// <returns></returns>
        [RemarkAttribute(Remark = "GET获取（对象类型）")]
        public static object Query(string key)
        {
            object o = HttpContext.Current.Request.QueryString[key];
            if (!o.Equals(null))
            {
                return o;
            }
            return null;
        }

        /// <summary>
        /// GET获取
        /// </summary>
        /// <param name="Key">获取的KEY值</param>
        /// <returns></returns>
        [RemarkAttribute(Remark = "GET获取（是否存在）")]
        public static bool QueryExists(string key)
        {
            return !string.IsNullOrEmpty(HttpContext.Current.Request.QueryString[key]);
        }

        /// <summary>
        /// GET获取
        /// </summary>
        /// <param name="Key">获取的KEY值</param>
        /// <returns></returns>
        [RemarkAttribute(Remark = "GET获取（string类型）")]
        public static string QueryString(string key)
        {
            object o = HttpContext.Current.Request.QueryString[key];
            if (o == null)
            {
                return "";
            }
            else
            {
                return o.ToString().Trim();
            }
        }

        /// <summary>
        /// GET获取
        /// </summary>
        /// <param name="Key">获取的KEY值</param>
        /// <returns></returns>
        [RemarkAttribute(Remark = "GET获取（int类型）")]
        public static int QueryInt(string key)
        {
            return QueryInt(key, 0);
        }
        [RemarkAttribute(Remark = "GET获取（int类型）【自定义默认值】")]
        public static int QueryInt(string key, int defaultValue)
        {
            object o = HttpContext.Current.Request.QueryString[key];
            try
            {
                return Convert.ToInt32(o.ToString().Trim());
            }
            catch (Exception)
            {
                return defaultValue;
            }
        }

        /// <summary>
        /// GET获取
        /// </summary>
        /// <param name="Key">获取的KEY值</param>
        /// <returns></returns>
        [RemarkAttribute(Remark = "GET获取（decimal类型）")]
        public static decimal QueryDecimal(string key)
        {
            return QueryDecimal(key, 0);
        }
        [RemarkAttribute(Remark = "GET获取（decimal类型）【自定义默认值】")]
        public static decimal QueryDecimal(string key, decimal defaultValue)
        {
            object o = HttpContext.Current.Request.QueryString[key];
            try
            {
                return Convert.ToDecimal(o.ToString().Trim());
            }
            catch (Exception)
            {
                return defaultValue;
            }
        }
        #endregion

        #region 获取当前访问页面地址
        /// <summary>
        /// 获取当前访问页面地址
        /// </summary>
        public static string GetScriptName
        {
            get
            {
                return System.Web.HttpContext.Current.Request.ServerVariables["SCRIPT_NAME"].ToString();
            }
        }
        #endregion

        #region 获取服务器操作系统
        /// <summary>
        /// 获取服务器操作系统
        /// </summary>
        public static string GetServerOS
        {
            get
            {
                string SystemOS = Environment.OSVersion.ToString();
                if (SystemOS.IndexOf("Windows 4.10") > -1)
                {
                    return "Windows 98";
                }
                else if (SystemOS.IndexOf("Windows 4.9") > -1)
                {
                    return "Windows Me";
                }
                else if (SystemOS.IndexOf("Windows NT 5.0") > -1)
                {
                    return "Windows 2000";
                }
                else if (SystemOS.IndexOf("Windows NT 5.1") > -1)
                {
                    return "Windows XP";
                }
                else if (SystemOS.IndexOf("Windows NT 5.2") > -1)
                {
                    return "Windows 2003";
                }
                else if (SystemOS.IndexOf("Windows NT 6.0") > -1)
                {
                    return "Windows Vista";
                }
                else
                {
                    return SystemOS;
                }
            }
        }
        #endregion

        #region 获取服务器名称
        /// <summary>
        /// 获取服务器名称
        /// </summary>
        public static string GetServerName
        {
            get
            {
                try
                {
                    return HttpContext.Current.Server.MachineName;
                }
                catch
                {
                    return "";
                }
            }
        }
        #endregion

        #region 获取服务器CPU信息
        /// <summary>
        /// 获取服务器CPU个数
        /// </summary>
        public static string GetCpuCount
        {
            get
            {
                try
                {
                    return Environment.GetEnvironmentVariable("NUMBER_OF_PROCESSORS");
                }
                catch
                {
                    return "";
                }
            }
        }
        /// <summary>
        /// 获取服务器CPU类型
        /// </summary>
        [RemarkAttribute(Remark = "获取服务器CPU类型")]
        public static string GetCpuIdentifier
        {
            get
            {
                try
                {
                    return Environment.GetEnvironmentVariable("PROCESSOR_IDENTIFIER");
                }
                catch
                {
                    return "";
                }
            }
        }
        #endregion

        #region 获取.NET解释引擎版本
        /// <summary>
        /// 获取.NET解释引擎版本
        /// </summary>
        public static string GetNetEngine
        {
            get
            {
                try
                {
                    return Environment.Version.Major + "." + Environment.Version.Minor + "." + Environment.Version.Build + "." + Environment.Version.Revision;
                }
                catch
                {
                    return "";
                }
            }
        }
        #endregion

        #region 检测当前url是否包含指定的字符
        /// <summary>
        /// 检测当前url是否包含指定的字符
        /// </summary>
        /// <param name="sChar">要检测的字符</param>
        /// <returns></returns>
        public static bool CheckScriptNameChar(string sChar)
        {
            bool rBool = false;
            if (GetScriptName.ToLower().LastIndexOf(sChar) >= 0)
                rBool = true;
            return rBool;
        }
        #endregion

        #region 获取当前页面的扩展名
        /// <summary>
        /// 获取当前页面的扩展名
        /// </summary>
        public static string GetScriptNameExt
        {
            get
            {
                return GetScriptName.Substring(GetScriptName.LastIndexOf(".") + 1);
            }
        }
        #endregion

        #region 获取当前访问页面地址参数
        /// <summary>
        /// 获取当前访问页面地址参数
        /// </summary>
        public static string GetScriptNameQueryString
        {
            get
            {
                return System.Web.HttpContext.Current.Request.ServerVariables["QUERY_STRING"].ToString();
            }
        }
        #endregion

        #region 获取当前访问页面Url
        /// <summary>
        /// 获取当前访问页面Url
        /// </summary>
        public static string GetScriptUrl
        {
            get
            {
                return GetScriptNameQueryString == "" ? GetScriptName : string.Format("{0}?{1}", GetScriptName, GetScriptNameQueryString);
            }
        }
        #endregion

        #region 获取系统物理路径
        /// <summary>
        /// 获取系统物理路径
        /// </summary>
        public static string GetServerPath
        {
            get
            {
                try
                {
                    return HttpContext.Current.Request.ServerVariables["APPL_RHYSICAL_PATH"];
                }
                catch
                {
                    return "";
                }
            }
        }
        #endregion

        #region 获取当前访问文件物理目录
        /// <summary>
        /// 获取当前访问文件物理目录
        /// </summary>
        /// <returns>路径</returns>
        public static string GetScriptPath
        {
            get
            {
                string Paths = System.Web.HttpContext.Current.Request.ServerVariables["PATH_TRANSLATED"].ToString();
                return Paths.Remove(Paths.LastIndexOf("\\"));
            }
        }
        #endregion

        #region 获得当前绝对路径
        /// <summary>
        /// 获得当前绝对路径
        /// </summary>
        /// <param name="strPath">指定的路径</param>
        /// <returns>绝对路径</returns>
        public static string GetMapPath(string strPath)
        {
            if (HttpContext.Current != null)
            {
                return HttpContext.Current.Server.MapPath(strPath);
            }
            else //非web程序引用
            {
                strPath = strPath.Replace("/", "\\");
                if (strPath.StartsWith("\\"))
                {
                    strPath = strPath.Substring(strPath.IndexOf('\\', 1)).TrimStart('\\');
                }
                return System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, strPath);
            }
        }
        #endregion

        #region 转换成绝对路径
        /// <summary>
        /// 转换成绝对路径
        /// </summary>
        /// <param name="virtualPath"></param>
        /// <param name="url"></param>
        /// <returns></returns>
        public static string ConvertAbsolutePath(string virtualPath, string url)
        {
            if (string.IsNullOrEmpty(url))
            {
                return string.Empty;
            }
            if (!url.Contains("://") && !url.StartsWith("/", StringComparison.InvariantCultureIgnoreCase))
            {
                return (virtualPath + url);
            }
            return url;
        }
        #endregion

        #region 获取用户IP地址
        /// <summary>
        /// 获取用户IP地址
        /// </summary>
        /// <returns></returns>
        [RemarkAttribute(Remark = "获取用户IP地址")]
        public static string GetIPAddress()
        {
            string user_IP = string.Empty;
            if (System.Web.HttpContext.Current.Request.ServerVariables["HTTP_VIA"] != null)
            {
                if (System.Web.HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"] != null)
                {
                    user_IP = System.Web.HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"].ToString();
                }
                else
                {
                    user_IP = System.Web.HttpContext.Current.Request.UserHostAddress;
                }
            }
            else
            {
                user_IP = System.Web.HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"].ToString();
            }
            return user_IP;
        }
        #endregion

        #region 获取主机IP
        /// <summary>
        /// 获取主机IP
        /// </summary>
        /// <param name="hostName"></param>
        /// <returns></returns>
        public static IPAddress GetHostIP(string hostName)
        {
            IPAddress[] hostAddresses = Dns.GetHostAddresses(hostName);
            IPAddress none = IPAddress.None;
            foreach (IPAddress address2 in hostAddresses)
            {
                if (address2.AddressFamily == AddressFamily.InterNetwork)
                {
                    return address2;
                }
            }
            return none;
        }
        /// <summary>
        /// 获取主机IP
        /// </summary>
        /// <returns></returns>
        public static IPAddress GetHostIP()
        {
            return GetHostIP("");
        }
        #endregion

        #region 获得操作系统
        /// <summary>
        /// 获得操作系统
        /// </summary>
        /// <returns>操作系统名称</returns>
        public static string GetSystem
        {
            get
            {
                string s = HttpContext.Current.Request.UserAgent.Trim().Replace("(", "").Replace(")", "");
                string[] sArray = s.Split(';');
                switch (sArray[2].Trim())
                {
                    case "Windows 4.10":
                        s = "Windows 98";
                        break;
                    case "Windows 4.9":
                        s = "Windows Me";
                        break;
                    case "Windows NT 5.0":
                        s = "Windows 2000";
                        break;
                    case "Windows NT 5.1":
                        s = "Windows XP";
                        break;
                    case "Windows NT 5.2":
                        s = "Windows 2003";
                        break;
                    case "Windows NT 6.0":
                        s = "Windows Vista";
                        break;
                    default:
                        s = "Other";
                        break;
                }
                return s;
            }
        }
        #endregion

        #region 获取服务器域名
        /// <summary>
        /// 获取服务器域名
        /// </summary>
        public static string GetServerHost
        {
            get
            {
                return HttpContext.Current.Request.ServerVariables["SERVER_NAME"].ToString();
            }
        }
        #endregion

        #region 获取服务器端口
        /// <summary>
        /// 获取服务器端口
        /// </summary>
        public static string GetServerPort
        {
            get
            {
                try
                {
                    return HttpContext.Current.Request.ServerVariables["SERVER_PORT"];
                }
                catch
                {
                    return "80";
                }
            }
        }
        #endregion

        #region 获取IIS版本
        /// <summary>
        /// 获取IIS版本
        /// </summary>
        public static string GetServerSoftware
        {
            get
            {
                try
                {
                    return HttpContext.Current.Request.ServerVariables["SERVER_SOFTWARE"];
                }
                catch
                {
                    return "";
                }
            }
        }
        #endregion

        #region 获取服务器
        /// <summary>
        /// 获取服务器
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public static string GetHomeUrl(string fileName)
        {
            string url = GetScriptName;

            return (string.Format("{0}/{1}", url.Remove(url.LastIndexOf('/')), fileName));
        }
        #endregion

        #region 返回html编码
        /// <summary>
        /// 返回html编码
        /// </summary>
        /// <param name="str">字符串</param>
        /// <returns>编码结果</returns>
        [RemarkAttribute(Remark = "返回html编码")]
        public static string HtmlEncode(string str)
        {
            return HttpUtility.HtmlEncode(str);
        }
        #endregion

        #region 返回html解码
        /// <summary>
        /// 返回html解码
        /// </summary>
        /// <param name="str">字符串</param>
        /// <returns>解码结果</returns>
        [RemarkAttribute(Remark = "返回html解码")]
        public static string HtmlDecode(string str)
        {
            return HttpUtility.HtmlDecode(str);
        }
        #endregion

        #region 返回url编码
        /// <summary>
        /// 返回url编码
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        [RemarkAttribute(Remark = "返回url编码")]
        public static string UrlEncode(string str)
        {
            return HttpContext.Current.Server.UrlEncode(str);
        }
        #endregion

        #region 返回url解码
        /// <summary>
        /// 返回url解码
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        [RemarkAttribute(Remark = "返回url解码")]
        public static string UrlDecode(string str)
        {
            return HttpContext.Current.Server.UrlDecode(str);
        }
        #endregion

        #region 返回正则编码
        /// <summary>
        /// 返回正则编码
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        [RemarkAttribute(Remark = "返回正则编码")]
        public static string RegexEscape(string str)
        {
            return Regex.Escape(str);
        }
        #endregion

        #region 返回正则解码
        /// <summary>
        /// 返回正则解码
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        [RemarkAttribute(Remark = "返回正则解码")]
        public static string RegexUnescape(string str)
        {
            return Regex.Unescape(str);
        }
        #endregion

        #region 返回DES加密
        /// <summary>
        /// 返回DES加密
        /// </summary>
        /// <param name="str"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        [RemarkAttribute(Remark = "返回DES加密（自定义加密格式）")]
        public static string DESEncode(string str, string key)
        {
            try
            {
                DESCryptoServiceProvider provider = new DESCryptoServiceProvider();
                provider.Key = Encoding.ASCII.GetBytes(key.Substring(0, 8));
                provider.IV = Encoding.ASCII.GetBytes(key.Substring(0, 8));
                byte[] bytes = Encoding.GetEncoding("GB2312").GetBytes(str);
                MemoryStream stream = new MemoryStream();
                CryptoStream stream2 = new CryptoStream(stream, provider.CreateEncryptor(), CryptoStreamMode.Write);
                stream2.Write(bytes, 0, bytes.Length);
                stream2.FlushFinalBlock();
                StringBuilder builder = new StringBuilder();
                foreach (byte num in stream.ToArray())
                {
                    builder.AppendFormat("{0:X2}", num);
                }
                stream.Close();
                return builder.ToString();
            }
            catch
            {
                return "0";
            }
        }

        /// <summary>
        /// 返回DES加密
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        [RemarkAttribute(Remark = "返回DES加密")]
        public static string DESEncode(string str)
        {
            return DESEncode(str, "1234567890!@#$");
        }
        #endregion

        #region 返回DES解密
        /// <summary>
        /// 返回DES解密
        /// </summary>
        /// <param name="str">Desc string</param>
        /// <param name="key">Key ,必须为8位 </param>
        /// <returns></returns>
        [RemarkAttribute(Remark = "返回DES解密（自定义解密格式）")]
        public static string DESDecode(string str, string key)
        {
            try
            {
                DESCryptoServiceProvider provider = new DESCryptoServiceProvider();
                provider.Key = Encoding.ASCII.GetBytes(key.Substring(0, 8));
                provider.IV = Encoding.ASCII.GetBytes(key.Substring(0, 8));
                byte[] buffer = new byte[str.Length / 2];
                for (int i = 0; i < (str.Length / 2); i++)
                {
                    int num2 = Convert.ToInt32(str.Substring(i * 2, 2), 0x10);
                    buffer[i] = (byte)num2;
                }
                MemoryStream stream = new MemoryStream();
                CryptoStream stream2 = new CryptoStream(stream, provider.CreateDecryptor(), CryptoStreamMode.Write);
                stream2.Write(buffer, 0, buffer.Length);
                stream2.FlushFinalBlock();
                stream.Close();
                return Encoding.GetEncoding("GB2312").GetString(stream.ToArray());
            }
            catch
            {
                return "0";
            }
        }

        /// <summary>
        /// 返回DES解密
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        [RemarkAttribute(Remark = "返回DES解密")]
        public static string DESDecode(string str)
        {
            return DESDecode(str, "1234567890!@#$");
        }
        #endregion

        #region 判断字符串是否是日期型
        /// <summary>
        /// 判断字符串是否是日期型
        /// </summary>
        /// <param name="strDate"></param>
        /// <returns></returns>
        [RemarkAttribute(Remark = "判断字符串是否是日期型")]
        public static bool IsDate(string strDate)
        {
            DateTime dtDate;
            bool bValid = true;
            try
            {
                dtDate = DateTime.Parse(strDate);
            }
            catch (FormatException)
            {
                // 如果解析方法失败则表示不是日期性数据
                bValid = false;
            }
            return bValid;
        }
        #endregion

        #region 获取返回路径
        /// <summary>
        /// 获取返回路径
        /// </summary>
        /// <param name="defaultUrl"></param>
        /// <returns></returns>
        public static string GetReturnUrl()
        {
            //获取返回URL
            string returnUrl = DataRequest.QueryString("ReturnUrl");
            //获取PageIndex所在位置
            int PageIndex_index = returnUrl.IndexOf("PageIndex");
            if (PageIndex_index != -1)
            {
                //获取PageIndex之后的字符串
                string PageIndex_behind = returnUrl.Substring(PageIndex_index);
                //获取PageIndex之后的字符串第一个出现&的位置
                int PageIndex_behindIndex = PageIndex_behind.IndexOf("&");
                if (PageIndex_behindIndex == -1)
                {
                    returnUrl = returnUrl.Replace(returnUrl.Substring(PageIndex_index), "PageIndex=" + DataRequest.QueryString("PageIndex"));
                }
                else
                {
                    returnUrl = returnUrl.Replace(returnUrl.Substring(PageIndex_index, PageIndex_behindIndex), "PageIndex=" + DataRequest.QueryString("PageIndex"));
                }
            }
            else
            {
                if (returnUrl.IndexOf("?") == -1)
                {
                    returnUrl = returnUrl + "?PageIndex=" + DataRequest.QueryString("PageIndex");
                }
                else
                {
                    returnUrl = returnUrl + "&PageIndex=" + DataRequest.QueryString("PageIndex");
                }
            }
            return returnUrl;
        }
        #endregion
    }
}
