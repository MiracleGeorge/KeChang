<%@ Control Language="C#" AutoEventWireup="true" CodeFile="SysDictionaryChildGrid.ascx.cs" Inherits="YouHoo.Web.Control.SYS.SysDictionaryChildGrid" %>
<%@ Import Namespace="YouHoo.DataTools" %>

<input type="hidden" id="bllName" value="YouhooSysDictionaryChildBLL" />
<table id="item_list" class="table table-bordered table-hover definewidth m10"
    cellpadding="3" cellspacing="0">
    <tr>
        <th style="width: 30px" align="center">
            <input id="chkChooseAll" type="checkbox" onclick="chooseAll('item_list', 'chkChooseAll')" />
        </th>
        <th align="center">
            选项名称
        </th>
        <th align="center">
            所属字典
        </th>
        <% if(ShowParentPower){ %>
        <th align="center">
            所属父级
        </th>
        <%} %>
        <th align="center" width="60">
            是否启用
        </th>
        <th align="center" width="60">
            排序
        </th>
        <th align="center" width="150">
            操作
        </th>
    </tr>
    <asp:Repeater ID="rp_data" runat="server" OnItemCommand="rp_data_ItemCommand">
        <ItemTemplate>
            <tr>
                <td align="center">
                    <asp:CheckBox ID="chkChoose" runat="server" />
                    <asp:HiddenField ID="hf_id" runat="server" Value='<%# Eval("dictionary_child_id") %>' />
                </td>
                <td align="center">
                    <label class="lbl_ajaxUpdate"><%# Eval("dictionary_child_name")%></label>
					<input type="text" class="validate[required,maxSize[500]] txt_ajaxUpdate" field="DictionaryChildName" value="<%# Eval("dictionary_child_name")%>" />
                </td>
                <td align="center">
                    <%# Eval("dictionary_name")%>
                </td>
                <% if(ShowParentPower){ %>
                <td align="center">
                    <%# Eval("parent_dictionary_child_name")%>
                </td>
                <%} %>
                <td align="center">
                    <img class="img_ajaxUpdate" field="IsStart" data-value="<%# Eval("is_start") %>" src='../Images/<%# Eval("is_start").ToString()=="1"?"active.gif":"no_active.gif" %>' alt="暂无图片" />
                </td>
                <td align="center">
                    <label class="lbl_ajaxUpdate"><%# Eval("sort")%></label>
                    <input type="text" class="validate[custom[onlyNumber]] txt_ajaxUpdate" field="Sort" value="<%# Eval("sort")%>" />
                </td>
                <td align="center" class="operate">
					<a href="javascript:dialogDetail('/SYS/SysDictionaryChildDetail.aspx?PageIndex=<%#PageIndex %>&ReturnUrl=<%=DataRequest.UrlEncode(Request.RawUrl) %>&dictionary_child_id=<%# Eval("dictionary_child_id") %>')">查看</a>
                    <asp:LinkButton ID="lnk_update" Text="修改" Visible='<%#UpdatePower %>' OnClientClick='<%# "return dialogUpdateSingle(&#39;/SYS/SysDictionaryChildEdit.aspx?PageIndex="+PageIndex+"&ReturnUrl="+DataRequest.UrlEncode(Request.RawUrl)+"&dictionary_id="+Eval("dictionary_id")+"&dictionary_child_id="+Eval("dictionary_child_id")+"&is_multilayer="+(DataRequest.QueryString("is_multilayer"))+"&#39;)" %>'
                        runat="server"></asp:LinkButton>
                    <asp:LinkButton ID="lnk_delete" Text="删除" Visible='<%#DeletePower %>' CommandName="delete"
                        CommandArgument='<%# Eval("dictionary_child_id") %>' OnClientClick="return popDeleteSingle(this);"
                        runat="server"></asp:LinkButton>
                    <asp:LinkButton ID="lnk_start" Text="启用" Visible='<%#StartPower && Eval("is_start").ToString()=="0" %>' CommandName="start"
                        CommandArgument='<%# Eval("dictionary_child_id") %>' OnClientClick="return popStartSingle(this);"
                        runat="server"></asp:LinkButton>
                    <asp:LinkButton ID="lnk_disabled" Text="不启用" Visible='<%#DisabledPower && Eval("is_start").ToString()=="1" %>' CommandName="disabled"
                        CommandArgument='<%# Eval("dictionary_child_id") %>' OnClientClick="return popDisabledSingle(this);"
                        runat="server"></asp:LinkButton>
                </td>
            </tr>
        </ItemTemplate>
        <FooterTemplate>
            <%# rp_data.Items.Count == 0 ? "<script type='text/javascript'>document.write('<tr><td align=\"center\" colspan=\"'+$(\"#item_list tr th\").length+'\">暂无记录</td></tr>');</script>" : "" %>
        </FooterTemplate>
    </asp:Repeater>
</table>
