<%@ Page Language="C#" MasterPageFile="~/PageEdit.Master" AutoEventWireup="true" CodeFile="SysStoreEdit.aspx.cs" Inherits="YouHoo.Web.SYS.SysStoreEdit" Title="无标题页" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
	<asp:HiddenField ID="hf_id" runat="server" />
	<table cellpadding="0" cellspacing="0" class="table table-bordered table-hover m10">
		<tr>
			<td align="right" class="tableleft">
				实验室编号：
			</td>
			<td align="left">
				<asp:TextBox ID="txt_Code" CssClass="validate[required,maxSize[50]]" runat="server"></asp:TextBox>
			</td>
		</tr>
        <tr>
			<td align="right" class="tableleft">
				实验室名称：
			</td>
			<td align="left">
				<asp:TextBox ID="txt_Name" CssClass="validate[required,maxSize[50]]" runat="server"></asp:TextBox>
			</td>
		</tr>
		<tr>
			<td align="right" class="tableleft">
				二级实验室代码：
			</td>
			<td align="left">
				<asp:TextBox ID="txt_SubCode" CssClass="validate[maxSize[50]]" runat="server"></asp:TextBox>
			</td>
		</tr>
		<tr>
			<td align="right" class="tableleft">
				二级实验室名称：
			</td>
			<td align="left">
				<asp:TextBox ID="txt_SubName" CssClass="validate[maxSize[50]]" runat="server"></asp:TextBox>
			</td>
		</tr>		
		<tr>
			<td align="right" class="tableleft">
				实验室电话：
			</td>
			<td align="left">
				<asp:TextBox ID="txt_Phone" CssClass="validate[maxSize[50]]" runat="server"></asp:TextBox>
			</td>
		</tr>
		<tr>
			<td align="right" class="tableleft">
				付款期限：
			</td>
			<td align="left">
				<asp:TextBox ID="txt_PaymentTerm" CssClass="validate[maxSize[50]]" runat="server"></asp:TextBox>
			</td>
		</tr>
		<tr>
			<td align="right" class="tableleft">
				实验室地址：
			</td>
			<td align="left">
				<asp:TextBox ID="txt_Adress" CssClass="validate[maxSize[100]]" runat="server"></asp:TextBox>
			</td>
		</tr>
		<tr>
			<td align="right" class="tableleft">
				备注：
			</td>
			<td align="left">
				<asp:TextBox ID="txt_remark" TextMode="MultiLine" Width="90%" Height="60" runat="server"></asp:TextBox>
			</td>
		</tr>
	</table>
	<div class="buttonParent">
		<div class="buttonShade">
			<asp:Button CssClass="Inputbtn" ID="btn_save" runat="server" Text="保存" OnClick="btn_save_Click" OnClientClick="SaveLoading()" />
			<input type="button" class="Inputbtn" value="关闭" onclick="top.Dialog.close()" />
		</div>
	</div>
</asp:Content>
