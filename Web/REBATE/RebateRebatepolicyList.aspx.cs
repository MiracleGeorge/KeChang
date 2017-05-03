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
using YouHoo.DataBll;
using YouHoo.Web;
using YouHoo.DataTools;

namespace YouHoo.Web.REBATE
{
	public partial class RebateRebatepolicyList : BasePage
	{
		private readonly YouhooRebateRebatepolicyBLL bll = new YouhooRebateRebatepolicyBLL();
		
		protected override void Page_Load(object sender, EventArgs e)
		{
			base.Page_Load(sender, e);
			if (!IsPostBack)
			{
				hf_returnUrl.Value = DataRequest.UrlEncode(Request.RawUrl);
				AspNetPager1.CurrentPageIndex = DataRequest.QueryInt("PageIndex");//��ȡ��ǰҳ��
				btn_search.Visible = IsPowerExistence("030201");//��ѯ��ťȨ�޿���
				btn_add.Visible = IsPowerExistence("030202");//��Ӱ�ťȨ�޿���
				btn_update.Visible = IsPowerExistence("030203");//�޸İ�ťȨ�޿���
				btn_delete.Visible = IsPowerExistence("030204");//ɾ����ťȨ�޿���
                BindDropDownListData();//�󶨲�ѯ�����������б�
                BindData();//������
			}
		}

