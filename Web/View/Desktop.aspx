<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Desktop.aspx.cs" Inherits="YouHoo.Web.View.Desktop" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta name="renderer" content="webkit|ie-stand|ie-comp" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge,chrome=1" />
    <title><%= SystemModel.SystemSetName %></title>
    <asp:Literal ID="lt_icon" runat="server"></asp:Literal>
    <link rel="Stylesheet" type="text/css" href="/Images/desktop/desktop.css" />
    <link rel="Stylesheet" type="text/css" href="/Js/validationEngine/validationEngine.jquery.css" />
    <link rel="Stylesheet" type="text/css" href="/Js/jsPrompt/css/prompt.css" />
    <link rel="Stylesheet" type="text/css" href="/Js/popup/skin/lightBlue/css/dialog.css" />
    <script type="text/javascript" src="/Js/jquery-1.8.2.min.js"></script>
    <script type="text/javascript" src="/Js/popup/js/dialog.js"></script>
    <script type="text/javascript" src="/Js/popup/js/drag.js"></script>
    <script type="text/javascript" src="/Js/jsPrompt/js/prompt.js"></script>
    <script type="text/javascript" src="/Js/showDialog.js"></script>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <table width="100%" border="0" cellspacing="0" cellpadding="0" style="table-layout: fixed;">
                <tr>
                    <td width="50%" valign="top">
                        <div class="box">
                            <div class="box_topcenter" style="height: 29px;">
                                <div class="box_topleft">
                                    <div class="box_topright">
                                        <div class="title">登录信息</div>
                                    </div>
                                </div>
                            </div>
                            <div class="box_middlecenter">
                                <div class="box_middleleft">
                                    <div class="box_middleright">
                                        <div class="boxContent" style="height: 95px;">
                                            <div class="dbList">
                                                <ul>
                                                    <li class="listArr text_slice" style="width: 100%;">登录用户：<asp:Literal ID="lbl_real_name" runat="server"></asp:Literal></li>
                                                    <li class="listArr text_slice" style="width: 100%;">所属角色：<asp:Label ID="lbl_powergroup_name" runat="server"></asp:Label></li>
                                                    <li class="listArr text_slice" style="width: 100%;">组织属性：<asp:Label ID="lbl_org_name" Style="color: #ff0000;" runat="server"></asp:Label>><asp:Label ID="lbl_dept_name" Style="color:#1c20fa;" runat="server"></asp:Label></li>
                                                    <li class="listArr text_slice" style="width: 100%;">上次登录时间：<asp:Label ID="lbl_login_time" runat="server"></asp:Label></li>
                                                </ul>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="box_bottomcenter" style="height: 2px;">
                                <div class="box_bottomleft">
                                    <div class="box_bottomright"></div>
                                </div>
                            </div>
                        </div>
                    </td>
                    <td width="50%" valign="top">
                        <div class="box">
                            <div class="box_topcenter" style="height: 29px;">
                                <div class="box_topleft">
                                    <div class="box_topright">
                                        <div class="title">系统信息</div>
                                    </div>
                                </div>
                            </div>
                            <div class="box_middlecenter">
                                <div class="box_middleleft">
                                    <div class="box_middleright">
                                        <div class="boxContent" style="height: 95px;">
                                            <div class="dbList">
                                                <ul>
                                                    <li class="listArr text_slice" style="width: 100%;">系统所在目录：<asp:Label ID="lbl_system_directory" runat="server"></asp:Label></li>
                                                    <li class="listArr text_slice" style="width: 100%;">.NET Framework 版本：<asp:Label ID="lbl_net_version" runat="server"></asp:Label></li>
                                                    <li class="listArr text_slice" style="width: 100%;">服务器IP地址：<asp:Label ID="lbl_server_ip" runat="server"></asp:Label></li>
                                                    <li class="listArr text_slice" style="width: 100%;"></li>
                                                </ul>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="box_bottomcenter" style="height: 2px;">
                                <div class="box_bottomleft">
                                    <div class="box_bottomright"></div>
                                </div>
                            </div>
                        </div>
                    </td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
