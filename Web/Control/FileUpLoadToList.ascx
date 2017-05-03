<%@ Control Language="C#" AutoEventWireup="true" CodeFile="FileUpLoadToList.ascx.cs" Inherits="YouHoo.Web.Control.FileUpLoadToList" %>

<link rel="stylesheet" type="text/css" href="/Js/uploadify/uploadify.css" />
<script type="text/javascript" src="/Js/uploadify/jquery.uploadify.js"></script>
<script type="text/javascript" src="/Js/uploadify/uploadifyHelper.js"></script>

<asp:HiddenField ID="hf_tableId" runat="server" />
<asp:HiddenField ID="hf_tableFileId" runat="server" />
<% if (!ReadOnly)
   { %>
<input id="file_upload" name="file_upload" type="file" keepdefaultstyle="true" multiple="true" />
<% } %>
<div class="fileInfo">
    <asp:Repeater ID="rp_files" runat="server">
        <ItemTemplate>
            <div style="margin-bottom: 5px;">
                <a href="<%# Eval("file_path") %>" style="margin-right: 5px;" target="_blank"><%# Eval("file_name")%></a>
                <% if (!ReadOnly)
                   {%>
                <a href="javascript:;" data-id="<%# Eval("file_id") %>" style="color: Red;" onclick="deleteFile(this)">É¾³ý</a>
                <%}%>
            </div>
        </ItemTemplate>
    </asp:Repeater>
</div>
