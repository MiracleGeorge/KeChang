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
using YouHoo.DataBll;
using YouHoo.Web;
using YouHoo.DataTools;
using YouHoo.DataModel;

namespace YouHoo.Web.SYS
{
	public partial class SysDictionaryChildList : BasePage
	{
		private readonly YouhooSysDictionaryChildBLL bll = new YouhooSysDictionaryChildBLL();

		protected override void Page_Load(object sender, EventArgs e)
		{
			base.Page_Load(sender, e);
			if (!IsPostBack)
			{
				hf_returnUrl.Value = DataRequest.UrlEncode(Request.RawUrl);
				AspNetPager1.CurrentPageIndex = DataRequest.QueryInt("PageIndex");//获取当前页数
                btn_search.Visible = IsPowerExistence("010801");//查询按钮权限控制
                btn_add.Visible = IsPowerExistence("010802");//添加按钮权限控制
                btn_update.Visible = IsPowerExistence("010803");//修改按钮权限控制
                btn_delete.Visible = IsPowerExistence("010804");//删除按钮权限控制
                btn_start.Visible = IsPowerExistence("010809");//启用按钮权限控制
                btn_disabled.Visible = IsPowerExistence("010810");//不启用按钮权限控制
				BindData();//绑定数据
			}
		}

		#region 绑定数据
		/// <summary>
		/// 绑定数据
		/// </summary>
		private void BindData()
        {
            //获取字典ID
            int dictionaryId = DataRequest.QueryInt("dictionary_id");
            string strWhere = " and a.dictionary_id = " + dictionaryId;
            if (!string.IsNullOrEmpty(txt_dictionary_child_name.Text.Trim()))
            {
                strWhere += " and a.dictionary_child_name like '%" + txt_dictionary_child_name.Text.Trim() + "%'";
            }
            else
            {
                //获取字典信息
                YouhooSysDictionaryModel ysd_model = new YouhooSysDictionaryBLL().GetModel(dictionaryId);
                if (ysd_model != null && ysd_model.IsMultilayer == 1)
                {
                    strWhere += " and a.parent_dictionary_child_id = " + DataRequest.QueryInt("dictionary_child_id");
                    DataGrid1.ShowParentPower = true;
                }
            }
            DataGrid1.UpdatePower = btn_update.Visible;
            DataGrid1.DeletePower = btn_delete.Visible;
            DataGrid1.StartPower = btn_start.Visible;
            DataGrid1.DisabledPower = btn_disabled.Visible;
			hf_pageIndex.Value = (DataGrid1.PageIndex = AspNetPager1.CurrentPageIndex).ToString();
            hf_pageIndex.Value = AspNetPager1.CurrentPageIndex.ToString();
			DataGrid1.Bind(bll.GetListByPage(AspNetPager1.CurrentPageIndex, PageSize, strWhere, "a.sort asc", out TotalRecord));//绑定数据
			AspNetPager1.RecordCount = TotalRecord; //总记录数
			AspNetPager1.PageSize = PageSize;       //每页显示记录数
		}
		#endregion

		#region "查询"按钮的单击事件
		/// <summary>
		/// "查询"按钮的单击事件
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		protected void btn_search_Click(object sender, EventArgs e)
		{
            AspNetPager1.CurrentPageIndex = 1;
			BindData();//绑定数据
		}
		#endregion

		#region "删除"按钮的单击事件
		/// <summary>
		/// "删除"按钮的单击事件
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		protected void btn_delete_Click(object sender, EventArgs e)
		{
            Delete(DataGrid1.SelectStr);//删除
		}

        private void Delete(string arrayId)
        {
            if (DatabasePrompt.Delete(bll.Delete(arrayId, GetUserId), this))
            {
                BindData();//绑定数据
            }
        }
        #endregion

        #region "启用"按钮的单击事件
        /// <summary>
        /// "启用"按钮的单击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btn_start_Click(object sender, EventArgs e)
        {
            Start(DataGrid1.SelectStr);//启用
        }

        private void Start(string arrayId)
        {
            if (DatabasePrompt.Custom(bll.Start(arrayId, GetUserId), "启用", this))
            {
                BindData();//绑定数据
            }
        }
        #endregion

        #region "不启用"按钮的单击事件
        /// <summary>
        /// "不启用"按钮的单击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btn_disabled_Click(object sender, EventArgs e)
        {
            Disabled(DataGrid1.SelectStr);//不启用
        }

        private void Disabled(string arrayId)
        {
            if (DatabasePrompt.Custom(bll.Disabled(arrayId, GetUserId), "不启用", this))
            {
                BindData();//绑定数据
            }
        }
        #endregion

		#region 分页控件页数改变事件
		/// <summary>
		/// 分页控件页数改变事件
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		protected void AspNetPager1_PageChanged(object sender, EventArgs e)
		{
			BindData();//绑定数据
		}
        #endregion

        #region repeater控件命令事件
        /// <summary>
        /// repeater控件命令事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void DataGrid1_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            switch (e.CommandName)
            {
                case "delete":
                    Delete(e.CommandArgument.ToString());//删除
                    break;
                case "start":
                    Start(e.CommandArgument.ToString());//启用
                    break;
                case "disabled":
                    Disabled(e.CommandArgument.ToString());//不启用
                    break;
                default:
                    break;
            }
        }
        #endregion
	}
}
