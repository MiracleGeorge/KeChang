using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Web;

namespace YouHoo.DataTools
{
    public class WordHelper
    {
        #region ����html��word
        /// <summary>
        /// ����html��word
        /// </summary>
        /// <param name="docName"></param>
        /// <param name="htmlCode"></param>
        public static void ExportHtmlToWord(string docName, string htmlCode)
        {
            //���������������
            HttpContext.Current.Response.Clear();
            //�����������http�ַ���
            HttpContext.Current.Response.Charset = "UTF-8";
            //��һ��HTTPͷ��ӵ������
            HttpContext.Current.Response.AddHeader("content-disposition", "attachment;filename=" + HttpUtility.UrlEncode(docName + ".doc") + "");
            //���������HTTP MIME����
            HttpContext.Current.Response.ContentType = "application/msword";
            //���ַ�����д��HTTP��Ӧ�����
            HttpContext.Current.Response.Write(htmlCode);
            //�����꣬�ر�
            HttpContext.Current.Response.End();
        }
        #endregion

        #region �����ı���word
        /// <summary>
        /// �����ı���word
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
            NPOI.XWPF.UserModel.XWPFDocument doc = new NPOI.XWPF.UserModel.XWPFDocument();      //�����µ�word�ĵ�

            NPOI.XWPF.UserModel.XWPFParagraph p1 = doc.CreateParagraph();   //�����ĵ�����Ӷ���
            p1.SetAlignment(NPOI.XWPF.UserModel.ParagraphAlignment.CENTER); //������䷽ʽΪ����
            NPOI.XWPF.UserModel.XWPFRun r1 = p1.CreateRun();                //��ö������������
            r1.SetText(text);

            FileStream sw = File.Create(path); //...
            doc.Write(sw);
            sw.Close();

            FileInfo file = new FileInfo(path);//�ļ�����·�������� //ע��: �ļ�����ĸ��ļ��������Everyone�û�������������ȫ����Ȩ��
            HttpContext.Current.Response.Clear();
            HttpContext.Current.Response.ClearHeaders();
            HttpContext.Current.Response.Buffer = false;
            HttpContext.Current.Response.ContentType = "application/msword";
            HttpContext.Current.Response.Charset = "utf-8";
            HttpContext.Current.Response.AppendHeader("Content-Disposition", "attachment;filename=" + HttpUtility.UrlEncode("output.doc", System.Text.Encoding.UTF8));
            HttpContext.Current.Response.AppendHeader("Content-Length", file.Length.ToString());
            HttpContext.Current.Response.WriteFile(file.FullName);
            HttpContext.Current.Response.Flush();                           //���Ͻ����ɵ�word�ļ��������û������
            File.Delete(path);                 //�����������ɵ�word�ļ�
        }
        #endregion
    }
}
