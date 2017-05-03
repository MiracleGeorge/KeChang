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
	public partial class VisitVisitwayEdit : BasePage
	{
		private YouhooVisitVisitwayBLL bll = new YouhooVisitVisitwayBLL();

		protected override void Page_Load(object sender, EventArgs e)
		{
			base.Page_Load(sender, e);
			if (!IsPostBack)
			{
				if (DataRequest.QueryExists("visit_way_id"))
				{
					YouhooVisitVisitwayModel model = bll.GetModel(DataRequest.QueryInt("visit_way_id"));
					if (model == null)
					{
						DataInexistence();
						return;
					}
					hf_id.Value = model.ToString();
					//txt_visit_way_id.Text = model.VisitWayId.ToString();
					txt_visit_name.Text = model.VisitName;
					txt_remark.Text = model.Remark;
				}
				btn_save.Visible = (IsPowerExistence("040202") && !DataRequest.QueryExists("visit_way_id")) || (IsPowerExistence("040203") && DataRequest.QueryExists("visit_way_id"));
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
			YouhooVisitVisitwayModel model = new YouhooVisitVisitwayModel();
			if (DataRequest.QueryExists("visit_way_id"))
			{
				model = bll.GetModel(DataRequest.QueryInt("visit_way_id"));
				if (model == null)
				{
					DataInexistence();
					return;
				}
			}
			//model.VisitWayId = DataConvert.ToInt32(txt_visit_way_id.Text.Trim());
			model.VisitName = txt_visit_name.Text.Trim();
			model.Remark = txt_remark.Text.Trim();
			if (DatabasePrompt.Save(bll.InsertUpdate(model, GetUserId), this))
			{
				PublicPrompt.CloseDialogAndRefresh(this);
			}
		}
		#endregion
	}
}
