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
	public partial class RebateSaleDetail : BasePage
	{
		private YouhooRebateSaleBLL bll = new YouhooRebateSaleBLL();

		protected override void Page_Load(object sender, EventArgs e)
		{
			base.Page_Load(sender, e);
			if (!IsPostBack)
			{
				YouhooRebateSaleModel model = bll.GetModel(DataRequest.QueryInt("Rebate_id"));
				if (model == null)
				{
					DataInexistence();
					return;
				}
				hf_id.Value = model.RebateId.ToString();
				lbl_Name.Text = model.Name;
				lbl_Code.Text = model.Code;
				lbl_remark.Text = model.Remark;
				btn_update.Visible = IsPowerExistence("020103");
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
			WebPage.Redirect("RebateSaleEdit.aspx?PageIndex=" + DataRequest.QueryString("PageIndex") + "&Rebate_id=" + DataRequest.QueryString("Rebate_id") + "&ReturnUrl=" + DataRequest.QueryString("ReturnUrl"), this);
		}
		#endregion
	}
}
