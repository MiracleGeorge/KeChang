using System;
using System.Collections.Generic;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using YouHoo.DataBll;
using YouHoo.DataModel;
using YouHoo.DataTools;

namespace YouHoo.Web.SYS
{
    public partial class SysDictionaryChildFrame : BasePage
    {
        protected override void Page_Load(object sender, EventArgs e)
        {
            base.Page_Load(sender, e);
            if (!IsPostBack)
            {
                if (!DataRequest.QueryExists("act"))
                {
                    //»ñÈ¡×ÖµäID
                    int dictionaryId = DataRequest.QueryInt("dictionary_id");
                    TreeFrame.Where = " and a.dictionary_id = " + dictionaryId + " and a.is_start = 1";
                    TreeFrame.ExtendParameter = "&dictionary_id=" + dictionaryId;
                }
            }
        }
    }
}