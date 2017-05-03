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
	public partial class VisitRecordEdit : BasePage
	{
		private YouhooVisitRecordBLL bll = new YouhooVisitRecordBLL();

		protected override void Page_Load(object sender, EventArgs e)
		{
			base.Page_Load(sender, e);
			if (!IsPostBack)
            {

                BindData();

                if (DataRequest.QueryExists("visit_id"))
				{
					YouhooVisitRecordModel model = bll.GetModel(DataRequest.QueryInt("visit_id"));
					if (model == null)
					{
						DataInexistence();
						return;
					}
					hf_id.Value = model.VisitId.ToString();
                    ddl_cusName.SelectedItem.Text = model.Ccusname ;
                    ddl_visitWay.SelectedValue = model.VisitWayId.ToString();
					txt_cCusAbbName.Text = model.Ccusabbname;
					txt_cCusCode.Text = model.Ccuscode;
					txt_phoneNumber.Text = model.Phonenumber;
					txt_cCusPerson.Text = model.Ccusperson;
					txt_visit_date.Text = model.VisitDate.ToString("yyyy-MM-dd");
					txt_visit_location.Text = model.VisitLocation;
					txt_visit_person.Text = model.VisitPerson;
					txt_visit_startTime.Text = model.VisitStarttime.ToString();
					txt_visit_endTime.Text = model.VisitEndtime.ToString();
					//txt_visit_way_id.Text = model.VisitWayId.ToString();
					txt_visit_content.Text = model.VisitContent;
					txt_visit_NextPlan.Text = model.VisitNextplan;
					txt_visit_ManagerOpinion.Text = model.VisitManageropinion;
					//txt_verifi_state.Text = model.VerifiState.ToString();
					txt_remark.Text = model.Remark;


                }


				btn_save.Visible = (IsPowerExistence("040102") && !DataRequest.QueryExists("visit_id")) || (IsPowerExistence("040103") && DataRequest.QueryExists("visit_id"));
			}
		}

        /// <summary>
        /// 绑定页面下拉框绑定数据
        /// </summary>
        public void BindData()
        {
            ddl_visitWay.DataSource = new YouhooVisitVisitwayBLL().GetList("");
            ddl_visitWay.DataTextField = "visit_name";
            ddl_visitWay.DataValueField = "visit_way_id";
            ddl_visitWay.DataBind();
            ddl_visitWay.Items.Insert(0, new ListItem("请选择", "0"));

            ddl_cusName.DataSource = new Ufida.UFCustomer().GetCustomerModel();
            ddl_cusName.DataTextField = "ccusName";
            ddl_cusName.DataValueField = "ccusCode";
            ddl_cusName.DataBind();
            ddl_cusName.Items.Insert(0, new ListItem("请选择", "0"));
        }

		#region "保存"按钮的单击事件
		/// <summary>
		/// "保存"按钮的单击事件
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		protected void btn_save_Click(object sender, EventArgs e)
		{
			YouhooVisitRecordModel model = new YouhooVisitRecordModel();
			if (DataRequest.QueryExists("visit_id"))
			{
				model = bll.GetModel(DataRequest.QueryInt("visit_id"));
				if (model == null)
				{
					DataInexistence();
					return;
				}
			}
            if (ddl_visitWay.Text != "")
            {
                model.Ccusname = ddl_cusName.SelectedItem.Text.Trim();
            }
            else
            {
                model.Ccusname = null;
            }
            model.Ccusabbname = txt_cCusAbbName.Text.Trim();
			model.Ccuscode = txt_cCusCode.Text.Trim();
			model.Phonenumber = txt_phoneNumber.Text.Trim();
			model.Ccusperson = txt_cCusPerson.Text.Trim();
			model.VisitDate = DataConvert.ToDateTime(txt_visit_date.Text.Trim());
			model.VisitLocation = txt_visit_location.Text.Trim();
			model.VisitPerson = txt_visit_person.Text.Trim();
			model.VisitStarttime = DataConvert.ToDateTime(txt_visit_startTime.Text.Trim());
			model.VisitEndtime = DataConvert.ToDateTime(txt_visit_endTime.Text.Trim());
            if (ddl_visitWay.Text != "")
            {
                model.VisitWayId= DataConvert.ToInt32(ddl_visitWay.SelectedValue);
            }
            else
            {
                model.VisitWayId = null;
            }
			
			model.VisitContent = txt_visit_content.Text.Trim();
			model.VisitNextplan = txt_visit_NextPlan.Text.Trim();
			model.VisitManageropinion = txt_visit_ManagerOpinion.Text.Trim();
			//model.VerifiState = DataConvert.ToInt32(txt_verifi_state.Text.Trim());
			model.Remark = txt_remark.Text.Trim();
			if (DatabasePrompt.Save(bll.InsertUpdate(model, GetUserId), this))
			{
				PublicPrompt.CloseDialogAndRefresh(this);
			}
		}
        #endregion






        protected void ddl_cusName_SelectedIndexChanged(object sender, EventArgs e)
        {
            Ufida.UFCustomer cus = new Ufida.UFCustomer();
            var currentCus=  cus.GetCustomerModel(ddl_cusName.SelectedValue);
            if (currentCus != null)
            {
                txt_cCusCode.Text =currentCus.cCusCode;
                txt_cCusAbbName.Text = currentCus.cCusAbbName;
                txt_cCusPerson.Text = currentCus.cCusPerson;
                txt_phoneNumber.Text = currentCus.cCusPhone;
                txt_visit_location.Text = currentCus.cCusAddress;
            }
        }
    }
}
