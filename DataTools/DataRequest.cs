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
        #region POST��ȡ
        /// <summary>
        /// POST��ȡ
        /// </summary>
        /// <param name="Key">��ȡ��KEYֵ</param>
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
        /// POST��ȡ
        /// </summary>
        /// <param name="Key">��ȡ��KEYֵ</param>
        /// <returns></returns>
        public static bool FormExists(string key)
        {
            return !string.IsNullOrEmpty(HttpContext.Current.Request.Form[key]);
        }

        /// <summary>
        /// POST��ȡ
        /// </summary>
        /// <param name="Key">��ȡ��KEYֵ</param>
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
        /// POST��ȡ
        /// </summary>
        /// <param name="Key">��ȡ��KEYֵ</param>
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
        /// POST��ȡ
        /// </summary>
        /// <param name="Key">��ȡ��KEYֵ</param>
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

        #region GET��ȡ
        /// <summary>
        /// GET��ȡ
        /// </summary>
        /// <param name="Key">��ȡ��KEYֵ</param>
        /// <returns></returns>
        [RemarkAttribute(Remark = "GET��ȡ���������ͣ�")]
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
        /// GET��ȡ
        /// </summary>
        /// <param name="Key">��ȡ��KEYֵ</param>
        /// <returns></returns>
        [RemarkAttribute(Remark = "GET��ȡ���Ƿ���ڣ�")]
        public static bool QueryExists(string key)
        {
            return !string.IsNullOrEmpty(HttpContext.Current.Request.QueryString[key]);
        }

        /// <summary>
        /// GET��ȡ
        /// </summary>
        /// <param name="Key">��ȡ��KEYֵ</param>
        /// <returns></returns>
        [RemarkAttribute(Remark = "GET��ȡ��string���ͣ�")]
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
        /// GET��ȡ
        /// </summary>
        /// <param name="Key">��ȡ��KEYֵ</param>
        /// <returns></returns>
        [RemarkAttribute(Remark = "GET��ȡ��int���ͣ�")]
        public static int QueryInt(string key)
        {
            return QueryInt(key, 0);
        }
        [RemarkAttribute(Remark = "GET��ȡ��int���ͣ����Զ���Ĭ��ֵ��")]
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
        /// GET��ȡ
        /// </summary>
        /// <param name="Key">��ȡ��KEYֵ</param>
        /// <returns></returns>
        [RemarkAttribute(Remark = "GET��ȡ��decimal���ͣ�")]
        public static decimal QueryDecimal(string key)
        {
            return QueryDecimal(key, 0);
        }
        [RemarkAttribute(Remark = "GET��ȡ��decimal���ͣ����Զ���Ĭ��ֵ��")]
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

        #region ��ȡ��ǰ����ҳ���ַ
        /// <summary>
        /// ��ȡ��ǰ����ҳ���ַ
        /// </summary>
        public static string GetScriptName
        {
            get
            {
                return System.Web.HttpContext.Current.Request.ServerVariables["SCRIPT_NAME"].ToString();
            }
        }
        #endregion

        #region ��ȡ����������ϵͳ
        /// <summary>
        /// ��ȡ����������ϵͳ
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

        #region ��ȡ����������
        /// <summary>
        /// ��ȡ����������
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

        #region ��ȡ������CPU��Ϣ
        /// <summary>
        /// ��ȡ������CPU����
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
        /// ��ȡ������CPU����
        /// </summary>
        [RemarkAttribute(Remark = "��ȡ������CPU����")]
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

        #region ��ȡ.NET��������汾
        /// <summary>
        /// ��ȡ.NET��������汾
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

        #region ��⵱ǰurl�Ƿ����ָ�����ַ�
        /// <summary>
        /// ��⵱ǰurl�Ƿ����ָ�����ַ�
        /// </summary>
        /// <param name="sChar">Ҫ�����ַ�</param>
        /// <returns></returns>
        public static bool CheckScriptNameChar(string sChar)
        {
            bool rBool = false;
            if (GetScriptName.ToLower().LastIndexOf(sChar) >= 0)
                rBool = true;
            return rBool;
        }
        #endregion

        #region ��ȡ��ǰҳ�����չ��
        /// <summary>
        /// ��ȡ��ǰҳ�����չ��
        /// </summary>
        public static string GetScriptNameExt
        {
            get
            {
                return GetScriptName.Substring(GetScriptName.LastIndexOf(".") + 1);
            }
        }
        #endregion

        #region ��ȡ��ǰ����ҳ���ַ����
        /// <summary>
        /// ��ȡ��ǰ����ҳ���ַ����
        /// </summary>
        public static string GetScriptNameQueryString
        {
            get
            {
                return System.Web.HttpContext.Current.Request.ServerVariables["QUERY_STRING"].ToString();
            }
        }
        #endregion

        #region ��ȡ��ǰ����ҳ��Url
        /// <summary>
        /// ��ȡ��ǰ����ҳ��Url
        /// </summary>
        public static string GetScriptUrl
        {
            get
            {
                return GetScriptNameQueryString == "" ? GetScriptName : string.Format("{0}?{1}", GetScriptName, GetScriptNameQueryString);
            }
        }
        #endregion

        #region ��ȡϵͳ����·��
        /// <summary>
        /// ��ȡϵͳ����·��
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

        #region ��ȡ��ǰ�����ļ�����Ŀ¼
        /// <summary>
        /// ��ȡ��ǰ�����ļ�����Ŀ¼
        /// </summary>
        /// <returns>·��</returns>
        public static string GetScriptPath
        {
            get
            {
                string Paths = System.Web.HttpContext.Current.Request.ServerVariables["PATH_TRANSLATED"].ToString();
                return Paths.Remove(Paths.LastIndexOf("\\"));
            }
        }
        #endregion

        #region ��õ�ǰ����·��
        /// <summary>
        /// ��õ�ǰ����·��
        /// </summary>
        /// <param name="strPath">ָ����·��</param>
        /// <returns>����·��</returns>
        public static string GetMapPath(string strPath)
        {
            if (HttpContext.Current != null)
            {
                return HttpContext.Current.Server.MapPath(strPath);
            }
            else //��web��������
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

        #region ת���ɾ���·��
        /// <summary>
        /// ת���ɾ���·��
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

        #region ��ȡ�û�IP��ַ
        /// <summary>
        /// ��ȡ�û�IP��ַ
        /// </summary>
        /// <returns></returns>
        [RemarkAttribute(Remark = "��ȡ�û�IP��ַ")]
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

        #region ��ȡ����IP
        /// <summary>
        /// ��ȡ����IP
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
        /// ��ȡ����IP
        /// </summary>
        /// <returns></returns>
        public static IPAddress GetHostIP()
        {
            return GetHostIP("");
        }
        #endregion

        #region ��ò���ϵͳ
        /// <summary>
        /// ��ò���ϵͳ
        /// </summary>
        /// <returns>����ϵͳ����</returns>
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

        #region ��ȡ����������
        /// <summary>
        /// ��ȡ����������
        /// </summary>
        public static string GetServerHost
        {
            get
            {
                return HttpContext.Current.Request.ServerVariables["SERVER_NAME"].ToString();
            }
        }
        #endregion

        #region ��ȡ�������˿�
        /// <summary>
        /// ��ȡ�������˿�
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

        #region ��ȡIIS�汾
        /// <summary>
        /// ��ȡIIS�汾
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

        #region ��ȡ������
        /// <summary>
        /// ��ȡ������
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public static string GetHomeUrl(string fileName)
        {
            string url = GetScriptName;

            return (string.Format("{0}/{1}", url.Remove(url.LastIndexOf('/')), fileName));
        }
        #endregion

        #region ����html����
        /// <summary>
        /// ����html����
        /// </summary>
        /// <param name="str">�ַ���</param>
        /// <returns>������</returns>
        [RemarkAttribute(Remark = "����html����")]
        public static string HtmlEncode(string str)
        {
            return HttpUtility.HtmlEncode(str);
        }
        #endregion

        #region ����html����
        /// <summary>
        /// ����html����
        /// </summary>
        /// <param name="str">�ַ���</param>
        /// <returns>������</returns>
        [RemarkAttribute(Remark = "����html����")]
        public static string HtmlDecode(string str)
        {
            return HttpUtility.HtmlDecode(str);
        }
        #endregion

        #region ����url����
        /// <summary>
        /// ����url����
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        [RemarkAttribute(Remark = "����url����")]
        public static string UrlEncode(string str)
        {
            return HttpContext.Current.Server.UrlEncode(str);
        }
        #endregion

        #region ����url����
        /// <summary>
        /// ����url����
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        [RemarkAttribute(Remark = "����url����")]
        public static string UrlDecode(string str)
        {
            return HttpContext.Current.Server.UrlDecode(str);
        }
        #endregion

        #region �����������
        /// <summary>
        /// �����������
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        [RemarkAttribute(Remark = "�����������")]
        public static string RegexEscape(string str)
        {
            return Regex.Escape(str);
        }
        #endregion

        #region �����������
        /// <summary>
        /// �����������
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        [RemarkAttribute(Remark = "�����������")]
        public static string RegexUnescape(string str)
        {
            return Regex.Unescape(str);
        }
        #endregion

        #region ����DES����
        /// <summary>
        /// ����DES����
        /// </summary>
        /// <param name="str"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        [RemarkAttribute(Remark = "����DES���ܣ��Զ�����ܸ�ʽ��")]
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
        /// ����DES����
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        [RemarkAttribute(Remark = "����DES����")]
        public static string DESEncode(string str)
        {
            return DESEncode(str, "1234567890!@#$");
        }
        #endregion

        #region ����DES����
        /// <summary>
        /// ����DES����
        /// </summary>
        /// <param name="str">Desc string</param>
        /// <param name="key">Key ,����Ϊ8λ </param>
        /// <returns></returns>
        [RemarkAttribute(Remark = "����DES���ܣ��Զ�����ܸ�ʽ��")]
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
        /// ����DES����
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        [RemarkAttribute(Remark = "����DES����")]
        public static string DESDecode(string str)
        {
            return DESDecode(str, "1234567890!@#$");
        }
        #endregion

        #region �ж��ַ����Ƿ���������
        /// <summary>
        /// �ж��ַ����Ƿ���������
        /// </summary>
        /// <param name="strDate"></param>
        /// <returns></returns>
        [RemarkAttribute(Remark = "�ж��ַ����Ƿ���������")]
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
                // �����������ʧ�����ʾ��������������
                bValid = false;
            }
            return bValid;
        }
        #endregion

        #region ��ȡ����·��
        /// <summary>
        /// ��ȡ����·��
        /// </summary>
        /// <param name="defaultUrl"></param>
        /// <returns></returns>
        public static string GetReturnUrl()
        {
            //��ȡ����URL
            string returnUrl = DataRequest.QueryString("ReturnUrl");
            //��ȡPageIndex����λ��
            int PageIndex_index = returnUrl.IndexOf("PageIndex");
            if (PageIndex_index != -1)
            {
                //��ȡPageIndex֮����ַ���
                string PageIndex_behind = returnUrl.Substring(PageIndex_index);
                //��ȡPageIndex֮����ַ�����һ������&��λ��
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
