<%@ Page Language="C#" MasterPageFile="~/PageEdit.Master" AutoEventWireup="true" CodeFile="SysUsersDetail.aspx.cs" Inherits="YouHoo.Web.SYS.SysUsersDetail" Title="�ޱ���ҳ" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
	<asp:HiddenField ID="hf_id" runat="server" />
	<table cellpadding="0" cellspacing="0" class="table table-bordered table-hover m10">
		<tr>
			<td align="right" class="tableleft">
				�û���ţ�
			</td>
			<td align="left">
				<asp:Label ID="lbl_usercode" runat="server"></asp:Label>
			</td>
		</tr>
        <tr>
			<td align="right" class="tableleft">
				�û�����
			</td>
			<td align="left">
				<asp:Label ID="lbl_username" runat="server"></asp:Label>
			</td>
		</tr>
		<tr>
			<td align="right" class="tableleft">
				������
			</td>
			<td align="left">
				<asp:Label ID="lbl_real_name" runat="server"></asp:Label>
			</td>
		</tr>
        <tr>
			<td align="right" class="tableleft">
				������˾(ʵ����)��
			</td>
			<td align="left">
				<asp:Label ID="lbl_StoreId" runat="server"></asp:Label>
			</td>
		</tr>
		<tr>
			<td align="right" class="tableleft">
				�������ţ�
			</td>
			<td align="left">
				<asp:Label ID="lbl_departmentId" runat="server"></asp:Label>
			</td>
		</tr>
		<tr>
			<td align="right" class="tableleft">
				�ƶ��绰��
			</td>
			<td align="left">
				<asp:Label ID="lbl_phone" runat="server"></asp:Label>
			</td>
		</tr>
		<tr>
			<td align="right" class="tableleft">
				�̶��绰��
			</td>
			<td align="left">
				<asp:Label ID="lbl_tel" runat="server"></asp:Label>
			</td>
		</tr>
		<tr>
			<td align="right" class="tableleft">
				�������䣺
			</td>
			<td align="left">
				<asp:Label ID="lbl_email" runat="server"></asp:Label>
			</td>
		</tr>
		<tr>
			<td align="right" class="tableleft">
				��ɫ��
			</td>
			<td align="left">
				<asp:Label ID="lbl_powergroup_id" runat="server"></asp:Label>
			</td>
		</tr>
        <tr>
			<td align="right" class="tableleft">
				�Ƿ�ҵ��Ա��
			</td>
			<td align="left">
				<asp:Label ID="lbl_IsSaleMan" runat="server"></asp:Label>
			</td>
		</tr>
		<tr>
			<td align="right" class="tableleft">
				״̬��
			</td>
			<td align="left">
				<asp:Label ID="lbl_status" runat="server"></asp:Label>
			</td>
		</tr>
		<tr>
			<td align="right" class="tableleft">
				��ע��
			</td>
			<td align="left">
				<asp:Label ID="lbl_remark" runat="server"></asp:Label>
			</td>
		</tr>
	</table>
	<div class="buttonParent">
		<div class="buttonShade">
			<asp:Button CssClass="Inputbtn" ID="btn_update" runat="server" Text="�޸�" OnClick="btn_update_Click" />
			<input type="button" class="Inputbtn" value="�ر�" onclick="top.Dialog.close()" />
		</div>
	</div>
</asp:Content>
