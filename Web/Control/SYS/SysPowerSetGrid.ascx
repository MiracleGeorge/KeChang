<%@ Control Language="C#" AutoEventWireup="true" CodeFile="SysPowerSetGrid.ascx.cs" Inherits="YouHoo.Web.Control.SYS.SysPowerSetGrid" %>
<%@ Import Namespace="YouHoo.DataTools" %>
<tr>
    <th width="15%">
        <input type="checkbox" id="cbo_chooseAll" onchange="chooseAll(this)" />
        <label for="cbo_chooseAll" style="font-weight: 700; font-size: 13px;">模块名称</label>
    </th>
    <th>
        权限
    </th>
</tr>
<asp:Repeater ID="grdSysPowergroups" runat="server" OnItemCommand="grdSysPowergroups_ItemCommand"
    OnItemDataBound="grdSysPowergroups_ItemDataBound">
    <ItemTemplate>
        <tr>
            <td width="15%">
                <input type="checkbox" id="chooseItem<%# Eval("module_id") %>" data-id="<%# Eval("module_id") %>" data-parent-id="<%# Eval("parentmodule_id") %>" onchange="chooseItem(this)" />
                <label for="chooseItem<%# Eval("module_id") %>"><%# Eval("module_name") %></label>
                <asp:HiddenField ID="hfmodule_id" runat="server" Value='<%# Eval("module_id") %>' />
                <asp:HiddenField ID="hfmodule_value" runat="server" Value='<%# Eval("module_value") %>' />
            </td>
            <td align="left" class="chklb">
                <asp:CheckBoxList ID="chkPower" runat="server" RepeatLayout="Flow" RepeatDirection="Horizontal">
                </asp:CheckBoxList>
            </td>
        </tr>
    </ItemTemplate>
    <FooterTemplate>
        <%#grdSysPowergroups.Items.Count == 0 ? "<tr><td align=\"center\" colspan=\"2\">暂无记录</td></tr>" : ""%></FooterTemplate>
</asp:Repeater>

<script type="text/javascript">
    function chooseAll(obj) {
        $("input[type='checkbox']").prop("checked", $(obj).prop("checked"));
    }
    function chooseItem(obj) {
        $("input[type='checkbox'][data-parent-id='" + $(obj).attr("data-id") + "']").prop("checked", $(obj).prop("checked"));
        $(obj).parent().next().find("input[type='checkbox']").prop("checked", $(obj).prop("checked"));
        $("input[type='checkbox'][data-parent-id='" + $(obj).attr("data-id") + "']").each(function () {
            chooseItem(this);
        })
    }
</script>