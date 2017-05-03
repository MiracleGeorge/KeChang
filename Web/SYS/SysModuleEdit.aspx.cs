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
	public partial class SysModuleEdit : BasePage
	{
		private YouhooSysModuleBLL bll = new YouhooSysModuleBLL();

		protected override void Page_Load(object sender, EventArgs e)
		{
            base.Page_Load(sender, e);
			if (!IsPostBack)
			{
                BindData();
                if (DataRequest.QueryString("module_id") != "")
                {
                    YouhooSysModuleModel model = bll.GetModel(DataRequest.QueryInt("module_id"));
                    hf_id.Value = model.ModuleId.ToString();
                    txt_module_name.Text = model.ModuleName;
                    ddl_parentmodule_id.SelectedValue = model.ParentmoduleId.ToString();
                    txt_module_url.Text = model.ModuleUrl;
                    txt_module_value.Text = model.ModuleValue;
                    txt_sort.Text = model.Sort.ToString();
                    txt_remark.Text = model.Remark;
				}
				btn_save.Visible = IsPowerExistence("010202") || IsPowerExistence("010203");
			}
		}

        #region ������
        /// <summary>
        /// ������
        /// </summary>
        protected void BindData()
        {
            ddl_parentmodule_id.DataSource = Converts.ConvertControlTree(bll.GetList(" order by a.sort asc"), "module_name", "module_id", "parentmodule_id", "0");
            ddl_parentmodule_id.DataTextField = "module_name";
            ddl_parentmodule_id.DataValueField = "module_id";
            ddl_parentmodule_id.DataBind();
            ddl_parentmodule_id.Items.Insert(0, new ListItem("��ѡ��", "0"));
        } 
        #endregion

		#region "����"��ť�ĵ����¼�
		/// <summary>
		/// "����"��ť�ĵ����¼�
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		protected void btn_save_Click(object sender, EventArgs e)
		{
            YouhooSysModuleModel model = new YouhooSysModuleModel();
            if (DataRequest.QueryString("module_id") == "")
			{
				if (!IsPowerExistence("010202"))
				{
                    PublicPrompt.Alert("��û��Ȩ��������ݣ�", this);
					return;
				}
			}
			else
			{
				if (!IsPowerExistence("010203"))
				{
                    PublicPrompt.Alert("��û��Ȩ���޸����ݣ�", this);
					return;
				}
                model = bll.GetModel(DataRequest.QueryInt("module_id"));
			}
            model.ModuleName = txt_module_name.Text.Trim();
            model.ParentmoduleId = DataConvert.ToInt32(ddl_parentmodule_id.SelectedValue);
            model.ModuleUrl = txt_module_url.Text.Trim();
            model.ModuleValue = txt_module_value.Text.Trim();
            model.Sort = DataConvert.ToInt32(txt_sort.Text.Trim());
            model.Remark = txt_remark.Text.Trim();
            if (DatabasePrompt.Save(bll.InsertUpdate(model, GetUserId), this))
            {
                PublicPrompt.CloseDialogAndRefresh(this);
            }
		}
		#endregion
	}
}
