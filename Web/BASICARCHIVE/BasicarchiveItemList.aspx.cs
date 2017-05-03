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

namespace YouHoo.Web.BASICARCHIVE
{
	public partial class BasicarchiveItemList : BasePage
	{
		private readonly YouhooBasicarchiveItemBLL bll = new YouhooBasicarchiveItemBLL();
		
		protected override void Page_Load(object sender, EventArgs e)
		{
			base.Page_Load(sender, e);
			if (!IsPostBack)
			{
				hf_returnUrl.Value = DataRequest.UrlEncode(Request.RawUrl);
				AspNetPager1.CurrentPageIndex = DataRequest.QueryInt("PageIndex");//��ȡ��ǰҳ��
				btn_search.Visible = IsPowerExistence("020601");//��ѯ��ťȨ�޿���
				btn_add.Visible = IsPowerExistence("020602");//��Ӱ�ťȨ�޿���
				btn_update.Visible = IsPowerExistence("020603");//�޸İ�ťȨ�޿���
				btn_delete.Visible = IsPowerExistence("020604");//ɾ����ťȨ�޿���
				BindData();//������
			}
		}

		#region ������
		/// <summary>
		/// ������
		/// </summary>
		private void BindData()
		{
			string strWhere = "";
			if (!string.IsNullOrEmpty(txt_search_field.Text.Trim()))
			{
				strWhere += " and a.search_field like '%" + txt_search_field.Text.Trim() + "%'";
			}
			DataGrid1.UpdatePower = btn_update.Visible;
			DataGrid1.DeletePower = btn_delete.Visible;
			AspNetPager1.PageSize = PageSize;//ÿҳ��ʾ��¼��
			hf_pageIndex.Value = (DataGrid1.PageIndex = AspNetPager1.CurrentPageIndex).ToString();
			DataGrid1.Bind(bll.GetListByPage(AspNetPager1.CurrentPageIndex, AspNetPager1.PageSize, strWhere, "a.id desc", out TotalRecord));//������
			AspNetPager1.RecordCount = TotalRecord;//�ܼ�¼��
		}
		#endregion

		#region "��ѯ"��ť�ĵ����¼�
		/// <summary>
		/// "��ѯ"��ť�ĵ����¼�
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		protected void btn_search_Click(object sender, EventArgs e)
		{
			AspNetPager1.CurrentPageIndex = 1;
			BindData();//������
		}
		#endregion

		#region "ɾ��"��ť�ĵ����¼�
		/// <summary>
		/// "ɾ��"��ť�ĵ����¼�
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		protected void btn_delete_Click(object sender, EventArgs e)
		{
			Delete(DataGrid1.SelectStr);//ɾ��
		}

		private void Delete(string arrayId)
		{
			if(DatabasePrompt.Delete(bll.Delete(arrayId, GetUserId), this))
			{
				BindData();//������
			}
		}
		#endregion

		#region ��ҳ�ؼ�ҳ���ı��¼�
		/// <summary>
		/// ��ҳ�ؼ�ҳ���ı��¼�
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		protected void AspNetPager1_PageChanged(object sender, EventArgs e)
		{
			BindData();//������
		}
		#endregion

		#region repeater�ؼ������¼�
		/// <summary>
		/// repeater�ؼ������¼�
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		protected void DataGrid1_ItemCommand(object source, RepeaterCommandEventArgs e)
		{
			switch (e.CommandName)
			{
				case "delete":
					Delete(e.CommandArgument.ToString());//ɾ��
					break;
				default:
					break;
			}
		}
		#endregion
	}
}
