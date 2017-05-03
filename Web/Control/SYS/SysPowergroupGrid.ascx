<%@ Control Language="C#" AutoEventWireup="true" CodeFile="SysPowergroupGrid.ascx.cs" Inherits="YouHoo.Web.Control.SYS.SysPowergroupGrid" %>
<%@ Import Namespace="YouHoo.DataTools" %>

<input type="hidden" id="bllName" value="YouhooSysPowergroupBLL" />
<table id="item_list" class="table table-bordered table-hover definewidth m10"
	cellpadding="3" cellspacing="0">
	<tr>
		<th style="width: 30px" align="center">
			<input type="checkbox" id="chkChooseAll" />
		</th>
        <th align="center">
			所属公司(实验室)
		</th>
		<th align="center">
			角色名称
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
					<asp:CheckBox ID="chkChoose" Enabled='<%# Eval("powergroup_id").ToString() != "1" %>' runat="server" />
					<asp:HiddenField ID="hf_id" runat="server" Value='<%# Eval("powergroup_id") %>' />
				</td>
                <td align="center">
					<%# Eval("StoreName")%>
				</td>
				<td align="center">
					<label class="lbl_ajaxUpdate"><%# Eval("powergroup_name")%></label>
					<input type="text" class="validate[required,maxSize[400]] txt_ajaxUpdate" field="PowergroupName" value="<%# Eval("powergroup_name")%>" />
				</td>
				<td align="center">
					<%# Eval("createoperator")%>
				</td>
				<td align="center">
					<%# Eval("createdate")%>
				</td>
				<td align="center" class="operate">
					<a href="javascript:dialogDetail('/SYS/SysPowergroupDetail.aspx?PageIndex=<%#PageIndex %>&ReturnUrl=<%=DataRequest.UrlEncode(Request.RawUrl) %>&powergroup_id=<%# Eval("powergroup_id") %>')">查看</a>
					<asp:LinkButton ID="lnk_update" Text="修改" Visible='<%#UpdatePower %>' OnClientClick='<%# "return dialogUpdateSingle(&#39;/SYS/SysPowergroupEdit.aspx?PageIndex="+PageIndex+"&ReturnUrl="+DataRequest.UrlEncode(Request.RawUrl)+"&powergroup_id="+Eval("powergroup_id")+"&#39;)" %>'
						runat="server"></asp:LinkButton>
					<asp:LinkButton ID="lnk_delete" Text="删除" Visible='<%#DeletePower && Eval("powergroup_id").ToString() != "1" %>' CommandName="delete"
						CommandArgument='<%# Eval("powergroup_id") %>' OnClientClick="return popDeleteSingle(this);"
						runat="server"></asp:LinkButton>
					<asp:LinkButton ID="lnk_powerSet" Text="权限设置" Visible='<%#PowerSetPower %>' OnClientClick='<%# "return dialogCustom(&#39;/SYS/SysPowerSet.aspx?PageIndex="+PageIndex+"&ReturnUrl="+DataRequest.UrlEncode(Request.RawUrl)+"&powergroup_id="+Eval("powergroup_id")+"&#39;, &#39;权限设置&#39;, 1000, 550)" %>'
						runat="server"></asp:LinkButton>
				</td>
			</tr>
		</ItemTemplate>
		<FooterTemplate>
			<%# rp_data.Items.Count == 0 ? "<script type='text/javascript'>document.write('<tr><td align=\"center\" colspan=\"'+$(\"#item_list tr th\").length+'\">暂无记录</td></tr>');</script>" : "" %>
		</FooterTemplate>
	</asp:Repeater>
</table>
