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
	public partial class SysModuleDetail : BasePage
	{
		private YouhooSysModuleBLL bll = new YouhooSysModuleBLL();

		protected override void Page_Load(object sender, EventArgs e)
		{
            base.Page_Load(sender, e);
			if (!IsPostBack)
			{
                if (DataRequest.QueryString("module_id") != "")
                {
                    YouhooSysModuleModel model = bll.GetModel(DataRequest.QueryInt("module_id"));
                    hf_id.Value = model.ModuleId.ToString();
                    lbl_module_name.Text = model.ModuleName;
                    //获取父级模块
                    YouhooSysModuleModel ysmm_model = new YouhooSysModuleBLL().GetModel(model.ParentmoduleId);
                    if (ysmm_model != null)
                    {
                        lbl_parentmodule_id.Text = ysmm_model.ModuleName;
                    }
                    lbl_module_url.Text = model.ModuleUrl;
                    lbl_module_value.Text = model.ModuleValue;
                    lbl_sort.Text = model.Sort.ToString();
                    lbl_remark.Text = model.Remark;
				}
				btn_update.Visible = IsPowerExistence("010203");
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
            WebPage.Redirect("SysModuleEdit.aspx?PageIndex=" + DataRequest.QueryString("PageIndex") + "&module_id=" + DataRequest.QueryString("module_id") + "&ReturnUrl=" + DataRequest.QueryString("ReturnUrl"), this);
		}
		#endregion
	}
}
