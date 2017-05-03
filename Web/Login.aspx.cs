using System;
using YouHoo.DataBll;
using YouHoo.DataModel;
using YouHoo.DataTools;
using System.Web.Security;
using System.Web;
using System.Web.UI.HtmlControls;
using System.Data;

namespace YouHoo.Web
{
    public partial class Login : BasePage
    {
        private readonly YouhooSysUsersBLL _sysUsersBll = new YouhooSysUsersBLL();

        protected override void Page_Load(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(SystemModel.SystemSetIcon)) lt_icon.Text = "<link rel=\"shortcut icon\" href=\"" + SystemModel.SystemSetIcon + "\"></link>";
            if (!IsPostBack)
            {
                //验证用户名是否存在
                if (Request.Cookies["Username"] != null)
                {
                    txtUserName.Text = Request.Cookies["Username"].Value.ToString();
                    txtUserPwd.Focus();
                }
                else
                {
                    txtUserName.Focus();
                }
            }
        }

        #region "登录"按钮的单击事件
        /// <summary>
        /// "登录"按钮的单击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnLogin_Click(object sender, EventArgs e)
        {
            string userName = txtUserName.Text.Trim();//用户名
            string userPwd = txtUserPwd.Text.Trim();//密码
            string code = txtCode.Text.Trim();//验证码

            if (userName.Equals("") || userPwd.Equals(""))//判断用户名和密码是否为空
            {
                PublicPrompt.Warning("请输入用户名或密码！", this);
                txtUserName.Focus();
                return;
            }
            //判断验证码是否正确
            if (!(Session[ASPNETAJAXWeb.ValidateCode.Page.ValidateCode.VALIDATECODEKEY] != null && txtCode.Text.Trim().ToLower() == Session[ASPNETAJAXWeb.ValidateCode.Page.ValidateCode.VALIDATECODEKEY].ToString().Trim().ToLower()))
            {
                PublicPrompt.Warning("验证码错误，请重新输入！", this);
                txtCode.Text = "";
                return;
            }
            //根据用户名和密码查找用户信息
            YouhooSysUsersModel model = _sysUsersBll.GetModelByUserNamePassWord(userName, StringHelper.Md5(userPwd));
            //验证是否存在此用户
            if (model == null)
            {
                PublicPrompt.Warning("用户名或密码错误！", this);
                txtCode.Text = "";
                txtUserPwd.Focus();
                return;
            }
            //保存用户名
            HttpCookie cookie = new HttpCookie("Username");
            cookie.Value = model.Username;
            cookie.Expires = DateTime.Now.AddMonths(1);
            Response.Cookies.Add(cookie);
            //获取上一次登录时间
            HttpCookie cookie_curr = Request.Cookies["UserLoginInfo_CurrTime"];
            HttpCookie cookie_last = new HttpCookie("UserLoginInfo_LastTime");
            if (cookie_curr != null && cookie_curr.Values["LoginId"] == model.UserId.ToString())
            {
                cookie_last.Values["LoginId"] = cookie_curr.Values["LoginId"];
                cookie_last.Values["LoginTime"] = cookie_curr.Values["LoginTime"];
                cookie_last.Expires = DateTime.Now.AddYears(1);
                Response.Cookies.Add(cookie_last);
            }
            cookie_curr = new HttpCookie("UserLoginInfo_CurrTime");
            cookie_curr.Values["LoginId"] = model.UserId.ToString();
            cookie_curr.Values["LoginTime"] = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            cookie_curr.Expires = DateTime.Now.AddYears(1);
            Response.Cookies.Add(cookie_curr);

            Session["UserId"] = model.UserId.ToString();//写入Session（用户id）
            Logger.Info("管理员登录：" + model.Username);//添加此用户登录日志

            //删除开发者登录
            cookie = new HttpCookie("IsDeveloper");
            cookie.Expires = DateTime.Now.AddDays(-1);
            Response.Cookies.Add(cookie);
            Response.Redirect("/View/Main.aspx");//登录成功后跳转到的页面
        }
        #endregion
    }
}
