<%@ Control Language="C#" AutoEventWireup="true" CodeFile="RebateRebatewayGrid.ascx.cs" Inherits="YouHoo.Web.Control.REBATE.RebateRebatewayGrid" %>
<%@ Import Namespace="YouHoo.DataTools" %>

<input type="hidden" id="bllName" value="YouhooRebateRebatewayBLL" />
<table id="item_list" class="table table-bordered table-hover definewidth m10"
	cellpadding="3" cellspacing="0">
	<tr>
		<th style="width: 30px" align="center">
			<input type="checkbox" id="chkChooseAll" />
		</th>
		<th align="center">
			��������
		</th>
		<th align="center">
			������ʽ����
		</th>
		<th align="center">
			������ʽ����
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
					<asp:HiddenField ID="hf_id" runat="server" Value='<%# Eval("id") %>' />
				</td>
				<td align="center">
					<label class="lbl_ajaxUpdate"><%# Eval("rebate_type")%></label>
                    <label class="validate[required,maxSize[50]] txt_ajaxUpdate" field="RebateType" ><%# Eval("rebate_type")%></label>
					<%--<input type="text" class="validate[required,maxSize[50]] txt_ajaxUpdate" field="RebateType" value="<%# Eval("rebate_type")%>" />--%>
				</td>
				<td align="center">
					<%--<label class="lbl_ajaxUpdate"><%# Eval("Name")%></label>
					<input type="text" class="validate[required,maxSize[50]] txt_ajaxUpdate" field="Name" value="<%# Eval("Name")%>" />--%>
                    <label><%# Eval("Name")%></label>
				</td>
				<td align="center">
                    <label><%# Eval("Code")%></label>
				</td>
				<td align="center" class="operate">
					<a href="javascript:dialogDetail('/REBATE/RebateRebatewayDetail.aspx?PageIndex=<%#PageIndex %>&ReturnUrl=<%=DataRequest.UrlEncode(Request.RawUrl) %>&id=<%# Eval("id") %>')">�鿴</a>
					<asp:LinkButton ID="lnk_update" Text="�޸�" Visible='<%#UpdatePower %>' OnClientClick='<%# "return dialogUpdateSingle(&#39;/REBATE/RebateRebatewayEdit.aspx?PageIndex="+PageIndex+"&ReturnUrl="+DataRequest.UrlEncode(Request.RawUrl)+"&id="+Eval("id")+"&#39;)" %>'
						runat="server"></asp:LinkButton>
					<asp:LinkButton ID="lnk_delete" Text="ɾ��" Visible='<%#DeletePower %>' CommandName="delete"
						CommandArgument='<%# Eval("id") %>' OnClientClick="return popDeleteSingle(this);"
						runat="server"></asp:LinkButton>
				</td>
			</tr>
		</ItemTemplate>
		<FooterTemplate>
			<%# rp_data.Items.Count == 0 ? "<script type='text/javascript'>document.write('<tr><td align=\"center\" colspan=\"'+$(\"#item_list tr th\").length+'\">���޼�¼</td></tr>');</script>" : "" %>
		</FooterTemplate>
	</asp:Repeater>
</table>