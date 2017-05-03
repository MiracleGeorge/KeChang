<%@ Control Language="C#" AutoEventWireup="true" CodeFile="RebateSaleGrid.ascx.cs" Inherits="YouHoo.Web.Control.REBATE.RebateSaleGrid" %>
<%@ Import Namespace="YouHoo.DataTools" %>

<input type="hidden" id="bllName" value="YouhooRebateSaleBLL" />
<table id="item_list" class="table table-bordered table-hover definewidth m10"
	cellpadding="3" cellspacing="0">
	<tr>
		<th style="width: 30px" align="center">
			<input type="checkbox" id="chkChooseAll" />
		</th>
		<th align="center">
			名称
		</th>
		<th align="center">
			Code
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
					<asp:HiddenField ID="hf_id" runat="server" Value='<%# Eval("Rebate_id") %>' />
				</td>
				<td align="center">
					<label class="lbl_ajaxUpdate"><%# Eval("Name")%></label>
					<input type="text" class="validate[maxSize[50]] txt_ajaxUpdate" field="Name" value="<%# Eval("Name")%>" />
				</td>
				<td align="center">
					<label class="lbl_ajaxUpdate"><%# Eval("Code")%></label>
					<input type="text" class="validate[maxSize[50]] txt_ajaxUpdate" field="Code" value="<%# Eval("Code")%>" />
				</td>
			<%--	<td align="center" class="operate">
					<a href="javascript:dialogDetail('/REBATE/RebateSaleDetail.aspx?PageIndex=<%#PageIndex %>&ReturnUrl=<%=DataRequest.UrlEncode(Request.RawUrl) %>&Rebate_id=<%# Eval("Rebate_id") %>')">查看</a>
					<asp:LinkButton ID="lnk_update" Text="修改" Visible='<%#UpdatePower %>' OnClientClick='<%# "return dialogUpdateSingle(&#39;/REBATE/RebateSaleEdit.aspx?PageIndex="+PageIndex+"&ReturnUrl="+DataRequest.UrlEncode(Request.RawUrl)+"&Rebate_id="+Eval("Rebate_id"))" %>'
						runat="server"></asp:LinkButton>
					<asp:LinkButton ID="lnk_delete" Text="删除" Visible='<%#DeletePower %>' CommandName="delete"
						CommandArgument='<%# Eval("Rebate_id") %>' OnClientClick="return popDeleteSingle(this);"
						runat="server"></asp:LinkButton>
				</td>--%>
			</tr>
		</ItemTemplate>
		<FooterTemplate>
			<%# rp_data.Items.Count == 0 ? "<script type='text/javascript'>document.write('<tr><td align=\"center\" colspan=\"'+$(\"#item_list tr th\").length+'\">暂无记录</td></tr>');</script>" : "" %>
		</FooterTemplate>
	</asp:Repeater>
</table>
