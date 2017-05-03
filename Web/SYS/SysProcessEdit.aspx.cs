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
	public partial class SysProcessEdit : BasePage
	{
		private YouhooSysProcessBLL bll = new YouhooSysProcessBLL();

		protected override void Page_Load(object sender, EventArgs e)
		{
			base.Page_Load(sender, e);
			if (!IsPostBack)
			{
				if (DataRequest.QueryExists("ID"))
				{
					YouhooSysProcessModel model = bll.GetModel(DataRequest.QueryInt("ID"));
					if (model == null)
					{
						DataInexistence();
						return;
					}
					hf_id.Value = model.Id.ToString();
					txt_Name.Text = model.Name;
					txt_Sort.Text = model.Sort.ToString();
					txt_remark.Text = model.Remark;
				}
				btn_save.Visible = (IsPowerExistence("030102") && !DataRequest.QueryExists("ID")) || (IsPowerExistence("030103") && DataRequest.QueryExists("ID"));
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
			YouhooSysProcessModel model = new YouhooSysProcessModel();
			if (DataRequest.QueryExists("ID"))
			{
				model = bll.GetModel(DataRequest.QueryInt("ID"));
				if (model == null)
				{
					DataInexistence();
					return;
				}
			}
			model.Name = txt_Name.Text.Trim();
			model.Sort = DataConvert.ToInt32(txt_Sort.Text.Trim());
			model.Remark = txt_remark.Text.Trim();
			if (DatabasePrompt.Save(bll.InsertUpdate(model, GetUserId), this))
			{
				PublicPrompt.CloseDialogAndRefresh(this);
			}
		}
		#endregion
	}
}
