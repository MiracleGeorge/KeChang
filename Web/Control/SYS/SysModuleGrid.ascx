<%@ Control Language="C#" AutoEventWireup="true" CodeFile="SysModuleGrid.ascx.cs" Inherits="YouHoo.Web.Control.SYS.SysModuleGrid" %>
<%@ Import Namespace="YouHoo.DataTools" %>
<table id="item_list" class="table table-bordered table-hover definewidth m10"
	cellpadding="3" cellspacing="0">
	<tr>
		<th style="width: 30px" align="center">
			<input id="chkChooseAll" type="checkbox" onclick="chooseAll('item_list','chkChooseAll')" />
		</th>
		<th align="center">
			ģ������
		</th>
		<th align="center">
			����ģ��
		</th>
		<th align="center" style="width:180px;">
			ģ�����ӵ�ַ
		</th>
		<th align="center">
			��ʶ���
		</th>
		<th align="center">
			����
		</th>
		<th align="center">
			������
		</th>
		<th align="center">
			����ʱ��
		</th>
		<th align="center">
			����
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
					<asp:LinkButton ID="lnk_update" Text="�޸�" Visible='<%#UpdatePower %>' OnClientClick='<%# "return dialogUpdateSingle(&#39;/SYS/SysModuleEdit.aspx?PageIndex="+PageIndex+"&ReturnUrl="+DataRequest.UrlEncode(Request.RawUrl)+"&module_id="+Eval("module_id")+"&#39;)" %>'
						runat="server"></asp:LinkButton>
					<asp:LinkButton ID="lnk_delete" Text="ɾ��" Visible='<%#DeletePower %>' CommandName="delete"
						CommandArgument='<%# Eval("module_id") %>' OnClientClick="return popDeleteSingle(this);"
						runat="server"></asp:LinkButton>
				</td>
			</tr>
		</ItemTemplate>
		<FooterTemplate>
			<%#rp_data.Items.Count == 0 ? "<tr><td align=\"center\" colspan=\"13\">���޼�¼</td></tr>" : ""%>
		</FooterTemplate>
	</asp:Repeater>
</table>
