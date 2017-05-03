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
				AspNetPager1.CurrentPageIndex = DataRequest.QueryInt("PageIndex");//��ȡ��ǰҳ��
                btn_search.Visible = IsPowerExistence("010801");//��ѯ��ťȨ�޿���
                btn_add.Visible = IsPowerExistence("010802");//��Ӱ�ťȨ�޿���
                btn_update.Visible = IsPowerExistence("010803");//�޸İ�ťȨ�޿���
                btn_delete.Visible = IsPowerExistence("010804");//ɾ����ťȨ�޿���
                btn_start.Visible = IsPowerExistence("010809");//���ð�ťȨ�޿���
                btn_disabled.Visible = IsPowerExistence("010810");//�����ð�ťȨ�޿���
				BindData();//������
			}
		}

		#region ������
		/// <summary>
		/// ������
		/// </summary>
		private void BindData()
        {
            //��ȡ�ֵ�ID
            int dictionaryId = DataRequest.QueryInt("dictionary_id");
            string strWhere = " and a.dictionary_id = " + dictionaryId;
            if (!string.IsNullOrEmpty(txt_dictionary_child_name.Text.Trim()))
            {
                strWhere += " and a.dictionary_child_name like '%" + txt_dictionary_child_name.Text.Trim() + "%'";
            }
            else
            {
                //��ȡ�ֵ���Ϣ
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
			DataGrid1.Bind(bll.GetListByPage(AspNetPager1.CurrentPageIndex, PageSize, strWhere, "a.sort asc", out TotalRecord));//������
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
            if (DatabasePrompt.Delete(bll.Delete(arrayId, GetUserId), this))
            {
                BindData();//������
            }
        }
        #endregion

        #region "����"��ť�ĵ����¼�
        /// <summary>
        /// "����"��ť�ĵ����¼�
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btn_start_Click(object sender, EventArgs e)
        {
            Start(DataGrid1.SelectStr);//����
        }

        private void Start(string arrayId)
        {
            if (DatabasePrompt.Custom(bll.Start(arrayId, GetUserId), "����", this))
            {
                BindData();//������
            }
        }
        #endregion

        #region "������"��ť�ĵ����¼�
        /// <summary>
        /// "������"��ť�ĵ����¼�
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btn_disabled_Click(object sender, EventArgs e)
        {
            Disabled(DataGrid1.SelectStr);//������
        }

        private void Disabled(string arrayId)
        {
            if (DatabasePrompt.Custom(bll.Disabled(arrayId, GetUserId), "������", this))
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
                case "start":
                    Start(e.CommandArgument.ToString());//����
                    break;
                case "disabled":
                    Disabled(e.CommandArgument.ToString());//������
                    break;
                default:
                    break;
            }
        }
        #endregion
	}
}
