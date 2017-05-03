<%@ Page Language="C#" MasterPageFile="~/PageList.Master" AutoEventWireup="true" CodeFile="RebateRebatepolicyList.aspx.cs" Inherits="YouHoo.Web.REBATE.RebateRebatepolicyList" Title="�ޱ���ҳ" %>

<%@ Register src="../Control/REBATE/RebateRebatepolicyGrid.ascx" tagname="RebateRebatepolicyGrid" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    ������<asp:DropDownList ID="ddl_searchChannel" runat="server"></asp:DropDownList>
    Ʒ�ƣ�<asp:DropDownList ID="ddl_searchBrand" runat="server"></asp:DropDownList>
    ������<asp:DropDownList ID="ddl_searchRegion" runat="server"></asp:DropDownList>
    Ʒ�ࣺ<asp:DropDownList ID="ddl_searchSort" runat="server" Enabled="False"></asp:DropDownList>
    Ʒ�<asp:DropDownList ID="ddl_searchItem" runat="server" Enabled="False"></asp:DropDownList>
    ʱ�Σ�<asp:DropDownList ID="ddl_searchTime" runat="server" Enabled="False"></asp:DropDownList>
    �۸�<asp:DropDownList ID="ddl_searchPrice" runat="server" Enabled="False"></asp:DropDownList>
    ֧�ַ�ʽ��<asp:DropDownList ID="ddl_supportWay" runat="server" Enabled="False"></asp:DropDownList>
    ֧�ֽ�<asp:DropDownList ID="ddl_supportPrice" runat="server" Enabled="False"></asp:DropDownList>
   
	<asp:Button CssClass="Inputbtn" ID="btn_search" runat="server" Text="��ѯ" OnClick="btn_search_Click" />
	<asp:Button CssClass="Inputbtn" ID="btn_add" runat="server" Text="���" OnClientClick="return dialogQuoAdd('/REBATE/RebateRebatepolicyEdit.aspx')" />
	<asp:Button CssClass="Inputbtn" ID="btn_update" runat="server" Text="�޸�" OnClientClick="return dialogUpdate('/REBATE/RebateRebatepolicyEdit.aspx', 'id')" />
	<asp:Button CssClass="Inputbtn" ID="btn_delete" runat="server" Text="ɾ��" OnClientClick="return popDelete(this);" OnClick="btn_delete_Click" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <asp:HiddenField ID="hf_returnUrl" runat="server" />
	<asp:HiddenField ID="hf_pageIndex" runat="server" />
	<div class="tableMain">
		<uc1:RebateRebatepolicyGrid ID="DataGrid1" runat="server" OnItemCommand="DataGrid1_ItemCommand" />
	</div>
	<div id="page">
		<ul>
			<webdiyer:AspNetPager CssClass="anpager" CurrentPageButtonClass="cpb" ID="AspNetPager1"
				runat="server" RecordCount="99999999" CustomInfoHTML="ҳ�Σ�%CurrentPageIndex%/%PageCount%ҳ  ÿҳ��ʾ��%PageSize%��  ��¼����%RecordCount%��"
				PageIndexBoxType="TextBox" ShowCustomInfoSection="Left" ShowPageIndexBox="Always"
				SubmitButtonText="Go" SubmitButtonClass="goClass" TextAfterPageIndexBox="ҳ" TextBeforePageIndexBox="ת��" Width="100%"
				CustomInfoSectionWidth="35%" CustomInfoTextAlign="Left" HorizontalAlign="Right"
				OnPageChanged="AspNetPager1_PageChanged" FirstPageText="��ҳ" LastPageText="βҳ"
				NextPageText="��һҳ" PrevPageText="��һҳ">
			</webdiyer:AspNetPager>
		</ul>
	</div>
</asp:Content>
