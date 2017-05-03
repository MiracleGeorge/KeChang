<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Main.aspx.cs" Inherits="YouHoo.Web.View.Main" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta name="renderer" content="webkit|ie-stand|ie-comp" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge,chrome=1" />
    <title><%= SystemModel.SystemSetName %></title>
    <asp:Literal ID="lt_icon" runat="server"></asp:Literal>
    <link rel="stylesheet" type="text/css" href="/Images/Css/metinfo.css" />
    <link rel="stylesheet" type="text/css" href="/Images/Icons/icon.css" />
    <link rel="Stylesheet" type="text/css" href="/Js/jsPrompt/css/prompt.css" />
    <link rel="Stylesheet" type="text/css" href="/Js/popup/skin/lightBlue/css/dialog.css" />
    <link rel="Stylesheet" type="text/css" href="/Js/chosen/skin/gray/chosen.css" />
    <script type="text/javascript" src="/Js/jquery-1.8.2.min.js"></script>
    <script type="text/javascript" src="/Js/popup/js/dialog.js"></script>
    <script type="text/javascript" src="/Js/popup/js/drag.js"></script>
    <script type="text/javascript" src="/Js/jsPrompt/js/prompt.js"></script>
    <script type="text/javascript" src="/Js/chosen/chosen.jquery.js"></script>
    <script type="text/javascript">
        $(function () {
            $("#bs_left,#bs_right").height($(window).height() - 122);
            $(window).resize(function () {
                $("#bs_left,#bs_right").height($(window).height() - 122);
            })
            $(".bs_leftArr").click(function () {
                if ($("#hideCon").is(":visible")) {
                    $("#hideCon").hide();
                    $(this).addClass("bs_rightArr").removeClass("bs_leftArr");
                }
                else {
                    $("#hideCon").show();
                    $(this).addClass("bs_leftArr").removeClass("bs_rightArr");
                }
            })
            $(".menu a").click(function () {
                $(this).addClass("on").siblings().removeClass("on");
                $(".icon_find").attr("href", $(this).attr("data-url"));
            })
        })

        //清除缓存
        function ClearCache() {
            $.ajax({
                type: "POST",
                url: "DataAction.aspx",
                data: {
                    act: "ClearCache"
                },
                success: function (data) {
                    top.msgbox.prompt(data, 2);
                }
            });
        }

        //退出登录
        function logout() {
            top.Dialog.confirm('您确定要退出系统吗？', function () {
                top.location.href = "../LoginOut.aspx";
            });
        }

        $(function () {
            if ($("#<%= hf_customizationPower.ClientID %>").val() == "1") {
                var customizationDialog = new top.Dialog();
                customizationDialog.ID = "customizationDialog";
                customizationDialog.Title = "系统提示";
                customizationDialog.Top = "100%";
                customizationDialog.Left = "100%";
                customizationDialog.Modal = false;
                customizationDialog.Width = 300;
                customizationDialog.Height = 32;
                customizationDialog.InnerHtml = "";
                customizationDialog.CancelEvent = function () { $("#_DialogDiv_customizationDialog").hide(); }
                customizationDialog.show();
                $("#_DialogDiv_customizationDialog").hide();

                getCustomizationOrder();
                setInterval(function () {
                    getCustomizationOrder();
                }, 3000);
            }
        })
        //获取裸钻定制订单数量
        function getCustomizationOrder() {
            $.ajax({
                type: "POST",
                url: "/OF/DataAction.aspx",
                data: {
                    act: "GetCustomizationOrder"
                },
                success: function (data) {
                    if (data) {
                        var ret = eval("(" + data + ")");
                        if (ret.flag == "1") {
                            if (parseInt(ret.msg) > 0) {
                                $("#_Container_customizationDialog").children(":gt(0)").remove();
                                $("#_Container_customizationDialog").append("<div class='lightOn' style='margin:6px 5px; background: url(../Images/Icons/lightOn.gif) no-repeat 0px 5px; padding-left: 20px;'><a href='../OF/OfBuyProductList.aspx' target='frmright'>您有 <span style='font-weight:bold; font-size:18px; color:#e17d11;'>" + ret.msg + "</span> 条新的裸钻定制订单，请及时处理！</a></div>");
                                $("#_DialogDiv_customizationDialog").show();
                            }
                            else {
                                $("#_DialogDiv_customizationDialog").hide();
                            }
                        }
                    }
                    else {
                        top.msgbox.prompt("操作异常！", 3);
                    }
                },
                error: function () {
                    top.msgbox.prompt("操作失败！", 3);
                }
            });
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <asp:HiddenField ID="hf_customizationPower" Value="0" runat="server" />
        <input type="hidden" id="hf_dialogIndex" value="1" />
        <div id="mainFrame">
            <!--头部与导航start-->
            <div id="hbox">
                <div id="bs_bannercenter">
                    <div id="bs_bannerleft">
                        <img src="<%= SystemModel.SystemSetHouLogo %>" alt="暂无图片" />
                    </div>
                    <div id="bs_bannerright">
                    </div>
                </div>
                <div id="bs_navcenter">
                    <div id="bs_navleft">
                        <div id="bs_navright">
                            <div class="bs_nav">
                                <div class="floatl menu">
                                    您好，【<asp:Label ID="lbl_store_name" Style="color: #ff0000;" runat="server"></asp:Label>】<asp:Label ID="lbl_real_name" Style="color: #1c57c4;" runat="server"></asp:Label>【今天是
                                    <script type="text/javascript">
                                        var weekDayLabels = new Array("星期日", "星期一", "星期二", "星期三", "星期四", "星期五", "星期六");
                                        var now = new Date();
                                        var year = now.getFullYear();
                                        var month = now.getMonth() + 1;
                                        var day = now.getDate()
                                        var currentime = year + "年" + month + "月" + day + "日 " + weekDayLabels[now.getDay()]
                                        document.write(currentime)
                                    </script>】
                                </div>
                                <div class="floatr">
                                   <%-- <a class="icon_find hand" href="/" target="_blank">浏览网站</a>--%>
                                    <a class="icon_home hand" href="Desktop.aspx" target="frmright">桌面</a>
                                    <span class="img_reload hand" onclick="ClearCache();">清除缓存</span>
                                    <a class="icon_edit hand" href="../SYS/SysUserChangePwd.aspx" target="frmright">修改密码</a>
                                    <span class="icon_exit hand" onclick="logout();">退出系统</span>
                                </div>
                                <div class="clear">
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <!--头部与导航end-->
            <table width="100%" cellpadding="0" cellspacing="0" class="table_border0">
                <tbody>
                    <tr>
                        <!--左侧区域start-->
                        <td id="hideCon" class="ver01 ali01">
                            <div id="lbox">
                                <div id="lbox_topcenter">
                                    <div id="lbox_topleft">
                                        <div id="lbox_topright">
                                        </div>
                                    </div>
                                </div>
                                <div id="lbox_middlecenter">
                                    <div id="lbox_middleleft">
                                        <div id="lbox_middleright">
                                            <div id="bs_left">
                                                <iframe height="100%" width="100%" frameborder="0" id="frmleft" name="frmleft" src="LeftTree.aspx"
                                                    allowtransparency="true"></iframe>
                                            </div>
                                            <!--更改左侧栏的宽度需要修改id="bs_left"的样式-->
                                        </div>
                                    </div>
                                </div>
                                <div id="lbox_bottomcenter">
                                    <div id="lbox_bottomleft">
                                        <div id="lbox_bottomright">
                                            <div class="lbox_foot">
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </td>
                        <!--左侧区域end-->
                        <!--分隔栏区域start-->
                        <td class="spliter main_shutiao ver02 ali02">
                            <div class="bs_leftArr" title="收缩/展开面板">
                            </div>
                        </td>
                        <!--分隔栏区域end-->
                        <!--右侧区域start-->
                        <td class="ali01 ver01" width="100%">
                            <div id="rbox">
                                <div id="rbox_topcenter">
                                    <div id="rbox_topleft">
                                        <div id="rbox_topright">
                                        </div>
                                    </div>
                                </div>
                                <div id="rbox_middlecenter">
                                    <div id="rbox_middleleft">
                                        <div id="rbox_middleright">
                                            <div id="bs_right">
                                                <iframe height="100%" width="100%" frameborder="0" id="frmright" name="frmright"
                                                    src="Desktop.aspx" allowtransparency="true"></iframe>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div id="rbox_bottomcenter">
                                    <div id="rbox_bottomleft">
                                        <div id="rbox_bottomright">
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </td>
                        <!--右侧区域end-->
                    </tr>
                </tbody>
            </table>
            <!--尾部区域start-->
            <div class="dialogTaskBg" style="text-align: center; color: #1f3f6e">
                技术支持：<a href="http://www.uftong.com" target="_blank">上海企通软件有限公司</a>
            </div>
            <div id="dialogTask" class="dialogTaskBg" style="display: none;">
                <div class="taskItemContainerParent">
                </div>
                <div class="taskItemButtonLeft" style="display: none;">
                </div>
                <div class="taskItemButtonRight" style="display: none;">
                </div>
            </div>
        </div>
    </form>
</body>
</html>
