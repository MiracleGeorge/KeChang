using System;
using System.Collections.Generic;
using System.Text;
using System.Web.UI.HtmlControls;
using System.Web;
using System.IO;
using System.Net;

namespace YouHoo.DataTools
{
    /// <summary>
    /// �ļ��ϴ���
    /// </summary>
    public class FileHelper
    {
        private string fileName;
        /// 
        /// �ϴ��ļ����� 
        /// 
        public string FileName
        {
            get
            {
                return fileName;
            }
            set
            {
                fileName = value;
            }
        }

        private string filepath;
        /// 
        /// �ϴ��ļ�·�� 
        /// 
        public string FilePath
        {
            get
            {
                return filepath;
            }
            set
            {
                filepath = value;
            }
        }

        private string fileExtension;
        /// 
        /// �ļ���չ�� 
        /// 
        public string FileExtension
        {
            get
            {
                return fileExtension;
            }
            set
            {
                fileExtension = value;
            }
        }

        #region ��ȡ�ϴ��ļ���С
        /// <summary>
        /// ��ȡ�ϴ��ļ���С
        /// </summary>
        /// <param name="contentLength"></param>
        /// <returns></returns>
        public static string ComputeSize(long contentLength)
        {
            double size;
            size = contentLength / 1024;
            if (size < 1)
            {
                return contentLength.ToString() + "�ֽ�";
            }
            size = size / 1024;
            if (size < 1)
            {
                return (size * 1024).ToString("#") + "KB";
            }
            size = size / 1024;
            if (size < 1)
            {
                return (size * 1024).ToString("#") + "MB";
            }
            size = size / 1024;
            if (size < 1)
            {
                return (size * 1024).ToString("#") + "GB";
            }
            return size.ToString("#") + "TB";
        } 
        #endregion

        #region �ϴ��ļ�����
        /// <summary>
        /// �ϴ��ļ�����
        /// </summary>
        /// <returns></returns>
        public static FileHelper UpLoadFile(HttpPostedFile postedFile)
        {
            FileHelper fp = new FileHelper();
            if (postedFile != null && !string.IsNullOrEmpty(postedFile.FileName))
            {
                string fileName, fileExtension;

                fileExtension = Path.GetExtension(Path.GetFileName(postedFile.FileName));//��ȡ�ļ���չ��
                fileName = Converts.ToDateTime(DateTime.Now, "ddHHmmss") + new Random().Next(1111, 9999) + fileExtension;//����ļ���

                string uploadPath = "/UploadFiles/" + Converts.ToDateTime(DateTime.Now, "yyyy") + "/" + Converts.ToDateTime(DateTime.Now, "MM") + "/";
                string savePath = HttpContext.Current.Server.MapPath(uploadPath);

                //�ж�·���Ƿ����,���������򴴽�·��
                DirectoryInfo upDir = new DirectoryInfo(savePath);
                if (!upDir.Exists)
                {
                    upDir.Create();
                }

                // 
                //�����ļ�
                // 
                try
                {
                    postedFile.SaveAs(savePath + fileName);

                    fp.FilePath = uploadPath + fileName;
                    fp.FileExtension = fileExtension;
                    fp.FileName = postedFile.FileName;
                }
                catch
                {
                    throw new ApplicationException("�ϴ�ʧ�ܣ�");
                }
            }
            //�����ϴ��ļ�����Ϣ 
            return fp;
        }
        #endregion

        #region ��ȡ�ϴ��ļ�����
        /// <summary>
        /// ��ȡ�ϴ��ļ�����
        /// </summary>
        /// <returns></returns>
        public static string GetUploadFilePath(HttpPostedFile postedFile)
        {
            FileHelper fileInfo = FileHelper.UpLoadFile(postedFile);
            return fileInfo.FilePath;
        }
        #endregion

        #region Http�ϴ��ļ�
        /// <summary>
        /// Http�ϴ��ļ�
        /// </summary>
        public static string HttpUploadFile(string url, string path)
        {
            // ���ò���
            HttpWebRequest request = WebRequest.Create(url) as HttpWebRequest;
            CookieContainer cookieContainer = new CookieContainer();
            request.CookieContainer = cookieContainer;
            request.AllowAutoRedirect = true;
            request.Method = "POST";
            string boundary = DateTime.Now.Ticks.ToString("X"); // ����ָ���
            request.ContentType = "multipart/form-data;charset=utf-8;boundary=" + boundary;
            byte[] itemBoundaryBytes = Encoding.UTF8.GetBytes("\r\n--" + boundary + "\r\n");
            byte[] endBoundaryBytes = Encoding.UTF8.GetBytes("\r\n--" + boundary + "--\r\n");

            int pos = path.LastIndexOf("\\");
            string fileName = path.Substring(pos + 1);

            //����ͷ����Ϣ 
            StringBuilder sbHeader = new StringBuilder(string.Format("Content-Disposition:form-data;name=\"file\";filename=\"{0}\"\r\nContent-Type:application/octet-stream\r\n\r\n", fileName));
            byte[] postHeaderBytes = Encoding.UTF8.GetBytes(sbHeader.ToString());

            FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read);
            byte[] bArr = new byte[fs.Length];
            fs.Read(bArr, 0, bArr.Length);
            fs.Close();

            Stream postStream = request.GetRequestStream();
            postStream.Write(itemBoundaryBytes, 0, itemBoundaryBytes.Length);
            postStream.Write(postHeaderBytes, 0, postHeaderBytes.Length);
            postStream.Write(bArr, 0, bArr.Length);
            postStream.Write(endBoundaryBytes, 0, endBoundaryBytes.Length);
            postStream.Close();

            //�������󲢻�ȡ��Ӧ��Ӧ����
            HttpWebResponse response = request.GetResponse() as HttpWebResponse;
            //ֱ��request.GetResponse()����ſ�ʼ��Ŀ����ҳ����Post����
            Stream instream = response.GetResponseStream();
            StreamReader sr = new StreamReader(instream, Encoding.UTF8);
            //���ؽ����ҳ��html������
            string content = sr.ReadToEnd();
            return content;
        }
        #endregion
    }
}
