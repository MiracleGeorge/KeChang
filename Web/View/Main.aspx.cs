using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Text;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using YouHoo.DataBll;
using YouHoo.DataModel;
using YouHoo.DataTools;

namespace YouHoo.Web.View
{
    public partial class Main : BasePage
    {
        protected override void Page_Load(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(SystemModel.SystemSetIcon)) lt_icon.Text = "<link rel=\"shortcut icon\" href=\"" + SystemModel.SystemSetIcon + "\"></link>";
            base.Page_Load(sender, e);
            if (!IsPostBack)
            {
                if (UserModel != null)
                {
                    YouhooSysStoreModel storeModel = new YouhooSysStoreBLL().GetModel(UserModel.Storeid);
                    if (storeModel != null)
                    {
                        lbl_store_name.Text = storeModel.Name.ToString();
                    }
                    lbl_real_name.Text = string.IsNullOrEmpty(UserModel.RealName) ? UserModel.Username : UserModel.RealName;
                    hf_customizationPower.Value = IsPowerExistence("080703") ? "1" : "0";
                }
            }
        }
    }
}