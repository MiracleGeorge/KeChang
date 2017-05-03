<%@ Page Language="C#" MasterPageFile="~/PageEdit.Master"  AutoEventWireup="true" CodeFile="SysModuleEdit.aspx.cs" Inherits="YouHoo.Web.SYS.SysModuleEdit" Title="�ޱ���ҳ"%>


<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
	<asp:HiddenField ID="hf_id" runat="server" />
	<table cellpadding="0" cellspacing="0" class="table table-bordered table-hover m10">
		<tr>
			<td align="right" class="tableleft">
				ģ�����ƣ�
			</td>
			<td align="left">
				<asp:TextBox ID="txt_module_name" CssClass="validate[required,maxSize[400]]" runat="server"></asp:TextBox>
			</td>
		</tr>
		<tr>
			<td align="right" class="tableleft">
				����ģ�飺
			</td>
			<td align="left">
				<asp:DropDownList ID="ddl_parentmodule_id" CssClass="validate[required]" runat="server"></asp:DropDownList>
			</td>
		</tr>
		<tr>
			<td align="right" class="tableleft">
				��ʶ��ţ�
			</td>
			<td align="left">
				<asp:TextBox ID="txt_module_value" CssClass="validate[maxSize[50]]" runat="server"></asp:TextBox>
			</td>
		</tr>
		<tr>
			<td align="right" class="tableleft">
				ģ�����ӵ�ַ��
			</td>
			<td align="left">
				<asp:TextBox ID="txt_module_url" CssClass="validate[maxSize[400]]" runat="server"></asp:TextBox>
			</td>
		</tr>
		<tr>
			<td align="right" class="tableleft">
				����
			</td>
			<td align="left">
				<asp:TextBox ID="txt_sort" CssClass="validate[custom[onlyNumber]] input_60" runat="server"></asp:TextBox>
			</td>
		</tr>
		<tr>
			<td align="right" class="tableleft">
				��ע��
			</td>
			<td align="left">
				<asp:TextBox ID="txt_remark" TextMode="MultiLine" Width="90%" Height="150" runat="server"></asp:TextBox>
			</td>
		</tr>
		<tr>
			<td align="right" class="tableleft">
			</td>
			<td align="left">
				<asp:Button CssClass="Inputbtn" ID="btn_save" runat="server" Text="����" OnClick="btn_save_Click" OnClientClick="SaveLoading()" />
				<input type="button" class="Inputbtn" value="�ر�" onclick="top.Dialog.close()" />
			</td>
		</tr>
	</table>
</asp:Content>
