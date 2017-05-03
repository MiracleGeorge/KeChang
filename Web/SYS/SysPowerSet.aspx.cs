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
    public partial class SysPowerSet : BasePage
    {
        protected override void Page_Load(object sender, EventArgs e)
        {
            base.Page_Load(sender, e);
            if (!IsPostBack)
            {
                BindData();
                btn_save.Visible = IsPowerExistence("010405");
            }
        }

        #region ������
        /// <summary>
        /// ������
        /// </summary>
        private void BindData()
        {
            DataTable dt = new YouhooSysModuleBLL().GetList(" order by a.sort asc");
            SysPowerSetGrid1.Bind(dt);
        }
        #endregion

        #region "����"��ť�ĵ����¼�
        /// <summary>
        /// "����"��ť�ĵ����¼�
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btn_save_Click(object sender, EventArgs e)
        {
            //�жϴ��ݹ�����id�Ƿ�Ϊ��
            if (DataRequest.QueryExists("powergroup_id"))
            {
                //���ݴ��ݹ�����idֵ���Ҷ�Ӧ�û���Ϣ
                YouhooSysPowergroupModel model = new YouhooSysPowergroupBLL().GetModel(DataRequest.QueryInt("powergroup_id"));
                model.PowergroupValue = SysPowerSetGrid1.SelectStr;
                if (DatabasePrompt.Save(new YouhooSysPowergroupBLL().InsertUpdate(model, GetUserId), this))
                {
                    PublicPrompt.CloseDialogAndRefresh(this);
                }
            }
        }
        #endregion
    }
}