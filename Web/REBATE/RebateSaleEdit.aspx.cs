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

namespace YouHoo.Web.REBATE
{
	public partial class RebateSaleEdit : BasePage
	{
		private YouhooRebateSaleBLL bll = new YouhooRebateSaleBLL();

		protected override void Page_Load(object sender, EventArgs e)
		{
			base.Page_Load(sender, e);
			if (!IsPostBack)
			{
				if (DataRequest.QueryExists("Rebate_id"))
				{
					YouhooRebateSaleModel model = bll.GetModel(DataRequest.QueryInt("Rebate_id"));
					if (model == null)
					{
						DataInexistence();
						return;
					}
					hf_id.Value = model.RebateId.ToString();
					txt_Name.Text = model.Name;
					txt_Code.Text = model.Code;
					txt_remark.Text = model.Remark;
				}
				btn_save.Visible = (IsPowerExistence("____02") && !DataRequest.QueryExists("Rebate_id")) || (IsPowerExistence("____03") && DataRequest.QueryExists("Rebate_id"));
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
			YouhooRebateSaleModel model = new YouhooRebateSaleModel();
			if (DataRequest.QueryExists("Rebate_id"))
			{
				model = bll.GetModel(DataRequest.QueryInt("Rebate_id"));
				if (model == null)
				{
					DataInexistence();
					return;
				}
			}
			model.Name = txt_Name.Text.Trim();
			model.Code = txt_Code.Text.Trim();
			model.Remark = txt_remark.Text.Trim();
			if (DatabasePrompt.Save(bll.InsertUpdate(model, GetUserId), this))
			{
				PublicPrompt.CloseDialogAndRefresh(this);
			}
		}
		#endregion
	}
}
