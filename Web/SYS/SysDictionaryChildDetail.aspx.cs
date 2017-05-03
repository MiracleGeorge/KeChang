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
    public partial class SysDictionaryChildDetail : BasePage
    {
        private YouhooSysDictionaryChildBLL bll = new YouhooSysDictionaryChildBLL();

        protected override void Page_Load(object sender, EventArgs e)
        {
            base.Page_Load(sender, e);
            if (!IsPostBack)
            {
                YouhooSysDictionaryChildModel model = bll.GetModel(DataRequest.QueryInt("dictionary_child_id"));
                if (model == null)
                {
                    DataInexistence();
                    return;
                }
                hf_id.Value = model.DictionaryChildId.ToString();
                lbl_dictionary_child_name.Text = model.DictionaryChildName;
                YouhooSysDictionaryModel ysd_model = new YouhooSysDictionaryBLL().GetModel(model.DictionaryId);
                if (ysd_model != null) lbl_dictionary_id.Text = ysd_model.DictionaryName;
                YouhooSysDictionaryChildModel ysdc_model = new YouhooSysDictionaryChildBLL().GetModel(model.ParentDictionaryChildId);
                if (ysdc_model != null) lbl_parent_dictionary_child_id.Text = ysdc_model.DictionaryChildName;
                lbl_is_start.Text = "<img src='../Images/" + (model.IsStart == 1 ? "active.gif" : "no_active.gif") + "' alt='暂无图片' />";
                lbl_sort.Text = model.Sort.ToString();
                lbl_remark.Text = model.Remark;
                btn_update.Visible = IsPowerExistence("010803");
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
            WebPage.Redirect("SysDictionaryChildEdit.aspx?PageIndex=" + DataRequest.QueryString("PageIndex") + "&dictionary_child_id=" + DataRequest.QueryString("dictionary_child_id") + "&ReturnUrl=" + DataRequest.QueryString("ReturnUrl"), this);
        }
        #endregion
    }
}
