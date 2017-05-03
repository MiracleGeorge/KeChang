<%@ Control Language="C#" AutoEventWireup="true" CodeFile="UEditor.ascx.cs" Inherits="YouHoo.Web.Control.UEditor" %>

<script type="text/javascript" charset="utf-8" src="/UEditor/ueditor.config.js"></script>
<script type="text/javascript" charset="utf-8" src="/UEditor/ueditor.all.min.js"> </script>
<!--建议手动加载语言，避免在ie下有时因为加载语言失败导致编辑器加载失败-->
<!--这里加载的语言文件会覆盖你在配置项目里添加的语言类型，比如你在配置项目里配置的是英文，这里加载的中文，那最后就是中文-->
<script type="text/javascript" charset="utf-8" src="/UEditor/lang/zh-cn/zh-cn.js"></script>

<asp:TextBox ID="txt_editor" TextMode="MultiLine" runat="server"></asp:TextBox>

<script type="text/javascript">
    $(function () {
        UE.getEditor("<%= txt_editor.ClientID %>");
    })
</script>