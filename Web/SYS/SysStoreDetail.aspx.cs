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
	public partial class SysStoreDetail : BasePage
	{
		private YouhooSysStoreBLL bll = new YouhooSysStoreBLL();

		protected override void Page_Load(object sender, EventArgs e)
		{
			base.Page_Load(sender, e);
			if (!IsPostBack)
			{
				YouhooSysStoreModel model = bll.GetModel(DataRequest.QueryInt("Id"));
				if (model == null)
				{
					DataInexistence();
					return;
				}
				hf_id.Value = model.Id.ToString();
				lbl_Code.Text = model.Code;
				lbl_SubCode.Text = model.Subcode;
				lbl_SubName.Text = model.Subname;
				lbl_Name.Text = model.Name;
				lbl_Phone.Text = model.Phone;
				lbl_PaymentTerm.Text = model.Paymentterm;
				lbl_Adress.Text = model.Adress;
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
			WebPage.Redirect("SysStoreEdit.aspx?PageIndex=" + DataRequest.QueryString("PageIndex") + "&Id=" + DataRequest.QueryString("Id") + "&ReturnUrl=" + DataRequest.QueryString("ReturnUrl"), this);
		}
		#endregion
	}
}