		#region ������
		/// <summary>
		/// ������
		/// </summary>
		private void BindData()
		{
            string strWhere = "";
            if (IsPostBack)
            {

                if (ddl_searchChannel.Text != "0")
                {
                    strWhere += " and a.channel_id =" + ddl_searchChannel.Text + "";
                }
                if (ddl_searchBrand.Text != "0")
                {
                    strWhere += " and a.brand_id = " + ddl_searchBrand.Text + "";
                }
                if (ddl_searchRegion.Text != "0")
                {
                    strWhere += " and a.region_id = " + ddl_searchRegion.Text + "";
                }

                var data = bll.GetListByPage(AspNetPager1.CurrentPageIndex, AspNetPager1.PageSize, strWhere, "a.id desc", out TotalRecord);

                //���ݲ�ѯ��� �жϳ�Ʒ�ƣ���������������ѡ���Ƿ����ʹ��
                if (data.Rows.Count < 1)
                {
                    ddl_searchSort.Enabled = false;
                    ddl_supportWay.Enabled = false;
                    ddl_supportPrice.Enabled = false;
                    ddl_searchItem.Enabled = false;
                    ddl_searchTime.Enabled = false;
                    ddl_searchPrice.Enabled = false;
                }
                else
                {
                    ddl_searchSort.Enabled = true;
                    ddl_supportWay.Enabled = true;
                    ddl_supportPrice.Enabled = true;
                    ddl_searchItem.Enabled = true;
                    ddl_searchTime.Enabled = true;
                    ddl_searchPrice.Enabled = true;
                }


                if (ddl_searchItem.Text != "0")
                {
                    strWhere += " and a.item_id = " + ddl_searchItem.Text + "";
                }
                if (ddl_searchTime.Text != "0")
                {
                    strWhere += " and a.time_id = " + ddl_searchTime.Text + "";
                }
                if (ddl_supportWay.Text != "0")
                {
                    strWhere += " and a.supportWay_id = " + ddl_supportWay.Text + "";
                }
                if (ddl_supportPrice.Text != "0")
                {
                    strWhere += " and a.supportPrice_id = " + ddl_supportPrice.Text + "";
                }
                if (ddl_searchSort.Text != "0")
                {
                    strWhere += " and a.sort_id_id = " + ddl_searchSort.Text + "";
                }
                if (ddl_searchPrice.Text != "0")
                {
                    strWhere += " and a.price_id = " + ddl_searchPrice.Text + "";
                }

                DataGrid1.UpdatePower = btn_update.Visible;
                DataGrid1.DeletePower = btn_delete.Visible;
                AspNetPager1.PageSize = PageSize;//ÿҳ��ʾ��¼��
                hf_pageIndex.Value = (DataGrid1.PageIndex = AspNetPager1.CurrentPageIndex).ToString();
                data = bll.GetListByPage(AspNetPager1.CurrentPageIndex, AspNetPager1.PageSize, strWhere, "a.id desc", out TotalRecord);
                DataGrid1.Bind(data);//������
                AspNetPager1.RecordCount = TotalRecord;//�ܼ�¼��
            }
            else
            {

                DataGrid1.UpdatePower = btn_update.Visible;
                DataGrid1.DeletePower = btn_delete.Visible;
                AspNetPager1.PageSize = PageSize;//ÿҳ��ʾ��¼��
                hf_pageIndex.Value = (DataGrid1.PageIndex = AspNetPager1.CurrentPageIndex).ToString();
                var data = bll.GetListByPage(AspNetPager1.CurrentPageIndex, AspNetPager1.PageSize, strWhere, "a.id desc", out TotalRecord);
                DataGrid1.Bind(data);//������
                AspNetPager1.RecordCount = TotalRecord;//�ܼ�¼��
            }


           

        }
        /// <summary>
        /// ����������Ĳ�ѯ������ȡ���ݵ�����,�������Ϊ0������û�δѡ�����
        /// </summary>
        private void GetDataRowCountByWhere()
        {
            string strWhere = "";
            if (ddl_searchChannel.Text != "0")
            {
                strWhere += " and a.channel_id =" + ddl_searchChannel.Text + "";
            }
            if (ddl_searchBrand.Text != "0")
            {
                strWhere += " and a.brand_id = " + ddl_searchBrand.Text + "";
            }
            if (ddl_searchRegion.Text != "0")
            {
                strWhere += " and a.region_id = " + ddl_searchRegion.Text + "";
            }
            if (ddl_searchItem.Text != "0")
            {
                strWhere += " and a.item_id = " + ddl_searchItem.Text + "";
            }
            if (ddl_searchTime.Text != "0")
            {
                strWhere += " and a.time_id = " + ddl_searchTime.Text + "";
            }
            if (ddl_supportWay.Text != "0")
            {
                strWhere += " and a.supportWay_id = " + ddl_supportWay.Text + "";
            }
            if (ddl_supportPrice.Text != "0")
            {
                strWhere += " and a.supportPrice = " + ddl_supportPrice.Text + "";
            }
            if (ddl_searchSort.Text != "0")
            {
                strWhere += " and a.sort_id_id = " + ddl_searchSort.Text + "";
            }
            if (ddl_searchPrice.Text != "0")
            {
                strWhere += " and a.price_id = " + ddl_searchPrice.Text + "";
            }
            
            var data = bll.GetListByPage(AspNetPager1.CurrentPageIndex, AspNetPager1.PageSize, strWhere, "a.id desc", out TotalRecord);

            if (data.Rows.Count < 0)
            {
                if (ddl_searchChannel.Text == "0")
                {
                    ddl_searchChannel.Enabled = false;
                }
                if (ddl_searchBrand.Text == "0")
                {
                    ddl_searchBrand.Enabled = false;
                }
                if (ddl_searchRegion.Text == "0")
                {
                    ddl_searchRegion.Enabled = false;
                }
                if (ddl_searchItem.Text == "0")
                {
                    ddl_searchItem.Enabled = false;
                }
                if (ddl_searchTime.Text == "0")
                {
                    ddl_searchTime.Enabled = false;
                }
                if (ddl_supportWay.Text == "0")
                {
                    ddl_supportWay.Enabled = false;
                }
                if (ddl_supportPrice.Text == "0")
                {
                    ddl_supportPrice.Enabled = false;
                }
                if (ddl_searchSort.Text == "0")
                {
                    ddl_searchSort.Enabled = false;
                }
                if (ddl_searchPrice.Text == "0")
                {
                    ddl_searchPrice.Enabled = false;
                }
            }
        }

