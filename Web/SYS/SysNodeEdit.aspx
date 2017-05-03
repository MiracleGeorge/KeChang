<%@ Page Language="C#" EnableEventValidation="false" MasterPageFile="~/PageEdit.Master" AutoEventWireup="true" CodeFile="SysNodeEdit.aspx.cs" Inherits="YouHoo.Web.SYS.SysNodeEdit" Title="无标题页" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script type="text/javascript" src="/Js/cityLinkage/DataAction.js"></script>
	<asp:HiddenField ID="hf_id" runat="server" />
	<table cellpadding="0" cellspacing="0" class="table table-bordered table-hover m10">
		<tr>
			<td align="right" class="tableleft">
				流程节点名称：
			</td>
			<td align="left">
				<asp:TextBox ID="txt_NodeName" CssClass="validate[required,maxSize[50]]" runat="server"></asp:TextBox>
			</td>
		</tr>
		<tr>
			<td align="right" class="tableleft">
				所属流程：
			</td>
			<td align="left">
                <asp:DropDownList ID="ddl_ProcessId" runat="server"  CssClass="validate[required]"></asp:DropDownList>
			</td>
		</tr>
		<tr>
			<td align="right" class="tableleft">
				所属公司(实验室)：
			</td>
			<td align="left">
				<asp:DropDownList ID="ddl_Store" Width="139" Height="30" CssClass="validate[required]" onchange="stroPowerChange('Store','powergroup_id')" runat="server"></asp:DropDownList>
                <asp:HiddenField ID="hf_Store" Value="0" runat="server" />
			</td>
		</tr>
		<tr>
			<td align="right" class="tableleft">
				审核角色：
			</td>
			<td align="left">
				<asp:DropDownList ID="ddl_powergroup_id" runat="server" CssClass="validate[required]"></asp:DropDownList>
                <asp:HiddenField ID="hf_powergroup_id" Value="0" runat="server" />
			</td>
		</tr>
		<tr>
			<td align="right" class="tableleft">
				备注：
			</td>
			<td align="left">
				<asp:TextBox ID="txt_remark" TextMode="MultiLine" Width="90%" Height="60" runat="server"></asp:TextBox>
			</td>
		</tr>
	</table>
	<div class="buttonParent">
		<div class="buttonShade">
			<asp:Button CssClass="Inputbtn" ID="btn_save" runat="server" Text="保存" OnClick="btn_save_Click" OnClientClick="SaveLoading()" />
			<input type="button" class="Inputbtn" value="关闭" onclick="top.Dialog.close()" />
		</div>
	</div>
</asp:Content>
