using System;
using YouHoo.DataTools;
using YouHoo.DataBll;
using YouHoo.DataModel;
using System.Web.UI;
using System.Text;

namespace YouHoo.Web
{
    /// <summary>
    /// 系统页面类
    /// 为所有控件的父页
    /// </summary>
    public class BaseControl : UserControl
    {
        private YouhooSysUsersModel _userModel;// 当前操作员信息对象
        private static YouhooSysSystemSetModel _systemModel;//获取当前系统信息对象
        public int TotalRecord;

        #region 登录人员信息属性
        /// <summary>
        /// 得到登录人员信息
        /// </summary>
        protected YouhooSysUsersModel UserModel
        {
            get
            {
                if (_userModel == null)//判断用户是否为空
                {
                    _userModel = new YouhooSysUsersBLL().GetModel(GetUserId);//根据用户id获取用户信息
                }
                return _userModel;
            }
            set { _userModel = value; }
        }

        /// <summary>
        /// 得到用户ID
        /// </summary>
        public int GetUserId
        {
            get
            {
                return DataConvert.ToInt32(Session["UserId"]);
            }
        }
        #endregion

        #region 得到系统信息
        /// <summary>
        /// 得到系统信息
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

        #region 判断权限是否存在
        /// <summary>
        /// 判断是否存在权限编号
        /// </summary>
        /// <param name="power">权限编号</param>
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

        #region 数据不存在执行的操作
        /// <summary>
        /// 数据不存在执行的操作
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
            script.Append("<title>抱歉，您访问的信息不存在！</title>");
            script.Append("<link rel=\"Stylesheet\" type=\"text/css\" href=\"/Js/jsPrompt/css/prompt.css\" />");
            script.Append("<script type=\"text/javascript\" src=\"/Js/jquery-1.8.2.min.js\"></script>");
            script.Append("<script type=\"text/javascript\" src=\"/Js/jsPrompt/js/prompt.js\"></script>");
            script.Append("<script type=\"text/javascript\">");
            script.Append("$(function(){");
            script.Append("top.msgbox.prompt(\"抱歉，您访问的信息不存在！\");");
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