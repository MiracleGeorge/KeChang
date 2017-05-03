<%@ Control Language="C#" AutoEventWireup="true" CodeFile="SysModuleGrid.ascx.cs" Inherits="YouHoo.Web.Control.SYS.SysModuleGrid" %>
<%@ Import Namespace="YouHoo.DataTools" %>
<table id="item_list" class="table table-bordered table-hover definewidth m10"
	cellpadding="3" cellspacing="0">
	<tr>
		<th style="width: 30px" align="center">
			<input id="chkChooseAll" type="checkbox" onclick="chooseAll('item_list','chkChooseAll')" />
		</th>
		<th align="center">
			模块名称
		</th>
		<th align="center">
			父级模块
		</th>
		<th align="center" style="width:180px;">
			模块链接地址
		</th>
		<th align="center">
			标识编号
		</th>
		<th align="center">
			排序
		</th>
		<th align="center">
			创建人
		</th>
		<th align="center">
			创建时间
		</th>
		<th align="center">
			操作
		</th>
	</tr>
	<asp:Repeater ID="rp_data" runat="server" OnItemCommand="rp_data_ItemCommand">
		<ItemTemplate>
			<tr>
				<td align="center">
					<asp:CheckBox ID="chkChoose" runat="server" />
					<asp:HiddenField ID="hf_id" runat="server" Value='<%# Eval("module_id") %>' />
				</td>
				<td align="left">
					<a href="javascript:dialogDetail('/SYS/SysModuleDetail.aspx?PageIndex=<%#PageIndex %>&ReturnUrl=<%=DataRequest.UrlEncode(Request.RawUrl) %>&module_id=<%# Eval("module_id") %>')">
						<%# Eval("module_name") %></a>
				</td>
				<td align="center">
					<%# Eval("parent_name")%>
				</td>
				<td align="center">
					<%# Eval("module_url")%>
				</td>
				<td align="center">
					<%# Eval("module_value")%>
				</td>
				<td align="center">
					<%# Eval("sort")%>
				</td>
				<td align="center">
					<%# Eval("createoperator")%>
				</td>
				<td align="center">
					<%# Eval("createdate")%>
				</td>
				<td align="center">
					<asp:LinkButton ID="lnk_update" Text="修改" Visible='<%#UpdatePower %>' OnClientClick='<%# "return dialogUpdateSingle(&#39;/SYS/SysModuleEdit.aspx?PageIndex="+PageIndex+"&ReturnUrl="+DataRequest.UrlEncode(Request.RawUrl)+"&module_id="+Eval("module_id")+"&#39;)" %>'
						runat="server"></asp:LinkButton>
					<asp:LinkButton ID="lnk_delete" Text="删除" Visible='<%#DeletePower %>' CommandName="delete"
						CommandArgument='<%# Eval("module_id") %>' OnClientClick="return popDeleteSingle(this);"
						runat="server"></asp:LinkButton>
				</td>
			</tr>
		</ItemTemplate>
		<FooterTemplate>
			<%#rp_data.Items.Count == 0 ? "<tr><td align=\"center\" colspan=\"13\">暂无记录</td></tr>" : ""%>
		</FooterTemplate>
	</asp:Repeater>
</table>
