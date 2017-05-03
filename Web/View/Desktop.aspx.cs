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
    public partial class Desktop : BasePage
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
                        lbl_org_name.Text = storeModel.Name.ToString();
                    }
                    YouhooSysDepartmentModel deptModel = new YouhooSysDepartmentBLL().GetModel(UserModel.Departmentid);
                    if (deptModel != null)
                    {
                        lbl_dept_name.Text = deptModel.Name.ToString();
                    }

                    //登录信息
                    lbl_real_name.Text = string.IsNullOrEmpty(UserModel.RealName) ? UserModel.Username : UserModel.RealName;
                    YouhooSysPowergroupModel ysp_model = new YouhooSysPowergroupBLL().GetModel(UserModel.PowergroupId);
                    if (ysp_model != null) lbl_powergroup_name.Text = ysp_model.PowergroupName;
                    HttpCookie cookie_last = Request.Cookies["UserLoginInfo_LastTime"];
                    if (cookie_last != null && cookie_last.Values["LoginId"] == GetUserId.ToString()) lbl_login_time.Text = cookie_last.Values["LoginTime"];
                    //系统信息
                    lbl_system_directory.Text = Request.PhysicalApplicationPath;
                    lbl_net_version.Text = DataRequest.GetNetEngine;
                    lbl_server_ip.Text = DataRequest.GetHostIP().ToString();
                }
            }
        }
    }
}