<%@ Page Language="C#" MasterPageFile="~/PageEdit.Master" AutoEventWireup="true" CodeFile="SysPowergroupEdit.aspx.cs" Inherits="YouHoo.Web.SYS.SysPowergroupEdit" Title="�ޱ���ҳ" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
	<asp:HiddenField ID="hf_id" runat="server" />
	<table cellpadding="0" cellspacing="0" class="table table-bordered table-hover m10">
        <tr>
			<td align="right" class="tableleft">
				������˾(ʵ����)��
			</td>
			<td align="left">
				<asp:DropDownList ID="ddl_StoreId" runat="server" CssClass="validate[required]"></asp:DropDownList>
			</td>
		</tr>
		<tr>
			<td align="right" class="tableleft">
				��ɫ���ƣ�
			</td>
			<td align="left">
				<asp:TextBox ID="txt_powergroup_name" CssClass="validate[required,maxSize[400]]" runat="server"></asp:TextBox>
			</td>
		</tr>
		<tr>
			<td align="right" class="tableleft">
				��ע��
			</td>
			<td align="left">
				<asp:TextBox ID="txt_remark" TextMode="MultiLine" Width="90%" Height="60" runat="server"></asp:TextBox>
			</td>
		</tr>
	</table>
    <div class="buttonParent">
        <div class="buttonShade">
            <asp:Button CssClass="Inputbtn" ID="btn_save" runat="server" Text="����" OnClick="btn_save_Click" OnClientClick="SaveLoading()" />
		    <input type="button" class="Inputbtn" value="�ر�" onclick="top.Dialog.close()" />
        </div>
    </div>
</asp:Content>