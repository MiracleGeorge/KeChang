$(function () {
    //全选及全不选
    $("#chkChooseAll").change(function () {
        var obj = $(this);
        $("#item_list tr:gt(0)").each(function () {
            if ($(this).find("input[type='checkbox']").length > 0 && !$(this).find("input[type='checkbox']").prop("disabled")) {
                $(this).find("input[type='checkbox']").prop("checked", obj.prop("checked"));
                if (obj.prop("checked")) {
                    $("#item_list tr:gt(0)").addClass("selected");
                }
                else {
                    $("#item_list tr:gt(0)").removeClass("selected");
                }
            }
        })
    })
    $("#item_list tr:gt(0)").click(function () {
        if ($(this).find("input[type='checkbox']").length > 0 && !$(this).find("input[type='checkbox']").prop("disabled")) {
            $(this).find("input[type='checkbox']").prop("checked", !$(this).find("input[type='checkbox']").prop("checked"));
            itemSelect($(this).find("input[type='checkbox']")[0]);
        }
    })
    $("#item_list tr:gt(0) input[type='checkbox']").change(function (e) {
        itemSelect(this);
    })
    $("#item_list tr:gt(0) input[type='checkbox'], #item_list tr:gt(0) .lbl_ajaxUpdate, #item_list tr:gt(0) .img_ajaxUpdate, #item_list tr:gt(0) .txt_ajaxUpdate, #item_list tr:gt(0) .ddl_ajaxUpdate, #item_list tr:gt(0) a").click(function (e) {
        e.stopPropagation();
    })
})
//选中效果
function itemSelect(obj) {
    $("#chkChooseAll").prop("checked", $("#item_list tr:gt(0) input[type='checkbox']:checked").length == $("#item_list tr:gt(0) input[type='checkbox']").length);
    if ($(obj).prop("checked")) {
        $(obj).closest("tr").addClass("selected");
    }
    else {
        $(obj).closest("tr").removeClass("selected");
    }
}

//删除提示
function popDelete(obj) {
    return confirmAlertCustom("您确定要删除选中数据吗？", "请选择要删除的数据！", obj);
}
function popDeleteSingle(obj) {
    return confirmCustom("您确定要删除该数据吗？", obj);
}

//提交提示
function popSend(obj) {
    return confirmAlertCustom("您确定要提交选中数据吗？", "请选择要提交的数据！", obj);
}
function popSendSingle(obj) {
    return confirmCustom("您确定要提交该数据吗？", obj);
}

//取消提交提示
function popCannelsumbit(obj) {
    return confirmAlertCustom("您确定要取消提交选中数据吗？", "请选择要取消提交的数据！", obj);
}
function popCannelsumbitSingle(obj) {
    return confirmCustom("您确定要取消提交该数据吗？", obj);
}

//导出提示
function popImportOut(obj) {
    var num = document.getElementsByTagName("input");
    var cnum = checknum(num);
    if (cnum == 0) {
        top.Dialog.alert("请选择要导出的数据！");
    }
    else {
        top.Dialog.confirm("您确定要导出选中数据吗？", function () { __doPostBack($(obj).attr("name"), ""); });
    }
    return false;
}
function popImportOutSingle(obj) {
    top.Dialog.confirm("您确定要导出该数据吗？", function () { location.href = $(obj).attr("href"); });
    return false;
}

//审核提示
function popShenhe(obj) {
    
    return confirmAlertCustom("您确定要审核选中数据吗？", "请选择要审核的数据！", obj);
}
function popShenheSingle(obj) {
    return confirmCustom("您确定要审核该数据吗？", obj);
}

//取消审核提示
function popCancelShenhe(obj) {
    return confirmAlertCustom("您确定要取消审核选中数据吗？", "请选择要取消审核的数据！", obj);
}
function popCancelShenheSingle(obj) {
    return confirmCustom("您确定要取消审核该数据吗？", obj);
}

//冻结提示
function popFrozen(obj) {
    return confirmAlertCustom("您确定要冻结选中数据吗？", "请选择要冻结的数据！", obj);
}
function popFrozenSingle(obj) {
    return confirmCustom("您确定要冻结该数据吗？", obj);
}

//取消冻结提示
function popCancelFrozen(obj) {
    return confirmAlertCustom("您确定要取消冻结选中数据吗？", "请选择要取消冻结的数据！", obj);
}
function popCancelFrozenSingle(obj) {
    return confirmCustom("您确定要取消冻结该数据吗？", obj);
}

