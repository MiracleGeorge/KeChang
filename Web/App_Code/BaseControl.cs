using System;
using YouHoo.DataTools;
using YouHoo.DataBll;
using YouHoo.DataModel;
using System.Web.UI;
using System.Text;

namespace YouHoo.Web
{
    /// <summary>
    /// ϵͳҳ����
    /// Ϊ���пؼ��ĸ�ҳ
    /// </summary>
    public class BaseControl : UserControl
    {
        private YouhooSysUsersModel _userModel;// ��ǰ����Ա��Ϣ����
        private static YouhooSysSystemSetModel _systemModel;//��ȡ��ǰϵͳ��Ϣ����
        public int TotalRecord;

        #region ��¼��Ա��Ϣ����
        /// <summary>
        /// �õ���¼��Ա��Ϣ
        /// </summary>
        protected YouhooSysUsersModel UserModel
        {
            get
            {
                if (_userModel == null)//�ж��û��Ƿ�Ϊ��
                {
                    _userModel = new YouhooSysUsersBLL().GetModel(GetUserId);//�����û�id��ȡ�û���Ϣ
                }
                return _userModel;
            }
            set { _userModel = value; }
        }

        /// <summary>
        /// �õ��û�ID
        /// </summary>
        public int GetUserId
        {
            get
            {
                return DataConvert.ToInt32(Session["UserId"]);
            }
        }
        #endregion

        #region �õ�ϵͳ��Ϣ
        /// <summary>
        /// �õ�ϵͳ��Ϣ
        /// </summary>
        public static YouhooSysSystemSetModel SystemModel
        {
            get
            {
                if (_systemModel == null)
                {
                    _systemModel = new YouhooSysSystemSetBLL().GetModel();
                }
                return _systemModel;
            }
            set { _systemModel = value; }
        }
        #endregion

        #region �ж�Ȩ���Ƿ����
        /// <summary>
        /// �ж��Ƿ����Ȩ�ޱ��
        /// </summary>
        /// <param name="power">Ȩ�ޱ��</param>
        /// <returns></returns>
        public bool IsPowerExistence(string power)
        {
            if (UserModel != null)
            {
                return Converts.IsStringSplit(UserModel.PowergroupValue, ',', power);
            }
            else
            {
                return false;
            }
        }
        #endregion

        #region ���ݲ�����ִ�еĲ���
        /// <summary>
        /// ���ݲ�����ִ�еĲ���
        /// </summary>
        public void DataInexistence()
        {
            StringBuilder script = new StringBuilder();
            script.Append("<!DOCTYPE html>");
            script.Append("<html xmlns=\"http://www.w3.org/1999/xhtml\">");
            script.Append("<head>");
            script.Append("<meta http-equiv=\"Content-Type\" content=\"text/html; charset=utf-8\" />");
            script.Append("<meta http-equiv=\"Content-Type\" content=\"text/html; charset=utf-8\" />");
            script.Append("<meta name=\"renderer\" content=\"webkit|ie-stand|ie-comp\" />");
            script.Append("<meta http-equiv=\"X-UA-Compatible\" content=\"IE=edge,chrome=1\" />");
            script.Append("<meta name=\"viewport\" content=\"width=device-width, initial-scale=1, maximum-scale=1, user-scalable=no\" />");
            script.Append("<title>��Ǹ�������ʵ���Ϣ�����ڣ�</title>");
            script.Append("<link rel=\"Stylesheet\" type=\"text/css\" href=\"/Js/jsPrompt/css/prompt.css\" />");
            script.Append("<script type=\"text/javascript\" src=\"/Js/jquery-1.8.2.min.js\"></script>");
            script.Append("<script type=\"text/javascript\" src=\"/Js/jsPrompt/js/prompt.js\"></script>");
            script.Append("<script type=\"text/javascript\">");
            script.Append("$(function(){");
            script.Append("top.msgbox.prompt(\"��Ǹ�������ʵ���Ϣ�����ڣ�\");");
            script.Append("})");
            script.Append("</script>");
            script.Append("</head>");
            script.Append("<body>");
            script.Append("</body>");
            script.Append("</html>");
            Response.Write(script.ToString());
            Response.End();
        }
        #endregion
    }
}