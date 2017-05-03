<%@ Page Language="C#" MasterPageFile="~/PageEdit.Master" AutoEventWireup="true" CodeFile="SysUsersDetail.aspx.cs" Inherits="YouHoo.Web.SYS.SysUsersDetail" Title="无标题页" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
	<asp:HiddenField ID="hf_id" runat="server" />
	<table cellpadding="0" cellspacing="0" class="table table-bordered table-hover m10">
		<tr>
			<td align="right" class="tableleft">
				用户编号：
			</td>
			<td align="left">
				<asp:Label ID="lbl_usercode" runat="server"></asp:Label>
			</td>
		</tr>
        <tr>
			<td align="right" class="tableleft">
				用户名：
			</td>
			<td align="left">
				<asp:Label ID="lbl_username" runat="server"></asp:Label>
			</td>
		</tr>
		<tr>
			<td align="right" class="tableleft">
				姓名：
			</td>
			<td align="left">
				<asp:Label ID="lbl_real_name" runat="server"></asp:Label>
			</td>
		</tr>
        <tr>
			<td align="right" class="tableleft">
				所属公司(实验室)：
			</td>
			<td align="left">
				<asp:Label ID="lbl_StoreId" runat="server"></asp:Label>
			</td>
		</tr>
		<tr>
			<td align="right" class="tableleft">
				所属部门：
			</td>
			<td align="left">
				<asp:Label ID="lbl_departmentId" runat="server"></asp:Label>
			</td>
		</tr>
		<tr>
			<td align="right" class="tableleft">
				移动电话：
			</td>
			<td align="left">
				<asp:Label ID="lbl_phone" runat="server"></asp:Label>
			</td>
		</tr>
		<tr>
			<td align="right" class="tableleft">
				固定电话：
			</td>
			<td align="left">
				<asp:Label ID="lbl_tel" runat="server"></asp:Label>
			</td>
		</tr>
		<tr>
			<td align="right" class="tableleft">
				电子邮箱：
			</td>
			<td align="left">
				<asp:Label ID="lbl_email" runat="server"></asp:Label>
			</td>
		</tr>
		<tr>
			<td align="right" class="tableleft">
				角色：
			</td>
			<td align="left">
				<asp:Label ID="lbl_powergroup_id" runat="server"></asp:Label>
			</td>
		</tr>
        <tr>
			<td align="right" class="tableleft">
				是否业务员：
			</td>
			<td align="left">
				<asp:Label ID="lbl_IsSaleMan" runat="server"></asp:Label>
			</td>
		</tr>
		<tr>
			<td align="right" class="tableleft">
				状态：
			</td>
			<td align="left">
				<asp:Label ID="lbl_status" runat="server"></asp:Label>
			</td>
		</tr>
		<tr>
			<td align="right" class="tableleft">
				备注：
			</td>
			<td align="left">
				<asp:Label ID="lbl_remark" runat="server"></asp:Label>
			</td>
		</tr>
	</table>
	<div class="buttonParent">
		<div class="buttonShade">
			<asp:Button CssClass="Inputbtn" ID="btn_update" runat="server" Text="修改" OnClick="btn_update_Click" />
			<input type="button" class="Inputbtn" value="关闭" onclick="top.Dialog.close()" />
		</div>
	</div>
</asp:Content>
