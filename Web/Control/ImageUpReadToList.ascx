<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ImageUpReadToList.ascx.cs" Inherits="YouHoo.Web.Control.ImageUpReadToList" %>
<%@ Import Namespace="YouHoo.DataTools" %>
<style type="text/css">
    /*Õº∆¨œ‡≤·—˘ Ω*/
    .photo-list ul { margin: 0; list-style: none; *display: inline-block; }
    .photo-list ul:after { content: "."; display: block; height: 0; clear: both; visibility: hidden; }
    .photo-list ul li { float: left; margin-right: 10px; text-align: center; *width: 139px; }
    .photo-list ul li .img-box { width: 60px; height: 60px; border: 1px #efefed solid; }
</style>
<div class="photo-list">
    <ul>
        <asp:Repeater ID="gridPayment" runat="server">
            <ItemTemplate>
                <li>
                    <div class="img-box">
                        <a href="<%#Eval("file_path")%>" target="_blank">
                            <img src="<%# Converts.SmallImageFilePath(Eval("file_path").ToString(), "60x60_" ) %>" />
                        </a>
                    </div>
                </li>
            </ItemTemplate>
        </asp:Repeater>
    </ul>
</div>
<asp:HiddenField ID="lalTableId" runat="server"></asp:HiddenField>
<asp:HiddenField ID="lalTableFileId" runat="server"></asp:HiddenField>
