<%@ Control Language="C#" AutoEventWireup="true" CodeFile="FileUpLoadToText.ascx.cs" Inherits="YouHoo.Web.Control.FileUpLoadToText" %>
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
    .box { display: block; float: left; margin-right: 4px; }
    .upload-file { line-height: 32px; }
    .upload-file img { margin-top: 1px; }
    .upload-path { width: 0px !important; padding: 0px !important; border: 0px !important; }
</style>

<script type="text/javascript" src="/Js/swfupload/swfupload.js"></script>
<script type="text/javascript" src="/Js/swfupload/swfupload.queue.js"></script>
<script type="text/javascript" src="/Js/swfupload/swfupload.handlers.js"></script>

<script type="text/javascript">
    $(function () {
        //初始化上传控件
        $("#<%=divupload.ClientID %>").each(function () {
            $(this).InitSWFUpload({
                water:"<%= IsWaterMark.ToString().ToLower() %>",
                btntext: "<%= FileType == YouHoo.Web.Control.FileTypeEnum.Image ? "选择图片" : "选择文件" %>",
                btnwidth: 66,
                btnheight: 28,
                filesize: "<%= FileType == YouHoo.Web.Control.FileTypeEnum.Image ? ConfigurationManager.AppSettings["LoadImage:Size"] : ConfigurationManager.AppSettings["LoadFile:Size"] %>",
                sendurl: "/Js/swfupload/FileUpload.aspx",
                flashurl: "/Js/swfupload/swfupload.swf",
                filetypes: "<%= FileType == YouHoo.Web.Control.FileTypeEnum.Image ? "*.jpg;*.jpeg;*.png;*.gif;*.ico" : "" %>",
                filetype:"<%= YouHoo.DataTools.DataConvert.ToInt32(FileType) %>",
                thumbnail:"<%= ThumbnailConfig %>"
            });
        });
    });
</script>

<div id="divupload" runat="server" class="upload-box box single-upload">请<a href="https://get.adobe.com/cn/flashplayer/?no_redirect" target="_blank">安装flash插件</a></div>
<div class="upload-file box"><%=FileUrl %></div>
<asp:TextBox ID="txtFileName" runat="server" CssClass="upload-path box" />