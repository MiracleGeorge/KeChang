<%@ Page Language="C#" MasterPageFile="~/PageEdit.Master" AutoEventWireup="true" CodeFile="SysDictionaryChildEdit.aspx.cs" Inherits="YouHoo.Web.SYS.SysDictionaryChildEdit" Title="无标题页" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:HiddenField ID="hf_id" runat="server" />
    <asp:HiddenField ID="hf_is_multilayer" Value="0" runat="server" />
    <table cellpadding="0" cellspacing="0" class="table table-bordered table-hover m10">
        <tr>
            <td align="right" class="tableleft">
                选项名称：
            </td>
            <td align="left">
                <asp:TextBox ID="txt_dictionary_child_name" CssClass="validate[required,maxSize[500]]" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td align="right" class="tableleft">
                所属字典：
            </td>
            <td align="left">
                <asp:DropDownList ID="ddl_dictionary_id" CssClass="validate[required]" runat="server"></asp:DropDownList>
            </td>
        </tr>
        <% if (hf_is_multilayer.Value == "1")
           { %>
        <tr>
            <td align="right" class="tableleft">
                所属父级：
            </td>
            <td align="left">
                <asp:DropDownList ID="ddl_parent_dictionary_child_id" runat="server"></asp:DropDownList>
            </td>
        </tr>
        <%} %>
        <tr>
            <td align="right" class="tableleft">
                是否启用：
            </td>
            <td align="left">
                <asp:CheckBox ID="cbo_is_start" Checked="true" runat="server" />
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
        <tr>
            <td align="right" class="tableleft">
            </td>
            <td align="left">
                <asp:Button CssClass="Inputbtn" ID="btn_save" runat="server" Text="保存" OnClick="btn_save_Click" OnClientClick="SaveLoading()" />
                <input type="button" class="Inputbtn" value="关闭" onclick="top.Dialog.close()" />
            </td>
        </tr>
    </table>
</asp:Content>
