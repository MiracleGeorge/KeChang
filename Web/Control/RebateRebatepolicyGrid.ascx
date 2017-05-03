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
			�������߱���
		</th>
		<th align="center">
			������������
		</th>
		<th align="center">
			Ʒ��
		</th>
		<th align="center">
			����
		</th>
		<th align="center">
			Ʒ��
		</th>
		<th align="center">
			�۸�
		</th>
		<th align="center">
			����
		</th>
		<th align="center">
			Ʒ��
		</th>
		<th align="center">
			֧�ַ�ʽ
		</th>
		<th align="center">
			֧�ּ۸�
		</th>
		<th align="center">
			������ʽ
		</th>
		<th align="center">
			ʱ��
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
					<asp:HiddenField ID="hf_id" runat="server" Value='<%# Eval("id") %>' />
				</td>
				<td align="center">
					<label class="lbl_ajaxUpdate"><%# Eval("Code")%></label>
					<input type="text" class="validate[required,maxSize[50]] txt_ajaxUpdate" field="Code" value="<%# Eval("Code")%>" />
				</td>
				<td align="center">
					<label class="lbl_ajaxUpdate"><%# Eval("Name")%></label>
					<input type="text" class="validate[required,maxSize[50]] txt_ajaxUpdate" field="Name" value="<%# Eval("Name")%>" />
				</td>
				<td align="center">
					<label class="lbl_ajaxUpdate"><%# Eval("brand_id")%></label>
					<input type="text" class="validate[required,custom[onlyNumber]] txt_ajaxUpdate" field="BrandId" value="<%# Eval("brand_id")%>" />
				</td>
				<td align="center">
					<label class="lbl_ajaxUpdate"><%# Eval("channel_id")%></label>
					<input type="text" class="validate[custom[onlyNumber]] txt_ajaxUpdate" field="ChannelId" value="<%# Eval("channel_id")%>" />
				</td>
				<td align="center">
					<label class="lbl_ajaxUpdate"><%# Eval("item_id")%></label>
					<input type="text" class="validate[custom[onlyNumber]] txt_ajaxUpdate" field="ItemId" value="<%# Eval("item_id")%>" />
				</td>
				<td align="center">
					<label class="lbl_ajaxUpdate"><%# Eval("price_id")%></label>
					<input type="text" class="validate[custom[onlyNumber]] txt_ajaxUpdate" field="PriceId" value="<%# Eval("price_id")%>" />
				</td>
				<td align="center">
					<label class="lbl_ajaxUpdate"><%# Eval("region_id")%></label>
					<input type="text" class="validate[custom[onlyNumber]] txt_ajaxUpdate" field="RegionId" value="<%# Eval("region_id")%>" />
				</td>
				<td align="center">
					<label class="lbl_ajaxUpdate"><%# Eval("sort_id_id")%></label>
					<input type="text" class="validate[custom[onlyNumber]] txt_ajaxUpdate" field="SortIdId" value="<%# Eval("sort_id_id")%>" />
				</td>
				<td align="center">
					<label class="lbl_ajaxUpdate"><%# Eval("SupportWay_id")%></label>
					<input type="text" class="validate[custom[onlyNumber]] txt_ajaxUpdate" field="SupportwayId" value="<%# Eval("SupportWay_id")%>" />
				</td>
				<td align="center">
					<label class="lbl_ajaxUpdate"><%# Eval("SupportPrice_id")%></label>
					<input type="text" class="validate[custom[onlyNumber]] txt_ajaxUpdate" field="SupportpriceId" value="<%# Eval("SupportPrice_id")%>" />
				</td>
				<td align="center">
					<label class="lbl_ajaxUpdate"><%# Eval("RebateType_id")%></label>
					<input type="text" class="validate[custom[onlyNumber]] txt_ajaxUpdate" field="RebatetypeId" value="<%# Eval("RebateType_id")%>" />
				</td>
				<td align="center">
					<label class="lbl_ajaxUpdate"><%# Eval("time_id")%></label>
					<input type="text" class="validate[custom[onlyNumber]] txt_ajaxUpdate" field="TimeId" value="<%# Eval("time_id")%>" />
				</td>
				<td align="center" class="operate">
					<a href="javascript:dialogDetail('/REBATE/RebateRebatepolicyDetail.aspx?PageIndex=<%#PageIndex %>&ReturnUrl=<%=DataRequest.UrlEncode(Request.RawUrl) %>&id=<%# Eval("id") %>')">�鿴</a>
					<asp:LinkButton ID="lnk_update" Text="�޸�" Visible='<%#UpdatePower %>' OnClientClick='<%# "return dialogUpdateSingle(&#39;/REBATE/RebateRebatepolicyEdit.aspx?PageIndex="+PageIndex+"&ReturnUrl="+DataRequest.UrlEncode(Request.RawUrl)+"&id="+Eval("id")+"&#39;)" %>'
						runat="server"></asp:LinkButton>
					<asp:LinkButton ID="lnk_delete" Text="ɾ��" Visible='<%#DeletePower %>' CommandName="delete"
						CommandArgument='<%# Eval("id") %>' OnClientClick="return popDeleteSingle(this);"
						runat="server"></asp:LinkButton>
				</td>
			</tr>
		</ItemTemplate>
		<FooterTemplate>
			<%# rp_data.Items.Count == 0 ? "<script type='text/javascript'>document.write('<tr><td align=\"center\" colspan=\"'+$(\"#item_list tr th\").length+'\">���޼�¼</td></tr>');</script>" : "" %>
		</FooterTemplate>
	</asp:Repeater>
</table>