        /// <summary>
        /// �󶨲�ѯ�õ���������������
        /// </summary>
        private void BindDropDownListData()
        {
            //Ʒ��
            ddl_searchBrand.DataSource = new YouhooBasicarchiveBrandBLL().GetList("");
            ddl_searchBrand.DataTextField = "Name";
            ddl_searchBrand.DataValueField = "id";
            ddl_searchBrand.DataBind();
            ddl_searchBrand.Items.Insert(0, new ListItem("��ѡ��", "0"));
            //����
            ddl_searchChannel.DataSource = new YouhooBasicarchiveChannelBLL().GetList("");
            ddl_searchChannel.DataTextField = "Name";
            ddl_searchChannel.DataValueField = "id";
            ddl_searchChannel.DataBind();
            ddl_searchChannel.Items.Insert(0, new ListItem("��ѡ��", "0"));
            //����
            ddl_searchRegion.DataSource = new YouhooBasicarchiveRegionBLL().GetList("");
            ddl_searchRegion.DataTextField = "Name";
            ddl_searchRegion.DataValueField = "id";
            ddl_searchRegion.DataBind();
            ddl_searchRegion.Items.Insert(0, new ListItem("��ѡ��", "0"));
            //Ʒ��
            ddl_searchSort.DataSource = new YouhooBasicarchiveSortBLL().GetList("");
            ddl_searchSort.DataTextField = "Name";
            ddl_searchSort.DataValueField = "id";
            ddl_searchSort.DataBind();
            ddl_searchSort.Items.Insert(0, new ListItem("��ѡ��", "0"));
            //Ʒ��
            ddl_searchItem.DataSource = new YouhooBasicarchiveItemBLL().GetList("");
            ddl_searchItem.DataTextField = "Name";
            ddl_searchItem.DataValueField = "id";
            ddl_searchItem.DataBind();
            ddl_searchItem.Items.Insert(0, new ListItem("��ѡ��", "0"));
            //ʱ��
            ddl_searchTime.DataSource = new YouhooBasicarchiveTimeBLL().GetList("");
            ddl_searchTime.DataTextField = "Name";
            ddl_searchTime.DataValueField = "id";
            ddl_searchTime.DataBind();
            ddl_searchTime.Items.Insert(0, new ListItem("��ѡ��", "0"));
            //֧�ֽ��
            ddl_supportPrice.DataSource = new YouhooBasicarchiveSupportpriceBLL().GetList("");
            ddl_supportPrice.DataTextField = "Name";
            ddl_supportPrice.DataValueField = "id";
            ddl_supportPrice.DataBind();
            ddl_supportPrice.Items.Insert(0, new ListItem("��ѡ��", "0"));
            //֧�ַ�ʽ
            ddl_supportWay.DataSource = new YouhooBasicarchiveSupportwayBLL().GetList("");
            ddl_supportWay.DataTextField = "Name";
            ddl_supportWay.DataValueField = "id";
            ddl_supportWay.DataBind();
            ddl_supportWay.Items.Insert(0, new ListItem("��ѡ��", "0"));
            //���
            ddl_searchPrice.DataSource = new YouhooBasicarchivePriceBLL().GetList("");
            ddl_searchPrice.DataTextField = "Name";
            ddl_searchPrice.DataValueField = "id";
            ddl_searchPrice.DataBind();
            ddl_searchPrice.Items.Insert(0, new ListItem("��ѡ��", "0"));
        }
		#endregion

		#region "��ѯ"��ť�ĵ����¼�
		/// <summary>
		/// "��ѯ"��ť�ĵ����¼�
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		protected void btn_search_Click(object sender, EventArgs e)
		{
			AspNetPager1.CurrentPageIndex = 1;
			BindData();//������
		}
		#endregion

		#region "ɾ��"��ť�ĵ����¼�
		/// <summary>
		/// "ɾ��"��ť�ĵ����¼�
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		protected void btn_delete_Click(object sender, EventArgs e)
		{
			Delete(DataGrid1.SelectStr);//ɾ��
		}

        private void Delete(string arrayId)
        {
            if (DatabasePrompt.Delete(bll.Delete(arrayId, GetUserId, ConfigurationManager.ConnectionStrings["ConnectionString"].ToString()), this))
			{
                BindData();//������
			}
		}
		#endregion

		#region ��ҳ�ؼ�ҳ���ı��¼�
		/// <summary>
		/// ��ҳ�ؼ�ҳ���ı��¼�
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		protected void AspNetPager1_PageChanged(object sender, EventArgs e)
		{
			BindData();//������
		}
		#endregion

		#region repeater�ؼ������¼�
		/// <summary>
		/// repeater�ؼ������¼�
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		protected void DataGrid1_ItemCommand(object source, RepeaterCommandEventArgs e)
		{
			switch (e.CommandName)
			{
				case "delete":
					Delete(e.CommandArgument.ToString());//ɾ��
					break;
				default:
					break;
			}
		}
        #endregion



       
    }
}
