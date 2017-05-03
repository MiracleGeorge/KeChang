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
    /// http���ӻ����࣬����ײ��httpͨ��
    /// </summary>
    public class HttpService
    {
        #region ����http post���󣬷�������
        /// <summary>
        /// ����http post���󣬷�������
        /// </summary>
        /// <param name="url">��ַ</param>
        /// <param name="xml">�������</param>
        /// <returns></returns>
        public static string Post(string url, string xml)
        {
            System.GC.Collect();//�������գ�����û�������رյ�http����

            string result = "";//���ؽ��

            HttpWebRequest request = null;
            HttpWebResponse response = null;
            Stream reqStream = null;

            try
            {
                request = (HttpWebRequest)WebRequest.Create(url);
                request.Method = "POST";

                //����POST���������ͺͳ���
                request.ContentType = "text/xml";
                byte[] data = System.Text.Encoding.UTF8.GetBytes(xml);
                request.ContentLength = data.Length;

                //��������д������
                reqStream = request.GetRequestStream();
                reqStream.Write(data, 0, data.Length);
                reqStream.Close();

                //��ȡ����˷���
                response = (HttpWebResponse)request.GetResponse();

                //��ȡ����˷�������
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
                //�ر����Ӻ���
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

        #region ����http get���󣬷�������
        /// <summary>
        /// ����http get���󣬷�������
        /// </summary>
        /// <param name="url">�����url��ַ</param>
        /// <returns></returns>
        public static string Get(string url)
        {
            System.GC.Collect();
            string result = "";

            HttpWebRequest request = null;
            HttpWebResponse response = null;

            //����url�Ի�ȡ����
            try
            {
                request = (HttpWebRequest)WebRequest.Create(url);
                request.Method = "GET";

                //��ȡ����������
                response = (HttpWebResponse)request.GetResponse();

                //��ȡHTTP��������
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
                //�ر����Ӻ���
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