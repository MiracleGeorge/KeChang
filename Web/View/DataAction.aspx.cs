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
using YouHoo.DataBll;
using YouHoo.DataModel;
using YouHoo.DataTools;
using Newtonsoft.Json;

namespace YouHoo.Web.SYS
{
    public partial class DataAction : BasePage
    {
        protected override void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string rmsg = "{msg:'δ�������',flag:'0'}";
                string action = DataRequest.FormString("act").ToLower();
                switch (action)
                {
                    case "clearcache":
                        rmsg = ClearCache();
                        break;
                    case "ajaxupdate":
                        rmsg = AjaxUpdate();
                        break;
                    case "ajaxvalidatecode":
                        rmsg = AjaxValidateCode();
                        break;
                    default:
                        break;
                }
                Response.Write(rmsg);
                Response.End();
            }
        }

        #region �������
        /// <summary>
        /// �������
        /// </summary>
        /// <returns></returns>
        protected string ClearCache()
        {
            //����û���¼����
            CacheHelper.RemoveAllCache();
            return "����ɹ���";
        } 
        #endregion

        #region Ajax�޸�
        /// <summary>
        /// Ajax�޸�
        /// </summary>
        /// <returns></returns>
        protected string AjaxUpdate()
        {
            string rmsg = "{msg:'δ�������',flag:'0'}";
            //��ȡbll����
            string bllName = DataRequest.FormString("bllName");
            //��ȡID
            int id = DataRequest.FormInt("id");
            //��ȡ�ֶ�����
            string field = DataRequest.FormString("field");
            //��ȡֵ
            string value = DataRequest.FormString("value");

            object[] parameter = new object[1] { id };
            object obj = ReflectionHelper.ExecMethod(Type.GetType("YouHoo.DataBll." + bllName + ", DataBll"), "GetModel", parameter);
            if (obj != null)
            {
                ReflectionHelper.SetPropertyValue(obj, field, value);
                parameter = new object[2] { obj, GetUserId };
                string returnInfo = "";
                int errorCode = DataConvert.ToInt32(ReflectionHelper.ExecMethod(Type.GetType("YouHoo.DataBll." + bllName + ", DataBll"), "InsertUpdate", parameter));
                DatabasePrompt.GetPromptInfo(errorCode, "�޸�", out returnInfo, this);
                rmsg = "{msg:'" + returnInfo + "',flag:'" + errorCode + "'}";
            }
            return rmsg;
        } 
        #endregion

        #region ��֤��֤���Ƿ���ȷ
        /// <summary>
        /// ��֤��֤���Ƿ���ȷ
        /// </summary>
        /// <returns></returns>
        protected string AjaxValidateCode()
        {
            string rmsg = "{msg:'δ�������',flag:'0'}";
            //��ȡ��֤��
            string code = DataRequest.FormString("fieldValue").Trim();
            //��֤����ȷ
            if (Session[ASPNETAJAXWeb.ValidateCode.Page.ValidateCode.VALIDATECODEKEY] != null && code == Session[ASPNETAJAXWeb.ValidateCode.Page.ValidateCode.VALIDATECODEKEY].ToString().Trim().ToLower())
            {
                rmsg = "{status:true}";
            }
            //��֤�����
            else
            {
                rmsg = "{status:false}";
            }
            return rmsg;
        }
        #endregion
    }
}