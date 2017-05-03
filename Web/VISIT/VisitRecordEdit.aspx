<%@ Page Language="C#" MasterPageFile="~/PageEdit.Master" AutoEventWireup="true" CodeFile="VisitRecordEdit.aspx.cs" Inherits="YouHoo.Web.VISIT.VisitRecordEdit" Title="�ޱ���ҳ" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
	<asp:HiddenField ID="hf_id" runat="server" />
	<table cellpadding="0" cellspacing="0" class="table table-bordered table-hover m10">
		<tr>
			<td align="right" class="tableleft">
				�ͻ����ƣ�
			</td>
			<td align="left">
				<asp:DropDownList ID="ddl_cusName" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddl_cusName_SelectedIndexChanged">
                </asp:DropDownList>
			</td>
		</tr>
		<tr>
			<td align="right" class="tableleft">
				�ͻ���ƣ�
			</td>
			<td align="left">
				<asp:TextBox ID="txt_cCusAbbName" CssClass="validate[required,maxSize[60]]" runat="server"></asp:TextBox>
			</td>
		</tr>
		<tr>
			<td align="right" class="tableleft">
				�ͻ����룺
			</td>
			<td align="left">
				<asp:TextBox ID="txt_cCusCode" CssClass="validate[required,maxSize[20]]" runat="server"></asp:TextBox>
			</td>
		</tr>
		<tr>
			<td align="right" class="tableleft">
				�绰��
			</td>
			<td align="left">
				<asp:TextBox ID="txt_phoneNumber" CssClass="validate[required,maxSize[100]]" runat="server"></asp:TextBox>
			</td>
		</tr>
		<tr>
			<td align="right" class="tableleft">
				��ϵ�ˣ�
			</td>
			<td align="left">
				<asp:TextBox ID="txt_cCusPerson" CssClass="validate[required,maxSize[50]]" runat="server"></asp:TextBox>
			</td>
		</tr>
		<tr>
			<td align="right" class="tableleft">
				�ݷ����ڣ�
			</td>
			<td align="left">
				<asp:TextBox ID="txt_visit_date" CssClass="validate[required,custom[date]] Wdate input_100" onfocus="WdatePicker()" runat="server"></asp:TextBox>
			</td>
		</tr>
		<tr>
			<td align="right" class="tableleft">
				��̸�ص㣺
			</td>
			<td align="left">
				<asp:TextBox ID="txt_visit_location" CssClass="validate[required,maxSize[100]]" runat="server"></asp:TextBox>
			</td>
		</tr>
		<tr>
			<td align="right" class="tableleft">
				��̸�ˣ�
			</td>
			<td align="left">
				<asp:TextBox ID="txt_visit_person" CssClass="validate[required,maxSize[50]]" runat="server"></asp:TextBox>
			</td>
		</tr>
		<tr>
			<td align="right" class="tableleft">
				��̸��ʼʱ�䣺
			</td>
			<td align="left">
				<asp:TextBox ID="txt_visit_startTime" CssClass="Wdate" onfocus="WdatePicker({dateFmt:'yyyy-MM-dd HH:mm:ss'})" style="width:300px" runat="server"></asp:TextBox>
			</td>
		</tr>
		<tr>
			<td align="right" class="tableleft">
				��̸����ʱ�䣺
			</td>
			<td align="left">
				<asp:TextBox ID="txt_visit_endTime" CssClass="Wdate" onfocus="WdatePicker({dateFmt:'yyyy-MM-dd HH:mm:ss'})" style="width:300px" runat="server"></asp:TextBox>
			</td>
		</tr>
		<tr>
			<td align="right" class="tableleft" style="height: 36px">
				��̸��ʽ
			</td>
			<td align="left" style="height: 36px">
                <asp:DropDownList ID="ddl_visitWay" runat="server" CssClass="validate[required,custom[onlyNumber]] input_60">
                </asp:DropDownList>
			</td>
		</tr>
		<tr>
			<td align="right" class="tableleft">
				��������
			</td>
			<td align="left">
				<asp:TextBox ID="txt_visit_content"  Width="90%" Height="60"  runat="server" TextMode="MultiLine"></asp:TextBox>
			</td>
		</tr>
		<tr>
			<td align="right" class="tableleft">
				�������ţ�
			</td>
			<td align="left">
				<asp:TextBox ID="txt_visit_NextPlan" Width="90%" Height="60" runat="server" TextMode="MultiLine"></asp:TextBox>
			</td>
		</tr>
		<tr>
			<td align="right" class="tableleft">
				���ܽ��飺
			</td>
			<td align="left">
				<asp:TextBox ID="txt_visit_ManagerOpinion" Width="90%" Height="60" runat="server" TextMode="MultiLine"></asp:TextBox>
			</td>
		</tr>
		<tr>
			<td align="right" class="tableleft">
				��ע��
			</td>
			<td align="left">
				<asp:TextBox ID="txt_remark" TextMode="MultiLine" Width="90%" Height="60" runat="server"></asp:TextBox>
			</td>
		</tr>
	</table>
	<div class="buttonParent">
		<div class="buttonShade">
			<asp:Button CssClass="Inputbtn" ID="btn_save" runat="server" Text="����" OnClick="btn_save_Click" OnClientClick="SaveLoading()" />
			<input type="button" class="Inputbtn" value="�ر�" onclick="top.Dialog.close()" />
		</div>
	</div>
</asp:Content>
