<%@ Page Language="C#" MasterPageFile="~/PageEdit.Master" AutoEventWireup="true" CodeFile="VisitRecordDetail.aspx.cs" Inherits="YouHoo.Web.VISIT.VisitRecordDetail" Title="无标题页" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
	<asp:HiddenField ID="hf_id" runat="server" />
	<table cellpadding="0" cellspacing="0" class="table table-bordered table-hover m10">
		<tr>
			<td align="right" class="tableleft">
				客户名称：
			</td>
			<td align="left">
				<asp:Label ID="lbl_cCusName" runat="server"></asp:Label>
			</td>
		</tr>
		<tr>
			<td align="right" class="tableleft">
				客户简称：
			</td>
			<td align="left">
				<asp:Label ID="lbl_cCusAbbName" runat="server"></asp:Label>
			</td>
		</tr>
		<tr>
			<td align="right" class="tableleft">
				客户编码：
			</td>
			<td align="left">
				<asp:Label ID="lbl_cCusCode" runat="server"></asp:Label>
			</td>
		</tr>
		<tr>
			<td align="right" class="tableleft">
				电话：
			</td>
			<td align="left">
				<asp:Label ID="lbl_phoneNumber" runat="server"></asp:Label>
			</td>
		</tr>
		<tr>
			<td align="right" class="tableleft">
				联系人：
			</td>
			<td align="left">
				<asp:Label ID="lbl_cCusPerson" runat="server"></asp:Label>
			</td>
		</tr>
		<tr>
			<td align="right" class="tableleft">
				拜访日期：
			</td>
			<td align="left">
				<asp:Label ID="lbl_visit_date" runat="server"></asp:Label>
			</td>
		</tr>
		<tr>
			<td align="right" class="tableleft">
				访谈地点：
			</td>
			<td align="left">
				<asp:Label ID="lbl_visit_location" runat="server"></asp:Label>
			</td>
		</tr>
		<tr>
			<td align="right" class="tableleft">
				访谈人：
			</td>
			<td align="left">
				<asp:Label ID="lbl_visit_person" runat="server"></asp:Label>
			</td>
		</tr>
		<tr>
			<td align="right" class="tableleft">
				访谈开始时间：
			</td>
			<td align="left">
				<asp:Label ID="lbl_visit_startTime" runat="server"></asp:Label>
			</td>
		</tr>
		<tr>
			<td align="right" class="tableleft">
				访谈结束时间：
			</td>
			<td align="left">
				<asp:Label ID="lbl_visit_endTime" runat="server"></asp:Label>
			</td>
		</tr>
		<tr>
			<td align="right" class="tableleft">
				访谈方式：
			</td>
			<td align="left">
				<asp:Label ID="lbl_visit_way_id" runat="server"></asp:Label>
			</td>
		</tr>
		<tr>
			<td align="right" class="tableleft">
				访谈内容：
			</td>
			<td align="left">
				<asp:Label ID="lbl_visit_content" runat="server"></asp:Label>
			</td>
		</tr>
		<tr>
			<td align="right" class="tableleft">
				后续安排：
			</td>
			<td align="left">
				<asp:Label ID="lbl_visit_NextPlan" runat="server"></asp:Label>
			</td>
		</tr>
		<tr>
			<td align="right" class="tableleft">
				主管建议：
			</td>
			<td align="left">
				<asp:Label ID="lbl_visit_ManagerOpinion" runat="server"></asp:Label>
			</td>
		</tr>
		<tr>
			<td align="right" class="tableleft">
				是否审核
			</td>
			<td align="left">
				<asp:Label ID="lbl_verifi_state" runat="server"></asp:Label>
			</td>
		</tr>
		<tr>
			<td align="right" class="tableleft">
				备注：
			</td>
			<td align="left">
				<asp:Label ID="lbl_remark" runat="server"></asp:Label>
			</td>
		</tr>
	</table>
	<div class="buttonParent">
		<div class="buttonShade">
			<asp:Button CssClass="Inputbtn" ID="btn_update" runat="server" Text="修改" OnClick="btn_update_Click" />
			<input type="button" class="Inputbtn" value="关闭" onclick="top.Dialog.close()" />
		</div>
	</div>
</asp:Content>
