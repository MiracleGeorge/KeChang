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
	public partial class SysStoreEdit : BasePage
	{
		private YouhooSysStoreBLL bll = new YouhooSysStoreBLL();

		protected override void Page_Load(object sender, EventArgs e)
		{
			base.Page_Load(sender, e);
			if (!IsPostBack)
			{
				if (DataRequest.QueryExists("Id"))
				{
					YouhooSysStoreModel model = bll.GetModel(DataRequest.QueryInt("Id"));
					if (model == null)
					{
						DataInexistence();
						return;
					}
					hf_id.Value = model.Id.ToString();
					txt_Code.Text = model.Code;
					txt_SubCode.Text = model.Subcode;
					txt_SubName.Text = model.Subname;
					txt_Name.Text = model.Name;
					txt_Phone.Text = model.Phone;
					txt_PaymentTerm.Text = model.Paymentterm;
					txt_Adress.Text = model.Adress;
					txt_remark.Text = model.Remark;
				}
				btn_save.Visible = (IsPowerExistence("020102") && !DataRequest.QueryExists("Id")) || (IsPowerExistence("020103") && DataRequest.QueryExists("Id"));
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
			YouhooSysStoreModel model = new YouhooSysStoreModel();
			if (DataRequest.QueryExists("Id"))
			{
				model = bll.GetModel(DataRequest.QueryInt("Id"));
				if (model == null)
				{
					DataInexistence();
					return;
				}
			}
			model.Code = txt_Code.Text.Trim();
			model.Subcode = txt_SubCode.Text.Trim();
			model.Subname = txt_SubName.Text.Trim();
			model.Name = txt_Name.Text.Trim();
			model.Phone = txt_Phone.Text.Trim();
			model.Paymentterm = txt_PaymentTerm.Text.Trim();
			model.Adress = txt_Adress.Text.Trim();
			model.Remark = txt_remark.Text.Trim();
			if (DatabasePrompt.Save(bll.InsertUpdate(model, GetUserId), this))
			{
				PublicPrompt.CloseDialogAndRefresh(this);
			}
		}
		#endregion
	}
}
