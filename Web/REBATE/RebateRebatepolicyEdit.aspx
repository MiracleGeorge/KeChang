<%@ Page Language="C#" MasterPageFile="~/PageEdit.Master" AutoEventWireup="true" CodeFile="RebateRebatepolicyEdit.aspx.cs" Inherits="YouHoo.Web.REBATE.RebateRebatepolicyEdit" Title="无标题页" %>



<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script type="text/javascript" src="../Js/newTabRow.js"></script>
   
    <asp:HiddenField ID="hf_id" runat="server" />
    <table cellpadding="0" cellspacing="0" class="table table-bordered table-hover m10">
        <tr>
            <td align="right" class="tableleft">返利政策编码：
            </td>
            <td align="left">
                <asp:TextBox ID="txt_Code" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td align="right" class="tableleft">返利政策名称：
            </td>
            <td align="left">
                <asp:TextBox ID="txt_Name" runat="server"></asp:TextBox>
            </td>
        </tr>
        <%--<tr>
			<td align="right" class="tableleft">
				品牌：
			</td>
			<td align="left">
				<asp:DropDownList ID="ddl_brand" runat="server" DataTextField="Name" DataValueField="id" CssClass="validate[required]">
                </asp:DropDownList>
			</td>
		</tr>--%>
        <tr>
            <td align="right" class="tableleft">渠道：
            </td>
            <td align="left">
                <asp:DropDownList ID="ddl_channel" runat="server" DataTextField="Name" DataValueField="id">
                </asp:DropDownList>
            </td>
        </tr>
        <%--<tr>
			<td align="right" class="tableleft">
				品项：
			</td>
			<td align="left">
				<asp:DropDownList ID="ddl_item" runat="server" DataSourceID="item" DataTextField="Name" DataValueField="id">
                </asp:DropDownList>
			    <asp:LinqDataSource ID="item" runat="server" ContextTypeName="YouHoo.DataBll.REBATE.KechangDataContext" EntityTypeName="" Select="new (id, Name)" TableName="youhoo_BasicArchive_item" Where="flag&lt;&gt;0">
                </asp:LinqDataSource>
			</td>
		</tr>--%>
        <tr>
            <td align="right" class="tableleft">价格：
            </td>
            <td align="left">
                <asp:TextBox runat="server" />
            </td>
        </tr>
        <tr>
            <td align="right" class="tableleft">大区：
            </td>
            <td align="left">
                <asp:DropDownList ID="ddl_region" runat="server" DataTextField="Name" DataValueField="id">
                </asp:DropDownList>
            </td>
        </tr>
          <tr>
            <td align="right" class="tableleft">市区：
            </td>
            <td align="left">
                <asp:DropDownList ID="ddl_town" runat="server" DataTextField="Name" DataValueField="id">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td align="right" class="tableleft">品类：
            </td>
            <td align="left">
                <asp:DropDownList ID="ddl_sort" runat="server" DataTextField="Name" DataValueField="id">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td align="right" class="tableleft">支持方式：
            </td>
            <td align="left">
                <asp:DropDownList ID="ddl_supportWay" runat="server" DataTextField="Name" DataValueField="id">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td align="right" class="tableleft">支持价格：
            </td>
            <td align="left">
                <asp:DropDownList ID="ddl_supportPrice" runat="server" DataTextField="Name" DataValueField="id">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td align="right" class="tableleft">返利方式：
            </td>
            <td align="left">
                <asp:DropDownList ID="ddl_rebateWay" runat="server" DataTextField="Name" DataValueField="id">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td align="right" class="tableleft">时段：
            </td>
            <td align="left">
                <asp:TextBox runat="server" CssClass="validate[required,custom[date]] Wdate input_100" onfocus="WdatePicker()"/>
                <span>至</span>
                <asp:TextBox runat="server" CssClass="validate[required,custom[date]] Wdate input_100" onfocus="WdatePicker()"/>

            </td>
        </tr>
        <tr>
            <td align="right" class="tableleft">备注：
            </td>
            <td align="left">
                <asp:TextBox ID="txt_remark" TextMode="MultiLine" Width="90%" Height="60" runat="server"></asp:TextBox>
            </td>
        </tr>
    </table>

    <link rel="stylesheet" type="text/css" href="/Images/Css/quotation.css" />
    <div class="menu_content" style="margin-top: 3px;">
        <div class="item">
            <input type="button" id="addOrder" class="Inputbtn" value="新增订单" />
            <table cellpadding="0" id="Order" cellspacing="0" class="table table-bordered table-hover">
                <tr>
                    <th align="center">品牌
                    </th>
                    <th align="center">品相
                    </th>
                    <th align="center">折扣
                    </th>
                    <th align="center" width="60">操作
                    </th>
                </tr>
                 <asp:Repeater ID="Reapter_PolicyDetails" runat="server">
                   <ItemTemplate>
                       <tr>
                           <th style="background-color:white">
<%--                               <asp:DropDownList ID="ddl_brand" runat="server">
                                   <asp:ListItem Value=""></asp:ListItem>
                               </asp:DropDownList>--%>
                               <select name="ddl_brand" id="brand_select" >
                                  <%# GetBrandList(Eval("brand_id").ToString())  %>
                                    
                                </select> 
                           </th>
                            <th style="background-color:white"">
                                   <select name="ddl_Item"  >
                                  <%# GetItemList(Eval("item_id").ToString())  %>
                                    
                                </select> 
                           </th>
                            <th style="background-color:white"">
                                 <input name="ddl_Discount"  type="text" value="<%# Eval("DisCount")%>" class="validate[required,custom[onlyNumberWide]] input_100"></input>
                           </th>
                            <th style="background-color:white"">
                                <a href="javascript:;" class="deleteOrder">删行</a>
                            </th>
                       </tr>
                   </ItemTemplate>
            </asp:Repeater>
                <asp:Literal ID="lt_Order" runat="server"></asp:Literal>
            </table>
        </div>
    </div>
    <div class="buttonParent">
        <div class="buttonShade">
            <asp:Button CssClass="Inputbtn" ID="btn_save" runat="server" Text="保存" OnClick="btn_save_Click" OnClientClick="SaveLoading()" />
            <input type="button" class="Inputbtn" value="关闭" onclick="top.Dialog.close()" />
        </div>
    </div>

</asp:Content>
