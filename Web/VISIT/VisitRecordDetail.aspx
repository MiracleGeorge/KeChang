<%@ Page Language="C#" MasterPageFile="~/PageEdit.Master" AutoEventWireup="true" CodeFile="VisitRecordDetail.aspx.cs" Inherits="YouHoo.Web.VISIT.VisitRecordDetail" Title="�ޱ���ҳ" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
	<asp:HiddenField ID="hf_id" runat="server" />
	<table cellpadding="0" cellspacing="0" class="table table-bordered table-hover m10">
		<tr>
			<td align="right" class="tableleft">
				�ͻ����ƣ�
			</td>
			<td align="left">
				<asp:Label ID="lbl_cCusName" runat="server"></asp:Label>
			</td>
		</tr>
		<tr>
			<td align="right" class="tableleft">
				�ͻ���ƣ�
			</td>
			<td align="left">
				<asp:Label ID="lbl_cCusAbbName" runat="server"></asp:Label>
			</td>
		</tr>
		<tr>
			<td align="right" class="tableleft">
				�ͻ����룺
			</td>
			<td align="left">
				<asp:Label ID="lbl_cCusCode" runat="server"></asp:Label>
			</td>
		</tr>
		<tr>
			<td align="right" class="tableleft">
				�绰��
			</td>
			<td align="left">
				<asp:Label ID="lbl_phoneNumber" runat="server"></asp:Label>
			</td>
		</tr>
		<tr>
			<td align="right" class="tableleft">
				��ϵ�ˣ�
			</td>
			<td align="left">
				<asp:Label ID="lbl_cCusPerson" runat="server"></asp:Label>
			</td>
		</tr>
		<tr>
			<td align="right" class="tableleft">
				�ݷ����ڣ�
			</td>
			<td align="left">
				<asp:Label ID="lbl_visit_date" runat="server"></asp:Label>
			</td>
		</tr>
		<tr>
			<td align="right" class="tableleft">
				��̸�ص㣺
			</td>
			<td align="left">
				<asp:Label ID="lbl_visit_location" runat="server"></asp:Label>
			</td>
		</tr>
		<tr>
			<td align="right" class="tableleft">
				��̸�ˣ�
			</td>
			<td align="left">
				<asp:Label ID="lbl_visit_person" runat="server"></asp:Label>
			</td>
		</tr>
		<tr>
			<td align="right" class="tableleft">
				��̸��ʼʱ�䣺
			</td>
			<td align="left">
				<asp:Label ID="lbl_visit_startTime" runat="server"></asp:Label>
			</td>
		</tr>
		<tr>
			<td align="right" class="tableleft">
				��̸����ʱ�䣺
			</td>
			<td align="left">
				<asp:Label ID="lbl_visit_endTime" runat="server"></asp:Label>
			</td>
		</tr>
		<tr>
			<td align="right" class="tableleft">
				��̸��ʽ��
			</td>
			<td align="left">
				<asp:Label ID="lbl_visit_way_id" runat="server"></asp:Label>
			</td>
		</tr>
		<tr>
			<td align="right" class="tableleft">
				��̸���ݣ�
			</td>
			<td align="left">
				<asp:Label ID="lbl_visit_content" runat="server"></asp:Label>
			</td>
		</tr>
		<tr>
			<td align="right" class="tableleft">
				�������ţ�
			</td>
			<td align="left">
				<asp:Label ID="lbl_visit_NextPlan" runat="server"></asp:Label>
			</td>
		</tr>
		<tr>
			<td align="right" class="tableleft">
				���ܽ��飺
			</td>
			<td align="left">
				<asp:Label ID="lbl_visit_ManagerOpinion" runat="server"></asp:Label>
			</td>
		</tr>
		<tr>
			<td align="right" class="tableleft">
				�Ƿ����
			</td>
			<td align="left">
				<asp:Label ID="lbl_verifi_state" runat="server"></asp:Label>
			</td>
		</tr>
		<tr>
			<td align="right" class="tableleft">
				��ע��
			</td>
			<td align="left">
				<asp:Label ID="lbl_remark" runat="server"></asp:Label>
			</td>
		</tr>
	</table>
	<div class="buttonParent">
		<div class="buttonShade">
			<asp:Button CssClass="Inputbtn" ID="btn_update" runat="server" Text="�޸�" OnClick="btn_update_Click" />
			<input type="button" class="Inputbtn" value="�ر�" onclick="top.Dialog.close()" />
		</div>
	</div>
</asp:Content>
