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
	public partial class SysPowerList : BasePage
	{
		private readonly YouhooSysPowerBLL bll = new YouhooSysPowerBLL();

		protected override void Page_Load(object sender, EventArgs e)
		{
			base.Page_Load(sender, e);
			if (!IsPostBack)
			{
				hf_returnUrl.Value = DataRequest.UrlEncode(Request.RawUrl);
				AspNetPager1.CurrentPageIndex = DataRequest.QueryInt("PageIndex");//��ȡ��ǰҳ��
                btn_search.Visible = IsPowerExistence("010301");//��ѯ��ťȨ�޿���
                btn_add.Visible = IsPowerExistence("010302");//��Ӱ�ťȨ�޿���
                btn_update.Visible = IsPowerExistence("010303");//�޸İ�ťȨ�޿���
                btn_delete.Visible = IsPowerExistence("010304");//ɾ����ťȨ�޿���
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
            if (!string.IsNullOrEmpty(txt_module_name.Text.Trim()))
            {
                strWhere += " and b.module_name like '%" + txt_module_name.Text.Trim() + "%'";
            }
            DataGrid1.UpdatePower = btn_update.Visible;
            DataGrid1.DeletePower = btn_delete.Visible;
			DataGrid1.PageIndex = AspNetPager1.CurrentPageIndex;
            hf_pageIndex.Value = AspNetPager1.CurrentPageIndex.ToString();
            DataGrid1.Bind(bll.GetListByPage(AspNetPager1.CurrentPageIndex, PageSize, strWhere, "b.parentmodule_id asc, b.sort asc, c.action_value asc", out TotalRecord));//������
            AspNetPager1.RecordCount = TotalRecord; //�ܼ�¼��
            AspNetPager1.PageSize = PageSize;       //ÿҳ��ʾ��¼��
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
			if (!IsPowerExistence("010301"))
			{
				PublicPrompt.Alert("��û��Ȩ�޲�ѯ���ݣ�", this);
				return;
            }
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
            if (!IsPowerExistence("010304"))
            {
                PublicPrompt.Alert("��û��Ȩ��ɾ�����ݣ�", this);
                return;
            }
            if (DatabasePrompt.Delete(bll.Delete(arrayId, GetUserId), this))
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
            if (e.CommandName == "delete")
            {
                Delete(e.CommandArgument.ToString());//ɾ��
            }
        }
        #endregion
	}
}
