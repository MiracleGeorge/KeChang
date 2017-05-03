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

        #region "�޸�"��ť�ĵ����¼�
        /// <summary>
        /// "�޸�"��ť�ĵ����¼�
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btn_save_Click(object sender, EventArgs e)
        {
            //��ȡ��¼�û���Ϣ
            YouhooSysUsersModel model = bll.GetModel(GetUserId);
            if (StringHelper.Md5(txtoldPwd.Text.Trim()) == model.Password)
            {
                model.Password = StringHelper.Md5(txtnewPwd.Text.Trim());
                string returnInfo = "";
                if (DatabasePrompt.Prompt(bll.InsertUpdate(model, GetUserId), "�����޸ĳɹ��������µ�¼��", "�����޸�ʧ�ܣ�", true, "/Login.aspx", true, 2, out returnInfo, this))
                {
                    //����û���¼����
                    CacheHelper.RemoveSearchCache(YouhooSysUsersBLL.CacheName);
                    Session["UserId"] = null;
                }
            }
            else
            {
                PublicPrompt.Fail("ԭ����������������룡", this);
                txtoldPwd.Text = "";
                txtoldPwd.Focus();
            }
        } 
        #endregion
    }
}
