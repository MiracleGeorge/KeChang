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
    public partial class SysActionDetail : BasePage
    {
        private YouhooSysActionBLL bll = new YouhooSysActionBLL();

        protected override void Page_Load(object sender, EventArgs e)
        {
            base.Page_Load(sender, e);
            if (!IsPostBack)
            {
                YouhooSysActionModel model = bll.GetModel(DataRequest.QueryInt("action_id"));
                if (model == null)
                {
                    DataInexistence();
                    return;
                }
                hf_id.Value = model.ActionId.ToString();
                lbl_action_name.Text = model.ActionName;
                lbl_action_value.Text = model.ActionValue;
                lbl_remark.Text = model.Remark;
                btn_update.Visible = IsPowerExistence("010103");
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
            WebPage.Redirect("SysActionEdit.aspx?PageIndex=" + DataRequest.QueryString("PageIndex") + "&action_id=" + DataRequest.QueryString("action_id") + "&ReturnUrl=" + DataRequest.QueryString("ReturnUrl"), this);
        }
        #endregion
    }
}
