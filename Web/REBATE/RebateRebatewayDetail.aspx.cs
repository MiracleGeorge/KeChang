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
	public partial class RebateRebatewayDetail : BasePage
	{
		private YouhooRebateRebatewayBLL bll = new YouhooRebateRebatewayBLL();

		protected override void Page_Load(object sender, EventArgs e)
		{
			base.Page_Load(sender, e);
			if (!IsPostBack)
			{
				YouhooRebateRebatewayModel model = bll.GetModel(DataRequest.QueryInt("id"));
				if (model == null)
				{
					DataInexistence();
					return;
				}
				hf_id.Value = model.Id.ToString();
               
                switch (model.RebateType)
                {
                    case "0":
                        lbl_rebate_type.Text = "采购";
                        break;
                    case "1":
                        lbl_rebate_type.Text = "销售";
                        break;
                    default:
                        break;
                }
				lbl_Name.Text = model.Name;
				lbl_Code.Text = model.Code;
				lbl_remark.Text = model.Remark;
				btn_update.Visible = IsPowerExistence("030103");
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
			WebPage.Redirect("RebateRebatewayEdit.aspx?PageIndex=" + DataRequest.QueryString("PageIndex") + "&id=" + DataRequest.QueryString("id") + "&ReturnUrl=" + DataRequest.QueryString("ReturnUrl"), this);
		}
		#endregion
	}
}
