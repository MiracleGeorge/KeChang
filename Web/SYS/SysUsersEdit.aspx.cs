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
using System.Collections.Generic;

namespace YouHoo.Web.SYS
{
	public partial class SysUsersEdit : BasePage
	{
		private YouhooSysUsersBLL bll = new YouhooSysUsersBLL();

		protected override void Page_Load(object sender, EventArgs e)
		{
            base.Page_Load(sender, e);
			if (!IsPostBack)
			{
                Converts.SetControlsData(ddl_Store, new YouhooSysStoreBLL().GetList(" and a.id>0 order by a.code asc"), "name", "id", true, "--请选择--");
                ddl_Department.Items.Add(new ListItem("--请选择--", ""));
                BindData();
                if (DataRequest.QueryExists("user_id"))
                {
                    YouhooSysUsersModel model = bll.GetModel(DataRequest.QueryInt("user_id"));
                    if (model == null)
                    {
                        DataInexistence();
                        return;
                    }
                    hf_id.Value = model.UserId.ToString();
                    hf_Store.Value = model.Storeid.ToString();
                    hf_Department.Value = model.Departmentid.ToString();
                    hf_username.Value = model.Username;
                    txt_username.Text = model.Username;
                    txt_usercode.Text = model.Usercode;
                    txt_real_name.Text = model.RealName;
                    txt_phone.Text = model.Phone;
                    txt_tel.Text = model.Tel;
                    txt_email.Text = model.Email;
                    hf_powergroup_id.Value = model.PowergroupId.ToString();
                    ddl_SaleMan.SelectedValue = model.Issaleman.ToString();
                    ddl_status.SelectedValue = model.Status.ToString();
                    txt_remark.Text = model.Remark;
				}
                Bindstoredeptlevel();
				btn_save.Visible = IsPowerExistence("010502") || IsPowerExistence("010503");
			}
		}

        #region 绑定门店部门级别信息
        /// <summary>
        /// 绑定地区信息
        /// </summary>
        protected void Bindstoredeptlevel()
        {
            ddl_Store.SelectedValue = hf_Store.Value;
            if (hf_Store.Value != "0")
            {
                Converts.SetControlsData(ddl_Department, new YouhooSysDepartmentBLL().GetList(" and a.storeid = " + hf_Store.Value + ""), "name", "id", true, "--请选择--");
                ddl_Department.SelectedValue = hf_Department.Value;

                Converts.SetControlsData(ddl_powergroup_id, new YouhooSysPowergroupBLL().GetList(" and a.storeid = " + hf_Store.Value + ""), "powergroup_name", "powergroup_id", true, "--请选择--");
                ddl_powergroup_id.SelectedValue = hf_powergroup_id.Value;
            }
        }
        #endregion

        #region 绑定数据
        /// <summary>
        /// 绑定数据
        /// </summary>
        protected void BindData()
        {
            ddl_powergroup_id.DataSource = new YouhooSysPowergroupBLL().GetList("");
            ddl_powergroup_id.DataTextField = "powergroup_name";
            ddl_powergroup_id.DataValueField = "powergroup_id";
            ddl_powergroup_id.DataBind();
            ddl_powergroup_id.Items.Insert(0, new ListItem("--请选择--", ""));
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
            YouhooSysUsersModel model = new YouhooSysUsersModel();
            if (DataRequest.QueryExists("user_id"))
            {
                model = bll.GetModel(DataRequest.QueryInt("user_id"));
                if (model == null)
                {
                    DataInexistence();
                    return;
                }
            }
            else
            {
                model.Password = StringHelper.Md5(SystemModel.InitialPwd);
            }
            model.Storeid = DataConvert.ToInt32(hf_Store.Value);
            model.Departmentid = DataConvert.ToInt32(hf_Department.Value);
            model.Username = txt_username.Text.Trim();
            model.Usercode = txt_usercode.Text.Trim();
            model.Phone = txt_phone.Text.Trim();
            model.RealName = txt_real_name.Text.Trim();
            model.Tel = txt_tel.Text.Trim();
            model.Email = txt_email.Text.Trim();
            model.PowergroupId = DataConvert.ToInt32(hf_powergroup_id.Value);
            model.Issaleman = DataConvert.ToBoolean(ddl_SaleMan.SelectedValue);
            model.Status = DataConvert.ToInt32(ddl_status.SelectedValue);
            model.Remark = txt_remark.Text.Trim();
            DatabasePrompt.PromptParam = new Dictionary<int, string>();
            DatabasePrompt.PromptParam.Add(-101, "用户名已存在！");
            if (DatabasePrompt.Save(bll.InsertUpdate(model, GetUserId), this))
            {
                PublicPrompt.CloseDialogAndRefresh(this);
            }
		}
		#endregion
	}
}
