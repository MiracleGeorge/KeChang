using System;
using System.Configuration;
using YouHoo.DataModel;
using YouHoo.DataBll;
using YouHoo.DataTools;
using System.Linq;

namespace YouHoo.Web.REBATE
{
    public partial class RebateRebatepolicyDetail : BasePage
	{
		private YouhooRebateRebatepolicyBLL bll = new YouhooRebateRebatepolicyBLL();

		protected override void Page_Load(object sender, EventArgs e)
		{
			base.Page_Load(sender, e);
			if (!IsPostBack)
			{
				YouhooRebateRebatepolicyModel model = bll.GetModel(DataRequest.QueryInt("id"));
				if (model == null)
				{
					DataInexistence();
					return;
				}
				hf_id.Value = model.Id.ToString();
				lbl_Code.Text = model.Code;
				lbl_Name.Text = model.Name;

                //获取返利维度所对应的中文名称
                var PolicyArchiveName= bll.GetPolicyArchiveName(DataRequest.QueryInt("id"),ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
                if(PolicyArchiveName !=null)
                {
                    lbl_channel_id.Text = PolicyArchiveName.ChannelName != null ? PolicyArchiveName.ChannelName : "";
                    lbl_price_id.Text = PolicyArchiveName.PriceName != null ? PolicyArchiveName.PriceName : "";
                    lbl_region_id.Text = PolicyArchiveName.RegionName != null ? PolicyArchiveName.RegionName : "";
                    lbl_sort_id_id.Text = PolicyArchiveName.SortName != null ? PolicyArchiveName.SortName : "";
                    lbl_SupportWay_id.Text = PolicyArchiveName.SupportWayName != null ? PolicyArchiveName.SupportWayName : ""; 
                    lbl_SupportPrice_id.Text = PolicyArchiveName.SupportPriceName != null ? PolicyArchiveName.SupportPriceName : "";
                    lbl_RebateType_id.Text = PolicyArchiveName.RebateWayName != null ? PolicyArchiveName.RebateWayName : "";
                    lbl_time_id.Text = PolicyArchiveName.TimeName != null ? PolicyArchiveName.TimeName : "";
                    lbl_remark.Text = PolicyArchiveName.remark != null ? PolicyArchiveName.remark : "";
                    btn_update.Visible = IsPowerExistence("030203");
                    //绑定表体数据
                    BindReapterPolicyDetails();
                }
                else
                {
                    DataInexistence();
                    return;
                }
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
			WebPage.Redirect("RebateRebatepolicyEdit.aspx?PageIndex=" + DataRequest.QueryString("PageIndex") + "&id=" + DataRequest.QueryString("id") + "&ReturnUrl=" + DataRequest.QueryString("ReturnUrl"), this);
		}


        private void BindReapterPolicyDetails()
        {
            //查询价格策略子表
            DataBll.REBATE.KechangDataContext kc = new DataBll.REBATE.KechangDataContext(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
            
                int Id =DataConvert.ToInt32(hf_id.Value);
                Reapter_PolicyDetails.DataSource= kc.v_RebatePolicys.Where(x=>x.PolicyId==Id);
                Reapter_PolicyDetails.DataBind();
        }
		#endregion
	}
}
