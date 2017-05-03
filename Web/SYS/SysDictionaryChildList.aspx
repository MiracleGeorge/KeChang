<%@ Page Language="C#" MasterPageFile="~/PageList.Master" AutoEventWireup="true" CodeFile="SysDictionaryChildList.aspx.cs" Inherits="YouHoo.Web.SYS.SysDictionaryChildList" Title="无标题页" %>
<%@ Import Namespace="YouHoo.DataTools" %>

<%@ Register src="../Control/SYS/SysDictionaryChildGrid.ascx" tagname="SysDictionaryChildGrid" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <style type="text/css">
        .mainbody {
            margin:5px;
        }
    </style>
    <script type="text/javascript">
        function add() {
            return dialogAdd("/SYS/SysDictionaryChildEdit.aspx", "&dictionary_id=<%= DataRequest.QueryInt("dictionary_id") %>&parent_dictionary_child_id=<%= DataRequest.QueryInt("dictionary_child_id") %>");
        }
    </script>
	选项名称：<asp:TextBox ID="txt_dictionary_child_name" runat="server" Width="80px"></asp:TextBox>
	<asp:Button CssClass="Inputbtn" ID="btn_search" runat="server" Text="查询" OnClick="btn_search_Click" />
	<asp:Button CssClass="Inputbtn" ID="btn_add" runat="server" Text="添加" OnClientClick="return add()" />
	<asp:Button CssClass="Inputbtn" ID="btn_update" runat="server" Text="修改" OnClientClick="return dialogUpdate('/SYS/SysDictionaryChildEdit.aspx', 'dictionary_child_id')" />
	<asp:Button CssClass="Inputbtn" ID="btn_delete" runat="server" Text="删除" OnClientClick="return popDelete(this);" OnClick="btn_delete_Click" />
	<asp:Button CssClass="Inputbtn" ID="btn_start" runat="server" Text="启用" OnClientClick="return popStart(this);" OnClick="btn_start_Click" />
	<asp:Button CssClass="Inputbtn" ID="btn_disabled" runat="server" Text="不启用" OnClientClick="return popDisabled(this);" OnClick="btn_disabled_Click" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
	<asp:HiddenField ID="hf_returnUrl" runat="server" />
    <asp:HiddenField ID="hf_pageIndex" runat="server" />
	<div class="tableMain">
		<uc1:SysDictionaryChildGrid ID="DataGrid1" runat="server" OnItemCommand="DataGrid1_ItemCommand" />
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
