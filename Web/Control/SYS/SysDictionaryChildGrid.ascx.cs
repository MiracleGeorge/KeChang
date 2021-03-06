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
using System.Collections.Generic;
using YouHoo.Web;
using YouHoo.DataTools;

namespace YouHoo.Web.Control.SYS
{
	public partial class SysDictionaryChildGrid : BaseControl
	{
		public event RepeaterCommandEventHandler ItemCommand;
        public int PageIndex = 0;
        private bool _updatePower = false;
        /// <summary>
        /// 修改权限
        /// </summary>
        public bool UpdatePower
        {
            get { return _updatePower; }
            set { _updatePower = value; }
        }
        private bool _deletePower = false;
        /// <summary>
        /// 删除权限
        /// </summary>
        public bool DeletePower
        {
            get { return _deletePower; }
            set { _deletePower = value; }
        }
        private bool _startPower = false;
        /// <summary>
        /// 启用权限
        /// </summary>
        public bool StartPower
        {
            get { return _startPower; }
            set { _startPower = value; }
        }
        private bool _disabledPower = false;
        /// <summary>
        /// 不启用权限
        /// </summary>
        public bool DisabledPower
        {
            get { return _disabledPower; }
            set { _disabledPower = value; }
        }
        private bool _showParentPower = false;
        /// <summary>
        /// 显示所属父级
        /// </summary>
        public bool ShowParentPower
        {
            get { return _showParentPower; }
            set { _showParentPower = value; }
        }
		public List<int> Selected
		{
			get
			{
				List<int> list = new List<int>();
				foreach (RepeaterItem item in rp_data.Items)
				{
					CheckBox cb = item.FindControl("chkChoose") as CheckBox;
					if (cb != null && cb.Checked)
					{
						HiddenField fld = item.FindControl("hf_id") as HiddenField;
						if (fld != null)
						{
							int id = DataConvert.ToInt32(fld.Value);
							list.Add(id);
						}
					}
				}
				return list;
			}
		}

		public string SelectStr
		{
			get
			{
				string str = "";
				foreach (RepeaterItem item in rp_data.Items)
				{
					CheckBox cb = item.FindControl("chkChoose") as CheckBox;
					if (cb != null && cb.Checked)
					{
						HiddenField fld = item.FindControl("hf_id") as HiddenField;
						if (fld != null)
						{
							str += fld.Value + ",";
						}
					}
				}
				return str.Trim(',');
			}
		}

		protected void rp_data_ItemCommand(object source, RepeaterCommandEventArgs e)
		{
			if (ItemCommand != null)
			{
				ItemCommand(source, e);
			}
		}

		public void Bind(object source)
		{
			rp_data.DataSource = source;
			rp_data.DataBind();
		}
	}
}
