using System;
using System.Text;
using System.Web.UI;

namespace YouHoo.DataTools
{
    /// <summary>
    /// 页面跳转类
    /// 
    /// 子窗体返回主窗体，关闭本页重新打开一个新的页。
    /// </summary>
    public class WebPage
    {
        ///<summary>
        ///名称：redirect
        ///功能：子窗体返回主窗体
        ///参数：url
        ///返回值：空
        ///</summary>
        public static void RedirectTop(string url, Page page)
        {
            ScriptManager.RegisterClientScriptBlock(page, typeof(Page), DateTime.Now.ToString().Replace(":", ""),
                                                    "window.top.document.location.href='" + url + "';", true);
        }

        /// <summary>
        /// 直接
        /// </summary>
        /// <param name="url"></param>
        /// <param name="updatePanel"></param>
        public static void Redirect(string url, UpdatePanel updatePanel)
        {
            ScriptManager.RegisterClientScriptBlock(updatePanel, typeof(UpdatePanel), DateTime.Now.ToString().Replace(":", ""),
                                                    "window.location.href='" + url + "';", true);
        }

        /// <summary>
        /// 直接
        /// </summary>
        /// <param name="url"></param>
        /// <param name="target">是否打开新窗口</param>
        /// <param name="page"></param>
        public static void Redirect(string url, string target, Page page)
        {
            ScriptManager.RegisterClientScriptBlock(page, typeof(Page), DateTime.Now.ToString().Replace(":", ""),
                                                    "window.open('" + url + "','" + target + "');", true);
        }

        /// <summary>
        /// 直接
        /// </summary>
        /// <param name="url"></param>
        /// <param name="target">是否打开新窗口</param>
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
        /// 关闭本页重新打开一个新的页
        /// </summary>
        /// <param name="url">页面链接</param>
        /// <param name="page"></param>
        public static void RedirectParent(string url, Page page)
        {
            ScriptManager.RegisterClientScriptBlock(page, typeof(Page), DateTime.Now.ToString().Replace(":", ""),
                                                    "parent.location='" + url + "';", true);
        }
    }
}