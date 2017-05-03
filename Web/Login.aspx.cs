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
                //��֤�û����Ƿ����
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

        #region "��¼"��ť�ĵ����¼�
        /// <summary>
        /// "��¼"��ť�ĵ����¼�
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnLogin_Click(object sender, EventArgs e)
        {
            string userName = txtUserName.Text.Trim();//�û���
            string userPwd = txtUserPwd.Text.Trim();//����
            string code = txtCode.Text.Trim();//��֤��

            if (userName.Equals("") || userPwd.Equals(""))//�ж��û����������Ƿ�Ϊ��
            {
                PublicPrompt.Warning("�������û��������룡", this);
                txtUserName.Focus();
                return;
            }
            //�ж���֤���Ƿ���ȷ
            if (!(Session[ASPNETAJAXWeb.ValidateCode.Page.ValidateCode.VALIDATECODEKEY] != null && txtCode.Text.Trim().ToLower() == Session[ASPNETAJAXWeb.ValidateCode.Page.ValidateCode.VALIDATECODEKEY].ToString().Trim().ToLower()))
            {
                PublicPrompt.Warning("��֤��������������룡", this);
                txtCode.Text = "";
                return;
            }
            //�����û�������������û���Ϣ
            YouhooSysUsersModel model = _sysUsersBll.GetModelByUserNamePassWord(userName, StringHelper.Md5(userPwd));
            //��֤�Ƿ���ڴ��û�
            if (model == null)
            {
                PublicPrompt.Warning("�û������������", this);
                txtCode.Text = "";
                txtUserPwd.Focus();
                return;
            }
            //�����û���
            HttpCookie cookie = new HttpCookie("Username");
            cookie.Value = model.Username;
            cookie.Expires = DateTime.Now.AddMonths(1);
            Response.Cookies.Add(cookie);
            //��ȡ��һ�ε�¼ʱ��
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

            Session["UserId"] = model.UserId.ToString();//д��Session���û�id��
            Logger.Info("����Ա��¼��" + model.Username);//��Ӵ��û���¼��־

            //ɾ�������ߵ�¼
            cookie = new HttpCookie("IsDeveloper");
            cookie.Expires = DateTime.Now.AddDays(-1);
            Response.Cookies.Add(cookie);
            Response.Redirect("/View/Main.aspx");//��¼�ɹ�����ת����ҳ��
        }
        #endregion
    }
}
