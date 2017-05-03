/****************************************
 * ��Ȩ���У��ϲ�����������޹�˾
 * ��    ַ��www.21it.com
 ****************************************/
using System;
using System.Data;
using System.Web.UI.WebControls;
using YouHoo.DataTools;
using YouHoo.DataBll;

namespace YouHoo.Web.Control
{
    public partial class ImageUpReadToList : BaseControl
    {
        public int TableId
        {
            get { return DataConvert.ToInt32(lalTableId.Value); }
            set { lalTableId.Value = value.ToString(); }
        }
        public int TableFileId
        {
            get { return DataConvert.ToInt32(lalTableFileId.Value); }
            set { lalTableFileId.Value = value.ToString(); }
        }

        private YouhooSysFilesBLL dal = new YouhooSysFilesBLL();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindData();
            }
        }

        public void BindData()
        {
            DataTable dt = dal.GetList(DataConvert.ToInt32(lalTableId.Value), DataConvert.ToInt32(lalTableFileId.Value));

            gridPayment.DataSource = dt;
            gridPayment.DataBind();
        }
    }
}

