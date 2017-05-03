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
	public partial class SysDepartmentEdit : BasePage
	{
		private YouhooSysDepartmentBLL bll = new YouhooSysDepartmentBLL();

		protected override void Page_Load(object sender, EventArgs e)
		{
			base.Page_Load(sender, e);
			if (!IsPostBack)
            {
                BindData();

				if (DataRequest.QueryExists("Id"))
				{
					YouhooSysDepartmentModel model = bll.GetModel(DataRequest.QueryInt("Id"));
					if (model == null)
					{
						DataInexistence();
						return;
					}
					hf_id.Value = model.Id.ToString();
                    ddl_StoreId.SelectedValue = model.Storeid.ToString();
					txt_Code.Text = model.Code;
					txt_Name.Text = model.Name;
					txt_SubCode.Text = model.Subcode;
					txt_SubName.Text = model.Subname;
					txt_remark.Text = model.Remark;
				}
				btn_save.Visible = (IsPowerExistence("020202") && !DataRequest.QueryExists("Id")) || (IsPowerExistence("020203") && DataRequest.QueryExists("Id"));
			}
		}

        #region 绑定数据
        /// <summary>
        /// 绑定数据
        /// </summary>
        protected void BindData()
        {
            ddl_StoreId.DataSource = new YouhooSysStoreBLL().GetList("");
            ddl_StoreId.DataTextField = "Name";
            ddl_StoreId.DataValueField = "Id";
            ddl_StoreId.DataBind();
            ddl_StoreId.Items.Insert(0, new ListItem("--请选择--", ""));
        }
        #endregion

		#region "保存"按钮的单击事件
		/// <summary>
		/// "保存"按钮的单击事件
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		protected void btn_save_Click(object sender, EventArgs e)
		{
			YouhooSysDepartmentModel model = new YouhooSysDepartmentModel();
			if (DataRequest.QueryExists("Id"))
			{
				model = bll.GetModel(DataRequest.QueryInt("Id"));
				if (model == null)
				{
					DataInexistence();
					return;
				}
			}
            model.Storeid = DataConvert.ToInt32(ddl_StoreId.SelectedValue);
			model.Code = txt_Code.Text.Trim();
			model.Name = txt_Name.Text.Trim();
			model.Subcode = txt_SubCode.Text.Trim();
			model.Subname = txt_SubName.Text.Trim();
			model.Remark = txt_remark.Text.Trim();
			if (DatabasePrompt.Save(bll.InsertUpdate(model, GetUserId), this))
			{
				PublicPrompt.CloseDialogAndRefresh(this);
			}
		}
		#endregion
	}
}
