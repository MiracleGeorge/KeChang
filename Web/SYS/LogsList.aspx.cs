using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using YouHoo.DataBll;
using YouHoo.DataTools;

namespace YouHoo.Web.SYS
{
    public partial class LogsList : BasePage
    {
        private readonly LogsBLL bll = new LogsBLL();

        protected override void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                base.Page_Load(sender, e);
                if (!IsPostBack)
                {
                    hf_returnUrl.Value = DataRequest.UrlEncode(Request.RawUrl);
                    AspNetPager1.CurrentPageIndex = DataRequest.QueryInt("PageIndex");//��ȡ��ǰҳ��
                    BindData();//������
                }
            }
        }

        #region ������
        /// <summary>
        /// ������
        /// </summary>
        private void BindData()
        {
            hf_pageIndex.Value = (DataGrid1.PageIndex = AspNetPager1.CurrentPageIndex).ToString();
            hf_pageIndex.Value = AspNetPager1.CurrentPageIndex.ToString();
            DataGrid1.Bind(bll.GetListByPage(AspNetPager1.CurrentPageIndex, PageSize, out TotalRecord));//������
            AspNetPager1.RecordCount = TotalRecord; //�ܼ�¼��
            AspNetPager1.PageSize = PageSize;       //ÿҳ��ʾ��¼��
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
    }
}