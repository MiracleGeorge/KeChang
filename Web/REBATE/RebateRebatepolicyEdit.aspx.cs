using System;
using System.Configuration;
using YouHoo.DataModel;
using YouHoo.DataBll;
using YouHoo.DataTools;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Web.UI.WebControls;
using System.Linq;
using YouHoo.DataBll.REBATE;
using System.Text;

namespace YouHoo.Web.REBATE
{
    public partial class RebateRebatepolicyEdit : BasePage
    {
        public static List<youhoo_BasicArchive_brand> BrandList;
        public static List<youhoo_BasicArchive_item> ItemList;

        private YouhooRebateRebatepolicyBLL bll = new YouhooRebateRebatepolicyBLL();

        protected override void Page_Load(object sender, EventArgs e)
        {
            base.Page_Load(sender, e);
            if (!IsPostBack)
            {
               

                BindData();

                if (DataRequest.QueryExists("id"))
                {
                    var model = bll.GetModelRetrunIQ(DataConvert.ToInt32(DataRequest.QueryInt("id")));
                    if (model == null)
                    {
                        DataInexistence();
                        return;
                    }
                    hf_id.Value = model.id.ToString();
                    txt_Code.Text =  model.Code;
                    txt_Name.Text = model.Name;
                    ddl_channel.SelectedValue = model.ChannelId.ToString();
                    ddl_price.SelectedValue = model.PriceId.ToString();
                    ddl_rebateWay.SelectedValue = model.RebateWayId.ToString();
                    ddl_region.SelectedValue = model.RegionId.ToString();
                    ddl_sort.SelectedValue = model.SortId.ToString();
                    //ddl_time.SelectedValue = model.TimeId.ToString();
                    ddl_supportPrice .SelectedValue = model.SupportPriceId.ToString();
                    ddl_supportWay .SelectedValue = model.SupportWayId.ToString();

                    //txt_channel_id.Text = model.ChannelId != null ? model.ChannelId.ToString() : "";
                    //txt_item_id.Text = model.ItemId != null ? model.ItemId.ToString() : "";
                    //txt_price_id.Text = model.PriceId != null ? model.PriceId.ToString() : "";
                    //txt_region_id.Text = model.RegionId != null ? model.RegionId.ToString() : "";
                    //txt_sort_id_id.Text = model.SortIdId != null ? model.SortIdId.ToString() : "";
                    //txt_SupportWay_id.Text = model.SupportwayId != null ? model.SupportwayId.ToString() : "";
                    //txt_SupportPrice_id.Text = model.SupportpriceId != null ? model.SupportpriceId.ToString() : "";
                    //txt_RebateType_id.Text = model.RebatetypeId != null ? model.RebatetypeId.ToString() : "";
                    //txt_time_id.Text = model.TimeId != null ? model.TimeId.ToString() : "";
                    //txt_remark.Text = model.Remark;
                }

                BindReapterPolicyDetails();
                ////品牌
                //ddl_searchBrand.DataSource = new YouhooBasicarchiveBrandBLL().GetList("");
                //ddl_searchBrand.DataTextField = "Name";
                //ddl_searchBrand.DataValueField = "id";
                //ddl_searchBrand.DataBind();
                //ddl_searchBrand.Items.Insert(0, new ListItem("请选择", "0"));
                btn_save.Visible = (IsPowerExistence("030202") && !DataRequest.QueryExists("id")) || (IsPowerExistence("030203") && DataRequest.QueryExists("id"));
            }
        }

        private void BindReapterPolicyDetails()
        {
            //查询价格策略字表
            DataBll.REBATE.KechangDataContext kc = new DataBll.REBATE.KechangDataContext(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());

            int Id = DataConvert.ToInt32(hf_id.Value);
            Reapter_PolicyDetails.DataSource = kc.v_RebatePolicys.Where(x => x.PolicyId == Id);
            Reapter_PolicyDetails.DataBind();
        }

