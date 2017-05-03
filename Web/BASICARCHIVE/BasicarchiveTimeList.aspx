<%@ Page Language="C#" MasterPageFile="~/PageList.Master" AutoEventWireup="true" CodeFile="BasicarchiveTimeList.aspx.cs" Inherits="YouHoo.Web.BASICARCHIVE.BasicarchiveTimeList" Title="无标题页" %>

<%@ Register src="../Control/BASICARCHIVE/BasicarchiveTimeGrid.ascx" tagname="BasicarchiveTimeGrid" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
	查询字段：<asp:TextBox ID="txt_search_field" runat="server" Width="80px"></asp:TextBox>
	<asp:Button CssClass="Inputbtn" ID="btn_search" runat="server" Text="查询" OnClick="btn_search_Click" />
	<asp:Button CssClass="Inputbtn" ID="btn_add" runat="server" Text="添加" OnClientClick="return dialogAdd('/BASICARCHIVE/BasicarchiveTimeEdit.aspx')" />
	<asp:Button CssClass="Inputbtn" ID="btn_update" runat="server" Text="修改" OnClientClick="return dialogUpdate('/BASICARCHIVE/BasicarchiveTimeEdit.aspx', 'id')" />
	<asp:Button CssClass="Inputbtn" ID="btn_delete" runat="server" Text="删除" OnClientClick="return popDelete(this);" OnClick="btn_delete_Click" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
	<asp:HiddenField ID="hf_returnUrl" runat="server" />
	<asp:HiddenField ID="hf_pageIndex" runat="server" />
	<div class="tableMain">
		<uc1:BasicarchiveTimeGrid ID="DataGrid1" runat="server" OnItemCommand="DataGrid1_ItemCommand" />
	</div>
	<div id="page">
		<ul>
			<webdiyer:AspNetPager CssClass="anpager" CurrentPageButtonClass="cpb" ID="AspNetPager1"
				runat="server" RecordCount="99999999" CustomInfoHTML="页次：%CurrentPageIndex%/%PageCount%页  每页显示：%PageSize%条  记录数：%RecordCount%条"
				PageIndexBoxType="TextBox" ShowCustomInfoSection="Left" ShowPageIndexBox="Always"
				SubmitButtonText="Go" SubmitButtonClass="goClass" TextAfterPageIndexBox="页" TextBeforePageIndexBox="转到" Width="100%"
				CustomInfoSectionWidth="35%" CustomInfoTextAlign="Left" HorizontalAlign="Right"
				OnPageChanged="AspNetPager1_PageChanged" FirstPageText="首页" LastPageText="尾页"
				NextPageText="下一页" PrevPageText="上一页">
			</webdiyer:AspNetPager>
		</ul>
	</div>
</asp:Content>
