<%@ Control Language="C#" AutoEventWireup="true" CodeFile="SysPowerGrid.ascx.cs" Inherits="YouHoo.Web.Control.SYS.SysPowerGrid" %>
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
			动作名称
		</th>
		<th align="center">
			标识编号
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
					<asp:HiddenField ID="hf_id" runat="server" Value='<%# Eval("power_id") %>' />
				</td>
				<td align="center">
					<a href="javascript:dialogDetail('/SYS/SysPowerDetail.aspx?PageIndex=<%#PageIndex %>&ReturnUrl=<%=DataRequest.UrlEncode(Request.RawUrl) %>&power_id=<%# Eval("power_id") %>')">
						<%# Eval("module_name") %></a>
				</td>
				<td align="center">
					<%# Eval("action_name")%>
				</td>
				<td align="center">
					<%# Eval("power_value")%>
				</td>
				<td align="center">
					<%# Eval("createoperator")%>
				</td>
				<td align="center">
					<%# Eval("createdate")%>
				</td>
				<td align="center">
					<asp:LinkButton ID="lnk_update" Text="修改" Visible='<%#UpdatePower %>' OnClientClick='<%# "return dialogUpdateSingle(&#39;/SYS/SysPowerEdit.aspx?PageIndex="+PageIndex+"&ReturnUrl="+DataRequest.UrlEncode(Request.RawUrl)+"&power_id="+Eval("power_id")+"&#39;)" %>'
						runat="server"></asp:LinkButton>
					<asp:LinkButton ID="lnk_delete" Text="删除" Visible='<%#DeletePower %>' CommandName="delete"
						CommandArgument='<%# Eval("power_id") %>' OnClientClick="return popDeleteSingle(this);"
						runat="server"></asp:LinkButton>
				</td>
			</tr>
		</ItemTemplate>
		<FooterTemplate>
			<%#rp_data.Items.Count == 0 ? "<tr><td align=\"center\" colspan=\"11\">暂无记录</td></tr>" : ""%>
		</FooterTemplate>
	</asp:Repeater>
</table>
