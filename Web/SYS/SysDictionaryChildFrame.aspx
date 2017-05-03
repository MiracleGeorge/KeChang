<%@ Page Language="C#" MasterPageFile="~/PageList.Master" AutoEventWireup="true" CodeFile="SysDictionaryChildFrame.aspx.cs" Inherits="YouHoo.Web.SYS.SysDictionaryChildFrame" %>

<%@ Register Src="~/Control/TreeFrame.ascx" TagPrefix="uc1" TagName="TreeFrame" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <asp:HiddenField ID="hf_dictionaryId" runat="server" />
    <uc1:TreeFrame ID="TreeFrame" IdName="dictionary_child_id" TextName="dictionary_child_name" ParentIdName="parent_dictionary_child_id" LinkUrl="SysDictionaryChildList.aspx" Target="frmrightChildContent" ExtendParameter="" BllName="YouhooSysDictionaryChildBLL" Where="" OrderBy="a.sort asc" runat="server" />
</asp:Content>