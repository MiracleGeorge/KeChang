using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using YouHoo.Web;
using YouHoo.DataBll;
using YouHoo.DataModel;
using YouHoo.DataTools;
using Newtonsoft.Json;

namespace YouHoo.Web.SYS
{
    public partial class DataAction : BasePage
    {
        protected override void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string rmsg = "{msg:'未定义操作',flag:'0'}";
                string action = DataRequest.FormString("act").ToLower();
                switch (action)
                {
                    case "ajaxupdate":
                        rmsg = AjaxUpdate();
                        break;
                    case "ajaxuser":
                        rmsg = AjaxUser();
                        break;
                    case "ajaxuserpwd":
                        rmsg = AjaxUserPwd();
                        break;
                    case "ajaxvalidatecode":
                        rmsg = AjaxValidateCode();
                        break;
                    default:
                        break;
                }
                Response.Write(rmsg);
                Response.End();
            }
        }

        #region Ajax修改
        /// <summary>
        /// Ajax修改
        /// </summary>
        /// <returns></returns>
        protected string AjaxUpdate()
        {
            string rmsg = "{msg:'未定义操作',flag:'0'}";
            //获取bll名称
            string bllName = DataRequest.FormString("bllName");
            //获取ID
            int id = DataRequest.FormInt("id");
            //获取字段名称
            string field = DataRequest.FormString("field");
            //获取值
            string value = DataRequest.FormString("value");

            object[] parameter = new object[1] { id };
            object obj = ReflectionHelper.ExecMethod(Type.GetType("YouHoo.DataBll." + bllName + ", DataBll"), "GetModel", parameter);
            if (obj != null)
            {
                ReflectionHelper.SetPropertyValue(obj, field, value);
                parameter = new object[2]{obj, GetUserId};
                string returnInfo = "";
                int errorCode = DataConvert.ToInt32(ReflectionHelper.ExecMethod(Type.GetType("YouHoo.DataBll." + bllName + ", DataBll"), "InsertUpdate", parameter));
                DatabasePrompt.GetPromptInfo(errorCode, "修改", out returnInfo, this);
                rmsg = "{msg:'" + returnInfo + "',flag:'" + errorCode + "'}";
            }
            return rmsg;
        } 
        #endregion

        #region 验证用户名是否可用
        /// <summary>
        /// 验证用户名是否可用
        /// </summary>
        /// <returns></returns>
        private string AjaxUser()
        {
            string rmsg = "{msg:'未定义操作',flag:'0'}";
            //获取用户名
            string username = DataRequest.FormString("fieldValue").Trim();
            //用户名存在
            if (new YouhooSysUsersBLL().Exists(username))
            {
                rmsg = "{status:false}";
            }
            //用户名可用
            else
            {
                rmsg = "{status:true}";
            }
            return rmsg;
        }
        #endregion

        #region 验证原密码是否正确
        /// <summary>
        /// 验证原密码是否正确
        /// </summary>
        /// <returns></returns>
        private string AjaxUserPwd()
        {
            string rmsg = "{msg:'未定义操作',flag:'0'}";
            //获取原密码
            string oldPwd = DataRequest.FormString("fieldValue").Trim();
            //密码正确
            if (StringHelper.Md5(oldPwd) == UserModel.Password)
            {
                rmsg = "{status:true}";
            }
            //密码错误
            else
            {
                rmsg = "{status:false}";
            }
            return rmsg;
        }
        #endregion

        #region 验证验证码是否正确
        /// <summary>
        /// 验证验证码是否正确
        /// </summary>
        /// <returns></returns>
        protected string AjaxValidateCode()
        {
            string rmsg = "{msg:'未定义操作',flag:'0'}";
            //获取验证码
            string code = DataRequest.FormString("fieldValue").Trim();
            //验证码正确
            if (Session[ASPNETAJAXWeb.ValidateCode.Page.ValidateCode.VALIDATECODEKEY] != null && code == Session[ASPNETAJAXWeb.ValidateCode.Page.ValidateCode.VALIDATECODEKEY].ToString().Trim().ToLower())
            {
                rmsg = "{status:true}";
            }
            //验证码错误
            else
            {
                rmsg = "{status:false}";
            }
            return rmsg;
        }
        #endregion
    }
}