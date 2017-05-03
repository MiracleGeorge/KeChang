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
    public partial class SysNodeDetail : BasePage
    {
        private YouhooSysNodeBLL bll = new YouhooSysNodeBLL();

        protected override void Page_Load(object sender, EventArgs e)
        {
            base.Page_Load(sender, e);
            if (!IsPostBack)
            {
                YouhooSysNodeModel model = bll.GetModel(DataRequest.QueryInt("ID"));
                if (model == null)
                {
                    DataInexistence();
                    return;
                }
                hf_id.Value = model.Id.ToString();
                lbl_NodeName.Text = model.Nodename;

                YouhooSysProcessModel process_Model = new YouhooSysProcessBLL().GetModel(model.Processid);
                if (process_Model != null) lbl_ProcessId.Text = process_Model.Name;
                YouhooSysStoreModel store_Model = new YouhooSysStoreBLL().GetModel(model.Storeid);
                if (store_Model != null) lbl_StoreId.Text = store_Model.Name;
                YouhooSysPowergroupModel power_Model = new YouhooSysPowergroupBLL().GetModel(model.Roleid);
                if (power_Model != null) lbl_RoleId.Text = power_Model.PowergroupName;
                
                lbl_remark.Text = model.Remark;
                btn_update.Visible = IsPowerExistence("030203");
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
            WebPage.Redirect("SysNodeEdit.aspx?PageIndex=" + DataRequest.QueryString("PageIndex") + "&ID=" + DataRequest.QueryString("ID") + "&ReturnUrl=" + DataRequest.QueryString("ReturnUrl"), this);
        }
        #endregion
    }
}
