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

        #region ��ʾ����
        private static Dictionary<int, string> _promptParam;
        /// <summary>
        /// ��ʾ����
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

        #region ������ʾ
        /// <summary>
        /// ������ʾ
        /// </summary>
        /// <returns></returns>
        public static bool Save(int errorCode, Page page)
        {
            return Custom(errorCode, "����", page);
        }
        public static bool Save(int errorCode, string url, Page page)
        {
            return Custom(errorCode, "����", url, page);
        }
        #endregion

        #region �ύ��˳ɹ�
        public static bool Post(int errorCode, Page page)
        {
            return Custom(errorCode, "����ύ", page);
        }
        public static bool Post(int errorCode, string url, Page page)
        {
            return Custom(errorCode, "����ύ", url, page);
        }
        #endregion

        #region ɾ����ʾ
        /// <summary>
        /// ɾ����ʾ
        /// </summary>
        /// <returns></returns>
        public static bool Delete(int errorCode, Page page)
        {
            return Custom(errorCode, "ɾ��", page);
        }
        public static bool Delete(int errorCode, string url, Page page)
        {
            return Custom(errorCode, "ɾ��", url, page);
        }
        #endregion

        #region ȡ���ύ��ʾ
        /// <summary>
        /// ȡ����ʾ
        /// </summary>
        /// <returns></returns>
        public static bool CannelPost(int errorCode, Page page)
        {
            return Custom(errorCode, "ȡ���ύ", page);
        }
        public static bool CannelPost(int errorCode, string url, Page page)
        {
            return Custom(errorCode, "ȡ���ύ", url, page);
        }
        #endregion

        #region ������ʾ��Ϣ
        public static bool baseMessage(int errorCode, string tishi, Page page)
        {
            return Custom(errorCode, tishi, page);
        }
        public static bool CannelbaseMessage(int errorCode, string tishi, string url, Page page)
        {
            return Custom(errorCode, tishi, url, page);
        }
        #endregion

        #region ��Ŀ��ֹ��ʾ
        public static bool Status(int errorCode, Page page)
        {
            return Custom(errorCode, "��ֹ", page);
        }
        #endregion

        #region ��Ŀ��ֹ��ʾ
        public static bool CannelStatus(int errorCode, Page page)
        {
            return Custom(errorCode, "��ֹ", page);
        }
        #endregion

        #region �Զ�����ʾ
        /// <summary>
        /// �Զ�����ʾ
        /// </summary>
        /// <returns></returns>
        public static bool Custom(int errorCode, string message, Page page)
        {
            return Prompt(errorCode, message + "�ɹ���", message + "ʧ�ܣ�", true, "", false, 1, out returnInfo, page);
        }
        public static bool Custom(int errorCode, string message, string url, Page page)
        {
            return Prompt(errorCode, message + "�ɹ���", message + "ʧ�ܣ�", true, url, false, 1, out returnInfo, page);
        }
        #endregion

        #region �ɹ�����ʾ
        /// <summary>
        /// �ɹ�����ʾ
        /// </summary>
        /// <returns></returns>
        public static bool SuccessNoPrompt(int errorCode, string message, Page page)
        {
            return Prompt(errorCode, message + "�ɹ���", message + "ʧ�ܣ�", false, "", false, 1, out returnInfo, page);
        }
        #endregion

        #region ��ȡ��ʾ��Ϣ
        /// <summary>
        /// ��ȡ��ʾ��Ϣ
        /// </summary>
        /// <returns></returns>
        public static bool GetPromptInfo(int errorCode, string message, out string returnInfo, Page page)
        {
            return Prompt(errorCode, message + "�ɹ���", message + "ʧ�ܣ�", false, "", false, 1, out returnInfo, page);
        }
        #endregion

        #region ���ݿ���ʾ�����ã�
        /// <summary>
        /// ���ݿ���ʾ�����ã�
        /// </summary>
        /// <param name="errorCode">���ݿⷵ�ش���</param>
        /// <param name="successMessage">�ɹ���ʾ</param>
        /// <param name="failMessage">ʧ����ʾ</param>
        /// <param name="isSuccessPrompt">�ɹ��Ƿ���Ҫ��ʾ</param>
        /// <param name="url">��ת·��</param>
        /// <param name="isRedirectTop">�Ƿ���ת������</param>
        /// <param name="type">��ʾ���ͣ�1����ͨ��ʾ��2��������ʾ��</param>
        /// <param name="info">������Ϣ</param>
        /// <param name="page"></param>
        /// <returns></returns>
        public static bool Prompt(int errorCode, string successMessage, string failMessage, bool isSuccessPrompt, string url, bool isRedirectTop, int type, out string returnInfo, Page page)
        {
            bool success = false;
            int promptType = 1;//Ĭ���Ǿ�����ʾ
            switch (errorCode)
            {
                case 1:
                    success = true;
                    returnInfo = successMessage;
                    promptType = 2;//�ɹ���ʾ
                    break;
                case -1:
                    returnInfo = failMessage;
                    promptType = 3;//ʧ����ʾ
                    break;
                case -11:
                    returnInfo = "���ĵ�¼�ѹ��ڣ������µ�¼��";
                    break;
                default:
                    returnInfo = "δ֪����";
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
            //������ת
            if (string.IsNullOrEmpty(url))
            {
                //��ͨ��ʾ
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
                //������ʾ
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
            //����ת
            else
            {
                //��ͨ��ʾ
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
                //������ʾ
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
