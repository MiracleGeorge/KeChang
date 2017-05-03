using System;
using System.Text;
using System.Web.UI;

namespace YouHoo.DataTools
{
    /// <summary>
    /// ҳ����ת��
    /// 
    /// �Ӵ��巵�������壬�رձ�ҳ���´�һ���µ�ҳ��
    /// </summary>
    public class WebPage
    {
        ///<summary>
        ///���ƣ�redirect
        ///���ܣ��Ӵ��巵��������
        ///������url
        ///����ֵ����
        ///</summary>
        public static void RedirectTop(string url, Page page)
        {
            ScriptManager.RegisterClientScriptBlock(page, typeof(Page), DateTime.Now.ToString().Replace(":", ""),
                                                    "window.top.document.location.href='" + url + "';", true);
        }

        /// <summary>
        /// ֱ��
        /// </summary>
        /// <param name="url"></param>
        /// <param name="updatePanel"></param>
        public static void Redirect(string url, UpdatePanel updatePanel)
        {
            ScriptManager.RegisterClientScriptBlock(updatePanel, typeof(UpdatePanel), DateTime.Now.ToString().Replace(":", ""),
                                                    "window.location.href='" + url + "';", true);
        }

        /// <summary>
        /// ֱ��
        /// </summary>
        /// <param name="url"></param>
        /// <param name="target">�Ƿ���´���</param>
        /// <param name="page"></param>
        public static void Redirect(string url, string target, Page page)
        {
            ScriptManager.RegisterClientScriptBlock(page, typeof(Page), DateTime.Now.ToString().Replace(":", ""),
                                                    "window.open('" + url + "','" + target + "');", true);
        }

        /// <summary>
        /// ֱ��
        /// </summary>
        /// <param name="url"></param>
        /// <param name="target">�Ƿ���´���</param>
        /// <param name="updatePanel"></param>
        public static void Redirect(string url, string target, UpdatePanel updatePanel)
        {
            ScriptManager.RegisterClientScriptBlock(updatePanel, typeof(UpdatePanel), DateTime.Now.ToString().Replace(":", ""),
                                                    "window.open('" + url + "','" + target + "');", true);
        }

        public static void Redirect(string url, Page page)
        {
            ScriptManager.RegisterClientScriptBlock(page, typeof(Page), DateTime.Now.ToString().Replace(":", ""),
                                                    "window.location.href='" + url + "';", true);
        }
        /// <summary>
        /// �رձ�ҳ���´�һ���µ�ҳ
        /// </summary>
        /// <param name="url">ҳ������</param>
        /// <param name="page"></param>
        public static void RedirectParent(string url, Page page)
        {
            ScriptManager.RegisterClientScriptBlock(page, typeof(Page), DateTime.Now.ToString().Replace(":", ""),
                                                    "parent.location='" + url + "';", true);
        }
    }
}