        public string GetBrandList(string id)
        {
            using (KechangDataContext kc = new KechangDataContext(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString()))
            {
                StringBuilder sb = new StringBuilder("<option value=\"0\">请选择<option>"); 
                BrandList = kc.youhoo_BasicArchive_brand.Select(x => x).ToList();
                foreach (var item in BrandList)
                {
                    string Sel = "";
                    if (item.id ==Convert.ToInt32(id))
                    {
                        Sel = "selected";
                    }
                    sb.AppendFormat("<option value=\"{0}\" {1}>{2}</option>",item.id,Sel,item.Name);
                }
                return sb.ToString();
            }
        }
        /// <summary>
        /// 获取表体品项列表（设置后台选中值）
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public string GetItemList(string id)
        {
            using (KechangDataContext kc = new KechangDataContext(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString()))
            {
                StringBuilder sb = new StringBuilder("<option value=\"0\">请选择<option>");
                ItemList = kc.youhoo_BasicArchive_item.Select(x => x).ToList();
                foreach (var item in ItemList)
                {
                    string Sel = "";
                    if (item.id == Convert.ToInt32(id))
                    {
                        Sel = "selected";
                    }
                    sb.AppendFormat("<option value=\"{0}\" {1}>{2}</option>", item.id, Sel, item.Name);
                }
                return sb.ToString();
            }
        }
        protected void BindData()
        {
            //YouhooBasicarchiveBrandBLL bll = new YouhooBasicarchiveBrandBLL();
            //ddl_brand.DataSource = bll.GetList("");
            //ddl_brand.DataTextField = "Name"; 
            //ddl_brand.DataValueField = "id";
            //ddl_brand.DataBind();
            //ddl_brand.Items.Insert(0, new ListItem("请选择", "0"));
            //地区
            ddl_region.DataSource = new YouhooBasicarchiveRegionBLL().GetList("");
            ddl_region.DataTextField = "Name";
            ddl_region.DataValueField = "id";
            ddl_region.DataBind();
            ddl_region.Items.Insert(0, new ListItem("请选择", "0"));
            //渠道
            ddl_channel.DataSource = new YouhooBasicarchiveChannelBLL().GetList("");
            ddl_channel.DataTextField = "Name";
            ddl_channel.DataValueField = "id";
            ddl_channel.DataBind();
            ddl_channel.Items.Insert(0, new ListItem("请选择", "0"));
            //品类
            ddl_sort.DataSource = new YouhooBasicarchiveSortBLL().GetList("");
            ddl_sort.DataTextField = "Name";
            ddl_sort.DataValueField = "id";
            ddl_sort.DataBind();
            ddl_sort.Items.Insert(0, new ListItem("请选择", "0"));
            //支持方式
            ddl_supportWay.DataSource = new YouhooBasicarchiveSupportwayBLL().GetList("");
            ddl_supportWay.DataTextField = "Name";
            ddl_supportWay.DataValueField = "id";
            ddl_supportWay.DataBind();
            ddl_supportWay.Items.Insert(0, new ListItem("请选择", "0"));
            //支持方式
            ddl_supportPrice.DataSource = new YouhooBasicarchiveSupportpriceBLL().GetList("");
            ddl_supportPrice.DataTextField = "Name";
            ddl_supportPrice.DataValueField = "id";
            ddl_supportPrice.DataBind();
            ddl_supportPrice.Items.Insert(0, new ListItem("请选择", "0"));
            //时段
            //ddl_time.DataSource = new YouhooBasicarchiveTimeBLL().GetList("");
            //ddl_time.DataTextField = "Name";
            //ddl_time.DataValueField = "id";
            //ddl_time.DataBind();
            //ddl_time.Items.Insert(0, new ListItem("请选择", "0"));
            //价格
            ddl_price.DataSource = new YouhooBasicarchivePriceBLL().GetList("");
            ddl_price.DataTextField = "Name";
            ddl_price.DataValueField = "id";
            ddl_price.DataBind();
            ddl_price.Items.Insert(0, new ListItem("请选择", "0"));
            //返利方式
            ddl_rebateWay.DataSource = new YouhooRebateRebatewayBLL().GetList("");
            ddl_rebateWay.DataTextField = "Name";
            ddl_rebateWay.DataValueField = "id";
            ddl_rebateWay.DataBind();
            ddl_rebateWay.Items.Insert(0, new ListItem("请选择", "0"));
        }

        /// <summary>
        /// 用户post请求获取品牌数据
        /// </summary>

