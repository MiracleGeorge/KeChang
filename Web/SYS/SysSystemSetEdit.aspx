<%@ Page Language="C#" MasterPageFile="~/PageEdit.Master" EnableEventValidation="false" AutoEventWireup="true" CodeFile="SysSystemSetEdit.aspx.cs" Inherits="YouHoo.Web.SYS.SysSystemSetEdit" Title="�ޱ���ҳ" %>

<%@ Register Src="~/Control/FileUpLoadToText.ascx" TagPrefix="uc1" TagName="FileUpLoadToText" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:HiddenField ID="hf_id" runat="server" />
    <table cellpadding="0" cellspacing="0" class="table table-bordered table-hover m10">
		<tr>
			<td align="right" class="tableleft">
				ϵͳ���ƣ�
			</td>
			<td align="left">
				<asp:TextBox ID="txt_system_set_name" CssClass="validate[maxSize[50]]" runat="server"></asp:TextBox>
			</td>
		</tr>
		<tr>
			<td align="right" class="tableleft">
				ϵͳlogo��
			</td>
			<td align="left">
                <uc1:FileUpLoadToText ID="txt_system_set_hou_logo" FileType="Image" IsWaterMark="false" runat="server" />
			</td>
		</tr>
		<tr>
			<td align="right" class="tableleft">
				ϵͳ��½ҳ��ʶ��
			</td>
			<td align="left">
                <uc1:FileUpLoadToText ID="txt_system_set_login_biaozhi" FileType="Image" IsWaterMark="false" runat="server" />
			</td>
		</tr>
		<tr>
			<td align="right" class="tableleft">
				ϵͳͼ�꣺
			</td>
			<td align="left">
                <uc1:FileUpLoadToText ID="txt_system_set_icon" FileType="Image" IsWaterMark="false" runat="server" />
			</td>
		</tr>
        <tr>
            <td align="right" class="tableleft">
                ��ʼ���룺
            </td>
            <td align="left">
                <asp:TextBox ID="txt_initialCode" TextMode="Password" CssClass="validate[required,minSize[6],maxSize[16]] input_100" runat="server"></asp:TextBox>
                <input id="cbo_initialCode" type="checkbox" onclick="if(this.checked){$('#<%=txt_initialCode.ClientID %>').prop('type','text');}else{$('#<%=txt_initialCode.ClientID %>').prop('type','password');}" /><label for="cbo_initialCode">����</label>
            </td>
        </tr>
        <tr>
            <td align="right" class="tableleft">
                �б���ʾ������
            </td>
            <td align="left">
                <asp:TextBox ID="txt_list_show_count" CssClass="validate[required,custom[onlyNumber]] input_60" runat="server"></asp:TextBox>
            </td>
        </tr>
    </table>
    <div class="buttonParent">
        <div class="buttonShade">
            <asp:Button CssClass="Inputbtn" ID="btn_save" runat="server" Text="����" OnClick="btn_save_Click" OnClientClick="SaveLoading()" />
        </div>
    </div>
</asp:Content>
