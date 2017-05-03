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

namespace YouHoo.Web.VISIT
{
	public partial class VisitVisitwayDetail : BasePage
	{
		private YouhooVisitVisitwayBLL bll = new YouhooVisitVisitwayBLL();

		protected override void Page_Load(object sender, EventArgs e)
		{
			base.Page_Load(sender, e);
			if (!IsPostBack)
			{
				YouhooVisitVisitwayModel model = bll.GetModel(DataRequest.QueryInt("visit_way_id"));
				if (model == null)
				{
					DataInexistence();
					return;
				}
				hf_id.Value = model.ToString();
				lbl_visit_way_id.Text = model.VisitWayId.ToString();
				lbl_visit_name.Text = model.VisitName;
				lbl_remark.Text = model.Remark;
				btn_update.Visible = IsPowerExistence("040203");
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
			WebPage.Redirect("VisitVisitwayEdit.aspx?PageIndex=" + DataRequest.QueryString("PageIndex") + "&visit_way_id=" + DataRequest.QueryString("visit_way_id") + "&ReturnUrl=" + DataRequest.QueryString("ReturnUrl"), this);
		}
		#endregion
	}
}
