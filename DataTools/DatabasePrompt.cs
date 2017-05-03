using System;
using System.Collections.Generic;
using System.Text;
using System.Web.UI;
using System.Collections;

namespace YouHoo.DataTools
{
    public class DatabasePrompt
    {
        private static string returnInfo;

        #region 提示参数
        private static Dictionary<int, string> _promptParam;
        /// <summary>
        /// 提示参数
        /// </summary>
        public static Dictionary<int, string> PromptParam
        {
            get { return DatabasePrompt._promptParam; }
            set
            {
                DatabasePrompt._promptParam = value;
            }
        }
        #endregion

        #region 保存提示
        /// <summary>
        /// 保存提示
        /// </summary>
        /// <returns></returns>
        public static bool Save(int errorCode, Page page)
        {
            return Custom(errorCode, "保存", page);
        }
        public static bool Save(int errorCode, string url, Page page)
        {
            return Custom(errorCode, "保存", url, page);
        }
        #endregion

        #region 提交审核成功
        public static bool Post(int errorCode, Page page)
        {
            return Custom(errorCode, "审核提交", page);
        }
        public static bool Post(int errorCode, string url, Page page)
        {
            return Custom(errorCode, "审核提交", url, page);
        }
        #endregion

        #region 删除提示
        /// <summary>
        /// 删除提示
        /// </summary>
        /// <returns></returns>
        public static bool Delete(int errorCode, Page page)
        {
            return Custom(errorCode, "删除", page);
        }
        public static bool Delete(int errorCode, string url, Page page)
        {
            return Custom(errorCode, "删除", url, page);
        }
        #endregion

        #region 取消提交提示
        /// <summary>
        /// 取消提示
        /// </summary>
        /// <returns></returns>
        public static bool CannelPost(int errorCode, Page page)
        {
            return Custom(errorCode, "取消提交", page);
        }
        public static bool CannelPost(int errorCode, string url, Page page)
        {
            return Custom(errorCode, "取消提交", url, page);
        }
        #endregion

        #region 公共提示消息
        public static bool baseMessage(int errorCode, string tishi, Page page)
        {
            return Custom(errorCode, tishi, page);
        }
        public static bool CannelbaseMessage(int errorCode, string tishi, string url, Page page)
        {
            return Custom(errorCode, tishi, url, page);
        }
        #endregion

        #region 项目终止提示
        public static bool Status(int errorCode, Page page)
        {
            return Custom(errorCode, "终止", page);
        }
        #endregion

        #region 项目终止提示
        public static bool CannelStatus(int errorCode, Page page)
        {
            return Custom(errorCode, "终止", page);
        }
        #endregion

        #region 自定义提示
        /// <summary>
        /// 自定义提示
        /// </summary>
        /// <returns></returns>
        public static bool Custom(int errorCode, string message, Page page)
        {
            return Prompt(errorCode, message + "成功！", message + "失败！", true, "", false, 1, out returnInfo, page);
        }
        public static bool Custom(int errorCode, string message, string url, Page page)
        {
            return Prompt(errorCode, message + "成功！", message + "失败！", true, url, false, 1, out returnInfo, page);
        }
        #endregion

        #region 成功不提示
        /// <summary>
        /// 成功不提示
        /// </summary>
        /// <returns></returns>
        public static bool SuccessNoPrompt(int errorCode, string message, Page page)
        {
            return Prompt(errorCode, message + "成功！", message + "失败！", false, "", false, 1, out returnInfo, page);
        }
        #endregion

        #region 获取提示信息
        /// <summary>
        /// 获取提示信息
        /// </summary>
        /// <returns></returns>
        public static bool GetPromptInfo(int errorCode, string message, out string returnInfo, Page page)
        {
            return Prompt(errorCode, message + "成功！", message + "失败！", false, "", false, 1, out returnInfo, page);
        }
        #endregion

        #region 数据库提示（公用）
        /// <summary>
        /// 数据库提示（公用）
        /// </summary>
        /// <param name="errorCode">数据库返回代码</param>
        /// <param name="successMessage">成功提示</param>
        /// <param name="failMessage">失败提示</param>
        /// <param name="isSuccessPrompt">成功是否需要提示</param>
        /// <param name="url">跳转路径</param>
        /// <param name="isRedirectTop">是否跳转至顶级</param>
        /// <param name="type">提示类型（1：普通提示；2：弹窗提示）</param>
        /// <param name="info">返回信息</param>
        /// <param name="page"></param>
        /// <returns></returns>
        public static bool Prompt(int errorCode, string successMessage, string failMessage, bool isSuccessPrompt, string url, bool isRedirectTop, int type, out string returnInfo, Page page)
        {
            bool success = false;
            int promptType = 1;//默认是警告提示
            switch (errorCode)
            {
                case 1:
                    success = true;
                    returnInfo = successMessage;
                    promptType = 2;//成功提示
                    break;
                case -1:
                    returnInfo = failMessage;
                    promptType = 3;//失败提示
                    break;
                case -11:
                    returnInfo = "您的登录已过期，请重新登录！";
                    break;
                default:
                    returnInfo = "未知错误";
                    if (PromptParam != null && PromptParam.Count > 0)
                    {
                        foreach (int key in PromptParam.Keys)
                        {
                            if (key == errorCode)
                            {
                                returnInfo = PromptParam[key];
                                break;
                            }
                        }
                    }
                    break;
            }
            //不需跳转
            if (string.IsNullOrEmpty(url))
            {
                //普通提示
                if (type == 1)
                {
                    if (promptType == 2)
                    {
                        if (isSuccessPrompt) PublicPrompt.Success(returnInfo, page);
                    }
                    else if (promptType == 3)
                    {
                        PublicPrompt.Fail(returnInfo, page);
                    }
                    else
                    {
                        PublicPrompt.Warning(returnInfo, page);
                    }
                }
                //弹窗提示
                else
                {
                    if (promptType == 2)
                    {
                        if (isSuccessPrompt) PublicPrompt.Alert(returnInfo, page);
                    }
                    else if (promptType == 3)
                    {
                        PublicPrompt.Alert(returnInfo, page);
                    }
                    else
                    {
                        PublicPrompt.Alert(returnInfo, page);
                    }
                }
            }
            //需跳转
            else
            {
                //普通提示
                if (type == 1)
                {
                    if (promptType == 2)
                    {
                        if (isSuccessPrompt) PublicPrompt.Success(returnInfo, url, page);
                    }
                    else if (promptType == 3)
                    {
                        PublicPrompt.Fail(returnInfo, page);
                    }
                    else
                    {
                        PublicPrompt.Warning(returnInfo, page);
                    }
                }
                //弹窗提示
                else
                {
                    if (promptType == 2)
                    {
                        if (isSuccessPrompt)
                        {
                            if (isRedirectTop) PublicPrompt.AlertRedirectTop(returnInfo, url, page);
                            else PublicPrompt.Alert(returnInfo, url, page);
                        }
                    }
                    else if (promptType == 3)
                    {
                        PublicPrompt.Alert(returnInfo, page);
                    }
                    else
                    {
                        PublicPrompt.Alert(returnInfo, page);
                    }
                }
            }
            return success;
        }
        #endregion
    }
}
