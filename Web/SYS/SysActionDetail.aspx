<%@ Page Language="C#" MasterPageFile="~/PageEdit.Master" AutoEventWireup="true" CodeFile="SysActionDetail.aspx.cs" Inherits="YouHoo.Web.SYS.SysActionDetail" Title="�ޱ���ҳ" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
	<asp:HiddenField ID="hf_id" runat="server" />
	<table cellpadding="0" cellspacing="0" class="table table-bordered table-hover m10">
		<tr>
			<td align="right" class="tableleft">
				�������ƣ�
			</td>
			<td align="left">
				<asp:Label ID="lbl_action_name" runat="server"></asp:Label>
			</td>
		</tr>
		<tr>
			<td align="right" class="tableleft">
				��ʶ��ţ�
			</td>
			<td align="left">
				<asp:Label ID="lbl_action_value" runat="server"></asp:Label>
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
