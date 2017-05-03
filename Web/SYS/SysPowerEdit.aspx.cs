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
	public partial class SysPowerEdit : BasePage
	{
		private YouhooSysPowerBLL bll = new YouhooSysPowerBLL();

		protected override void Page_Load(object sender, EventArgs e)
		{
            base.Page_Load(sender, e);
			if (!IsPostBack)
			{
                BindData();
                if (DataRequest.QueryString("power_id") != "")
                {
                    YouhooSysPowerModel model = bll.GetModel(DataRequest.QueryInt("power_id"));
                    hf_id.Value = model.PowerId.ToString();
                    ddl_module_id.SelectedValue = model.ModuleId.ToString();
                    ddl_action_id.SelectedValue = model.ActionId.ToString();
                    txt_power_value.Text = model.PowerValue;
                    txt_remark.Text = model.Remark;
				}
                btn_save.Visible = IsPowerExistence("010302") || IsPowerExistence("010303");
			}
        }

        #region 绑定数据
        /// <summary>
        /// 绑定数据
        /// </summary>
        protected void BindData()
        {
            foreach (DataRow o in Converts.ConvertTableTree(new YouhooSysModuleBLL().GetList(" order by a.sort asc"), "module_name", "module_id", "parentmodule_id", "0").Rows)
            {
                ddl_module_id.Items.Add(new ListItem(o["module_name"].ToString() + "_" + o["module_value"].ToString(), o["module_id"].ToString()));
            }
            foreach (DataRow o in new YouhooSysActionBLL().GetList(" order by a.action_value asc").Rows)
            {
                ddl_action_id.Items.Add(new ListItem(o["action_name"].ToString() + "_" + o["action_value"].ToString(), o["action_id"].ToString()));
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
            YouhooSysPowerModel model = new YouhooSysPowerModel();
            if (DataRequest.QueryString("power_id") == "")
            {
                if (!IsPowerExistence("010302"))
                {
                    PublicPrompt.Alert("您没有权限添加数据！", this);
                    return;
                }
            }
            else
            {
                if (!IsPowerExistence("010303"))
                {
                    PublicPrompt.Alert("您没有权限修改数据！", this);
                    return;
                }
                model = bll.GetModel(DataRequest.QueryInt("power_id"));
            }
            model.ModuleId = DataConvert.ToInt32(ddl_module_id.SelectedValue);
            model.ActionId = DataConvert.ToInt32(ddl_action_id.SelectedValue);
            model.PowerValue = hf_power_value.Value.Trim();
            model.Remark = txt_remark.Text.Trim();
            DatabasePrompt.PromptParam = new Dictionary<int, string>();
            DatabasePrompt.PromptParam.Add(-99, "标识编号已存在！");
            if (DataRequest.QueryString("power_id") == "")
            {
                DatabasePrompt.Save(bll.InsertUpdate(model, GetUserId), this);
            }
            else
            {
                if (DatabasePrompt.Save(bll.InsertUpdate(model, GetUserId), this))
                {
                    PublicPrompt.CloseDialogAndRefresh(this);
                }
            }
		}
		#endregion
	}
}
