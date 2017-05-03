<%@ Page Language="C#" AutoEventWireup="true" CodeFile="LeftTree.aspx.cs" Inherits="YouHoo.Web.View.LeftTree" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta name="renderer" content="webkit|ie-stand|ie-comp" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge,chrome=1" />
    <title><%= SystemModel %></title>
    <asp:Literal ID="lt_icon" runat="server"></asp:Literal>
    <link rel="Stylesheet" type="text/css" href="/Js/ztree/zTreeStyle.css" />
    <link rel="Stylesheet" type="text/css" href="/Js/jsPrompt/css/prompt.css" />
    <link rel="Stylesheet" type="text/css" href="/Js/popup/skin/lightBlue/css/dialog.css" />
    <script type="text/javascript" src="/Js/jquery-1.8.2.min.js"></script>
    <script type="text/javascript" src="/Js/ztree/jquery.ztree.core-3.5.min.js"></script>
    <script type="text/javascript" src="/Js/popup/js/dialog.js"></script>
    <script type="text/javascript" src="/Js/popup/js/drag.js"></script>
    <script type="text/javascript" src="/Js/jsPrompt/js/prompt.js"></script>
    <script type="text/javascript">
        var setting = {
            view: {
                dblClickExpand: false
            },
            async: {
                enable: true,
                type: "get",
                autoParam: ["id"],
                otherParam: {
                    "moduleId": $("#<%= hf_module_id.ClientID %>").val()
                },
                contentType: "application/json",
                dataType: "text",
                url: "LeftTree.aspx?act=GetTreeAsync"
            },
            data: {
                simpleData: {
                    enable: true
                }
            },
            callback: {
                onClick: onNodeClick
            }
        };

        //单击展开节点
        function onNodeClick(event, treeId, treeNode) {
            var zTree = $.fn.zTree.getZTreeObj("tree");
            zTree.expandNode(treeNode);
        }

        $(function () {
            if ($("#<%=hf_node.ClientID%>").val() != "[]") {
                var node = eval("(" + $("#hf_node").val() + ")");
                $.fn.zTree.init($("#tree"), setting, node);
            }
        })
    </script>
</head>
<body style="height: 100%; background-color: #f1f8ff;">
    <form id="form2" runat="server">
        <asp:HiddenField ID="hf_module_id" runat="server" />
        <asp:HiddenField ID="hf_node" runat="server" />
        <div id="scrollContent" style="overflow-x: hidden; width: 194px;">
            <ul id="tree" class="ztree"></ul>
        </div>
    </form>
</body>
</html>
