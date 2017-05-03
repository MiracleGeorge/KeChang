<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="YouHoo.Web.Login" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta name="renderer" content="webkit|ie-stand|ie-comp" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge,chrome=1" />
    <title><%= SystemModel.SystemSetName %>-登录</title>
    <asp:Literal ID="lt_icon" runat="server"></asp:Literal>
    <link rel="stylesheet" type="text/css" href="/Images/Css/login.css" />
    <link rel="Stylesheet" type="text/css" href="/Js/validationEngine/validationEngine.jquery.css" />
    <link rel="Stylesheet" type="text/css" href="/Js/jsPrompt/css/prompt.css" />
    <link rel="Stylesheet" type="text/css" href="/Js/popup/skin/lightBlue/css/dialog.css" />
    <script type="text/javascript" src="/Js/jquery-1.8.2.min.js"></script>
    <script type="text/javascript" src="/Js/validationEngine/validationEngine.js"></script>
    <script type="text/javascript" src="/Js/validationEngine/validationRule.js"></script>
    <script type="text/javascript" src="/Js/popup/js/dialog.js"></script>
    <script type="text/javascript" src="/Js/popup/js/drag.js"></script>
    <script type="text/javascript" src="/Js/jsPrompt/js/prompt.js"></script>
    <script type="text/javascript">
        $(function () {
            $("body").width($(window).width()).height($(window).height());
        });
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <div class="login_main">
            <div class="login_con">
                <!--logo及微博的外链  S-->
                <div class="log_logo_weibo">
                    <p class="log_logo float_l">
                        <%= SystemModel.SystemSetName %>
                    </p>
                </div>
                <!--logo及微博的外链  E-->
                <table width="100%" cellpadding="0" cellspacing="0">
                    <tr>
                        <td class="log_l_img">
                            <!--左边书架图片  S-->
                            <img src="<%= SystemModel.SystemSetLoginBiaozhi %>" alt="暂无图片" />
                        </td>
                        <td class="log_r_form">
                            <!--右边登录表单  S-->
                            <h2 class="denglu">用户登录</h2>
                            <table width="100%" border="0" cellspacing="0" cellpadding="0" class="log_table">
                                <tbody>
                                    <tr>
                                        <td height="36" class="left_td">
                                            用户名：
                                        </td>
                                        <td align="left" class="right_td">
                                            <asp:TextBox ID="txtUserName" runat="server" CssClass="validate[required,custom[username]] input175 input" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td height="36" class="left_td">
                                            密码：
                                        </td>
                                        <td align="left" class="right_td">
                                            <asp:TextBox ID="txtUserPwd" runat="server" CssClass="validate[required,minSize[6],maxSize[16]] input175 input" TextMode="Password" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td height="36" class="left_td">
                                            验证码：
                                        </td>
                                        <td align="left" class="right_td">
                                            <asp:TextBox ID="txtCode" runat="server" CssClass="validate[required,ajax[ajaxValidateCode]] input110 input" />
                                            <cite class="yzm">
                                                <img id="imgValidateCode" border="1" src="View/ValidateCode.aspx" style="cursor: pointer;"
                                                    alt="" onclick="this.src='View/ValidateCode.aspx?'+Math.random()" title="点击更换验证码" />
                                            </cite>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td height="42">
                                            &nbsp;
                                        </td>
                                        <td align="left" class="right_td">
                                            <asp:Button ID="btnLogin" runat="server" CssClass="loginbtn" OnClick="btnLogin_Click" OnClientClick="SaveLoading()" />
                                        </td>
                                    </tr>
                                </tbody>
                            </table>
                            <!--右边登录表单  E-->
                        </td>
                    </tr>
                </table>
            </div>
        </div>
    </form>
</body>
</html>
