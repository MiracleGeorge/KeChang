<%@ Control Language="C#" AutoEventWireup="true" CodeFile="SysProcessGrid.ascx.cs" Inherits="YouHoo.Web.Control.SYS.SysProcessGrid" %>
<%@ Import Namespace="YouHoo.DataTools" %>

<input type="hidden" id="bllName" value="YouhooSysProcessBLL" />
<table id="item_list" class="table table-bordered table-hover definewidth m10"
	cellpadding="3" cellspacing="0">
	<tr>
		<th style="width: 30px" align="center">
			<input type="checkbox" id="chkChooseAll" />
		</th>
		<th align="center">
			流程名称
		</th>
		<th align="center">
			排序
		</th>
		<th align="center">
			操作
		</th>
	</tr>
	<asp:Repeater ID="rp_data" runat="server" OnItemCommand="rp_data_ItemCommand">
		<ItemTemplate>
			<tr>
				<td align="center">
					<asp:CheckBox ID="chkChoose" runat="server" Enabled='<%# !(Eval("Id").ToString() == "1" || Eval("Id").ToString() == "2") %>' />
					<asp:HiddenField ID="hf_id" runat="server" Value='<%# Eval("ID") %>' />
				</td>
				<td align="center">
					<label class="lbl_ajaxUpdate"><%# Eval("Name")%></label>
					<input type="text" class="validate[required,maxSize[50]] txt_ajaxUpdate" field="Name" value="<%# Eval("Name")%>" />
				</td>
				<td align="center">
					<label class="lbl_ajaxUpdate"><%# Eval("Sort")%></label>
					<input type="text" class="validate[required,custom[onlyNumber]] txt_ajaxUpdate" field="Sort" value="<%# Eval("Sort")%>" />
				</td>
				<td align="center" class="operate">
					<a href="javascript:dialogDetail('/SYS/SysProcessDetail.aspx?PageIndex=<%#PageIndex %>&ReturnUrl=<%=DataRequest.UrlEncode(Request.RawUrl) %>&ID=<%# Eval("ID") %>')">查看</a>
					<asp:LinkButton ID="lnk_update" Text="修改" Visible='<%#UpdatePower %>' OnClientClick='<%# "return dialogUpdateSingle(&#39;/SYS/SysProcessEdit.aspx?PageIndex="+PageIndex+"&ReturnUrl="+DataRequest.UrlEncode(Request.RawUrl)+"&ID="+Eval("ID")+"&#39;)" %>'
						runat="server"></asp:LinkButton>
					<asp:LinkButton ID="lnk_delete" Text="删除" Visible='<%#DeletePower && !(Eval("Id").ToString() != "1" || Eval("Id").ToString() != "2") %>' CommandName="delete"
						CommandArgument='<%# Eval("ID") %>' OnClientClick="return popDeleteSingle(this);"
						runat="server"></asp:LinkButton>
				</td>
			</tr>
		</ItemTemplate>
		<FooterTemplate>
			<%# rp_data.Items.Count == 0 ? "<script type='text/javascript'>document.write('<tr><td align=\"center\" colspan=\"'+$(\"#item_list tr th\").length+'\">暂无记录</td></tr>');</script>" : "" %>
		</FooterTemplate>
	</asp:Repeater>
</table>
