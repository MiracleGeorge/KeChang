using System;
using YouHoo.Web;
using YouHoo.DataBll;
using YouHoo.DataModel;
namespace YouHoo.Web
{
    public partial class PageEdit : System.Web.UI.MasterPage
    {
        private YouhooSysSystemSetModel _systemModel;
        /// <summary>
        /// 系统信息
        /// </summary>
        public YouhooSysSystemSetModel SystemModel
        {
            get
            {
                if (_systemModel == null) _systemModel = new YouhooSysSystemSetBLL().GetModel();
                return _systemModel;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(SystemModel.SystemSetIcon)) lt_icon.Text = "<link rel=\"shortcut icon\" href=\"" + SystemModel.SystemSetIcon + "\"></link>";
        }
    }
}