<%@ Page Language="C#" MasterPageFile="~/PageEdit.Master" AutoEventWireup="true" CodeFile="RebateRebatepolicyDetail.aspx.cs" Inherits="YouHoo.Web.REBATE.RebateRebatepolicyDetail" Title="�ޱ���ҳ" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
	<asp:HiddenField ID="hf_id" runat="server" />
	<table cellpadding="0" cellspacing="0" class="table table-bordered table-hover m10">
		<tr>
			<td align="right" class="tableleft">
				�������߱��룺
			</td>
			<td align="left">
				<asp:Label ID="lbl_Code" runat="server"></asp:Label>
			</td>
		</tr>
		<tr>
			<td align="right" class="tableleft">
				�����������ƣ�
			</td>
			<td align="left">
				<asp:Label ID="lbl_Name" runat="server"></asp:Label>
			</td>
		</tr>
		<%--<tr>
			<td align="right" class="tableleft">
				Ʒ�ƣ�
			</td>
			<td align="left">
				<asp:Label ID="lbl_brand_id" runat="server"></asp:Label>
			</td>
		</tr>--%>
		<tr>
			<td align="right" class="tableleft">
				������
			</td>
			<td align="left">
				<asp:Label ID="lbl_channel_id" runat="server"></asp:Label>
			</td>
		</tr>
		<%--<tr>
			<td align="right" class="tableleft">
				Ʒ�
			</td>
			<td align="left">
				<asp:Label ID="lbl_item_id" runat="server"></asp:Label>
			</td>
		</tr>--%>
		<tr>
			<td align="right" class="tableleft">
				�۸�
			</td>
			<td align="left">
				<asp:Label ID="lbl_price_id" runat="server"></asp:Label>
			</td>
		</tr>
		<tr>
			<td align="right" class="tableleft">
				������
			</td>
			<td align="left">
				<asp:Label ID="lbl_region_id" runat="server"></asp:Label>
			</td>
		</tr>
		<tr>
			<td align="right" class="tableleft">
				Ʒ�ࣺ
			</td>
			<td align="left">
				<asp:Label ID="lbl_sort_id_id" runat="server"></asp:Label>
			</td>
		</tr>
		<tr>
			<td align="right" class="tableleft">
				֧�ַ�ʽ��
			</td>
			<td align="left">
				<asp:Label ID="lbl_SupportWay_id" runat="server"></asp:Label>
			</td>
		</tr>
		<tr>
			<td align="right" class="tableleft">
				֧�ּ۸�
			</td>
			<td align="left">
				<asp:Label ID="lbl_SupportPrice_id" runat="server"></asp:Label>
			</td>
		</tr>
		<tr>
			<td align="right" class="tableleft">
				������ʽ��
			</td>
			<td align="left">
				<asp:Label ID="lbl_RebateType_id" runat="server"></asp:Label>
			</td>
		</tr>
		<tr>
			<td align="right" class="tableleft">
				ʱ�Σ�
			</td>
			<td align="left">
				<asp:Label ID="lbl_time_id" runat="server"></asp:Label>
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

      <link rel="stylesheet" type="text/css" href="/Images/Css/quotation.css" />
    <div class="menu_content" style="margin-top: 3px;">
        <div class="item">
            
            <table cellpadding="0" id="List_Order" cellspacing="0" class="table table-bordered table-hover">
                <tr>
                    <th align="center">Ʒ��
                    </th>
                    <th align="center">Ʒ��
                    </th>
                    <th align="center">�ۿ�
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
			<asp:Button CssClass="Inputbtn" ID="btn_update" runat="server" Text="�޸�" OnClick="btn_update_Click" />
			<input type="button" class="Inputbtn" value="�ر�" onclick="top.Dialog.close()" />
		</div>
	</div>
</asp:Content>
