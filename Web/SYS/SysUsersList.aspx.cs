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
    public partial class SysUsersList : BasePage
    {
        private readonly YouhooSysUsersBLL bll = new YouhooSysUsersBLL();

        protected override void Page_Load(object sender, EventArgs e)
        {
            base.Page_Load(sender, e);
            if (!IsPostBack)
            {
                hf_returnUrl.Value = DataRequest.UrlEncode(Request.RawUrl);
                AspNetPager1.CurrentPageIndex = DataRequest.QueryInt("PageIndex");//��ȡ��ǰҳ��
                btn_search.Visible = IsPowerExistence("010501");//��ѯ��ťȨ�޿���
                btn_add.Visible = IsPowerExistence("010502");//��Ӱ�ťȨ�޿���
                btn_update.Visible = IsPowerExistence("010503");//�޸İ�ťȨ�޿���
                btn_delete.Visible = IsPowerExistence("010504");//ɾ����ťȨ�޿���
                btn_pwdReset.Visible = IsPowerExistence("010506");//�������ð�ťȨ�޿���
                btn_freeze.Visible = IsPowerExistence("010507");//���ᰴťȨ�޿���
                btn_cancelFreeze.Visible = IsPowerExistence("010508");//ȡ�����ᰴťȨ�޿���
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
            if (!string.IsNullOrEmpty(txt_username.Text.Trim()))
            {
                strWhere += " and a.username like '%" + txt_username.Text.Trim() + "%'";
            }
            if (!string.IsNullOrEmpty(txt_real_name.Text.Trim()))
            {
                strWhere += " and a.real_name like '%" + txt_real_name.Text.Trim() + "%'";
            }
            DataGrid1.UpdatePower = btn_update.Visible;
            DataGrid1.DeletePower = btn_delete.Visible;
            DataGrid1.PwdResetPower = btn_pwdReset.Visible;
            DataGrid1.FreezePower = btn_freeze.Visible;
            DataGrid1.CancelFreeze = btn_cancelFreeze.Visible;
            hf_pageIndex.Value = (DataGrid1.PageIndex = AspNetPager1.CurrentPageIndex).ToString();
            hf_pageIndex.Value = AspNetPager1.CurrentPageIndex.ToString();
            DataGrid1.Bind(bll.GetListByPage(AspNetPager1.CurrentPageIndex, PageSize, strWhere, "a.user_id asc", out TotalRecord));//������
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

        #region "��������"��ť�ĵ����¼�
        /// <summary>
        /// "��������"��ť�ĵ����¼�
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btn_pwdReset_Click(object sender, EventArgs e)
        {
            PwdReset(DataGrid1.SelectStr);//��������
        }

        private void PwdReset(string arrayId)
        {
            if (DatabasePrompt.Custom(bll.PwdReset(arrayId, StringHelper.Md5(SystemModel.InitialPwd), GetUserId), "��������", this))
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
        protected void btn_freeze_Click(object sender, EventArgs e)
        {
            Freeze(DataGrid1.SelectStr);
        }

        private void Freeze(string arrayId)
        {
            if (DatabasePrompt.Custom(bll.Freeze(arrayId, GetUserId), "����", this))
            {
                BindData();//������
            }
        }
        #endregion

        #region "ȡ������"��ť�ĵ����¼�
        /// <summary>
        /// "ȡ������"��ť�ĵ����¼�
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btn_cancelFreeze_Click(object sender, EventArgs e)
        {
            CancelFreeze(DataGrid1.SelectStr);
        }

        private void CancelFreeze(string arrayId)
        {
            if (DatabasePrompt.Custom(bll.CancelFreeze(arrayId, GetUserId), "ȡ������", this))
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
                case "pwdReset":
                    PwdReset(e.CommandArgument.ToString());//��������
                    break;
                case "freeze":
                    Freeze(e.CommandArgument.ToString());//����
                    break;
                case "cancelFreeze":
                    CancelFreeze(e.CommandArgument.ToString());//ȡ������
                    break;
                default:
                    break;
            }
        }
        #endregion
    }
}
