<%@ Control Language="C#" AutoEventWireup="true" CodeFile="SysUsersGrid.ascx.cs" Inherits="YouHoo.Web.Control.SYS.SysUsersGrid" %>
<%@ Import Namespace="YouHoo.DataTools" %>

<input type="hidden" id="bllName" value="YouhooSysUsersBLL" />
<table id="item_list" class="table table-bordered table-hover definewidth m10"
    cellpadding="3" cellspacing="0">
    <tr>
        <th style="width: 30px" align="center">
            <input id="chkChooseAll" type="checkbox" onclick="chooseAll('item_list', 'chkChooseAll')" />
        </th>
        <th align="center">用户编号
        </th>
        <th align="center">用户名
        </th>

        <th align="center" style="width:120px;">所属公司(实验室)
        </th>
        <th align="center">所属部门
        </th>
        <th align="center">移动电话
        </th>
        <th align="center" style="width:80px;">角色
        </th>
        <th align="center">是否业务员
        </th>
        <th align="center" width="60">状态
        </th>
        <th align="center" width="200">操作
        </th>
    </tr>
    <asp:Repeater ID="rp_data" runat="server" OnItemCommand="rp_data_ItemCommand">
        <ItemTemplate>
            <tr>
                <td align="center">
                    <asp:CheckBox ID="chkChoose" Enabled='<%# Eval("user_id").ToString() != "1" %>' runat="server" />
                    <asp:HiddenField ID="hf_id" runat="server" Value='<%# Eval("user_id") %>' />
                </td>
                <td align="center">
                    <%# Eval("usercode")%>
                </td>
                <td align="center">
                    <%# Eval("username")%>
                </td>

                <td align="center">
                    <%# Eval("substorename")%>
                </td>
                <td align="center">
                    <%# Eval("subdepname")%>
                </td>
                <td align="center">
                    <label class="lbl_ajaxUpdate"><%# Eval("phone")%></label>
                    <input type="text" class="validate[maxSize[50]] txt_ajaxUpdate" field="Phone" value="<%# Eval("phone")%>" />
                </td>
                <td align="center">
                    <%# Eval("powergroup_name")%>
                </td>
                <td align="center">
                    <%# Eval("IsSaleMan").ToString() == "False" ? "否" : "<span style='color:red;'>是</span>" %>
                </td>
                <td align="center">
                    <%# Eval("status").ToString() == "0" ? "正常" : "<span style='color:red;'>冻结</span>" %>
                </td>
                <td align="center" class="operate">
                    <a href="javascript:dialogDetail('/SYS/SysUsersDetail.aspx?PageIndex=<%#PageIndex %>&ReturnUrl=<%=DataRequest.UrlEncode(Request.RawUrl) %>&user_id=<%# Eval("user_id") %>')">查看</a>
                    <asp:LinkButton ID="lnk_update" Text="修改" Visible='<%#UpdatePower %>' OnClientClick='<%# "return dialogUpdateSingle(&#39;/SYS/SysUsersEdit.aspx?PageIndex="+PageIndex+"&ReturnUrl="+DataRequest.UrlEncode(Request.RawUrl)+"&user_id="+Eval("user_id")+"&#39;)" %>'
                        runat="server"></asp:LinkButton>
                    <asp:LinkButton ID="lnk_delete" Text="删除" Visible='<%#DeletePower && Eval("user_id").ToString() != "1" %>' CommandName="delete"
                        CommandArgument='<%# Eval("user_id") %>' OnClientClick="return popDeleteSingle(this);"
                        runat="server"></asp:LinkButton>
                    <asp:LinkButton ID="lnk_pwdReset" Text="密码重置" Visible='<%#PwdResetPower %>' CommandName="pwdReset"
                        CommandArgument='<%# Eval("user_id") %>' OnClientClick="return popPwdResetSingle(this);"
                        runat="server"></asp:LinkButton>
                    <asp:LinkButton ID="lnk_freeze" Text="冻结" Visible='<%#FreezePower && Eval("status").ToString()=="0" %>' CommandName="freeze"
                        CommandArgument='<%# Eval("user_id") %>' OnClientClick="return popFreezeSingle(this);"
                        runat="server"></asp:LinkButton>
                    <asp:LinkButton ID="lnk_cancelFreeze" Text="取消冻结" Visible='<%#CancelFreeze && Eval("status").ToString()=="1" %>' CommandName="cancelFreeze"
                        CommandArgument='<%# Eval("user_id") %>' OnClientClick="return popCancelFreezeSingle(this);"
                        runat="server"></asp:LinkButton>
                </td>
            </tr>
        </ItemTemplate>
        <FooterTemplate>
            <%# rp_data.Items.Count == 0 ? "<script type='text/javascript'>document.write('<tr><td align=\"center\" colspan=\"'+$(\"#item_list tr th\").length+'\">暂无记录</td></tr>');</script>" : "" %>
        </FooterTemplate>
    </asp:Repeater>
</table>
