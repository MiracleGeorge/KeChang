using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Web;

namespace YouHoo.DataTools
{
    public class WordHelper
    {
        #region 导出html成word
        /// <summary>
        /// 导出html成word
        /// </summary>
        /// <param name="docName"></param>
        /// <param name="htmlCode"></param>
        public static void ExportHtmlToWord(string docName, string htmlCode)
        {
            //清除反冲区的内容
            HttpContext.Current.Response.Clear();
            //设置输出流的http字符集
            HttpContext.Current.Response.Charset = "UTF-8";
            //将一个HTTP头添加到输出流
            HttpContext.Current.Response.AddHeader("content-disposition", "attachment;filename=" + HttpUtility.UrlEncode(docName + ".doc") + "");
            //设置输出的HTTP MIME类型
            HttpContext.Current.Response.ContentType = "application/msword";
            //把字符数组写入HTTP响应输出流
            HttpContext.Current.Response.Write(htmlCode);
            //发送完，关闭
            HttpContext.Current.Response.End();
        }
        #endregion

        #region 导出文本成word
        /// <summary>
        /// 导出文本成word
        /// </summary>
        /// <param name="docName"></param>
        /// <param name="text"></param>
        public static void ExportTextToWord(string docName, string text)
        {
            string path = HttpContext.Current.Request.MapPath("/UploadFiles/" + DateTime.Now.Year + "/" + DateTime.Now.Month + "/");
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            path += StringHelper.GenerateStringID() + ".doc";
            NPOI.XWPF.UserModel.XWPFDocument doc = new NPOI.XWPF.UserModel.XWPFDocument();      //创建新的word文档

            NPOI.XWPF.UserModel.XWPFParagraph p1 = doc.CreateParagraph();   //向新文档中添加段落
            p1.SetAlignment(NPOI.XWPF.UserModel.ParagraphAlignment.CENTER); //段落对其方式为居中
            NPOI.XWPF.UserModel.XWPFRun r1 = p1.CreateRun();                //向该段落中添加文字
            r1.SetText(text);

            FileStream sw = File.Create(path); //...
            doc.Write(sw);
            sw.Close();

            FileInfo file = new FileInfo(path);//文件保存路径及名称 //注意: 文件保存的父文件夹需添加Everyone用户，并给予其完全控制权限
            HttpContext.Current.Response.Clear();
            HttpContext.Current.Response.ClearHeaders();
            HttpContext.Current.Response.Buffer = false;
            HttpContext.Current.Response.ContentType = "application/msword";
            HttpContext.Current.Response.Charset = "utf-8";
            HttpContext.Current.Response.AppendHeader("Content-Disposition", "attachment;filename=" + HttpUtility.UrlEncode("output.doc", System.Text.Encoding.UTF8));
            HttpContext.Current.Response.AppendHeader("Content-Length", file.Length.ToString());
            HttpContext.Current.Response.WriteFile(file.FullName);
            HttpContext.Current.Response.Flush();                           //以上将生成的word文件发送至用户浏览器
            File.Delete(path);                 //清除服务端生成的word文件
        }
        #endregion
    }
}
