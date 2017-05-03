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
using YouHoo.DataTools;
using YouHoo.DataBll;
using YouHoo.DataModel;
using System.Text;

namespace YouHoo.Web.View
{
    public partial class LeftTree : BasePage
    {
        protected override void Page_Load(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(SystemModel.SystemSetIcon)) lt_icon.Text = "<link rel=\"shortcut icon\" href=\"" + SystemModel.SystemSetIcon + "\"></link>";
            base.Page_Load(sender, e);
            if (DataRequest.QueryString("act") == "GetTreeAsync")
            {
                GetTreeAsync();
            }
            if (!IsPostBack)
            {
                hf_node.Value = GetTree(0);
            }
        }

        #region ��ȡ���ڵ�
        /// <summary>
        /// ��ȡ���ڵ�
        /// </summary>
        public string GetTree(int parentId)
        {
            //��ȡ���ж����ڵ�
            string node = "";
            DataTable dt_tree = new YouhooSysModuleBLL().GetList(" and a.parentmodule_id = " + parentId + " order by a.sort asc");
            foreach (DataRow row in dt_tree.Rows)
            {
                if (IsPowerExistence(row["module_value"].ToString() + "00"))
                {
                    //�жϸýڵ����Ƿ�����ӽڵ�
                    DataTable dt_tree_temp = new YouhooSysModuleBLL().GetListByPage(1, 0, " and a.parentmodule_id = " + row["module_id"], "a.module_id asc", out TotalRecord);
                    if (TotalRecord > 0)
                    {
                        node += "{id:'" + row["module_id"] + "', pId:'" + parentId + "', name:'" + row["module_name"] + "', isParent:'true'},";
                    }
                    else
                    {
                        node += "{id:'" + row["module_id"] + "', pId:'" + parentId + "', name:'" + row["module_name"] + "', url:'" + row["module_url"] + "', target:'frmright'},";
                    }
                }
            }
            if (node != "")
            {
                node = node.Trim(',');
                node = "[" + node + "]";
            }
            return node;
        }
        #endregion

        #region ��ȡ���ڵ㣨�첽���أ�
        /// <summary>
        /// ��ȡ���ڵ㣨�첽���أ�
        /// </summary>
        public void GetTreeAsync()
        {
            //��ȡid
            int id = DataRequest.QueryInt("id");
            string node = GetTree(id);
            Response.Write(node);
            Response.End();
        }
        #endregion
    }
}