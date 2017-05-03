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
    public partial class SysPowergroupDetail : BasePage
    {
        private YouhooSysPowergroupBLL bll = new YouhooSysPowergroupBLL();

        protected override void Page_Load(object sender, EventArgs e)
        {
            base.Page_Load(sender, e);
            if (!IsPostBack)
            {
                YouhooSysPowergroupModel model = bll.GetModel(DataRequest.QueryInt("powergroup_id"));
                if (model == null)
                {
                    DataInexistence();
                    return;
                }
                hf_id.Value = model.PowergroupId.ToString();
                YouhooSysStoreModel storeModel = new YouhooSysStoreBLL().GetModel(model.Storeid);
                if (storeModel != null) lbl_StoreId.Text = storeModel.Name;
                lbl_powergroup_name.Text = model.PowergroupName;
                lbl_remark.Text = model.Remark;
                btn_update.Visible = IsPowerExistence("010403");
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
            WebPage.Redirect("SysPowergroupEdit.aspx?PageIndex=" + DataRequest.QueryString("PageIndex") + "&powergroup_id=" + DataRequest.QueryString("powergroup_id") + "&ReturnUrl=" + DataRequest.QueryString("ReturnUrl"), this);
        }
        #endregion
    }
}
