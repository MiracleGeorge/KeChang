//门店部门角色联动
function stroChange(Store, Department, powergroup_id) {
    $("input[type='hidden'][id$=hf_" + Store + "]").val($("select[id$=ddl_" + Store + "]").val());
    $("select[id$=ddl_" + Department + "]").empty();
    $("input[type='hidden'][id$=hf_" + Department + "]").val("");
    $("select[id$=ddl_" + powergroup_id + "]").empty();
    $("input[type='hidden'][id$=hf_" + powergroup_id + "]").val("");
    if ($("select[id$=ddl_" + Store + "]").val() != "") {
        $("select[id$=ddl_" + Department + "]").append("<option value=''>数据加载中</option>");
        $("select[id$=ddl_" + powergroup_id + "]").append("<option value=''>数据加载中</option>");
        $.ajax({
            type: "POST",
            url: "/Js/cityLinkage/DataAction.aspx",
            data: {
                act: "StorChange",
                stroId: $("select[id$=ddl_" + Store + "]").val()
            },
            success: function (data) {
                if (data) {
                    var ret = eval("(" + data + ")");
                    if (ret.flag == "1") {
                        $("select[id$=ddl_" + Department + "]").empty();
                        $("select[id$=ddl_" + powergroup_id + "]").empty();
                        $("select[id$=ddl_" + Department + "]").append("<option value=''>--请选择--</option>");
                        for (var i = 0; i < ret.msg.length; i++) {
                            $("select[id$=ddl_" + Department + "]").append("<option value='" + ret.msg[i].Id + "'>" + ret.msg[i].Name + "</option>");
                            $("input[type='hidden'][id$=hf_" + Department + "]").val(ret.msg[i].Id);
                        }
                        for (var i = 0; i < ret.power.length; i++) {
                            $("select[id$=ddl_" + powergroup_id + "]").append("<option value='" + ret.power[i].powergroup_id + "'>" + ret.power[i].powergroup_name + "</option>");
                            $("input[type='hidden'][id$=hf_" + powergroup_id + "]").val(ret.power[i].powergroup_id);
                        }
                        $("select[id$=ddl_" + Department + "]").trigger("chosen:updated");
                        $("select[id$=ddl_" + powergroup_id + "]").trigger("chosen:updated");
                    }
                }
                else {
                    top.msgbox.prompt("操作异常！");
                }
            },
            error: function () {
                top.msgbox.prompt("操作失败！");
            }
        });
    }
    else {
        $("select[id$=ddl_" + Department + "]").append("<option value=''>--请选择--</option>");
        $("select[id$=ddl_" + powergroup_id + "]").append("<option value=''>--请选择--</option>");
    }
    $("select[id$=ddl_" + Department + "]").trigger("chosen:updated");
    $("select[id$=ddl_" + powergroup_id + "]").trigger("chosen:updated");
}

//门店角色联动
function stroPowerChange(Store, powergroup_id) {
    $("input[type='hidden'][id$=hf_" + Store + "]").val($("select[id$=ddl_" + Store + "]").val());
    $("select[id$=ddl_" + powergroup_id + "]").empty();
    $("input[type='hidden'][id$=hf_" + powergroup_id + "]").val("");
    if ($("select[id$=ddl_" + Store + "]").val() != "") {
        $("select[id$=ddl_" + powergroup_id + "]").append("<option value=''>数据加载中</option>");
        $.ajax({
            type: "POST",
            url: "/Js/cityLinkage/DataAction.aspx",
            data: {
                act: "StorPowerChange",
                stroId: $("select[id$=ddl_" + Store + "]").val()
            },
            success: function (data) {
                if (data) {
                    var ret = eval("(" + data + ")");
                    if (ret.flag == "1") {
                        $("select[id$=ddl_" + powergroup_id + "]").empty();
                        $("select[id$=ddl_" + powergroup_id + "]").append("<option value=''>--请选择--</option>");
                        for (var i = 0; i < ret.power.length; i++) {
                            $("select[id$=ddl_" + powergroup_id + "]").append("<option value='" + ret.power[i].powergroup_id + "'>" + ret.power[i].powergroup_name + "</option>");
                            $("input[type='hidden'][id$=hf_" + powergroup_id + "]").val(ret.power[i].powergroup_id);
                        }
                        $("select[id$=ddl_" + powergroup_id + "]").trigger("chosen:updated");
                    }
                }
                else {
                    top.msgbox.prompt("操作异常！");
                }
            },
            error: function () {
                top.msgbox.prompt("操作失败！");
            }
        });
    }
    else {
        $("select[id$=ddl_" + powergroup_id + "]").append("<option value=''>--请选择--</option>");
    }
    $("select[id$=ddl_" + powergroup_id + "]").trigger("chosen:updated");
}

