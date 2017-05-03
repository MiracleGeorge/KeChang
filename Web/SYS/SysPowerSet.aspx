<%@ Page Language="C#" MasterPageFile="~/PageEdit.Master" AutoEventWireup="true" CodeFile="SysPowerSet.aspx.cs" Inherits="YouHoo.Web.SYS.SysPowerSet" %>

<%@ Register Src="../Control/SYS/SysPowerSetGrid.ascx" TagName="SysPowerSetGrid" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <style type="text/css">
        .chklb label
        {
            display: inline-block;
            margin-right: 8px;
        }
    </style>
    <table id="SysPowerSetGrid" class="table table-bordered table-hover m10"
        cellpadding="3" cellspacing="0">
        <uc1:SysPowerSetGrid ID="SysPowerSetGrid1" runat="server" />
    </table>
    <div class="buttonParent">
        <div class="buttonShade">
            <asp:Button CssClass="Inputbtn" ID="btn_save" runat="server" Text="±£´æ" OnClick="btn_save_Click" OnClientClick="SaveLoading()" />
		    <input type="button" class="Inputbtn" value="¹Ø±Õ" onclick="top.Dialog.close()" />
        </div>
    </div>
</asp:Content>