        #region "保存"按钮的单击事件
        /// <summary>
        /// "保存"按钮的单击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btn_save_Click(object sender, EventArgs e)
        {
            //通过请求的表单id判斷是新增還是修改
            string requestId = DataRequest.QueryString("id");
            #region 装载表头信息
            DataBll.REBATE.youhoo_rebate_RebatePolicy policy = new DataBll.REBATE.youhoo_rebate_RebatePolicy();
            policy.Code = txt_Code.Text.Trim();
            policy.Name = txt_Name.Text.Trim();
            policy.flag = 1;
            if (ddl_channel.Text.Trim() != "")
            {
                policy.channel_id = DataConvert.ToInt32(ddl_channel.Text.Trim());
            }
            else
            {
                policy.channel_id = null;
            }
            //if (ddl_item.Text.Trim() != "")
            //{
            //    policy.ItemId = DataConvert.ToInt32(ddl_item.Text.Trim());
            //}
            //else
            //{
            //    policy.ItemId = null;
            //}
            if (ddl_price.Text.Trim() != "")
            {
                policy.price_id = DataConvert.ToInt32(ddl_price.Text.Trim());
            }
            else
            {
                policy.price_id = null;
            }
            if (ddl_region.Text.Trim() != "")
            {
                policy.region_id = DataConvert.ToInt32(ddl_region.Text.Trim());
            }
            else
            {
                policy.region_id = null;
            }
            if (ddl_sort.Text.Trim() != "")
            {
                policy.sort_id_id = DataConvert.ToInt32(ddl_sort.Text.Trim());
            }
            else
            {
                policy.sort_id_id = null;
            }
            if (ddl_supportWay.Text.Trim() != "")
            {
                policy.SupportWay_id = DataConvert.ToInt32(ddl_supportWay.Text.Trim());
            }
            else
            {
                policy.SupportWay_id = null;
            }
            if (ddl_supportPrice.Text.Trim() != "")
            {
                policy.SupportPrice_id = DataConvert.ToInt32(ddl_supportPrice.Text.Trim());
            }
            else
            {
                policy.SupportPrice_id = null;
            }
            if (ddl_rebateWay.Text.Trim() != "")
            {
                policy.RebateType_id = DataConvert.ToInt32(ddl_rebateWay.Text.Trim());
            }
            else
            {
                policy.RebateType_id = null;
            }
            //if (ddl_time.Text.Trim() != "")
            //{
            //    policy.time_id = DataConvert.ToInt32(ddl_time.Text.Trim());
            //}
            //else
            //{
            //    policy.time_id = null;
            //}
            #endregion
            if (requestId == "")//新增
            {
                #region 创建并赋值要新增的价格政策对象（表体：用linq的关系绑定主表和子表）

                //向表体添加数据
                var arryBrand = Request.Params.GetValues("ddl_brand");//品牌
                var arryItem = Request.Params.GetValues("ddl_Item");//品项
                var arryDiscount = Request.Params.GetValues("ddl_DisCount");//折扣
                if (arryBrand != null)
                {
                    //遍历并赋值表体行的数据
                    for (int i = 0; i < arryBrand.Length; i++)
                    {
                        policy.youhoo_rebate_RebatePolicys.Add(new DataBll.REBATE.youhoo_rebate_RebatePolicys
                        {
                            brand_id = DataConvert.ToInt32(arryBrand[i]),
                            item_id = DataConvert.ToInt32(arryItem[i]),
                            DisCount = DataConvert.ToDouble(arryDiscount[i]),
                            flag = 1,
                        });
                    }
                }
                if(DatabasePrompt.Save(new DataBll.YouhooRebateRebatepolicyBLL().InsertNewPolicy(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString(), policy), this))
                {
                    //关闭并刷新页面
                    PublicPrompt.CloseDialogAndRefresh(this);
                }

     
                #endregion
            }
            else//修改
            {
                //向表体添加数据
                var arryBrand = Request.Params.GetValues("ddl_brand");//品牌
                var arryItem = Request.Params.GetValues("ddl_Item");//品项
                var arryDiscount = Request.Params.GetValues("ddl_DisCount");//折扣
                //获取表体数据
                List<DataBll.REBATE.youhoo_rebate_RebatePolicys> listPolicys = new List<DataBll.REBATE.youhoo_rebate_RebatePolicys>();
                if (arryBrand!=null)
                {
                    for (int i = 0; i < arryBrand.Length; i++)
                    {
                        listPolicys.Add(new DataBll.REBATE.youhoo_rebate_RebatePolicys
                        {
                            Policy_id = DataConvert.ToInt32(requestId),
                            brand_id = DataConvert.ToInt32(arryBrand[i]),
                            item_id = DataConvert.ToInt32(arryItem[i]),
                            DisCount = DataConvert.ToDouble(arryDiscount[i]),
                            flag = 1,
                        });

                    }
                }
                if (DatabasePrompt.Save(new DataBll.YouhooRebateRebatepolicyBLL().UpdatePolicy(DataConvert.ToInt32(requestId), policy, ConfigurationManager.ConnectionStrings["ConnectionString"].ToString(), listPolicys),this))
                {
                    //关闭并刷新页面
                    PublicPrompt.CloseDialogAndRefresh(this);
                }
               
            }

        }
        #endregion


    }
}
