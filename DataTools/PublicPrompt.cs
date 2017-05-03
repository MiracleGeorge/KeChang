using System;
using System.Collections.Generic;
using System.Text;
using System.Web.UI;

namespace YouHoo.DataTools
{
    public class PublicPrompt
    {
        #region 警告提示
        /// <summary>
        /// 警告提示
        /// </summary>
        public static void Warning(string message, Page page)
        {
            PublicPrompt.HidePrompt(page);
            StringHelper.CustomScript("top.msgbox.prompt(\"" + message + "\", 1);", page);
        }
        public static void Warning(string message, string url, Page page)
        {
            PublicPrompt.HidePrompt(page);
            StringHelper.CustomScript("top.msgbox.prompt(\"" + message + "\", 1);location.href='" + url + "';", page);
        }
        #endregion

        #region 成功提示
        /// <summary>
        /// 成功提示
        /// </summary>
        public static void Success(string message, Page page)
        {
            PublicPrompt.HidePrompt(page);
            StringHelper.CustomScript("top.msgbox.prompt(\"" + message + "\", 2);", page);
        }
        public static void Success(string message, string url, Page page)
        {
            PublicPrompt.HidePrompt(page);
            StringHelper.CustomScript("top.msgbox.prompt(\"" + message + "\", 2);location.href='" + url + "';", page);
        }
        #endregion

        #region 失败提示
        /// <summary>
        /// 失败提示
        /// </summary>
        public static void Fail(string message, Page page)
        {
            PublicPrompt.HidePrompt(page);
            StringHelper.CustomScript("top.msgbox.prompt(\"" + message + "\", 3);", page);
        }
        public static void Fail(string message, string url, Page page)
        {
            PublicPrompt.HidePrompt(page);
            StringHelper.CustomScript("top.msgbox.prompt(\"" + message + "\", 3);location.href='" + url + "';", page);
        }
        #endregion

        #region 加载提示
        /// <summary>
        /// 加载提示
        /// </summary>
        public static void Loading(string message, Page page)
        {
            PublicPrompt.HidePrompt(page);
            StringHelper.CustomScript("top.msgbox.prompt(\"" + message + "\", 4);", page);
        }
        public static void Loading(string message, string url, Page page)
        {
            PublicPrompt.HidePrompt(page);
            StringHelper.CustomScript("top.msgbox.prompt(\"" + message + "\", 4);location.href='" + url + "';", page);
        }
        #endregion

        #region 隐藏提示
        /// <summary>
        /// 隐藏提示
        /// </summary>
        /// <param name="message"></param>
        /// <param name="page"></param>
        public static void HidePrompt(Page page)
        {
            StringHelper.CustomScript("top.msgbox.hidden();", page);
        }
        #endregion

        #region 弹出警告信息
        /// <summary>
        /// 弹出警告信息
        /// </summary>
        public static void Alert(string message, Page page)
        {
            StringHelper.CustomScript("top.Dialog.alert(\"" + message + "\");", page);
            HidePrompt(page);
        }

        public static void Alert(string message, string url, Page page)
        {
            StringHelper.CustomScript("top.Dialog.alert(\"" + message + "\", function(){location.href='" + url + "';});", page);
            HidePrompt(page);
        }

        public static void AlertRedirectTop(string message, string url, Page page)
        {
            StringHelper.CustomScript("top.Dialog.alert(\"" + message + "\", function(){top.location.href='" + url + "';});", page);
            HidePrompt(page);
        }
        #endregion

        #region 弹出确认信息
        /// <summary>
        /// 弹出确认信息
        /// </summary>
        public static void Confirm(string message, Page page)
        {
            StringHelper.CustomScript("top.Dialog.confirm(\"" + message + "\");", page);
            HidePrompt(page);
        }

        public static void Confirm(string message, string url, Page page)
        {
            StringHelper.CustomScript("top.Dialog.confirm(\"" + message + "\", function(){location.href='" + url + "';});", page);
            HidePrompt(page);
        }
        #endregion

        #region 关闭弹出页
        /// <summary>
        /// 关闭弹出页
        /// </summary>
        /// <param name="page"></param>
        public static void CloseDialog(Page page)
        {
            StringHelper.CustomScript("top.Dialog.close();", page);
        }

        /// <summary>
        /// 关闭弹出页并刷新页面
        /// </summary>
        public static void CloseDialogAndRefresh(Page page)
        {
            StringHelper.CustomScript("top.document.getElementById('frmright').contentWindow.location.href = '" + DataRequest.GetReturnUrl() + "'; top.Dialog.close();", page);
        }
        public static void CloseDialogAndRefresh(string url, Page page)
        {
            StringHelper.CustomScript("top.document.getElementById('frmright').contentWindow.location.href = '" + url + "'; top.Dialog.close();", page);
        }
        public static void CloseDialogAndRefreshContent(Page page)
        {
            StringHelper.CustomScript("top.document.getElementById('frmright').contentWindow.document.getElementById('frmrightContent').contentWindow.location.href = '" + DataRequest.GetReturnUrl() + "'; top.Dialog.close();", page);
        }
        public static void CloseDialogAndRefreshChildContent(Page page)
        {
            StringHelper.CustomScript("top.document.getElementById('frmright').contentWindow.document.getElementById('frmrightContent').contentWindow.document.getElementById('frmrightChildContent').contentWindow.location.href = '" + DataRequest.GetReturnUrl() + "'; top.Dialog.close();", page);
        }
        #endregion
    }
}