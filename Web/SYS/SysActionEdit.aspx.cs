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
	public partial class SysActionEdit : BasePage
	{
		private YouhooSysActionBLL bll = new YouhooSysActionBLL();

		protected override void Page_Load(object sender, EventArgs e)
		{
            base.Page_Load(sender, e);
			if (!IsPostBack)
			{
                if (DataRequest.QueryExists("action_id"))
				{
                    YouhooSysActionModel model = bll.GetModel(DataRequest.QueryInt("action_id"));
                    if (model == null)
                    {
                        DataInexistence();
                        return;
                    }
                    hf_id.Value = model.ActionId.ToString();
                    txt_action_name.Text = model.ActionName;
                    txt_action_value.Text = model.ActionValue;
                    txt_remark.Text = model.Remark;
				}
                btn_save.Visible = (IsPowerExistence("010102") && !DataRequest.QueryExists("action_id")) || (IsPowerExistence("010103") && DataRequest.QueryExists("action_id"));
			}
		}

		#region "保存"按钮的单击事件
		/// <summary>
		/// "保存"按钮的单击事件
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		protected void btn_save_Click(object sender, EventArgs e)
        {
			YouhooSysActionModel model = new YouhooSysActionModel();
            if (DataRequest.QueryExists("action_id"))
			{
                model = bll.GetModel(DataRequest.QueryInt("action_id"));
                if (model == null)
                {
                    DataInexistence();
                    return;
                }
			}
            model.ActionName = txt_action_name.Text.Trim();
            model.ActionValue = txt_action_value.Text.Trim();
            model.Remark = txt_remark.Text.Trim();
            if (DatabasePrompt.Save(bll.InsertUpdate(model, GetUserId), this))
            {
                PublicPrompt.CloseDialogAndRefresh(this);
            }
		}
		#endregion
	}
}
