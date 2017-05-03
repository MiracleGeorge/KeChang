using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using YouHoo.DataBll;
using YouHoo.DataTools;

namespace YouHoo.Web.Control
{
    public partial class FileUpLoadToList : BaseControl
    {
        public int TableId
        {
            get { return DataConvert.ToInt32(hf_tableId.Value); }
            set { hf_tableId.Value = value.ToString(); }
        }
        public int TableFileId
        {
            get { return DataConvert.ToInt32(hf_tableFileId.Value); }
            set { hf_tableFileId.Value = value.ToString(); }
        }
        private bool readOnly = false;
        /// <summary>
        /// 是否只读
        /// </summary>
        public bool ReadOnly
        {
            get { return readOnly; }
            set { readOnly = value; }
        }

        private YouhooSysFilesBLL dal = new YouhooSysFilesBLL();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindData();
            }
        }

        #region 绑定数据
        /// <summary>
        /// 绑定数据
        /// </summary>
        protected void BindData()
        {
            rp_files.DataSource = new YouhooSysFilesBLL().GetList(TableId, TableFileId);
            rp_files.DataBind();
        } 
        #endregion
    }
}