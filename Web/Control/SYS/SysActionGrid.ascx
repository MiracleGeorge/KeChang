<%@ Control Language="C#" AutoEventWireup="true" CodeFile="SysActionGrid.ascx.cs"
    Inherits="YouHoo.Web.Control.SYS.SysActionGrid" %>
<%@ Import Namespace="YouHoo.DataTools" %>

<input type="hidden" id="bllName" value="YouhooSysActionBLL" />
<table id="item_list" class="table table-bordered table-hover definewidth m10" cellpadding="3"
    cellspacing="0">
    <tr>
        <th style="width: 30px" align="center">
            <input type="checkbox" id="chkChooseAll" />
        </th>
        <th align="center">
            ��������
        </th>
        <th align="center">
            ��ʶ���
        </th>
        <th align="center">
            ������
        </th>
        <th align="center">
            ����ʱ��
        </th>
        <th align="center">
            ����
        </th>
    </tr>
    <asp:Repeater ID="rp_data" runat="server" OnItemCommand="rp_data_ItemCommand">
        <ItemTemplate>
            <tr>
                <td align="center">
                    <asp:CheckBox ID="chkChoose" runat="server" />
                    <asp:HiddenField ID="hf_id" runat="server" Value='<%# Eval("action_id") %>' />
                </td>
                <td align="center">
                    <label class="lbl_ajaxUpdate"><%# Eval("action_name")%></label>
					<input type="text" class="validate[required,maxSize[400]] txt_ajaxUpdate" field="ActionName" value="<%# Eval("action_name")%>" />
                </td>
                <td align="center">
                    <label class="lbl_ajaxUpdate"><%# Eval("action_value")%></label>
					<input type="text" class="validate[required,maxSize[50]] txt_ajaxUpdate" field="ActionValue" value="<%# Eval("action_value")%>" />
                </td>
                <td align="center">
                    <%# Eval("createoperator")%>
                </td>
                <td align="center">
                    <%# Eval("createdate")%>
                </td>
                <td align="center" class="operate">
					<a href="javascript:dialogDetail('/SYS/SysActionDetail.aspx?PageIndex=<%#PageIndex %>&ReturnUrl=<%=DataRequest.UrlEncode(Request.RawUrl) %>&action_id=<%# Eval("action_id") %>')">�鿴</a>
                    <asp:LinkButton ID="lnk_update" Text="�޸�" Visible='<%#UpdatePower %>' OnClientClick='<%# "return dialogUpdateSingle(&#39;/SYS/SysActionEdit.aspx?PageIndex="+PageIndex+"&ReturnUrl="+DataRequest.UrlEncode(Request.RawUrl)+"&action_id="+Eval("action_id")+"&#39;)" %>'
                        runat="server"></asp:LinkButton>
                    <asp:LinkButton ID="lnk_delete" Text="ɾ��" Visible='<%#DeletePower %>' CommandName="delete"
                        CommandArgument='<%# Eval("action_id") %>' OnClientClick="return popDeleteSingle(this);"
                        runat="server"></asp:LinkButton>
                </td>
            </tr>
        </ItemTemplate>
        <FooterTemplate>
            <%# rp_data.Items.Count == 0 ? "<script type='text/javascript'>document.write('<tr><td align=\"center\" colspan=\"'+$(\"#item_list tr th\").length+'\">���޼�¼</td></tr>');</script>" : "" %>
        </FooterTemplate>
    </asp:Repeater>
</table>
