<%@ Control Language="C#" AutoEventWireup="true" CodeFile="UEditor.ascx.cs" Inherits="YouHoo.Web.Control.UEditor" %>

<script type="text/javascript" charset="utf-8" src="/UEditor/ueditor.config.js"></script>
<script type="text/javascript" charset="utf-8" src="/UEditor/ueditor.all.min.js"> </script>
<!--�����ֶ��������ԣ�������ie����ʱ��Ϊ��������ʧ�ܵ��±༭������ʧ��-->
<!--������ص������ļ��Ḳ������������Ŀ����ӵ��������ͣ���������������Ŀ�����õ���Ӣ�ģ�������ص����ģ�������������-->
<script type="text/javascript" charset="utf-8" src="/UEditor/lang/zh-cn/zh-cn.js"></script>

<asp:TextBox ID="txt_editor" TextMode="MultiLine" runat="server"></asp:TextBox>

<script type="text/javascript">
    $(function () {
        UE.getEditor("<%= txt_editor.ClientID %>");
    })
</script>