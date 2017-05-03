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
using YouHoo.DataModel;
using YouHoo.DataBll;
using YouHoo.DataTools;

namespace YouHoo.Web.SYS
{
    public partial class SysUsersDetail : BasePage
    {
        private YouhooSysUsersBLL bll = new YouhooSysUsersBLL();

        protected override void Page_Load(object sender, EventArgs e)
        {
            base.Page_Load(sender, e);
            if (!IsPostBack)
            {
                YouhooSysUsersModel model = bll.GetModel(DataRequest.QueryInt("user_id"));
                if (model == null)
                {
                    DataInexistence();
                    return;
                }
                hf_id.Value = model.UserId.ToString();
                lbl_username.Text = model.Username;
                lbl_real_name.Text = model.RealName;
                lbl_tel.Text = model.Tel;
                lbl_email.Text = model.Email;
                lbl_usercode.Text = model.Usercode;
                YouhooSysPowergroupModel ysp_model = new YouhooSysPowergroupBLL().GetModel(model.PowergroupId);
                if (ysp_model != null) lbl_powergroup_id.Text = ysp_model.PowergroupName;
                YouhooSysStoreModel store_model = new YouhooSysStoreBLL().GetModel(model.Storeid);
                if (store_model != null) lbl_StoreId.Text = store_model.Name;
                YouhooSysDepartmentModel dept_model = new YouhooSysDepartmentBLL().GetModel(model.Departmentid);
                if (dept_model != null) lbl_departmentId.Text = dept_model.Name;
                lbl_status.Text = model.Status == 0 ? "正常" : "<span style='color:red;'>冻结</span>";
                lbl_IsSaleMan.Text = model.Issaleman == false ? "否" : "<span style='color:red;'>是</span>";
                lbl_remark.Text = model.Remark;
                btn_update.Visible = IsPowerExistence("010503");
            }
        }

        #region "修改"按钮的单击事件
        /// <summary>
        /// "修改"按钮的单击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btn_update_Click(object sender, EventArgs e)
        {
            WebPage.Redirect("SysUsersEdit.aspx?PageIndex=" + DataRequest.QueryString("PageIndex") + "&user_id=" + DataRequest.QueryString("user_id") + "&ReturnUrl=" + DataRequest.QueryString("ReturnUrl"), this);
        }
        #endregion
    }
}
