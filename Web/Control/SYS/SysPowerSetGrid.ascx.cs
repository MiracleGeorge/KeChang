using System;
using System.Collections.Generic;
using YouHoo.DataTools;
using YouHoo.Web;
using System.Web.UI.WebControls;
using System.Data;
using YouHoo.DataBll;

namespace YouHoo.Web.Control.SYS
{
    public partial class SysPowerSetGrid : BaseControl
    {
        public event RepeaterCommandEventHandler ItemCommand;

        public string SelectStr
        {
            get
            {
                string str = "";
                foreach (RepeaterItem item in grdSysPowergroups.Items)
                {
                    CheckBoxList chkPower = item.FindControl("chkPower") as CheckBoxList;
                    string chk = Converts.GetControlsValue(chkPower);
                    if (!string.IsNullOrEmpty(chk))
                    {
                        str += chk + ",";
                    }
                }
                if (str != "") str = str.Trim(',');
                return str;
            }
        }

        protected void grdSysPowergroups_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (ItemCommand != null)
            {
                ItemCommand(source, e);
            }
        }
        protected void grdSysPowergroups_ItemDataBound(object source, RepeaterItemEventArgs e)
        {
            if ((e.Item.ItemType == ListItemType.Item) || (e.Item.ItemType == ListItemType.AlternatingItem))
            {
                CheckBoxList chkPower = e.Item.FindControl("chkPower") as CheckBoxList;
                HiddenField hfmodule_id = e.Item.FindControl("hfmodule_id") as HiddenField;
                HiddenField hfmodule_value = e.Item.FindControl("hfmodule_value") as HiddenField;
                DataTable dt = new YouhooSysPowerBLL().GetActionList(DataConvert.ToInt32(hfmodule_id.Value), DataRequest.QueryInt("powergroup_id"));
                if (dt != null && dt.Rows.Count != 0)
                {
                    foreach (DataRow o in dt.Rows)
                    {
                        chkPower.Items.Add(new ListItem(o["action_name"].ToString(), o["power_value"].ToString()));
                        chkPower.Items[chkPower.Items.Count - 1].Selected = o["ispower"].ToString() == "1";
                    }
                }
            }
        }

        public void Bind(object source)
        {
            DataTable dt_dataTemp = source as DataTable;
            DataTable dt_data = dt_dataTemp.Clone();
            dt_data.Columns["module_id"].DataType = typeof(string);
            dt_data.Columns["parentmodule_id"].DataType = typeof(string);
            foreach (DataRow row in dt_dataTemp.Rows)
            {
                dt_data.Rows.Add(row.ItemArray);
            }
            grdSysPowergroups.DataSource = Converts.ConvertTableTree(dt_data, "module_name", "module_id", "parentmodule_id", "0");
            grdSysPowergroups.DataBind();
        }

        #region 获取下级模块
        /// <summary>
        /// 获取下级模块
        /// </summary>
        protected void GetChildModule(DataTable dt_data, int parentmoduleId, string siteId, string parentModuleId)
        {
            DataTable dt_module = new YouhooSysModuleBLL().GetList(" and a.parentmodule_id = " + parentmoduleId + " order by a.sort asc");
            foreach (DataRow row in dt_module.Rows)
            {
                DataRow rowTemp = dt_data.NewRow();
                string moduleId = siteId + "_" + row["module_id"].ToString();
                rowTemp["module_id"] = moduleId;
                rowTemp["module_name"] = row["module_name"].ToString();
                rowTemp["parentmodule_id"] = parentModuleId;
                rowTemp["module_value"] = siteId + "_" + row["module_value"].ToString();
                dt_data.Rows.Add(rowTemp);
                GetChildModule(dt_data, DataConvert.ToInt32(row["module_id"]), siteId, moduleId);
            }
        }
        #endregion
    }
}