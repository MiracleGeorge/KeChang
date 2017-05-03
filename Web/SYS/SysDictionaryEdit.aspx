<%@ Page Language="C#" MasterPageFile="~/PageEdit.Master" AutoEventWireup="true" CodeFile="SysDictionaryEdit.aspx.cs" Inherits="YouHoo.Web.SYS.SysDictionaryEdit" Title="无标题页" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
	<asp:HiddenField ID="hf_id" runat="server" />
	<table cellpadding="0" cellspacing="0" class="table table-bordered table-hover m10">
		<tr>
			<td align="right" class="tableleft">
				字典名称：
			</td>
			<td align="left">
				<asp:TextBox ID="txt_dictionary_name" CssClass="validate[required,maxSize[50]]" runat="server"></asp:TextBox>
			</td>
		</tr>
		<tr>
			<td align="right" class="tableleft">
				是否为多层级结构：
			</td>
			<td align="left">
                <asp:CheckBox ID="cbo_is_multilayer" runat="server" />
			</td>
		</tr>
		<tr>
			<td align="right" class="tableleft">
				排序：
			</td>
			<td align="left">
				<asp:TextBox ID="txt_sort" CssClass="validate[custom[onlyNumber]] input_60" runat="server"></asp:TextBox>
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
