<%@ Control Language="C#" AutoEventWireup="true" CodeFile="VisitVisitwayGrid.ascx.cs" Inherits="YouHoo.Web.Control.VISIT.VisitVisitwayGrid" %>
<%@ Import Namespace="YouHoo.DataTools" %>

<input type="hidden" id="bllName" value="YouhooVisitVisitwayBLL" />
<table id="item_list" class="table table-bordered table-hover definewidth m10"
	cellpadding="3" cellspacing="0">
	<tr>
		<th style="width: 30px" align="center">
			<input type="checkbox" id="chkChooseAll" />
		</th>
		<th align="center">
			�ݷ÷�ʽ����
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
					<asp:HiddenField ID="hf_id" runat="server" Value='<%# Eval("visit_way_id") %>' />
				</td>
				<%--<td align="center">
					<label class="lbl_ajaxUpdate"><%# Eval("visit_way_id")%></label>
					<input type="text" class="validate[required,custom[onlyNumber]] txt_ajaxUpdate" field="VisitWayId" value="<%# Eval("visit_way_id")%>" />
				</td>--%>
				<td align="center">
					<label class="lbl_ajaxUpdate"><%# Eval("visit_name")%></label>
					<input type="text" class="validate[required,maxSize[50]] txt_ajaxUpdate" field="VisitName" value="<%# Eval("visit_name")%>" />
				</td>
				<td align="center" class="operate">
					<a href="javascript:dialogDetail('/VISIT/VisitVisitwayDetail.aspx?PageIndex=<%#PageIndex %>&ReturnUrl=<%=DataRequest.UrlEncode(Request.RawUrl) %>&visit_way_id=<%# Eval("visit_way_id") %>')">�鿴</a>
					<asp:LinkButton ID="lnk_update" Text="�޸�" Visible='<%#UpdatePower %>' OnClientClick='<%# "return dialogUpdateSingle(&#39;/VISIT/VisitVisitwayEdit.aspx?PageIndex="+PageIndex+"&ReturnUrl="+DataRequest.UrlEncode(Request.RawUrl)+"&visit_way_id="+Eval("visit_way_id")+"&#39;)" %>'
						runat="server"></asp:LinkButton>
					<asp:LinkButton ID="lnk_delete" Text="ɾ��" Visible='<%#DeletePower %>' CommandName="delete"
						CommandArgument='<%# Eval("visit_way_id") %>' OnClientClick="return popDeleteSingle(this);"
						runat="server"></asp:LinkButton>
				</td>
			</tr>
		</ItemTemplate>
		<FooterTemplate>
			<%# rp_data.Items.Count == 0 ? "<script type='text/javascript'>document.write('<tr><td align=\"center\" colspan=\"'+$(\"#item_list tr th\").length+'\">���޼�¼</td></tr>');</script>" : "" %>
		</FooterTemplate>
	</asp:Repeater>
</table>
