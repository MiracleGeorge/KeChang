<%@ Page Language="C#" MasterPageFile="~/PageEdit.Master" AutoEventWireup="true" CodeFile="SysStoreDetail.aspx.cs" Inherits="YouHoo.Web.SYS.SysStoreDetail" Title="�ޱ���ҳ" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
	<asp:HiddenField ID="hf_id" runat="server" />
	<table cellpadding="0" cellspacing="0" class="table table-bordered table-hover m10">
		<tr>
			<td align="right" class="tableleft">
				ʵ���ұ�ţ�
			</td>
			<td align="left">
				<asp:Label ID="lbl_Code" runat="server"></asp:Label>
			</td>
		</tr>
        <tr>
			<td align="right" class="tableleft">
				ʵ�������ƣ�
			</td>
			<td align="left">
				<asp:Label ID="lbl_Name" runat="server"></asp:Label>
			</td>
		</tr>
		<tr>
			<td align="right" class="tableleft">
				����ʵ���Ҵ��룺
			</td>
			<td align="left">
				<asp:Label ID="lbl_SubCode" runat="server"></asp:Label>
			</td>
		</tr>
		<tr>
			<td align="right" class="tableleft">
				����ʵ�������ƣ�
			</td>
			<td align="left">
				<asp:Label ID="lbl_SubName" runat="server"></asp:Label>
			</td>
		</tr>
		<tr>
			<td align="right" class="tableleft">
				ʵ���ҵ绰��
			</td>
			<td align="left">
				<asp:Label ID="lbl_Phone" runat="server"></asp:Label>
			</td>
		</tr>
		<tr>
			<td align="right" class="tableleft">
				�������ޣ�
			</td>
			<td align="left">
				<asp:Label ID="lbl_PaymentTerm" runat="server"></asp:Label>
			</td>
		</tr>
		<tr>
			<td align="right" class="tableleft">
				ʵ���ҵ�ַ��
			</td>
			<td align="left">
				<asp:Label ID="lbl_Adress" runat="server"></asp:Label>
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