//关闭提示
function popClose(obj) {
    return confirmAlertCustom("您确定要关闭选中数据吗？", "请选择要关闭的数据！", obj);
}
function popCloseSingle(obj) {
    return confirmCustom("您确定要关闭该数据吗？", obj);
}

//关闭冻结提示
function popCancelClose(obj) {
    return confirmAlertCustom("您确定要取消关闭选中数据吗？", "请选择要取消关闭的数据！", obj);
}
function popCancelCloseSingle(obj) {
    return confirmCustom("您确定要取消关闭该数据吗？", obj);
}

//密码重置提示
function popPwdReset(obj) {
    return confirmAlertCustom("您确定要对选中数据进行密码重置操作吗？", "请选择要进行密码重置操作的数据！", obj);
}
function popPwdResetSingle(obj) {
    return confirmCustom("您确定要对该数据进行密码重置操作吗？", obj);
}

//冻结提示
function popFreeze(obj) {
    return confirmAlertCustom("您确定要冻结选中数据吗？", "请选择要冻结的数据！", obj);
}
function popFreezeSingle(obj) {
    return confirmCustom("您确定要冻结该数据吗？", obj);
}

//取消冻结提示
function popCancelFreeze(obj) {
    return confirmAlertCustom("您确定要取消冻结选中数据吗？", "请选择要取消冻结的数据！", obj);
}
function popCancelFreezeSingle(obj) {
    return confirmCustom("您确定要取消冻结该数据吗？", obj);
}

//启用提示
function popStart(obj) {
    return confirmAlertCustom("您确定要启用选中数据吗？", "请选择要启用的数据！", obj);
}
function popStartSingle(obj) {
    return confirmCustom("您确定要启用该数据吗？", obj);
}

//不启用提示
function popDisabled(obj) {
    return confirmAlertCustom("您确定要不启用选中数据吗？", "请选择要不启用的数据！", obj);
}
function popDisabledSingle(obj) {
    return confirmCustom("您确定要不启用该数据吗？", obj);
}

//置顶提示
function popStick(obj) {
    return confirmAlertCustom("您确定要置顶选中数据吗？", "请选择要置顶的数据！", obj);
}
function popStickSingle(obj) {
    return confirmCustom("您确定要置顶该数据吗？", obj);
}

//取消置顶提示
function popCancelStick(obj) {
    return confirmAlertCustom("您确定要取消置顶选中数据吗？", "请选择要取消置顶的数据！", obj);
}
function popCancelStickSingle(obj) {
    return confirmCustom("您确定要取消置顶该数据吗？", obj);
}

//推荐提示
function popRecommend(obj) {
    return confirmAlertCustom("您确定要推荐选中数据吗？", "请选择要推荐的数据！", obj);
}
function popRecommendSingle(obj) {
    return confirmCustom("您确定要推荐该数据吗？", obj);
}

//取消推荐提示
function popCancelRecommend(obj) {
    return confirmAlertCustom("您确定要取消推荐选中数据吗？", "请选择要取消推荐的数据！", obj);
}
function popCancelRecommendSingle(obj) {
    return confirmCustom("您确定要取消推荐该数据吗？", obj);
}

//弹出自定义确认、警告信息
function confirmAlertCustom(constr, alestr, obj) {
    var num = document.getElementsByTagName("input");
    var cnum = checknum(num);
    if (cnum == 0) {
        top.Dialog.alert(alestr);
    }
    else {
        top.Dialog.confirm(constr, function () { __doPostBack($(obj).attr("name"), ""); top.msgbox.prompt("操作中，请稍候...", 4); });
    }
    return false;
}
//弹出自定义确认信息
function confirmCustom(constr, obj) {
    top.Dialog.confirm(constr, function () { location.href = $(obj).attr("href"); top.msgbox.prompt("操作中，请稍候...", 4); });
    return false;
}

//判断是否只有一个选中了
function checknum(num) {
    var cnum = 0;
    for (i = 0; i < num.length; i++) {
        if (num[i].type == "checkbox" && num[i].id.indexOf("_chkChoose") >= 0) {
            if (num[i].checked == true && num[i].name != '') {
                cnum++;
            }
        }
    }
    return cnum;
}