﻿using System;
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
public partial class VISIT_VisitRecordListEx : BasePage
{

    private readonly YouhooVisitRecordBLL bll = new YouhooVisitRecordBLL();

    private static string ccusCode = "";
    protected override void Page_Load(object sender, EventArgs e)
    {
        base.Page_Load(sender, e);
        if (!IsPostBack)
        {
            hf_returnUrl.Value = DataRequest.UrlEncode(Request.RawUrl);
            AspNetPager1.CurrentPageIndex = DataRequest.QueryInt("PageIndex");//获取当前页数
            btn_search.Visible = IsPowerExistence("040101");//查询按钮权限控制
            btn_add.Visible = IsPowerExistence("040102");//添加按钮权限控制
            btn_update.Visible = IsPowerExistence("040103");//修改按钮权限控制
            btn_delete.Visible = IsPowerExistence("040104");//删除按钮权限控制
            btn_verify.Visible = IsPowerExistence("040115");//审核按钮权限控制
             ccusCode = Request.QueryString["CustomerCode"];
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
        if (!string.IsNullOrWhiteSpace(ccusCode))
        {
            strWhere += " and a.ccuscode =" + ccusCode + "";
        }
        if (!string.IsNullOrEmpty(txt_search_field.Text.Trim()))
        {
            strWhere += " and a.ccusName like '%" + txt_search_field.Text.Trim() + "%'";
        }
        DataGrid1.UpdatePower = btn_update.Visible;
        DataGrid1.DeletePower = btn_delete.Visible;
        AspNetPager1.PageSize = PageSize;//每页显示记录数
        hf_pageIndex.Value = (DataGrid1.PageIndex = AspNetPager1.CurrentPageIndex).ToString();
        DataGrid1.Bind(bll.GetListByPage(AspNetPager1.CurrentPageIndex, AspNetPager1.PageSize, strWhere, "a.visit_id desc", out TotalRecord));//绑定数据
        AspNetPager1.RecordCount = TotalRecord;//总记录数
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


    #region "删除"按钮的单击事件
    /// <summary>
    /// "审核"按钮的单击事件
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btn_verify_Click(object sender, EventArgs e)
    {
        if (DatabasePrompt.Post(new YouhooVisitRecordBLLExtend().VeriftyVisitRecord(DataGrid1.SelectStr.Split(','), 1), this))
        {
            BindData();//绑定数据
        }
    }

    private void Verify(string arrayId)
    {
        if (DatabasePrompt.Post(bll.Delete(arrayId, GetUserId), this))
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
    #region "取消审核按钮事件"
    protected void btn_cancelVerify_Click(object sender, EventArgs e)
    {
        if (DatabasePrompt.CannelPost(new YouhooVisitRecordBLLExtend().VeriftyVisitRecord(DataGrid1.SelectStr.Split(','), 0), this))
        {
            BindData();//绑定数据
        }
    }
    #endregion

    
}