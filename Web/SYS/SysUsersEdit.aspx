<%@ Page Language="C#" EnableEventValidation="false" MasterPageFile="~/PageEdit.Master" AutoEventWireup="true" CodeFile="SysUsersEdit.aspx.cs" Inherits="YouHoo.Web.SYS.SysUsersEdit" Title="�ޱ���ҳ" %>

<%@ Register Src="../Control/FileUpLoadToText.ascx" TagName="FileUpLoadToText" TagPrefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script type="text/javascript" src="/Js/cityLinkage/DataAction.js"></script>
    <script type="text/javascript">
        $(function () {
            if ($.trim($("#<%=txt_username.ClientID %>").val()) == $.trim($("#<%=hf_username.ClientID %>").val())) {
                $("#<%=txt_username.ClientID %>").attr("class", "validate[required,custom[username]]");
            }
            else {
                $("#<%=txt_username.ClientID %>").attr("class", "validate[required,custom[username],ajax[ajaxUser]]");
            }
        })
        function UsernameChange() {
            if ($.trim($("#<%=txt_username.ClientID %>").val()) == $.trim($("#<%=hf_username.ClientID %>").val())) {
                $("#<%=txt_username.ClientID %>").attr("class", "validate[required,custom[username]]" + ($("#<%=txt_username.ClientID %>").validationEngine("validate") ? " errorField" : ""));
            }
            else {
                $("#<%=txt_username.ClientID %>").attr("class", "validate[required,custom[username],ajax[ajaxUser]]" + ($("#<%=txt_username.ClientID %>").validationEngine("validate") ? " errorField" : ""));
            }
        }
    </script>
    <asp:HiddenField ID="hf_id" runat="server" />
    <asp:HiddenField ID="hf_username" runat="server" />
    <table cellpadding="0" cellspacing="0" class="table table-bordered table-hover m10">
        <tr>
            <td align="right" class="tableleft">�û���ţ�
            </td>
            <td align="left">
                <asp:TextBox ID="txt_usercode" CssClass="validate[required,maxSize[50]]" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td align="right" class="tableleft">�û�����
            </td>
            <td align="left">
                <asp:TextBox ID="txt_username" CssClass="validate[required,custom[username],ajax[ajaxUser]]" onchange="UsernameChange()" runat="server"></asp:TextBox>
                <p style="color: #999;">* 4~16���ַ�����ʹ����ĸ�����ּ��»��ߣ�������ĸ��ͷ.</p>
            </td>
        </tr>
        <tr>
            <td align="right" class="tableleft">������
            </td>
            <td align="left">
                <asp:TextBox ID="txt_real_name" CssClass="validate[maxSize[20]]" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td align="right" class="tableleft">������˾(ʵ����)��
            </td>
            <td align="left">
                <asp:DropDownList ID="ddl_Store" Width="139" Height="30" CssClass="validate[required]" onchange="stroChange('Store','Department','powergroup_id')" runat="server"></asp:DropDownList>
                <asp:HiddenField ID="hf_Store" Value="0" runat="server" />
            </td>
        </tr>
        <tr>
            <td align="right" class="tableleft">�������ţ�
            </td>
            <td align="left">
                <asp:DropDownList ID="ddl_Department" Width="139" Height="30" CssClass="validate[required]" runat="server"></asp:DropDownList>
                <asp:HiddenField ID="hf_Department" Value="0" runat="server" />
            </td>
        </tr>
        <tr>
            <td align="right" class="tableleft">�ƶ��绰��
            </td>
            <td align="left">
                <asp:TextBox ID="txt_phone" CssClass="validate[maxSize[50]]" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td align="right" class="tableleft">�̶��绰��
            </td>
            <td align="left">
                <asp:TextBox ID="txt_tel" CssClass="validate[maxSize[20],custom[muchTel]]" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td align="right" class="tableleft">�������䣺
            </td>
            <td align="left">
                <asp:TextBox ID="txt_email" CssClass="validate[maxSize[50],custom[email]]" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="tableleft">��ɫ��
            </td>
            <td align="left">
                <asp:DropDownList ID="ddl_powergroup_id" runat="server" CssClass="validate[required]"></asp:DropDownList>
                <asp:HiddenField ID="hf_powergroup_id" Value="0" runat="server" />
            </td>
        </tr>
        <tr>
            <td align="right" class="tableleft">�Ƿ�ҵ��Ա��
            </td>
            <td align="left">
                <asp:DropDownList ID="ddl_SaleMan" runat="server">
                    <asp:ListItem Value="True">��</asp:ListItem>
                    <asp:ListItem Value="False">��</asp:ListItem>
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td align="right" class="tableleft">״̬��
            </td>
            <td align="left">
                <asp:DropDownList ID="ddl_status" runat="server">
                    <asp:ListItem Value="0">����</asp:ListItem>
                    <asp:ListItem Value="1">����</asp:ListItem>
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td align="right" class="tableleft">��ע��
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
