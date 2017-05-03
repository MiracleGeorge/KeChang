using System;
using System.Collections.Generic;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using YouHoo.DataBll;
using YouHoo.DataTools;

namespace YouHoo.Web.Control
{
    public partial class TreeFrame : BaseControl
    {
        /// <summary>
        /// ID����
        /// </summary>
        public string IdName
        {
            get { return hf_idName.Value; }
            set { hf_idName.Value = value; }
        }
        /// <summary>
        /// ��ʾ�ı�����
        /// </summary>
        public string TextName
        {
            get { return hf_textName.Value; }
            set { hf_textName.Value = value; }
        }
        /// <summary>
        /// ����ID����
        /// </summary>
        public string ParentIdName
        {
            get { return hf_parentIdName.Value; }
            set { hf_parentIdName.Value = value; }
        }
        /// <summary>
        /// ����·��
        /// </summary>
        public string LinkUrl
        {
            get { return hf_linkUrl.Value; }
            set { hf_linkUrl.Value = value; }
        }
        /// <summary>
        /// ����Ŀ��
        /// </summary>
        public string Target
        {
            get { return hf_target.Value; }
            set { hf_target.Value = value; }
        }
        /// <summary>
        /// ��չ����������ʵ��һЩ�ض���ҵ��
        /// </summary>
        public string ExtendParameter
        {
            get { return hf_extendParameter.Value; }
            set { hf_extendParameter.Value = value; }
        }
        /// <summary>
        /// Ҫ���õ�BLL����
        /// </summary>
        public string BllName
        {
            get { return hf_bllName.Value; }
            set { hf_bllName.Value = value; }
        }
        /// <summary>
        /// where����
        /// </summary>
        public string Where
        {
            get { return hf_where.Value; }
            set { hf_where.Value = value; }
        }
        /// <summary>
        /// ����ʽ
        /// </summary>
        public string OrderBy
        {
            get { return hf_orderBy.Value; }
            set { hf_orderBy.Value = value; }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (DataRequest.QueryString("act") == "GetTreeAsync")
            {
                hf_extendParameter.Value = DataRequest.QueryString("ExtendParameter");
                hf_where.Value = DataRequest.QueryString("Where");
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
            string parentIdName = hf_parentIdName.Value;
            string extendParameter = hf_extendParameter.Value;
            string node = "";
            object[] parameter = new object[1] { " and a." + hf_parentIdName.Value + " = " + parentId + hf_where.Value + " order by " + hf_orderBy.Value };
            DataTable dt_tree = ReflectionHelper.ExecMethod(Type.GetType("YouHoo.DataBll." + hf_bllName.Value + ", DataBll"), "GetList", parameter) as DataTable;
            foreach (DataRow row in dt_tree.Rows)
            {
                //�жϸýڵ����Ƿ�����ӽڵ�
                object[] outParameter;
                object[] parameter_temp = new object[5] { 1, 0, " and a." + hf_parentIdName.Value + " = " + row[hf_idName.Value] + "" + hf_where.Value, hf_orderBy.Value, 0 };
                DataTable dt_tree_temp = ReflectionHelper.ExecMethod(Type.GetType("YouHoo.DataBll." + hf_bllName.Value + ", DataBll"), "GetListByPage", parameter_temp, out outParameter) as DataTable;
                if (DataConvert.ToInt32(outParameter[4]) > 0)
                {
                    node += "{id:'" + row[hf_idName.Value] + "', pId:'" + row[hf_parentIdName.Value] + "', name:'" + row[hf_textName.Value] + "', url:'" + hf_linkUrl.Value + "?" + hf_idName.Value + "=" + row[hf_idName.Value] + hf_extendParameter.Value + "', target:'" + hf_target.Value + "', isParent:'true'},";
                }
                else
                {
                    node += "{id:'" + row[hf_idName.Value] + "', pId:'" + row[hf_parentIdName.Value] + "', name:'" + row[hf_textName.Value] + "', url:'" + hf_linkUrl.Value + "?" + hf_idName.Value + "=" + row[hf_idName.Value] + hf_extendParameter.Value + "', target:'" + hf_target.Value + "'},";
                }
            }
            if (node != null)
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
            string node = GetTree(DataRequest.QueryInt("id"));
            Response.Write(node);
            Response.End();
        }
        #endregion
    }
}