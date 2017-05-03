using System;
using System.Collections.Generic;
using System.Web;
using System.Net;
using System.IO;
using System.Text;
using YouHoo.DataTools;

namespace YouHoo.DataTools
{
    /// <summary>
    /// http连接基础类，负责底层的http通信
    /// </summary>
    public class HttpService
    {
        #region 处理http post请求，返回数据
        /// <summary>
        /// 处理http post请求，返回数据
        /// </summary>
        /// <param name="url">地址</param>
        /// <param name="xml">请求参数</param>
        /// <returns></returns>
        public static string Post(string url, string xml)
        {
            System.GC.Collect();//垃圾回收，回收没有正常关闭的http连接

            string result = "";//返回结果

            HttpWebRequest request = null;
            HttpWebResponse response = null;
            Stream reqStream = null;

            try
            {
                request = (HttpWebRequest)WebRequest.Create(url);
                request.Method = "POST";

                //设置POST的数据类型和长度
                request.ContentType = "text/xml";
                byte[] data = System.Text.Encoding.UTF8.GetBytes(xml);
                request.ContentLength = data.Length;

                //往服务器写入数据
                reqStream = request.GetRequestStream();
                reqStream.Write(data, 0, data.Length);
                reqStream.Close();

                //获取服务端返回
                response = (HttpWebResponse)request.GetResponse();

                //获取服务端返回数据
                StreamReader sr = new StreamReader(response.GetResponseStream(), Encoding.UTF8);
                result = sr.ReadToEnd().Trim();
                sr.Close();
            }
            catch (System.Threading.ThreadAbortException e)
            {
                Logger.Error("HttpService" + ":" + "Thread - caught ThreadAbortException - resetting.");
                Logger.Error("Exception message" + ":" + e.Message);
                System.Threading.Thread.ResetAbort();
            }
            catch (WebException e)
            {
                Logger.Error("HttpService" + ":" + e.ToString());
                if (e.Status == WebExceptionStatus.ProtocolError)
                {
                    Logger.Error("HttpService" + ":" + "StatusCode : " + ((HttpWebResponse)e.Response).StatusCode);
                    Logger.Error("HttpService" + ":" + "StatusDescription : " + ((HttpWebResponse)e.Response).StatusDescription);
                }
                throw e;
            }
            catch (Exception e)
            {
                Logger.Error("HttpService" + ":" + e.ToString());
                throw e;
            }
            finally
            {
                //关闭连接和流
                if (response != null)
                {
                    response.Close();
                }
                if (request != null)
                {
                    request.Abort();
                }
            }
            return result;
        }
        #endregion

        #region 处理http get请求，返回数据
        /// <summary>
        /// 处理http get请求，返回数据
        /// </summary>
        /// <param name="url">请求的url地址</param>
        /// <returns></returns>
        public static string Get(string url)
        {
            System.GC.Collect();
            string result = "";

            HttpWebRequest request = null;
            HttpWebResponse response = null;

            //请求url以获取数据
            try
            {
                request = (HttpWebRequest)WebRequest.Create(url);
                request.Method = "GET";

                //获取服务器返回
                response = (HttpWebResponse)request.GetResponse();

                //获取HTTP返回数据
                StreamReader sr = new StreamReader(response.GetResponseStream(), Encoding.UTF8);
                result = sr.ReadToEnd().Trim();
                sr.Close();
            }
            catch (System.Threading.ThreadAbortException e)
            {
                Logger.Error("HttpService" + ":" + "Thread - caught ThreadAbortException - resetting.");
                Logger.Error("Exception message" + ":" + e.Message);
                System.Threading.Thread.ResetAbort();
            }
            catch (WebException e)
            {
                Logger.Error("HttpService" + ":" + e.ToString());
                if (e.Status == WebExceptionStatus.ProtocolError)
                {
                    Logger.Error("HttpService" + ":" + "StatusCode : " + ((HttpWebResponse)e.Response).StatusCode);
                    Logger.Error("HttpService" + ":" + "StatusDescription : " + ((HttpWebResponse)e.Response).StatusDescription);
                }
                throw e;
            }
            catch (Exception e)
            {
                Logger.Error("HttpService" + ":" + e.ToString());
                throw e;
            }
            finally
            {
                //关闭连接和流
                if (response != null)
                {
                    response.Close();
                }
                if (request != null)
                {
                    request.Abort();
                }
            }
            return result;
        }
        #endregion
    }
}