<%@ Page Language="C#" MasterPageFile="~/PageList.Master" AutoEventWireup="true" CodeFile="SysDictionaryFrame.aspx.cs" Inherits="YouHoo.Web.SYS.SysDictionaryFrame" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link rel="Stylesheet" type="text/css" href="/Js/portraitMenu/portraitMenu.css" />
    <script type="text/javascript" src="/Js/portraitMenu/portraitMenu.js"></script>
    <script type="text/javascript">
        $(function () {
            $(".tableMain table").height($(window).height() - 31);
            $(".tableMain table").find(".tableMain_tree, iframe").height($(window).height() - 51);
        })
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <div class="tableMain">
        <table class="table table-bordered definewidth m10" style="background-color: #e8f6ff;">
            <tr>
                <td valign="top" width="150">
                    <div class="list_menu">
                        <asp:Repeater ID="rp_dictionary" OnItemCommand="rp_dictionary_ItemCommand" runat="server">
                            <ItemTemplate>
                                <div class="list_menu_item">
                                    <a href="<%# Eval("is_multilayer").ToString() == "1" ? "SysDictionaryChildFrame.aspx" : "SysDictionaryChildList.aspx" %>?dictionary_id=<%# Eval("dictionary_id") %>" class="text_slice" target="frmrightContent" title="<%# Eval("dictionary_name") %>"><%# Eval("dictionary_name") %></a>
                                    <div class="menu" style="float: left; display: none; text-indent: 0; margin-left: 5px;">
                                        <a href="javascript:dialogUpdateSingle('/SYS/SysDictionaryEdit.aspx?dictionary_id=<%# Eval("dictionary_id") %>')" class="icon_edit">&nbsp;</a>
                                        <asp:LinkButton ID="lnk_delete" CommandName="delete" CommandArgument='<%# Eval("dictionary_id") %>' OnClientClick="return popDeleteSingle(this);" CssClass="icon_delete" runat="server">&nbsp;</asp:LinkButton>
                                    </div>
                                </div>
                            </ItemTemplate>
                        </asp:Repeater>
                        <div class="list_menu_item nobg">
                            <a href="javascript:dialogAdd('/SYS/SysDictionaryEdit.aspx');" class="icon_add">&nbsp;</a>
                        </div>
                    </div>
                </td>
                <td valign="top">
                    <iframe height="100%" width="100%" frameborder="0" id="frmrightContent" name="frmrightContent" allowtransparency="true"></iframe>
                </td>
            </tr>
        </table>
    </div>
    <script type="text/javascript">
        $(function () {
            $(".list_menu .list_menu_item").not(":last").hover(function () {
                $(this).find(".menu").show();
                $(this).find(".text_slice").width(86);
            }, function () {
                $(this).find(".menu").hide();
                $(this).find(".text_slice").width("100%");
            })
        })
    </script>
</asp:Content>
