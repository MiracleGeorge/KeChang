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
	public partial class VisitRecordDetail : BasePage
	{
		private YouhooVisitRecordBLL bll = new YouhooVisitRecordBLL();

		protected override void Page_Load(object sender, EventArgs e)
		{
			base.Page_Load(sender, e);
			if (!IsPostBack)
			{
				DataBll.VISIT.v_VisitRecordWay model =new  DataBll.YouhooVisitRecordBLLExtend().GetVisitRecordModel(DataRequest.QueryInt("visit_id"));
				if (model == null)
				{
					DataInexistence();
					return;
				}
				hf_id.Value = model.visit_id.ToString();
				lbl_cCusName.Text = model.cCusName;
				lbl_cCusAbbName.Text = model.cCusAbbName;
				lbl_cCusCode.Text = model.cCusCode;
				lbl_phoneNumber.Text = model.phoneNumber;
				lbl_cCusPerson.Text = model.cCusPerson;
				lbl_visit_date.Text = model.visit_date.ToString();
				lbl_visit_location.Text = model.visit_location;
				lbl_visit_person.Text = model.visit_person;
				lbl_visit_startTime.Text = model.visit_startTime.ToString();
				lbl_visit_endTime.Text = model.visit_endTime.ToString();
                lbl_visit_way_id.Text = model.visit_name;
				lbl_visit_content.Text = model.visit_content;
				lbl_visit_NextPlan.Text = model.visit_NextPlan;
				lbl_visit_ManagerOpinion.Text = model.visit_ManagerOpinion;
                lbl_verifi_state.Text = model.verifi_state.ToString() == "0" ? "否":"是" ;
				lbl_remark.Text = model.remark;
				btn_update.Visible = IsPowerExistence("040103");
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
			WebPage.Redirect("VisitRecordEdit.aspx?PageIndex=" + DataRequest.QueryString("PageIndex") + "&visit_id=" + DataRequest.QueryString("visit_id") + "&ReturnUrl=" + DataRequest.QueryString("ReturnUrl"), this);
		}
		#endregion
	}
}
