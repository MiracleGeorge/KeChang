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
	public partial class SysPowerDetail : BasePage
	{
		private YouhooSysPowerBLL bll = new YouhooSysPowerBLL();

		protected override void Page_Load(object sender, EventArgs e)
		{
            base.Page_Load(sender, e);
			if (!IsPostBack)
			{
                if (DataRequest.QueryString("power_id") != "")
                {
                    YouhooSysPowerModel model = bll.GetModel(DataRequest.QueryInt("power_id"));
                    hf_id.Value = model.PowerId.ToString();
                    YouhooSysModuleModel ysmm_model = new YouhooSysModuleBLL().GetModel(model.ModuleId);
                    if (ysmm_model != null)
                    {
                        lbl_module_id.Text = ysmm_model.ModuleName;
                    }
                    YouhooSysActionModel ysam_model = new YouhooSysActionBLL().GetModel(model.ActionId);
                    if (ysam_model != null)
                    {
                        lbl_action_id.Text = ysam_model.ActionName;
                    }
                    lbl_power_value.Text = model.PowerValue;
                    lbl_remark.Text = model.Remark;
				}
				btn_update.Visible = IsPowerExistence("010303");
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
            WebPage.Redirect("SysPowerEdit.aspx?PageIndex=" + DataRequest.QueryString("PageIndex") + "&power_id=" + DataRequest.QueryString("power_id") + "&ReturnUrl=" + DataRequest.QueryString("ReturnUrl"), this);
		}
		#endregion
	}
}
