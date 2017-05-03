<%@ Control Language="C#" AutoEventWireup="true" CodeFile="VisitRecordGrid.ascx.cs" Inherits="YouHoo.Web.Control.VISIT.VisitRecordGrid" %>
<%@ Import Namespace="YouHoo.DataTools" %>

<input type="hidden" id="bllName" value="YouhooVisitRecordBLL" />
<table id="item_list" class="table table-bordered table-hover definewidth m10"
    cellpadding="3" cellspacing="0">
    <tr>
        <th style="width: 30px" align="center">
            <input type="checkbox" id="chkChooseAll" />
        </th>
        <th align="center">客户名称
        </th>
        <th align="center">客户简称
        </th>
        <th align="center">客户编码
        </th>
        <th align="center">电话
        </th>
        <th align="center">操作
        </th>


    </tr>
    <asp:Repeater ID="rp_data" runat="server" OnItemCommand="rp_data_ItemCommand">
        <ItemTemplate>
            <tr>
                <td align="center">
                    <asp:CheckBox ID="chkChoose" runat="server" />
<%--                    <asp:HiddenField ID="hf_id" runat="server" Value='<%# Eval("visit_id") %>' />--%>
                </td>
                <td align="center">
                    <label><%# Eval("cCusName")%></label>
                    <%--<input type="text" class="validate[required,maxSize[98]] txt_ajaxUpdate" field="Ccusname" value="<%# Eval("cCusName")%>" />--%>
                    <label class="validate[required,maxSize[98]] txt_ajaxUpdate"><%# Eval("cCusName")%></label>
                </td>
                <td align="center">
                    <label><%# Eval("cCusAbbName")%></label>
                    <%--<input type="text" class="validate[required,maxSize[60]] txt_ajaxUpdate" field="Ccusabbname" value="<%# Eval("cCusAbbName")%>" />--%>
                    <label class="validate[required,maxSize[60]] txt_ajaxUpdate" field="Ccusabbname"><%# Eval("cCusAbbName")%></label>


                </td>
                <td align="center">
                    <label><%# Eval("cCusCode")%></label>
                    <%--<input type="text" class="validate[required,maxSize[20]] txt_ajaxUpdate" field="Ccuscode" value="<%# Eval("cCusCode")%>" />--%>
                    <label class="validate[required,maxSize[20]] txt_ajaxUpdate"><%# Eval("cCusCode")%></label>
                </td>
                <td align="center">
                    <label><%# Eval("phoneNumber")%></label>
                    <%--<input type="text" class="validate[required,maxSize[100]] txt_ajaxUpdate" field="Phonenumber" value="<%# Eval("phoneNumber")%>" />--%>
                    <label class="validate[required,maxSize[100]] txt_ajaxUpdate" field="Phonenumber"><%# Eval("phoneNumber")%></label>

                </td>
               <%-- <td align="center">
                    <label><%# Eval("cCusPerson")%></label>
                    <label class="validate[required,maxSize[50]] txt_ajaxUpdate"><%# Eval("cCusPerson")%></label>
                </td>  --%> 

                <td align="center" class="operate">
                    <%--<a href="javascript:dialogDetail('/VISIT/VisitRecordDetail.aspx?PageIndex=<%#PageIndex %>&ReturnUrl=<%=DataRequest.UrlEncode(Request.RawUrl) %>&visit_id=<%# Eval("visit_id") %>')">查看详情</a>--%>
                     <a href="/VISIT/VisitRecordListEx.aspx?CustomerCode=<%# Eval("cCusCode")%>">查看详情</a>
<%--                    <asp:LinkButton ID="lnk_update" Text="修改" Visible='<%#UpdatePower %>' OnClientClick='<%# "return dialogUpdateSingle(&#39;/VISIT/VisitRecordEdit.aspx?PageIndex="+PageIndex+"&ReturnUrl="+DataRequest.UrlEncode(Request.RawUrl)+"&visit_id="+Eval("visit_id")+"&#39;)" %>'
                        runat="server"></asp:LinkButton>
                    <asp:LinkButton ID="lnk_delete" Text="删除" Visible='<%#DeletePower %>' CommandName="delete"
                        CommandArgument='<%# Eval("visit_id") %>' OnClientClick="return popDeleteSingle(this);"
                        runat="server"></asp:LinkButton>--%>
                </td>
            </tr>
        </ItemTemplate>
        <FooterTemplate>
            <%# rp_data.Items.Count == 0 ? "<script type='text/javascript'>document.write('<tr><td align=\"center\" colspan=\"'+$(\"#item_list tr th\").length+'\">暂无记录</td></tr>');</script>" : "" %>
        </FooterTemplate>
    </asp:Repeater>
</table>
