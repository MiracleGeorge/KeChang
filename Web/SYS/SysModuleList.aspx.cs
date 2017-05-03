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

namespace YouHoo.Web.SYS
{
	public partial class SysModuleList : BasePage
	{
		private readonly YouhooSysModuleBLL bll = new YouhooSysModuleBLL();
		protected override void Page_Load(object sender, EventArgs e)
		{
            base.Page_Load(sender, e);
			if (!IsPostBack)
			{
                hf_returnUrl.Value = DataRequest.UrlEncode(Request.RawUrl);
                btn_search.Visible = IsPowerExistence("010201");//查询按钮权限控制
				btn_add.Visible = IsPowerExistence("010202");//添加按钮权限控制
				btn_update.Visible = IsPowerExistence("010203");//修改按钮权限控制
				btn_delete.Visible = IsPowerExistence("010204");//删除按钮权限控制
				BindData();//绑定数据
			}
		}

		#region 绑定数据
		/// <summary>
		/// 绑定数据
		/// </summary>
		private void BindData()
		{
            string strWhere = "";
            if (!string.IsNullOrEmpty(txt_search_field.Text.Trim()))
            {
                strWhere += " and a.module_name like '%" + txt_search_field.Text.Trim() + "%'";
            }
            DataGrid1.UpdatePower = btn_update.Visible;
            DataGrid1.DeletePower = btn_delete.Visible;
            hf_pageIndex.Value = (DataGrid1.PageIndex = AspNetPager1.CurrentPageIndex).ToString();
            hf_pageIndex.Value = AspNetPager1.CurrentPageIndex.ToString();
            DataGrid1.Bind(bll.GetListByPage(AspNetPager1.CurrentPageIndex, PageSize, strWhere, "a.module_value asc", out TotalRecord));//绑定数据
            AspNetPager1.RecordCount = TotalRecord; //总记录数
            AspNetPager1.PageSize = PageSize;       //每页显示记录数

            //DataGrid1.UpdatePower = btn_update.Visible;
            //DataGrid1.DeletePower = btn_delete.Visible;
            //DataGrid1.Bind(Converts.ConvertTableTree(bll.GetList(" order by a.sort asc"), "module_name", "module_id", "parentmodule_id", "0"));//绑定模块数据
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
			if (!IsPowerExistence("010201"))
			{
				PublicPrompt.Alert("您没有权限查询数据！", this);
				return;
            }
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
            if (!IsPowerExistence("010204"))
            {
                PublicPrompt.Alert("您没有权限删除数据！", this);
                return;
            }
            if (DatabasePrompt.Delete(bll.Delete(arrayId, GetUserId), this))
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
            if (e.CommandName == "delete")
            {
                Delete(e.CommandArgument.ToString());//删除
            }
        }
        #endregion
	}
}
