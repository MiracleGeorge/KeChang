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

namespace YouHoo.Web.REBATE
{
	public partial class RebateRebatepolicyList : BasePage
	{
		private readonly YouhooRebateRebatepolicyBLL bll = new YouhooRebateRebatepolicyBLL();
		
		protected override void Page_Load(object sender, EventArgs e)
		{
			base.Page_Load(sender, e);
			if (!IsPostBack)
			{
				hf_returnUrl.Value = DataRequest.UrlEncode(Request.RawUrl);
				AspNetPager1.CurrentPageIndex = DataRequest.QueryInt("PageIndex");//获取当前页数
				btn_search.Visible = IsPowerExistence("030201");//查询按钮权限控制
				btn_add.Visible = IsPowerExistence("030202");//添加按钮权限控制
				btn_update.Visible = IsPowerExistence("030203");//修改按钮权限控制
				btn_delete.Visible = IsPowerExistence("030204");//删除按钮权限控制
                BindDropDownListData();//绑定查询条件下拉框列表
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
            if (IsPostBack)
            {

                if (ddl_searchChannel.Text != "0")
                {
                    strWhere += " and a.channel_id =" + ddl_searchChannel.Text + "";
                }
                if (ddl_searchBrand.Text != "0")
                {
                    strWhere += " and a.brand_id = " + ddl_searchBrand.Text + "";
                }
                if (ddl_searchRegion.Text != "0")
                {
                    strWhere += " and a.region_id = " + ddl_searchRegion.Text + "";
                }

                var data = bll.GetListByPage(AspNetPager1.CurrentPageIndex, AspNetPager1.PageSize, strWhere, "a.id desc", out TotalRecord);

                //根据查询结果 判断除品牌，渠道，地区条件选项是否可以使用
                if (data.Rows.Count < 1)
                {
                    ddl_searchSort.Enabled = false;
                    ddl_supportWay.Enabled = false;
                    ddl_supportPrice.Enabled = false;
                    ddl_searchItem.Enabled = false;
                    ddl_searchTime.Enabled = false;
                    ddl_searchPrice.Enabled = false;
                }
                else
                {
                    ddl_searchSort.Enabled = true;
                    ddl_supportWay.Enabled = true;
                    ddl_supportPrice.Enabled = true;
                    ddl_searchItem.Enabled = true;
                    ddl_searchTime.Enabled = true;
                    ddl_searchPrice.Enabled = true;
                }


                if (ddl_searchItem.Text != "0")
                {
                    strWhere += " and a.item_id = " + ddl_searchItem.Text + "";
                }
                if (ddl_searchTime.Text != "0")
                {
                    strWhere += " and a.time_id = " + ddl_searchTime.Text + "";
                }
                if (ddl_supportWay.Text != "0")
                {
                    strWhere += " and a.supportWay_id = " + ddl_supportWay.Text + "";
                }
                if (ddl_supportPrice.Text != "0")
                {
                    strWhere += " and a.supportPrice_id = " + ddl_supportPrice.Text + "";
                }
                if (ddl_searchSort.Text != "0")
                {
                    strWhere += " and a.sort_id_id = " + ddl_searchSort.Text + "";
                }
                if (ddl_searchPrice.Text != "0")
                {
                    strWhere += " and a.price_id = " + ddl_searchPrice.Text + "";
                }

                DataGrid1.UpdatePower = btn_update.Visible;
                DataGrid1.DeletePower = btn_delete.Visible;
                AspNetPager1.PageSize = PageSize;//每页显示记录数
                hf_pageIndex.Value = (DataGrid1.PageIndex = AspNetPager1.CurrentPageIndex).ToString();
                data = bll.GetListByPage(AspNetPager1.CurrentPageIndex, AspNetPager1.PageSize, strWhere, "a.id desc", out TotalRecord);
                DataGrid1.Bind(data);//绑定数据
                AspNetPager1.RecordCount = TotalRecord;//总记录数
            }
            else
            {

                DataGrid1.UpdatePower = btn_update.Visible;
                DataGrid1.DeletePower = btn_delete.Visible;
                AspNetPager1.PageSize = PageSize;//每页显示记录数
                hf_pageIndex.Value = (DataGrid1.PageIndex = AspNetPager1.CurrentPageIndex).ToString();
                var data = bll.GetListByPage(AspNetPager1.CurrentPageIndex, AspNetPager1.PageSize, strWhere, "a.id desc", out TotalRecord);
                DataGrid1.Bind(data);//绑定数据
                AspNetPager1.RecordCount = TotalRecord;//总记录数
            }


           

        }
        /// <summary>
        /// 根据下拉框的查询条件获取数据的行数,如果行数为0，则禁用还未选择的项
        /// </summary>
        private void GetDataRowCountByWhere()
        {
            string strWhere = "";
            if (ddl_searchChannel.Text != "0")
            {
                strWhere += " and a.channel_id =" + ddl_searchChannel.Text + "";
            }
            if (ddl_searchBrand.Text != "0")
            {
                strWhere += " and a.brand_id = " + ddl_searchBrand.Text + "";
            }
            if (ddl_searchRegion.Text != "0")
            {
                strWhere += " and a.region_id = " + ddl_searchRegion.Text + "";
            }
            if (ddl_searchItem.Text != "0")
            {
                strWhere += " and a.item_id = " + ddl_searchItem.Text + "";
            }
            if (ddl_searchTime.Text != "0")
            {
                strWhere += " and a.time_id = " + ddl_searchTime.Text + "";
            }
            if (ddl_supportWay.Text != "0")
            {
                strWhere += " and a.supportWay_id = " + ddl_supportWay.Text + "";
            }
            if (ddl_supportPrice.Text != "0")
            {
                strWhere += " and a.supportPrice = " + ddl_supportPrice.Text + "";
            }
            if (ddl_searchSort.Text != "0")
            {
                strWhere += " and a.sort_id_id = " + ddl_searchSort.Text + "";
            }
            if (ddl_searchPrice.Text != "0")
            {
                strWhere += " and a.price_id = " + ddl_searchPrice.Text + "";
            }
            
            var data = bll.GetListByPage(AspNetPager1.CurrentPageIndex, AspNetPager1.PageSize, strWhere, "a.id desc", out TotalRecord);

            if (data.Rows.Count < 0)
            {
                if (ddl_searchChannel.Text == "0")
                {
                    ddl_searchChannel.Enabled = false;
                }
                if (ddl_searchBrand.Text == "0")
                {
                    ddl_searchBrand.Enabled = false;
                }
                if (ddl_searchRegion.Text == "0")
                {
                    ddl_searchRegion.Enabled = false;
                }
                if (ddl_searchItem.Text == "0")
                {
                    ddl_searchItem.Enabled = false;
                }
                if (ddl_searchTime.Text == "0")
                {
                    ddl_searchTime.Enabled = false;
                }
                if (ddl_supportWay.Text == "0")
                {
                    ddl_supportWay.Enabled = false;
                }
                if (ddl_supportPrice.Text == "0")
                {
                    ddl_supportPrice.Enabled = false;
                }
                if (ddl_searchSort.Text == "0")
                {
                    ddl_searchSort.Enabled = false;
                }
                if (ddl_searchPrice.Text == "0")
                {
                    ddl_searchPrice.Enabled = false;
                }
            }
        }

        /// <summary>
        /// 绑定查询用的条件下拉框数据
        /// </summary>
        private void BindDropDownListData()
        {
            //品牌
            ddl_searchBrand.DataSource = new YouhooBasicarchiveBrandBLL().GetList("");
            ddl_searchBrand.DataTextField = "Name";
            ddl_searchBrand.DataValueField = "id";
            ddl_searchBrand.DataBind();
            ddl_searchBrand.Items.Insert(0, new ListItem("请选择", "0"));
            //渠道
            ddl_searchChannel.DataSource = new YouhooBasicarchiveChannelBLL().GetList("");
            ddl_searchChannel.DataTextField = "Name";
            ddl_searchChannel.DataValueField = "id";
            ddl_searchChannel.DataBind();
            ddl_searchChannel.Items.Insert(0, new ListItem("请选择", "0"));
            //地区
            ddl_searchRegion.DataSource = new YouhooBasicarchiveRegionBLL().GetList("");
            ddl_searchRegion.DataTextField = "Name";
            ddl_searchRegion.DataValueField = "id";
            ddl_searchRegion.DataBind();
            ddl_searchRegion.Items.Insert(0, new ListItem("请选择", "0"));
            //品类
            ddl_searchSort.DataSource = new YouhooBasicarchiveSortBLL().GetList("");
            ddl_searchSort.DataTextField = "Name";
            ddl_searchSort.DataValueField = "id";
            ddl_searchSort.DataBind();
            ddl_searchSort.Items.Insert(0, new ListItem("请选择", "0"));
            //品项
            ddl_searchItem.DataSource = new YouhooBasicarchiveItemBLL().GetList("");
            ddl_searchItem.DataTextField = "Name";
            ddl_searchItem.DataValueField = "id";
            ddl_searchItem.DataBind();
            ddl_searchItem.Items.Insert(0, new ListItem("请选择", "0"));
            //时段
            ddl_searchTime.DataSource = new YouhooBasicarchiveTimeBLL().GetList("");
            ddl_searchTime.DataTextField = "Name";
            ddl_searchTime.DataValueField = "id";
            ddl_searchTime.DataBind();
            ddl_searchTime.Items.Insert(0, new ListItem("请选择", "0"));
            //支持金额
            ddl_supportPrice.DataSource = new YouhooBasicarchiveSupportpriceBLL().GetList("");
            ddl_supportPrice.DataTextField = "Name";
            ddl_supportPrice.DataValueField = "id";
            ddl_supportPrice.DataBind();
            ddl_supportPrice.Items.Insert(0, new ListItem("请选择", "0"));
            //支持方式
            ddl_supportWay.DataSource = new YouhooBasicarchiveSupportwayBLL().GetList("");
            ddl_supportWay.DataTextField = "Name";
            ddl_supportWay.DataValueField = "id";
            ddl_supportWay.DataBind();
            ddl_supportWay.Items.Insert(0, new ListItem("请选择", "0"));
            //金额
            ddl_searchPrice.DataSource = new YouhooBasicarchivePriceBLL().GetList("");
            ddl_searchPrice.DataTextField = "Name";
            ddl_searchPrice.DataValueField = "id";
            ddl_searchPrice.DataBind();
            ddl_searchPrice.Items.Insert(0, new ListItem("请选择", "0"));
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
            if (DatabasePrompt.Delete(bll.Delete(arrayId, GetUserId, ConfigurationManager.ConnectionStrings["ConnectionString"].ToString()), this))
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
				default:
					break;
			}
		}
        #endregion



       
    }
}
