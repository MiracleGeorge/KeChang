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
    /// 文件上传类
    /// </summary>
    public class FileHelper
    {
        private string fileName;
        /// 
        /// 上传文件名称 
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
        /// 上传文件路径 
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
        /// 文件扩展名 
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

        #region 获取上传文件大小
        /// <summary>
        /// 获取上传文件大小
        /// </summary>
        /// <param name="contentLength"></param>
        /// <returns></returns>
        public static string ComputeSize(long contentLength)
        {
            double size;
            size = contentLength / 1024;
            if (size < 1)
            {
                return contentLength.ToString() + "字节";
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

        #region 上传文件方法
        /// <summary>
        /// 上传文件方法
        /// </summary>
        /// <returns></returns>
        public static FileHelper UpLoadFile(HttpPostedFile postedFile)
        {
            FileHelper fp = new FileHelper();
            if (postedFile != null && !string.IsNullOrEmpty(postedFile.FileName))
            {
                string fileName, fileExtension;

                fileExtension = Path.GetExtension(Path.GetFileName(postedFile.FileName));//获取文件拓展名
                fileName = Converts.ToDateTime(DateTime.Now, "ddHHmmss") + new Random().Next(1111, 9999) + fileExtension;//随机文件名

                string uploadPath = "/UploadFiles/" + Converts.ToDateTime(DateTime.Now, "yyyy") + "/" + Converts.ToDateTime(DateTime.Now, "MM") + "/";
                string savePath = HttpContext.Current.Server.MapPath(uploadPath);

                //判断路径是否存在,若不存在则创建路径
                DirectoryInfo upDir = new DirectoryInfo(savePath);
                if (!upDir.Exists)
                {
                    upDir.Create();
                }

                // 
                //保存文件
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
                    throw new ApplicationException("上传失败！");
                }
            }
            //返回上传文件的信息 
            return fp;
        }
        #endregion

        #region 获取上传文件名称
        /// <summary>
        /// 获取上传文件名称
        /// </summary>
        /// <returns></returns>
        public static string GetUploadFilePath(HttpPostedFile postedFile)
        {
            FileHelper fileInfo = FileHelper.UpLoadFile(postedFile);
            return fileInfo.FilePath;
        }
        #endregion

        #region Http上传文件
        /// <summary>
        /// Http上传文件
        /// </summary>
        public static string HttpUploadFile(string url, string path)
        {
            // 设置参数
            HttpWebRequest request = WebRequest.Create(url) as HttpWebRequest;
            CookieContainer cookieContainer = new CookieContainer();
            request.CookieContainer = cookieContainer;
            request.AllowAutoRedirect = true;
            request.Method = "POST";
            string boundary = DateTime.Now.Ticks.ToString("X"); // 随机分隔线
            request.ContentType = "multipart/form-data;charset=utf-8;boundary=" + boundary;
            byte[] itemBoundaryBytes = Encoding.UTF8.GetBytes("\r\n--" + boundary + "\r\n");
            byte[] endBoundaryBytes = Encoding.UTF8.GetBytes("\r\n--" + boundary + "--\r\n");

            int pos = path.LastIndexOf("\\");
            string fileName = path.Substring(pos + 1);

            //请求头部信息 
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

            //发送请求并获取相应回应数据
            HttpWebResponse response = request.GetResponse() as HttpWebResponse;
            //直到request.GetResponse()程序才开始向目标网页发送Post请求
            Stream instream = response.GetResponseStream();
            StreamReader sr = new StreamReader(instream, Encoding.UTF8);
            //返回结果网页（html）代码
            string content = sr.ReadToEnd();
            return content;
        }
        #endregion
    }
}
