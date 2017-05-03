<%@ Page Language="C#" MasterPageFile="~/PageEdit.Master" AutoEventWireup="true" CodeFile="SysDictionaryChildDetail.aspx.cs" Inherits="YouHoo.Web.SYS.SysDictionaryChildDetail" Title="无标题页" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
	<asp:HiddenField ID="hf_id" runat="server" />
	<table cellpadding="0" cellspacing="0" class="table table-bordered table-hover m10">
		<tr>
			<td align="right" class="tableleft">
				选项名称：
			</td>
			<td align="left">
				<asp:Label ID="lbl_dictionary_child_name" runat="server"></asp:Label>
			</td>
		</tr>
		<tr>
			<td align="right" class="tableleft">
				所属字典：
			</td>
			<td align="left">
				<asp:Label ID="lbl_dictionary_id" runat="server"></asp:Label>
			</td>
		</tr>
        <% if(YouHoo.DataTools.DataRequest.QueryInt("is_multilayer") == 1){ %>
		<tr>
			<td align="right" class="tableleft">
				所属父级：
			</td>
			<td align="left">
				<asp:Label ID="lbl_parent_dictionary_child_id" runat="server"></asp:Label>
			</td>
		</tr>
        <%} %>
        <tr>
			<td align="right" class="tableleft">
				是否启用：
			</td>
			<td align="left">
				<asp:Label ID="lbl_is_start" runat="server"></asp:Label>
			</td>
		</tr>
		<tr>
			<td align="right" class="tableleft">
				排序：
			</td>
			<td align="left">
				<asp:Label ID="lbl_sort" runat="server"></asp:Label>
			</td>
		</tr>
		<tr>
			<td align="right" class="tableleft">
				备注：
			</td>
			<td align="left">
				<asp:Label ID="lbl_remark" runat="server"></asp:Label>
			</td>
		</tr>
		<tr>
			<td align="right" class="tableleft">
			</td>
			<td align="left">
				<asp:Button CssClass="Inputbtn" ID="btn_update" runat="server" Text="修改" OnClick="btn_update_Click" />
				<input type="button" class="Inputbtn" value="关闭" onclick="top.Dialog.close()" />
			</td>
		</tr>
	</table>
</asp:Content>
