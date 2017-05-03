<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ImageUpLoadToList.ascx.cs" Inherits="YouHoo.Web.Control.ImageUpLoadToList" %>
<%@ Import Namespace="YouHoo.DataTools" %>
<style type="text/css">
    /*上传样式*/
    .upload-box { position: relative; display: inline-block; height: 30px; vertical-align: middle; *display: inline; border: 1px solid #e1e1e1; }
    .upload-box .upload-btn { display: inline-block; height:30px; color: #333; background: #fff; }
    .upload-box .upload-progress { position: absolute; top: 0; left: 0; padding: 2px 5px; width: 115px; height: 26px; border: 1px solid #d7d7d7; background: #fff; overflow: hidden; }
    .upload-box .upload-progress .txt { display: block; padding-right: 10px; font-weight: normal; font-style: normal; font-size: 11px; line-height: 18px; height: 18px; text-overflow: ellipsis; overflow: hidden; }
    .upload-box .upload-progress .bar { position: relative; display: block; width: 112px; height: 4px; border: 1px solid #1da76b; }
    .upload-box .upload-progress .bar b { display: block; width: 0%; height: 4px; font-weight: normal; text-indent: -99em; background: #28B779; overflow: hidden; }
    .upload-file .delete_file { display: inline-block; width: 9px; height: 10px; margin-left: 5px; margin-top:2px; vertical-align: middle; background: url(/Js/swfupload/skin_icons.gif) no-repeat; }
    .swfupload { padding: 8px 0px 16px 0px; }
    .box { display: block; float: left; margin:4px 6px 4px 0px; }
    .upload-file { line-height: 32px; }
    .upload-file img { margin-top: 1px; }
    .upload-path { width: 0px !important; padding: 0px !important; border: 0px !important; }

    /*图片相册样式*/
    .photo-list { margin: 0px; padding: 0px; }
    .photo-list ul { margin: 0; list-style: none; *display: inline-block; }
    .photo-list ul:after { content: "."; display: block; height: 0; clear: both; visibility: hidden; }
    .photo-list ul li { float: left; margin-right: 10px; text-align: center; *width: 47px; }
    .photo-list ul li .img-box { margin-left: 15px; position: relative; width: 20px; height: 20px; overflow: hidden; border: 3px #efefed solid; cursor: pointer; }
    .photo-list ul li .img-box.selected { border: 3px #f60 solid; }
    .photo-list ul li .img-box img { width: 20px; height: 20px; opacity: 1; }
    .photo-list ul li .img-box .remark { top: 106px; left: 0px; margin: 0; padding: 3px 2px; position: absolute; display: block; width: 32px; height: 28px; overflow: hidden; background: #000; filter: alpha(opacity=50); opacity: 0.5; -moz-opacity: 0.5; text-align: left; font-family: "Microsoft Yahei"; }
    .photo-list ul li .img-box .remark:hover { top: 0px; }
    .photo-list ul li .img-box .remark i { color: #fff; font-style: normal; position: relative; line-height: 18px; }
    .photo-list ul li a { font-size: 12px; margin-right: 5px; padding: 0px; }
</style>
<script type="text/javascript" src="/Js/swfupload/swfupload.js"></script>
<script type="text/javascript" src="/Js/swfupload/swfupload.queue.js"></script>
<script type="text/javascript" src="/Js/swfupload/swfupload.handlers.js"></script>

<script type="text/javascript">
    $(function () {
        $("#<%=divupload.ClientID %>").each(function() {
            $(this).InitSWFUpload({
                btntext: "批量上传",
                btnwidth: 66,
                single: false,
                filesize: "<%= YouHoo.DataTools.DataConvert.ToInt32(ConfigurationManager.AppSettings["LoadImage:Size"]) %>",
                sendurl: "/Js/swfupload/FileUpload.aspx",
                flashurl: "/Js/swfupload/swfupload.swf",
                filetypes: "*.jpg;*.jpeg;*.png;*.gif;*.ico",
                tableid: <%= TableId %>,
                tablefileid: <%= TableFileId %>,
                fileids: "<%= hfFileS.ClientID %>",
                thumbnail:"<%= ThumbnailConfig %>"
            });
        });
    });
</script>

<div id="divupload" runat="server" class="upload-box box multi-upload">请<a href="https://get.adobe.com/cn/flashplayer/?no_redirect" target="_blank">安装flash插件</a></div>
<div class="photo-list">
    <ul>
        <asp:Repeater ID="gridPayment" runat="server">
            <ItemTemplate>
                <li data-id="<%#Eval("file_id")%>">
                    <div class="img-box<%#!String.IsNullOrEmpty(Eval("remark").ToString()) ? " selected" :""%>">
                        <input type="hidden" name="hid_photo_name" value="<%#Eval("file_id")%>" />
                        <asp:HiddenField ID="hffile_id" Value='<%#Eval("file_id")%>' runat="server"></asp:HiddenField>
                        <a href="<%#Eval("file_path")%>" target="_blank">
                            <img src="<%# Converts.IsFileExists( Converts.SmallImageFilePath( Eval("file_path").ToString(),"x_" )) ?  Converts.SmallImageFilePath( Eval("file_path").ToString(),"x_" ) : Eval("file_path").ToString() %>" /></a>
                        <span class="remark"><i>
                            <%#Eval("file_name") + "<br>" + Eval("file_size")%></i></span>
                    </div>
                    <a href="javascript:;" onclick="setFocusImg(this,<%#Eval("file_id")%>);">封面</a>
                    <a href="javascript:;" onclick="delImg(this,<%#Eval("file_id")%>);">删除</a>
                </li>
            </ItemTemplate>
        </asp:Repeater>
    </ul>
</div>
<asp:HiddenField ID="lalTableId" runat="server"></asp:HiddenField>
<asp:HiddenField ID="lalTableFileId" runat="server"></asp:HiddenField>
<asp:HiddenField ID="hfFileS" Value="" runat="server" />
