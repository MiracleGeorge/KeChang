<%@ Control Language="C#" AutoEventWireup="true" CodeFile="TreeFrame.ascx.cs" Inherits="YouHoo.Web.Control.TreeFrame" %>

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
                ExtendParameter: "<%= hf_extendParameter.Value %>",
                Where: "<%= hf_where.Value %>"
            },
            contentType: "application/json",
            dataType: "text",
            url: "<%= Request.Path %>?act=GetTreeAsync"
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
        $(".tableMain table").height($(window).height() - 31);
        $(".tableMain table").find(".tableMain_tree, iframe").height($(window).height() - 51);

        if ($("#<%=hf_node.ClientID%>").val() != "[]") {
            var node = eval("(" + $("#<%=hf_node.ClientID%>").val() + ")");
            $.fn.zTree.init($("#tree"), setting, node);
        }
    })
</script>

<asp:HiddenField ID="hf_node" runat="server" />
<asp:HiddenField ID="hf_idName" runat="server" />
<asp:HiddenField ID="hf_textName" runat="server" />
<asp:HiddenField ID="hf_parentIdName" runat="server" />
<asp:HiddenField ID="hf_linkUrl" runat="server" />
<asp:HiddenField ID="hf_target" runat="server" />
<asp:HiddenField ID="hf_extendParameter" runat="server" />
<asp:HiddenField ID="hf_bllName" runat="server" />
<asp:HiddenField ID="hf_where" runat="server" />
<asp:HiddenField ID="hf_orderBy" runat="server" />
<div class="tableMain">
    <table class="table table-bordered definewidth m10" style="background-color: #e8f6ff;">
        <tr>
            <td valign="top" width="150">
                <div class="tableMain_tree" style="width: 150px;">
                    <ul id="tree" class="ztree"></ul>
                </div>
            </td>
            <td valign="top">
                <iframe height="100%" width="100%" frameborder="0" id="<%= hf_target.Value %>" name="<%= hf_target.Value %>" src="<%= hf_linkUrl.Value + "?"+hf_idName.Value+"=0" + hf_extendParameter.Value %>" allowtransparency="true"></iframe>
            </td>
        </tr>
    </table>
</div>
