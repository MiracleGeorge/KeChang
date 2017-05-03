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
	public partial class SysNodeEdit : BasePage
	{
		private YouhooSysNodeBLL bll = new YouhooSysNodeBLL();

		protected override void Page_Load(object sender, EventArgs e)
		{
			base.Page_Load(sender, e);
			if (!IsPostBack)
            {
                BindData();

                Converts.SetControlsData(ddl_Store, new YouhooSysStoreBLL().GetList(" and a.id>0 order by a.code asc"), "name", "id", true, "--请选择--");
                ddl_powergroup_id.Items.Add(new ListItem("--请选择--", ""));

				if (DataRequest.QueryExists("ID"))
				{
					YouhooSysNodeModel model = bll.GetModel(DataRequest.QueryInt("ID"));
					if (model == null)
					{
						DataInexistence();
						return;
					}
					hf_id.Value = model.Id.ToString();
					txt_NodeName.Text = model.Nodename;
                    ddl_ProcessId.SelectedValue = model.Processid.ToString();
                    hf_powergroup_id.Value = model.Roleid.ToString();
                    hf_Store.Value = model.Storeid.ToString();
                    //txt_StoreId.Text = model.Storeid.ToString();
                    //txt_RoleId.Text = model.Roleid.ToString();
					txt_remark.Text = model.Remark;
				}
                Bindstorepower();
				btn_save.Visible = (IsPowerExistence("030202") && !DataRequest.QueryExists("ID")) || (IsPowerExistence("030203") && DataRequest.QueryExists("ID"));
			}
		}

        #region 绑定数据
        /// <summary>
        /// 绑定数据
        /// </summary>
        protected void BindData()
        {
            ddl_ProcessId.DataSource = new YouhooSysProcessBLL().GetList("");
            ddl_ProcessId.DataTextField = "Name";
            ddl_ProcessId.DataValueField = "Id";
            ddl_ProcessId.DataBind();
            ddl_ProcessId.Items.Insert(0, new ListItem("--请选择--", ""));
        }
        #endregion

        #region 绑定门店部门级别信息
        /// <summary>
        /// 绑定地区信息
        /// </summary>
        protected void Bindstorepower()
        {
            ddl_Store.SelectedValue = hf_Store.Value;
            if (hf_Store.Value != "0")
            {
                Converts.SetControlsData(ddl_powergroup_id, new YouhooSysPowergroupBLL().GetList(" and a.storeid = " + hf_Store.Value + ""), "powergroup_name", "powergroup_id", true, "--请选择--");
                ddl_powergroup_id.SelectedValue = hf_powergroup_id.Value;
            }
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
			YouhooSysNodeModel model = new YouhooSysNodeModel();
			if (DataRequest.QueryExists("ID"))
			{
				model = bll.GetModel(DataRequest.QueryInt("ID"));
				if (model == null)
				{
					DataInexistence();
					return;
				}
			}
			model.Nodename = txt_NodeName.Text.Trim();
            model.Processid = DataConvert.ToInt32(ddl_ProcessId.SelectedValue);
            model.Storeid = DataConvert.ToInt32(hf_Store.Value);
            model.Roleid = DataConvert.ToInt32(hf_powergroup_id.Value);
            //model.Storeid = DataConvert.ToInt32(txt_StoreId.Text.Trim());
            //model.Roleid = DataConvert.ToInt32(txt_RoleId.Text.Trim());
			model.Remark = txt_remark.Text.Trim();
			if (DatabasePrompt.Save(bll.InsertUpdate(model, GetUserId), this))
			{
				PublicPrompt.CloseDialogAndRefresh(this);
			}
		}
		#endregion
	}
}
