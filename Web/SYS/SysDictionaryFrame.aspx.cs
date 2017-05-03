using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using YouHoo.DataBll;
using YouHoo.DataTools;

namespace YouHoo.Web.SYS
{
    public partial class SysDictionaryFrame : BasePage
    {
        private YouhooSysDictionaryBLL bll = new YouhooSysDictionaryBLL();

        protected override void Page_Load(object sender, EventArgs e)
        {
            base.Page_Load(sender, e);
            if (!IsPostBack)
            {
                BindData();
            }
        }

        #region 绑定数据
        /// <summary>
        /// 绑定数据
        /// </summary>
        protected void BindData()
        {
            rp_dictionary.DataSource = bll.GetList(" order by a.sort asc");
            rp_dictionary.DataBind();
        }
        #endregion

        #region 控件行命令事件
        /// <summary>
        /// 控件行命令事件
        /// </summary>
        /// <param name="source"></param>
        /// <param name="e"></param>
        protected void rp_dictionary_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            switch (e.CommandName)
            {
                case "delete":
                    if (DatabasePrompt.Delete(bll.Delete(e.CommandArgument.ToString(), GetUserId), this))
                    {
                        PublicPrompt.CloseDialogAndRefresh("SysDictionaryFrame.aspx", this);
                    }
                    break;
            }
        }
        #endregion
    }
}