using System;
using YouHoo.DataBll;
using YouHoo.DataModel;
using YouHoo.DataTools;
using System.Web.Security;

namespace YouHoo.Web
{
    public partial class LoginOut : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //����û���¼����
            CacheHelper.RemoveSearchCache(YouhooSysUsersBLL.CacheName);
            Session["UserId"] = null;
            WebPage.Redirect("/Login.aspx", this);
        }
    }
}
