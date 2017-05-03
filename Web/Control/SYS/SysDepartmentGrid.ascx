<%@ Control Language="C#" AutoEventWireup="true" CodeFile="SysDepartmentGrid.ascx.cs" Inherits="YouHoo.Web.Control.SYS.SysDepartmentGrid" %>
<%@ Import Namespace="YouHoo.DataTools" %>

<input type="hidden" id="bllName" value="YouhooSysDepartmentBLL" />
<table id="item_list" class="table table-bordered table-hover definewidth m10"
	cellpadding="3" cellspacing="0">
	<tr>
		<th style="width: 30px" align="center">
			<input type="checkbox" id="chkChooseAll" />
		</th>
		<th align="center">
			所属门店
		</th>
		<th align="center">
			部门编号
		</th>
		<th align="center">
			部门名称
		</th>
		<th align="center">
			二级部门编号
		</th>
		<th align="center">
			二级部门名称
		</th>
		<th align="center">
			操作
		</th>
	</tr>
	<asp:Repeater ID="rp_data" runat="server" OnItemCommand="rp_data_ItemCommand">
		<ItemTemplate>
			<tr>
				<td align="center">
					<asp:CheckBox ID="chkChoose" Enabled='<%# Eval("Id").ToString() != "1" %>' runat="server" />
					<asp:HiddenField ID="hf_id" runat="server" Value='<%# Eval("Id") %>' />
				</td>
				<td align="center">
					<%# Eval("storename")%>
				</td>
				<td align="center">
					<label class="lbl_ajaxUpdate"><%# Eval("Code")%></label>
					<input type="text" class="validate[required,maxSize[50]] txt_ajaxUpdate" field="Code" value="<%# Eval("Code")%>" />
				</td>
				<td align="center">
					<label class="lbl_ajaxUpdate"><%# Eval("Name")%></label>
					<input type="text" class="validate[required,maxSize[128]] txt_ajaxUpdate" field="Name" value="<%# Eval("Name")%>" />
				</td>
				<td align="center">
					<label class="lbl_ajaxUpdate"><%# Eval("SubCode")%></label>
					<input type="text" class="validate[maxSize[50]] txt_ajaxUpdate" field="Subcode" value="<%# Eval("SubCode")%>" />
				</td>
				<td align="center">
					<label class="lbl_ajaxUpdate"><%# Eval("SubName")%></label>
					<input type="text" class="validate[maxSize[50]] txt_ajaxUpdate" field="Subname" value="<%# Eval("SubName")%>" />
				</td>
				<td align="center" class="operate">
					<a href="javascript:dialogDetail('/SYS/SysDepartmentDetail.aspx?PageIndex=<%#PageIndex %>&ReturnUrl=<%=DataRequest.UrlEncode(Request.RawUrl) %>&Id=<%# Eval("Id") %>')">查看</a>
					<asp:LinkButton ID="lnk_update" Text="修改" Visible='<%#UpdatePower %>' OnClientClick='<%# "return dialogUpdateSingle(&#39;/SYS/SysDepartmentEdit.aspx?PageIndex="+PageIndex+"&ReturnUrl="+DataRequest.UrlEncode(Request.RawUrl)+"&Id="+Eval("Id")+"&#39;)" %>'
						runat="server"></asp:LinkButton>
					<asp:LinkButton ID="lnk_delete" Text="删除" Visible='<%#DeletePower && Eval("Id").ToString() != "1" %>' CommandName="delete"
						CommandArgument='<%# Eval("Id") %>' OnClientClick="return popDeleteSingle(this);"
						runat="server"></asp:LinkButton>
				</td>
			</tr>
		</ItemTemplate>
		<FooterTemplate>
			<%# rp_data.Items.Count == 0 ? "<script type='text/javascript'>document.write('<tr><td align=\"center\" colspan=\"'+$(\"#item_list tr th\").length+'\">暂无记录</td></tr>');</script>" : "" %>
		</FooterTemplate>
	</asp:Repeater>
</table>
