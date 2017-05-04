<%@ Control Language="C#" AutoEventWireup="true" CodeFile="RebateRebatepolicyGrid.ascx.cs" Inherits="YouHoo.Web.Control.REBATE.RebateRebatepolicyGrid" %>
<%@ Import Namespace="YouHoo.DataTools" %>

<input type="hidden" id="bllName" value="YouhooRebateRebatepolicyBLL" />
<table id="item_list" class="table table-bordered table-hover definewidth m10" 
	cellpadding="3" cellspacing="0">
	<tr>
		<th style="width: 30px" align="center">
			<input type="checkbox" id="chkChooseAll" />
		</th>
		<th align="center">
			返利政策编码
		</th>
		<th align="center">
			返利政策名称
		</th>
		<%--<th align="center">
			品牌
		</th>--%>
		<th align="center">
			渠道
		</th>
		<%--<th align="center">
			品项
		</th>--%>
		<th align="center">
			价格
		</th>
		<th align="center">
			大区
         </th>
        <th align="center">
			市区
		</th>
		<th align="center">
			品类
		</th>
		<th align="center">
			支持方式
		</th>
		<th align="center">
			支持价格
		</th>
		<th align="center">
			返利方式
		</th>
		<th align="center">
			时段
		</th>
		<th align="center">
			操作
		</th>
	</tr>
	<asp:Repeater ID="rp_data" runat="server" OnItemCommand="rp_data_ItemCommand">
		<ItemTemplate>
			<tr>
				<td align="center">
					<asp:CheckBox ID="chkChoose" runat="server" />
					<asp:HiddenField ID="hf_id" runat="server" Value='<%# Eval("id") %>' />
				</td>
				<td align="center">
					<label ><%# Eval("Code")%></label>
					<%--<input type="text" class="validate[required,maxSize[50]] txt_ajaxUpdate" field="Code" value="<%# Eval("Code")%>" />--%>

                  
				</td>
				<td align="center">
<%--					<label class="lbl_ajaxUpdate"><%# Eval("Name")%></label>
					<input type="text" class="validate[required,maxSize[50]] txt_ajaxUpdate" field="Name" value="<%# Eval("Name")%>" />--%>
                    <label><%# Eval("Name")%></label>
				</td>
				<%--<td align="center">
					<label class="lbl_ajaxUpdate"><%# Eval("BrandName")%></label>
					<input type="text" class="validate[required,custom[onlyNumber]] txt_ajaxUpdate" field="BrandId" value="<%# Eval("brand_id")%>" />
					<label><%# Eval("BrandName")%></label>
				</td>--%>
				<td align="center">
					<%--<label class="lbl_ajaxUpdate"><%# Eval("ChannelName")%></label>
					<input type="text" class="validate[custom[onlyNumber]] txt_ajaxUpdate" field="ChannelId" value="<%# Eval("channel_id")%>" />--%>
                    <label><%# Eval("ChannelName")%></label>
				</td>
				<%--<td align="center">
					<label class="lbl_ajaxUpdate"><%# Eval("ItemName")%></label>
					<input type="text" class="validate[custom[onlyNumber]] txt_ajaxUpdate" field="ItemId" value="<%# Eval("item_id")%>" />
				</td>--%>
				<td align="center">
					<%--<label class="lbl_ajaxUpdate"><%# Eval("PriceName")%></label>
					<input type="text" class="validate[custom[onlyNumber]] txt_ajaxUpdate" field="PriceId" value="<%# Eval("price_id")%>" />--%>
                    <label><%# Eval("price")%></label>
				</td>
				<td align="center">
					<%--<label class="lbl_ajaxUpdate"><%# Eval("RegionName")%></label>
					<input type="text" class="validate[custom[onlyNumber]] txt_ajaxUpdate" field="RegionId" value="<%# Eval("region_id")%>" />--%>
                    <label><%# Eval("RegionName")%></label>
				</td>
                <td align="center">
					<%--<label class="lbl_ajaxUpdate"><%# Eval("RegionName")%></label>
					<input type="text" class="validate[custom[onlyNumber]] txt_ajaxUpdate" field="RegionId" value="<%# Eval("region_id")%>" />--%>
                    <label><%# Eval("RegionName")%></label>
				</td>
				<td align="center">
			<%--		<label class="lbl_ajaxUpdate"><%# Eval("SortName")%></label>
					<input type="text" class="validate[custom[onlyNumber]] txt_ajaxUpdate" field="SortIdId" value="<%# Eval("sort_id_id")%>" />--%>
                    <label><%# Eval("SortName")%></label>
				</td>
				<td align="center">
					<%--<label class="lbl_ajaxUpdate"><%# Eval("RebateWayName")%></label>
					<input type="text" class="validate[custom[onlyNumber]] txt_ajaxUpdate" field="RebatetypeId" value="<%# Eval("RebateType_id")%>" />--%>
                    <label><%# Eval("RebateWayName")%></label>
				</td>
				<td align="center" class="operate">
					<a href="javascript:dialogDetail('/REBATE/RebateRebatepolicyDetail.aspx?PageIndex=<%#PageIndex %>&ReturnUrl=<%=DataRequest.UrlEncode(Request.RawUrl) %>&id=<%# Eval("id") %>')">查看</a>
					<asp:LinkButton ID="lnk_update" Text="修改" Visible='<%#UpdatePower %>' OnClientClick='<%# "return dialogUpdateSingle(&#39;/REBATE/RebateRebatepolicyEdit.aspx?PageIndex="+PageIndex+"&ReturnUrl="+DataRequest.UrlEncode(Request.RawUrl)+"&id="+Eval("id")+"&#39;)" %>'
						runat="server"></asp:LinkButton>
					<asp:LinkButton ID="lnk_delete" Text="删除" Visible='<%#DeletePower %>' CommandName="delete"
						CommandArgument='<%# Eval("id") %>' OnClientClick="return popDeleteSingle(this);"
						runat="server"></asp:LinkButton>
				</td>
			</tr>
		</ItemTemplate>
		<FooterTemplate>
			<%# rp_data.Items.Count == 0 ? "<script type='text/javascript'>document.write('<tr><td align=\"center\" colspan=\"'+$(\"#item_list tr th\").length+'\">暂无记录</td></tr>');</script>" : "" %>
		</FooterTemplate>
	</asp:Repeater>
</table>
