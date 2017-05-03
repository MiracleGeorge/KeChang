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
    public partial class SysDictionaryEdit : BasePage
    {
        private YouhooSysDictionaryBLL bll = new YouhooSysDictionaryBLL();

        protected override void Page_Load(object sender, EventArgs e)
        {
            base.Page_Load(sender, e);
            if (!IsPostBack)
            {
                if (DataRequest.QueryExists("dictionary_id"))
                {
                    YouhooSysDictionaryModel model = bll.GetModel(DataRequest.QueryInt("dictionary_id"));
                    if (model == null)
                    {
                        DataInexistence();
                        return;
                    }
                    hf_id.Value = model.DictionaryId.ToString();
                    txt_dictionary_name.Text = model.DictionaryName;
                    cbo_is_multilayer.Checked = model.IsMultilayer == 1;
                    txt_sort.Text = model.Sort.ToString();
                    txt_remark.Text = model.Remark;
                }
                btn_save.Visible = (IsPowerExistence("010802") && !DataRequest.QueryExists("dictionary_id")) || (IsPowerExistence("010803") && DataRequest.QueryExists("dictionary_id"));
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
            YouhooSysDictionaryModel model = new YouhooSysDictionaryModel();
            if (DataRequest.QueryExists("dictionary_id"))
            {
                model = bll.GetModel(DataRequest.QueryInt("dictionary_id"));
                if (model == null)
                {
                    DataInexistence();
                    return;
                }
            }
            model.DictionaryName = txt_dictionary_name.Text.Trim();
            model.IsMultilayer = cbo_is_multilayer.Checked ? 1 : 0;
            model.Sort = DataConvert.ToInt32(txt_sort.Text);
            model.Remark = txt_remark.Text.Trim();
            if (DatabasePrompt.Save(bll.InsertUpdate(model, GetUserId), this))
            {
                PublicPrompt.CloseDialogAndRefresh("SysDictionaryFrame.aspx", this);
            }
        }
        #endregion
    }
}
