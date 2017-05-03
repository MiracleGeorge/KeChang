<%@ Page Language="C#" MasterPageFile="~/PageEdit.Master" AutoEventWireup="true" CodeFile="SysPowerEdit.aspx.cs" Inherits="YouHoo.Web.SYS.SysPowerEdit" Title="无标题页" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script type="text/javascript">
        $(function() {
            powerChange();
        })
        
        function powerChange() {
            $("#<%=txt_power_value.ClientID %>").val($("#<%=ddl_module_id.ClientID %> > option:selected").text().split("_")[1] + $("#<%=ddl_action_id.ClientID %> > option:selected").text().split("_")[1]);
            $("#<%=hf_power_value.ClientID %>").val($("#<%=ddl_module_id.ClientID %> > option:selected").text().split("_")[1] + $("#<%=ddl_action_id.ClientID %> > option:selected").text().split("_")[1]);
        }
    </script>
	<asp:HiddenField ID="hf_id" runat="server" />
	<table cellpadding="0" cellspacing="0" class="table table-bordered table-hover m10">
		<tr>
			<td align="right" class="tableleft">
				模块：
			</td>
			<td align="left">
				<asp:DropDownList ID="ddl_module_id" CssClass="validate[required]" runat="server" onchange="powerChange()"></asp:DropDownList>
			</td>
		</tr>
		<tr>
			<td align="right" class="tableleft">
				动作：
			</td>
			<td align="left">
				<asp:DropDownList ID="ddl_action_id" CssClass="validate[required]" runat="server" onchange="powerChange()"></asp:DropDownList>
			</td>
		</tr>
		<tr>
			<td align="right" class="tableleft">
				标识编号：
	        </td>
			<td align="left">
				<asp:TextBox ID="txt_power_value" CssClass="validate[maxSize[50]]" Enabled="false" runat="server"></asp:TextBox>
				<asp:HiddenField ID="hf_power_value" runat="server" />
			</td>
		</tr>
		<tr>
			<td align="right" class="tableleft">
				备注：
			</td>
			<td align="left">
				<asp:TextBox ID="txt_remark" TextMode="MultiLine" Width="90%" Height="150" runat="server"></asp:TextBox>
			</td>
		</tr>
		<tr>
			<td align="right" class="tableleft">
			</td>
			<td align="left">
				<asp:Button CssClass="Inputbtn" ID="btn_save" runat="server" Text="保存" OnClick="btn_save_Click" OnClientClick="SaveLoading()" />
				<input type="button" class="Inputbtn" value="关闭" onclick="top.Dialog.close()" />
			</td>
		</tr>
	</table>
</asp:Content>
