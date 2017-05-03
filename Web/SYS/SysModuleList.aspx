<%@ Page Language="C#" MasterPageFile="~/PageList.Master" AutoEventWireup="true" CodeFile="SysModuleList.aspx.cs" Inherits="YouHoo.Web.SYS.SysModuleList" Title="�ޱ���ҳ" %>

<%@ Register src="../Control/SYS/SysModuleGrid.ascx" tagname="SysModuleGrid" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
	ģ�����ƣ�<asp:TextBox ID="txt_search_field" runat="server" Width="80px"></asp:TextBox>
	<asp:Button CssClass="Inputbtn" ID="btn_search" runat="server" Text="��ѯ" OnClick="btn_search_Click" />
	<asp:Button CssClass="Inputbtn" ID="btn_add" runat="server" Text="����" OnClientClick="return dialogAdd('/SYS/SysModuleEdit.aspx')" />
	<asp:Button CssClass="Inputbtn" ID="btn_update" runat="server" Text="�޸�" OnClientClick="return dialogUpdate('/SYS/SysModuleEdit.aspx', 'module_id')" />
	<asp:Button CssClass="Inputbtn" ID="btn_delete" runat="server" Text="ɾ��" OnClientClick="return popDelete(this);" OnClick="btn_delete_Click" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
	<asp:HiddenField ID="hf_returnUrl" runat="server" />
    <asp:HiddenField ID="hf_pageIndex" runat="server" />
	<div class="tableMain">
		<uc1:SysModuleGrid ID="DataGrid1" runat="server" OnItemCommand="DataGrid1_ItemCommand" />
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