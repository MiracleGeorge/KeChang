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
using Newtonsoft.Json;
using System.IO;
using YouHoo.DataModel;

namespace YouHoo.Web.Js.cityLinkage
{
    public partial class DataAction : BasePage
    {
        protected override void Page_Load(object sender, EventArgs e)
        {
            base.Page_Load(sender, e);
            if (!IsPostBack)
            {
                string rmsg = "{msg:'未定义操作',flag:'0'}";
                string action = DataRequest.FormString("act").ToLower();
                switch (action)
                {
                    case "storchange":
                        rmsg = StorChange();
                        break;
                    case "storpowerchange":
                        rmsg = StorPowerChange();
                        break;
                    case "departchange":
                        rmsg = departChange();
                        break;
                    case "storuserchange":
                        rmsg = StorUserChange();
                        break;
                    default:
                        break;
                }
                Response.Write(rmsg);
                Response.End();
            }
        }

        /// <summary>
        /// 门店部门角色联动——获取部门
        /// </summary>
        /// <returns></returns>
        protected string StorChange()
        {
            string rmsg = "{msg:'未定义操作',flag:'0'}";
            //获取门店ID
            int storId = DataRequest.FormInt("stroId");
            DataTable dt_dept = new YouhooSysDepartmentBLL().GetList(" and a.storeid = " + storId);
            DataTable dt_PowerId = new YouhooSysPowergroupBLL().GetList(" and a.StoreId = " + storId);

            rmsg = "{msg:" + JsonConvert.SerializeObject(dt_dept) + ",power:" + JsonConvert.SerializeObject(dt_PowerId) + ",flag:'1'}";
            return rmsg;
        }

        // <summary>
        /// 门店部门用户联动——获取用户
        /// </summary>
        /// <returns></returns>
        protected string StorUserChange()
        {
            string rmsg = "{msg:'未定义操作',flag:'0'}";
            //获取省ID
            int storeId = DataRequest.FormInt("storeId");
            DataTable dt_depart = new YouhooSysDepartmentBLL().GetList(" and a.storeid = " + storeId);
            rmsg = "{msg:" + Converts.ConvertDataTableToJson(dt_depart) + ",flag:1}";
            return rmsg;
        }

        public string departChange()
        {
            string rmsg = "{msg:'未定义操作',flag:'0'}";
            //获取市ID
            int departId = DataRequest.FormInt("departId");
            DataTable dt_user = new YouhooSysUsersBLL().GetList(" and a.departmentId = " + departId);
            rmsg = "{msg:" + Converts.ConvertDataTableToJson(dt_user) + ",flag:1}";
            return rmsg;
        }

        /// <summary>
        /// 门店角色联动——获取角色
        /// </summary>
        /// <returns></returns>
        protected string StorPowerChange()
        {
            string rmsg = "{msg:'未定义操作',flag:'0'}";
            //获取门店ID
            int storId = DataRequest.FormInt("stroId");
            DataTable dt_PowerId = new YouhooSysPowergroupBLL().GetList(" and a.StoreId = " + storId + " and a.powergroup_id!=1");

            rmsg = "{power:" + JsonConvert.SerializeObject(dt_PowerId) + ",flag:'1'}";
            return rmsg;
        }
    }
}