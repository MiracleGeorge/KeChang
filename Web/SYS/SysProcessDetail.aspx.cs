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
	public partial class SysProcessDetail : BasePage
	{
		private YouhooSysProcessBLL bll = new YouhooSysProcessBLL();

		protected override void Page_Load(object sender, EventArgs e)
		{
			base.Page_Load(sender, e);
			if (!IsPostBack)
			{
				YouhooSysProcessModel model = bll.GetModel(DataRequest.QueryInt("ID"));
				if (model == null)
				{
					DataInexistence();
					return;
				}
				hf_id.Value = model.Id.ToString();
				lbl_Name.Text = model.Name;
				lbl_Sort.Text = model.Sort.ToString();
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
			WebPage.Redirect("SysProcessEdit.aspx?PageIndex=" + DataRequest.QueryString("PageIndex") + "&ID=" + DataRequest.QueryString("ID") + "&ReturnUrl=" + DataRequest.QueryString("ReturnUrl"), this);
		}
		#endregion
	}
}
