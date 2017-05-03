<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SysUserChangePwd.aspx.cs" Inherits="YouHoo.Web.SYS.SysUserChangePwd" MasterPageFile="../PageEdit.Master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table cellpadding="0" cellspacing="0" class="table table-bordered table-hover m10">
        <tr>
            <td class="tableleft">
                登录帐号：
            </td>
            <td align="left">
                <asp:Label runat="server" ID="lblName"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="tableleft">
                原密码：
            </td>
            <td align="left">
                <asp:TextBox ID="txtoldPwd" runat="server" CssClass="validate[required,ajax[ajaxUserPwd]]" TextMode="Password" Width="200px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="tableleft">
                新密码：
            </td>
            <td align="left">
                <asp:TextBox ID="txtnewPwd" runat="server" CssClass="validate[required,minSize[6],maxSize[16]]" TextMode="Password" Width="200px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="tableleft">
                重复新密码：
            </td>
            <td align="left">
                <asp:TextBox ID="txtnewPwd2" runat="server" TextMode="Password" Width="200px"></asp:TextBox>
            </td>
        </tr>
    </table>
    <div class="buttonParent">
        <div class="buttonShade">
            <asp:Button CssClass="Inputbtn" ID="btn_save" runat="server" Text="修改" OnClick="btn_save_Click" OnClientClick="SaveLoading()" />
        </div>
    </div>
</asp:Content>
