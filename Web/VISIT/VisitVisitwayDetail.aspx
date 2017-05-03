<%@ Page Language="C#" MasterPageFile="~/PageEdit.Master" AutoEventWireup="true" CodeFile="VisitVisitwayDetail.aspx.cs" Inherits="YouHoo.Web.VISIT.VisitVisitwayDetail" Title="无标题页" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
	<asp:HiddenField ID="hf_id" runat="server" />
	<table cellpadding="0" cellspacing="0" class="table table-bordered table-hover m10">
		<tr>
			<td align="right" class="tableleft">
				visit_way_id：
			</td>
			<td align="left">
				<asp:Label ID="lbl_visit_way_id" runat="server"></asp:Label>
			</td>
		</tr>
		<tr>
			<td align="right" class="tableleft">
				visit_name：
			</td>
			<td align="left">
				<asp:Label ID="lbl_visit_name" runat="server"></asp:Label>
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
