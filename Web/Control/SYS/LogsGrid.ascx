<%@ Control Language="C#" AutoEventWireup="true" CodeFile="LogsGrid.ascx.cs" Inherits="YouHoo.Web.Control.SYS.LogsGrid" %>
<%@ Import Namespace="YouHoo.DataTools" %>

<input type="hidden" id="bllName" value="LogsBLL" />
<table id="item_list" class="table table-bordered table-hover definewidth m10" cellpadding="3"
    cellspacing="0">
    <tr>
        <th align="center">
            ��������
        </th>
        <th align="center" width="200">
            ��������
        </th>
        <th align="center" width="200">
            ����Ա
        </th>
        <th align="center" width="200">
            ����ʱ��
        </th>
    </tr>
    <asp:Repeater ID="rp_data" runat="server">
        <ItemTemplate>
            <tr>
                <td align="center">
                    <%# Eval("tablename") %>
                </td>
                <td align="center">
                    <%# Eval("datatype")%>
                </td>
                <td align="center">
                    <%# Eval("cname")%>
                </td>
                <td align="center">
                    <%# Eval("createdate")%>
                </td>
            </tr>
        </ItemTemplate>
        <FooterTemplate>
            <%# rp_data.Items.Count == 0 ? "<script type='text/javascript'>document.write('<tr><td align=\"center\" colspan=\"'+$(\"#item_list tr th\").length+'\">���޼�¼</td></tr>');</script>" : "" %>
        </FooterTemplate>
    </asp:Repeater>
</table>
