<%@ Page Language="C#" MasterPageFile="~/PageEdit.Master" AutoEventWireup="true" CodeFile="RebateRebatepolicyDetail.aspx.cs" Inherits="YouHoo.Web.REBATE.RebateRebatepolicyDetail" Title="无标题页" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
	<asp:HiddenField ID="hf_id" runat="server" />
	<table cellpadding="0" cellspacing="0" class="table table-bordered table-hover m10">
		<tr>
			<td align="right" class="tableleft">
				返利政策编码：
			</td>
			<td align="left">
				<asp:Label ID="lbl_Code" runat="server"></asp:Label>
			</td>
		</tr>
		<tr>
			<td align="right" class="tableleft">
				返利政策名称：
			</td>
			<td align="left">
				<asp:Label ID="lbl_Name" runat="server"></asp:Label>
			</td>
		</tr>
		<%--<tr>
			<td align="right" class="tableleft">
				品牌：
			</td>
			<td align="left">
				<asp:Label ID="lbl_brand_id" runat="server"></asp:Label>
			</td>
		</tr>--%>
		<tr>
			<td align="right" class="tableleft">
				渠道：
			</td>
			<td align="left">
				<asp:Label ID="lbl_channel_id" runat="server"></asp:Label>
			</td>
		</tr>
		<%--<tr>
			<td align="right" class="tableleft">
				品项：
			</td>
			<td align="left">
				<asp:Label ID="lbl_item_id" runat="server"></asp:Label>
			</td>
		</tr>--%>
		<tr>
			<td align="right" class="tableleft">
				价格：
			</td>
			<td align="left">
				<asp:Label ID="lbl_price_id" runat="server"></asp:Label>
			</td>
		</tr>
		<tr>
			<td align="right" class="tableleft">
				地区：
			</td>
			<td align="left">
				<asp:Label ID="lbl_region_id" runat="server"></asp:Label>
			</td>
		</tr>
		<tr>
			<td align="right" class="tableleft">
				品类：
			</td>
			<td align="left">
				<asp:Label ID="lbl_sort_id_id" runat="server"></asp:Label>
			</td>
		</tr>
		<tr>
			<td align="right" class="tableleft">
				支持方式：
			</td>
			<td align="left">
				<asp:Label ID="lbl_SupportWay_id" runat="server"></asp:Label>
			</td>
		</tr>
		<tr>
			<td align="right" class="tableleft">
				支持价格：
			</td>
			<td align="left">
				<asp:Label ID="lbl_SupportPrice_id" runat="server"></asp:Label>
			</td>
		</tr>
		<tr>
			<td align="right" class="tableleft">
				返利方式：
			</td>
			<td align="left">
				<asp:Label ID="lbl_RebateType_id" runat="server"></asp:Label>
			</td>
		</tr>
		<tr>
			<td align="right" class="tableleft">
				时段：
			</td>
			<td align="left">
				<asp:Label ID="lbl_time_id" runat="server"></asp:Label>
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

      <link rel="stylesheet" type="text/css" href="/Images/Css/quotation.css" />
    <div class="menu_content" style="margin-top: 3px;">
        <div class="item">
            
            <table cellpadding="0" id="List_Order" cellspacing="0" class="table table-bordered table-hover">
                <tr>
                    <th align="center">品牌
                    </th>
                    <th align="center">品项
                    </th>
                    <th align="center">折扣
                    </th>
                </tr>
             <asp:Repeater ID="Reapter_PolicyDetails" runat="server">
                   <ItemTemplate>
                      <tr>
                      <th style="background-color:white">
                            <label><%# Eval("brandName")%></label>
                      </th>
                      <th style="background-color:white"">
                            <label><%# Eval("itemName")%> </label>
                       </th>
                       <th style="background-color:white"">
                             <label><%# Eval("DisCount")%></label>
                       </th> 
                   </ItemTemplate>
            </asp:Repeater>
                
            </table>
        </div>
    </div>
	<div class="buttonParent">
		<div class="buttonShade">
			<asp:Button CssClass="Inputbtn" ID="btn_update" runat="server" Text="修改" OnClick="btn_update_Click" />
			<input type="button" class="Inputbtn" value="关闭" onclick="top.Dialog.close()" />
		</div>
	</div>
</asp:Content>
