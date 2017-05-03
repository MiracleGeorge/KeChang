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
	public partial class SysPowergroupEdit : BasePage
	{
		private YouhooSysPowergroupBLL bll = new YouhooSysPowergroupBLL();

		protected override void Page_Load(object sender, EventArgs e)
		{
            base.Page_Load(sender, e);
			if (!IsPostBack)
            {
                BindData();

                if (DataRequest.QueryExists("powergroup_id"))
                {
                    YouhooSysPowergroupModel model = bll.GetModel(DataRequest.QueryInt("powergroup_id"));
                    if (model == null)
                    {
                        DataInexistence();
                        return;
                    }
                    hf_id.Value = model.PowergroupId.ToString();
                    ddl_StoreId.SelectedValue = model.Storeid.ToString();
                    txt_powergroup_name.Text = model.PowergroupName;
                    txt_remark.Text = model.Remark;
				}
                btn_save.Visible = (IsPowerExistence("010402") && !DataRequest.QueryExists("powergroup_id")) || (IsPowerExistence("010403") && DataRequest.QueryExists("powergroup_id"));
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
			YouhooSysPowergroupModel model = new YouhooSysPowergroupModel();
            if (DataRequest.QueryExists("powergroup_id"))
			{
                model = bll.GetModel(DataRequest.QueryInt("powergroup_id"));
                if (model == null)
                {
                    DataInexistence();
                    return;
                }
			}
            model.Storeid = DataConvert.ToInt32(ddl_StoreId.SelectedValue);
            model.PowergroupName = txt_powergroup_name.Text.Trim();
            model.Remark = txt_remark.Text.Trim();
            if (DatabasePrompt.Save(bll.InsertUpdate(model, GetUserId), this))
            {
                PublicPrompt.CloseDialogAndRefresh(this);
            }
		}
		#endregion
	}
}
