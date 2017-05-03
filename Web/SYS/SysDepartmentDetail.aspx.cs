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
	public partial class SysDepartmentDetail : BasePage
	{
		private YouhooSysDepartmentBLL bll = new YouhooSysDepartmentBLL();

		protected override void Page_Load(object sender, EventArgs e)
		{
			base.Page_Load(sender, e);
			if (!IsPostBack)
			{
				YouhooSysDepartmentModel model = bll.GetModel(DataRequest.QueryInt("Id"));
				if (model == null)
				{
					DataInexistence();
					return;
				}
				hf_id.Value = model.Id.ToString();
                YouhooSysStoreModel store_Model = new YouhooSysStoreBLL().GetModel(model.Storeid);
                if (store_Model != null) lbl_StoreId.Text = store_Model.Name;
				
				lbl_Code.Text = model.Code;
				lbl_Name.Text = model.Name;
				lbl_SubCode.Text = model.Subcode;
				lbl_SubName.Text = model.Subname;
				lbl_remark.Text = model.Remark;
				btn_update.Visible = IsPowerExistence("020203");
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
			WebPage.Redirect("SysDepartmentEdit.aspx?PageIndex=" + DataRequest.QueryString("PageIndex") + "&Id=" + DataRequest.QueryString("Id") + "&ReturnUrl=" + DataRequest.QueryString("ReturnUrl"), this);
		}
		#endregion
	}
}
