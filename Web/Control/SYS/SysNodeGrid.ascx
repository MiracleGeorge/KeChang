<%@ Control Language="C#" AutoEventWireup="true" CodeFile="SysNodeGrid.ascx.cs" Inherits="YouHoo.Web.Control.SYS.SysNodeGrid" %>
<%@ Import Namespace="YouHoo.DataTools" %>

<input type="hidden" id="bllName" value="YouhooSysNodeBLL" />
<table id="item_list" class="table table-bordered table-hover definewidth m10"
	cellpadding="3" cellspacing="0">
	<tr>
		<th style="width: 30px" align="center">
			<input type="checkbox" id="chkChooseAll" />
		</th>
		<th align="center">
			流程节点名称
		</th>
		<th align="center">
			所属流程
		</th>
		<th align="center">
			所属公司(实验室)
		</th>
		<th align="center">
			审核角色
		</th>
		<th align="center">
			操作
		</th>
	</tr>
	<asp:Repeater ID="rp_data" runat="server" OnItemCommand="rp_data_ItemCommand">
		<ItemTemplate>
			<tr>
				<td align="center">
					<asp:CheckBox ID="chkChoose" Enabled='<%# !(Eval("Id").ToString() == "1" || Eval("Id").ToString() == "2") %>' runat="server" />
					<asp:HiddenField ID="hf_id" runat="server" Value='<%# Eval("ID") %>' />
				</td>
				<td align="center">
					<label class="lbl_ajaxUpdate"><%# Eval("NodeName")%></label>
					<input type="text" class="validate[required,maxSize[50]] txt_ajaxUpdate" field="Nodename" value="<%# Eval("NodeName")%>" />
				</td>
				<td align="center">
					<%# Eval("processname")%>
				</td>
				<td align="center">
					<%# Eval("storename")%>
				</td>
				<td align="center">
					<%# Eval("rolename")%>
				</td>
				<td align="center" class="operate">
					<a href="javascript:dialogDetail('/SYS/SysNodeDetail.aspx?PageIndex=<%#PageIndex %>&ReturnUrl=<%=DataRequest.UrlEncode(Request.RawUrl) %>&ID=<%# Eval("ID") %>')">查看</a>
					<asp:LinkButton ID="lnk_update" Text="修改" Visible='<%#UpdatePower %>' OnClientClick='<%# "return dialogUpdateSingle(&#39;/SYS/SysNodeEdit.aspx?PageIndex="+PageIndex+"&ReturnUrl="+DataRequest.UrlEncode(Request.RawUrl)+"&ID="+Eval("ID")+"&#39;)" %>'
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
