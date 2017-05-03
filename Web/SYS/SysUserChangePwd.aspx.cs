using System;
using System.Web.UI.HtmlControls;
using YouHoo.DataTools;
using YouHoo.DataBll;
using YouHoo.DataModel;
using System.Web.Security;
using System.IO;
using System.Web;

namespace YouHoo.Web.SYS
{
    public partial class SysUserChangePwd : BasePage
    {
        private readonly YouhooSysUsersBLL bll = new YouhooSysUsersBLL();
        protected override void Page_Load(object sender, EventArgs e)
		{
            base.Page_Load(sender, e);
            if (!IsPostBack)
            {
                if (GetUserId != 0)
                {
                    txtnewPwd2.CssClass = "validate[required,equals[" + txtnewPwd.ClientID + "]]";
                    lblName.Text = UserModel.Username;
                }
            }
        }

        #region "修改"按钮的单击事件
        /// <summary>
        /// "修改"按钮的单击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btn_save_Click(object sender, EventArgs e)
        {
            //获取登录用户信息
            YouhooSysUsersModel model = bll.GetModel(GetUserId);
            if (StringHelper.Md5(txtoldPwd.Text.Trim()) == model.Password)
            {
                model.Password = StringHelper.Md5(txtnewPwd.Text.Trim());
                string returnInfo = "";
                if (DatabasePrompt.Prompt(bll.InsertUpdate(model, GetUserId), "密码修改成功，请重新登录！", "密码修改失败！", true, "/Login.aspx", true, 2, out returnInfo, this))
                {
                    //清除用户登录缓存
                    CacheHelper.RemoveSearchCache(YouhooSysUsersBLL.CacheName);
                    Session["UserId"] = null;
                }
            }
            else
            {
                PublicPrompt.Fail("原密码错误，请重新输入！", this);
                txtoldPwd.Text = "";
                txtoldPwd.Focus();
            }
        } 
        #endregion
    }
}
