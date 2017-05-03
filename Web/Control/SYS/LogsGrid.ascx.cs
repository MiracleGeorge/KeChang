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
using System.Collections.Generic;
using YouHoo.Web;
using YouHoo.DataTools;

namespace YouHoo.Web.Control.SYS
{
    public partial class LogsGrid : BaseControl
    {
        public int PageIndex = 0;

        public void Bind(object source)
        {
            rp_data.DataSource = source;
            rp_data.DataBind();
        }
    }
}
