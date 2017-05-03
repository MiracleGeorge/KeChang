<%@ Control Language="C#" AutoEventWireup="true" CodeFile="VisitRecordGridEx.ascx.cs" Inherits="YouHoo.Web.Control.VISIT.VisitRecordGrid" %>
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
        <th align="center">联系人
        </th>
        <th align="center">拜访日期
        </th>
        <th align="center">访谈地点
        </th>
        <th align="center">访谈人
        </th>
        <th align="center">访谈开始时间
        </th>
        <th align="center">访谈结束时间
        </th>
        <th align="center">访谈方式
        </th>
        <th align="center">主管建议
        </th>
        <th align="center">是否审核
        </th>
        <th align="center">制单人
        </th>
        <th align="center">操作
        </th>


    </tr>
    <asp:Repeater ID="rp_data" runat="server" OnItemCommand="rp_data_ItemCommand">
        <ItemTemplate>
            <tr>
                <td align="center">
                    <asp:CheckBox ID="chkChoose" runat="server" />
                    <asp:HiddenField ID="hf_id" runat="server" Value='<%# Eval("visit_id") %>' />
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
                <td align="center">
                    <label><%# Eval("cCusPerson")%></label>
                    <%--<input type="text" class="validate[required,maxSize[50]] txt_ajaxUpdate" field="Ccusperson" value="<%# Eval("cCusPerson")%>" />--%>
                    <label class="validate[required,maxSize[50]] txt_ajaxUpdate"><%# Eval("cCusPerson")%></label>

                </td>
                <td align="center">
                    <label><%# Convert.ToDateTime(Eval("visit_date")).ToShortDateString()%></label>
                    <label class="validate[required,maxSize[100]] txt_ajaxUpdate"><%# Eval("visit_date")%></label>
                </td>
                <td align="center">
                    <label><%# Eval("visit_location")%></label>
                    <%--<input type="text" class="validate[required,maxSize[100]] txt_ajaxUpdate" field="VisitLocation" value="<%# Eval("visit_location")%>" />--%>
                    <label class="validate[required,maxSize[100]] txt_ajaxUpdate"><%# Eval("visit_location")%></label>

                </td>
                <td align="center">
                    <label><%# Eval("visit_person")%></label>
                    <%--<input type="text" class="validate[required,maxSize[50]] txt_ajaxUpdate" field="VisitPerson" value="<%# Eval("visit_person")%>" />--%>
                    <label class="validate[required,maxSize[50]] txt_ajaxUpdate"><%# Eval("visit_person")%></label>

                </td>
                <td align="center">
                    <label><%# Eval("visit_startTime")%></label>
                    <%--<input type="text" class="validate[required,custom[date]] txt_ajaxUpdate Wdate input_100" onfocus="WdatePicker()" field="VisitStarttime" value="<%# Eval("visit_startTime")%>" />--%>
                    <label class="validate[required,custom[date]] txt_ajaxUpdate Wdate input_100"><%# Eval("visit_startTime")%></label>

                </td>
                <td align="center">
                    <label><%# Eval("visit_endTime")%></label>
                    <%--<input type="text" class="validate[required,custom[date]] txt_ajaxUpdate Wdate input_100" onfocus="WdatePicker()" field="VisitEndtime" value="<%# Eval("visit_endTime")%>" />--%>
                    <label class="validate[required,custom[date]] txt_ajaxUpdate Wdate input_100"><%# Eval("visit_endTime")%></label>

                </td>
                <td align="center">
                    <label><%# Eval("visit_name")%></label>
                    <%--<input type="text" class="validate[required,custom[onlyNumber]] txt_ajaxUpdate" field="VisitWayId" value="<%# Eval("visit_way_id")%>" />--%>
                    <label class="validate[required,custom[onlyNumber]] txt_ajaxUpdate"><%# Eval("visit_name")%></label>
                </td>
                <%--        <td align="center">
                    <label class="lbl_ajaxUpdate"><%# Eval("visit_content")%></label>
                    <input type="text" class="validate[maxSize[400]] txt_ajaxUpdate" field="VisitContent" value="<%# Eval("visit_content")%>" />
                    <label class="validate[maxSize[400]] txt_ajaxUpdate"><%# Eval("visit_content")%></label>

                </td>
                <td align="center">
                    <label class="lbl_ajaxUpdate"><%# Eval("visit_NextPlan")%></label>
                    <input type="text" class="validate[maxSize[300]] txt_ajaxUpdate" field="VisitNextplan" value="<%# Eval("visit_NextPlan")%>" />
                    <label class="validate[maxSize[300]] txt_ajaxUpdate"><%# Eval("visit_NextPlan")%></label>

                </td>--%>
                <td align="center">
                    <label><%# Eval("visit_ManagerOpinion")%></label>
                    <label class="validate[maxSize[10]] txt_ajaxUpdate"><%# Eval("visit_ManagerOpinion")%></label>
                </td>
                <td align="center">
                    <label><%# Eval("verifi_state").ToString()=="0"?"否":"是"%></label>
                    <label class="validate[required,custom[onlyNumber]] txt_ajaxUpdate"><%# Eval("verifi_state")%></label>
                </td>
                <td align="center">
                    <label><%# Eval("createoperator")%></label>
                    <label class="validate[required,custom[onlyNumber]] txt_ajaxUpdate"><%# Eval("createoperator")%></label>
                </td>

                <td align="center" class="operate">
                    <a href="javascript:dialogDetail('/VISIT/VisitRecordDetail.aspx?PageIndex=<%#PageIndex %>&ReturnUrl=<%=DataRequest.UrlEncode(Request.RawUrl) %>&visit_id=<%# Eval("visit_id") %>')">查看</a>
                    <asp:LinkButton ID="lnk_update" Text="修改" Visible='<%#UpdatePower %>' OnClientClick='<%# "return dialogUpdateSingle(&#39;/VISIT/VisitRecordEdit.aspx?PageIndex="+PageIndex+"&ReturnUrl="+DataRequest.UrlEncode(Request.RawUrl)+"&visit_id="+Eval("visit_id")+"&#39;)" %>'
                        runat="server"></asp:LinkButton>
                    <asp:LinkButton ID="lnk_delete" Text="删除" Visible='<%#DeletePower %>' CommandName="delete"
                        CommandArgument='<%# Eval("visit_id") %>' OnClientClick="return popDeleteSingle(this);"
                        runat="server"></asp:LinkButton>
                </td>
            </tr>
        </ItemTemplate>
        <FooterTemplate>
            <%# rp_data.Items.Count == 0 ? "<script type='text/javascript'>document.write('<tr><td align=\"center\" colspan=\"'+$(\"#item_list tr th\").length+'\">暂无记录</td></tr>');</script>" : "" %>
        </FooterTemplate>
    </asp:Repeater>
</table>