//一级服务项目与二级服务项目联动
function serviceChange(FService, TService) {
    $("input[type='hidden'][id$=hf_" + FService + "]").val($("select[id$=ddl_" + FService + "]").val());
    $("select[id$=ddl_" + TService + "]").empty();
    $("input[type='hidden'][id$=hf_" + TService + "]").val("");
    if ($("select[id$=ddl_" + FService + "]").val() != "") {
        $("select[id$=ddl_" + TService + "]").append("<option value=''>数据加载中</option>");
        $.ajax({
            type: "POST",
            url: "/Js/cityLinkage/DataAction.aspx",
            data: {
                act: "ServicePowerChange",
                stroId: $("select[id$=ddl_" + FService + "]").val()
            },
            success: function (data) {
                if (data) {
                    var ret = eval("(" + data + ")");
                    if (ret.flag == "1") {
                        $("select[id$=ddl_" + TService + "]").empty();
                        $("select[id$=ddl_" + TService + "]").append("<option value=''>--请选择--</option>");
                        for (var i = 0; i < ret.service.length; i++) {
                            $("select[id$=ddl_" + TService + "]").append("<option value='" + ret.service[i].Id + "'>" + ret.service[i].Name + "</option>");
                            $("input[type='hidden'][id$=hf_" + TService + "]").val(ret.service[i].Id);
                        }
                        $("select[id$=ddl_" + TService + "]").trigger("chosen:updated");
                    }
                }
                else {
                    top.msgbox.prompt("操作异常！");
                }
            },
            error: function () {
                top.msgbox.prompt("操作失败！");
            }
        });
    }
    else {
        $("select[id$=ddl_" + TService + "]").append("<option value=''>--请选择--</option>");
    }
    $("select[id$=ddl_" + TService + "]").trigger("chosen:updated");
}

//门店部门用户联动
function strouserChange(Store, Department, userid) {
    $("input[type='hidden'][id$=hf_" + Store + "]").val($("select[id$=ddl_" + Store + "]").val());
    $("select[id$=ddl_" + Department + "]").empty();
    $("input[type='hidden'][id$=hf_" + Department + "]").val("");
    $("select[id$=ddl_" + userid + "]").empty();
    $("input[type='hidden'][id$=hf_" + userid + "]").val("");
    if ($("select[id$=ddl_" + Store + "]").val() != "") {
        $("select[id$=ddl_" + Department + "]").append("<option value=''>数据加载中</option>");
        $("select[id$=ddl_" + userid + "]").append("<option value=''>数据加载中</option>");
        $.ajax({
            type: "POST",
            url: "/Js/cityLinkage/DataAction.aspx",
            data: {
                act: "StorUserChange",
                storeId: $("select[id$=ddl_" + Store + "]").val()
            },
            success: function (data) {
                if (data) {
                    var ret = eval("(" + data + ")");
                    if (ret.flag == "1") {
                        $("select[id$=ddl_" + Department + "]").empty();
                        $("select[id$=ddl_" + userid + "]").empty();
                        $("select[id$=ddl_" + Department + "]").append("<option value=''>--请选择--</option>");
                        $("select[id$=ddl_" + userid + "]").append("<option value=''>--请选择--</option>");
                        for (var i = 0; i < ret.msg.length; i++) {
                            $("select[id$=ddl_" + Department + "]").append("<option value='" + ret.msg[i].Id + "'>" + ret.msg[i].Name + "</option>");
                        }
                        $("select[id$=ddl_" + Department + "]").trigger("chosen:updated");
                        $("select[id$=ddl_" + userid + "]").trigger("chosen:updated");
                    }
                }
                else {
                    top.msgbox.prompt("操作异常！");
                }
            },
            error: function () {
                top.msgbox.prompt("操作失败！");
            }
        });
    }
    else {
        $("select[id$=ddl_" + Department + "]").append("<option value=''>--请选择--</option>");
        $("select[id$=ddl_" + userid + "]").append("<option value=''>--请选择--</option>");
    }
    $("select[id$=ddl_" + Department + "]").trigger("chosen:updated");
    $("select[id$=ddl_" + userid + "]").trigger("chosen:updated");
}

function departChange(Store, Department, userid) {
    $("input[type='hidden'][id$=hf_" + Department + "]").val($("select[id$=ddl_" + Department + "]").val());
    $("select[id$=ddl_" + userid + "]").empty();
    $("input[type='hidden'][id$=hf_" + userid + "]").val("");
    if ($("select[id$=ddl_" + Department + "]").val() != "") {
        $("select[id$=ddl_" + userid + "]").append("<option value=''>数据加载中</option>");
        $.ajax({
            type: "POST",
            url: "/Js/cityLinkage/DataAction.aspx",
            data: {
                act: "departChange",
                departId: $("select[id$=ddl_" + Department + "]").val()
            },
            success: function (data) {
                if (data) {
                    var ret = eval("(" + data + ")");
                    if (ret.flag == "1") {
                        $("select[id$=ddl_" + userid + "]").empty();
                        $("select[id$=ddl_" + userid + "]").append("<option value=''>--请选择--</option>");
                        for (var i = 0; i < ret.msg.length; i++) {
                            $("select[id$=ddl_" + userid + "]").append("<option value='" + ret.msg[i].user_id + "'>" + ret.msg[i].username + "</option>");
                        }
                        $("select[id$=ddl_" + userid + "]").trigger("chosen:updated");
                    }
                }
                else {
                    top.msgbox.prompt("操作异常！");
                }
            },
            error: function () {
                top.msgbox.prompt("操作失败！");
            }
        });
    }
    else {
        $("select[id$=ddl_" + userid + "]").append("<option value=''>--请选择--</option>");
    }
    $("select[id$=ddl_" + userid + "]").trigger("chosen:updated");
}

function userChange(Store, Department, userid) {
    $("input[type='hidden'][id$=hf_" + userid + "]").val($("select[id$=ddl_" + userid + "]").val());
}