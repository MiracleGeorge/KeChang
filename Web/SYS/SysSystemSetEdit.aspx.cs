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
    public partial class SysSystemSetEdit : BasePage
    {
        private YouhooSysSystemSetBLL bll = new YouhooSysSystemSetBLL();

        protected override void Page_Load(object sender, EventArgs e)
        {
            base.Page_Load(sender, e);
            if (!IsPostBack)
            {
                YouhooSysSystemSetModel model = bll.GetModel();
                if (model == null)
                {
                    DataInexistence();
                    return;
                }
                hf_id.Value = model.SystemSetId.ToString();
                txt_system_set_name.Text = model.SystemSetName;
                txt_system_set_hou_logo.Text = model.SystemSetHouLogo;
                txt_system_set_login_biaozhi.Text = model.SystemSetLoginBiaozhi;
                txt_system_set_icon.Text = model.SystemSetIcon;
                txt_initialCode.Attributes["value"] = model.InitialPwd;
                txt_list_show_count.Text = model.ListShowCount.ToString();
                btn_save.Visible = IsPowerExistence("010603");
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
            YouhooSysSystemSetModel model = bll.GetModel();
            if (model == null)
            {
                DataInexistence();
                return;
            }
            model.SystemSetName = txt_system_set_name.Text.Trim();
            model.SystemSetHouLogo = txt_system_set_hou_logo.Text.Trim();
            model.SystemSetLoginBiaozhi = txt_system_set_login_biaozhi.Text.Trim();
            model.SystemSetIcon = txt_system_set_icon.Text.Trim();
            model.InitialPwd = txt_initialCode.Text.Trim();
            txt_initialCode.Attributes["value"] = model.InitialPwd;
            model.ListShowCount = DataConvert.ToInt32(txt_list_show_count.Text.Trim());
            DatabasePrompt.Save(bll.InsertUpdate(model, GetUserId), this);
            BasePage.SystemModel = null;
            BaseControl.SystemModel = null;
        }
        #endregion
    }
}
