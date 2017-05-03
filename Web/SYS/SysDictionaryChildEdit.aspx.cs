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
    public partial class SysDictionaryChildEdit : BasePage
    {
        private YouhooSysDictionaryChildBLL bll = new YouhooSysDictionaryChildBLL();

        protected override void Page_Load(object sender, EventArgs e)
        {
            base.Page_Load(sender, e);
            if (!IsPostBack)
            {
                Converts.SetControlsData(ddl_dictionary_id, new YouhooSysDictionaryBLL().GetList(" order by a.sort asc"), "dictionary_name", "dictionary_id", true, "--请选择--");
                if (DataRequest.QueryExists("dictionary_child_id"))
                {
                    YouhooSysDictionaryChildModel model = bll.GetModel(DataRequest.QueryInt("dictionary_child_id"));
                    if (model == null)
                    {
                        DataInexistence();
                        return;
                    }
                    hf_id.Value = model.DictionaryChildId.ToString();
                    txt_dictionary_child_name.Text = model.DictionaryChildName;
                    ddl_dictionary_id.SelectedValue = model.DictionaryId.ToString();
                    YouhooSysDictionaryModel ysd_model = new YouhooSysDictionaryBLL().GetModel(model.DictionaryId);
                    if (ysd_model != null) hf_is_multilayer.Value = ysd_model.IsMultilayer.ToString();
                    Converts.SetControlsData(ddl_parent_dictionary_child_id, Converts.ConvertControlTree(new YouhooSysDictionaryChildBLL().GetList(" and a.dictionary_id = " + model.DictionaryId + " and a.is_start = 1"), "dictionary_child_name", "dictionary_child_id", "parent_dictionary_child_id", "0"), "dictionary_child_name", "dictionary_child_id", true, "--请选择--");
                    ddl_parent_dictionary_child_id.SelectedValue = model.ParentDictionaryChildId.ToString();
                    cbo_is_start.Checked = model.IsStart == 1;
                    txt_sort.Text = model.Sort.ToString();
                    txt_remark.Text = model.Remark;
                }
                else
                {
                    //获取所属字典ID
                    int dictionaryId = DataRequest.QueryInt("dictionary_id");
                    ddl_dictionary_id.SelectedValue = dictionaryId.ToString();
                    YouhooSysDictionaryModel ysd_model = new YouhooSysDictionaryBLL().GetModel(dictionaryId);
                    if (ysd_model != null) hf_is_multilayer.Value = ysd_model.IsMultilayer.ToString();
                    Converts.SetControlsData(ddl_parent_dictionary_child_id, Converts.ConvertControlTree(new YouhooSysDictionaryChildBLL().GetList(" and a.dictionary_id = " + dictionaryId + " and a.is_start = 1"), "dictionary_child_name", "dictionary_child_id", "parent_dictionary_child_id", "0"), "dictionary_child_name", "dictionary_child_id", true, "--请选择--");
                    ddl_parent_dictionary_child_id.SelectedValue = DataRequest.QueryString("parent_dictionary_child_id");
                }
                btn_save.Visible = (IsPowerExistence("010802") && !DataRequest.QueryExists("dictionary_child_id")) || (IsPowerExistence("010803") && DataRequest.QueryExists("dictionary_child_id"));
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
            YouhooSysDictionaryChildModel model = new YouhooSysDictionaryChildModel();
            if (DataRequest.QueryExists("dictionary_child_id"))
            {
                model = bll.GetModel(DataRequest.QueryInt("dictionary_child_id"));
                if (model == null)
                {
                    DataInexistence();
                    return;
                }
            }
            model.DictionaryChildName = txt_dictionary_child_name.Text.Trim();
            model.DictionaryId = DataConvert.ToInt32(ddl_dictionary_id.SelectedValue);
            model.ParentDictionaryChildId = DataConvert.ToInt32(ddl_parent_dictionary_child_id.SelectedValue);
            model.IsStart = cbo_is_start.Checked ? 1 : 0;
            model.Sort = DataConvert.ToInt32(txt_sort.Text.Trim());
            model.Remark = txt_remark.Text.Trim();
            if (DataRequest.QueryExists("dictionary_child_id"))
            {
                if (DatabasePrompt.Save(bll.InsertUpdate(model, GetUserId), this))
                {
                    if (hf_is_multilayer.Value == "1")
                    {
                        PublicPrompt.CloseDialogAndRefreshChildContent(this);
                    }
                    else
                    {
                        PublicPrompt.CloseDialogAndRefreshContent(this);
                    }
                }
            }
            else
            {
                if (DatabasePrompt.Save(bll.InsertUpdate(model, GetUserId), this))
                {
                    if (hf_is_multilayer.Value == "1")
                    {
                        PublicPrompt.CloseDialogAndRefreshChildContent(this);
                    }
                    else
                    {
                        PublicPrompt.CloseDialogAndRefreshContent(this);
                    }
                }
            }
        }
        #endregion
    }
}
