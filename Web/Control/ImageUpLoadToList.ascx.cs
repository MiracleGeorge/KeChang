using System;
using System.Data;
using System.Web.UI.WebControls;
using YouHoo.DataBll;
using YouHoo.DataTools;

namespace YouHoo.Web.Control
{
    public partial class ImageUpLoadToList : BaseControl
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

        /// <summary>
        /// �Ƿ��ѡ
        /// </summary>
        public bool Required
        {
            set
            {
                if (value == true) divupload.Attributes["class"] = "upload-box box multi-upload validate[required]";
            }
        }

        /// <summary>
        /// ����ͼ���ã���ʽ����50|50,100|100,150|150����һ������ͼ���|��һ������ͼ�߶�,�ڶ�������ͼ���|�ڶ�������ͼ�߶�
        /// </summary>
        private string thumbnailConfig;
        public string ThumbnailConfig
        {
            get { return thumbnailConfig; }
            set { thumbnailConfig = value; }
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

        public string GetFileIdS
        {
            get { return hfFileS.Value; }
        }

        public string SelectStr
        {
            get
            {
                string str = "";
                foreach (RepeaterItem o in gridPayment.Items)
                {
                    str += ((HiddenField)o.FindControl("hffile_id")).Value + ",";
                }
                return str;
            }
        }

        protected void gridPayment_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName.Equals("delete"))
            {
                HiddenField hffile_id = e.Item.FindControl("hffile_id") as HiddenField;
                int returnvalue = dal.Delete(hffile_id.Value, 0);
                switch (returnvalue)
                {
                    case -99:
                        PublicPrompt.Alert("��¼��ʱ�������µ�¼", Page);
                        break;
                    case -1:
                        PublicPrompt.Alert("ɾ����������ϵͳ����Ա��ϵ��", Page);
                        break;
                    default:
                        BindData();
                        break;
                }
            }
        }
    }
}

