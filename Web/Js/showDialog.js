//弹出窗口

function dialog(url, title) {
    top.Dialog.open({ URL: url, ID: "a" + $("#hf_dialogIndex", top.document).val(), Width: 950, Height: 500, Title: title, ShowMaxButton: true });
    $("#hf_dialogIndex", top.document).val(parseInt($("#hf_dialogIndex", top.document).val()) + 1);
    return false;
}

function dialogSb(url, title) {
    top.Dialog.open({ URL: url, ID: "a" + $("#hf_dialogIndex", top.document).val(), Width: 500, Height: 280, Title: title, ShowMaxButton: true });
    $("#hf_dialogIndex", top.document).val(parseInt($("#hf_dialogIndex", top.document).val()) + 1);
    return false;
}

function dialogQuo(url, title) {
    top.Dialog.open({ URL: url, ID: "a" + $("#hf_dialogIndex", top.document).val(), Width: 950, Height: 500, Title: title, ShowMaxButton: true });
    $("#hf_dialogIndex", top.document).val(parseInt($("#hf_dialogIndex", top.document).val()) + 1);
    return false;
}

function dialogCustom(url, title, width, height) {
    top.Dialog.open({ URL: url, ID: "a" + $("#hf_dialogIndex", top.document).val(), Width: width, Height: height, Title: title, ShowMaxButton: true });
    $("#hf_dialogIndex", top.document).val(parseInt($("#hf_dialogIndex", top.document).val()) + 1);
    return false;
}

function dialogAdd(url, extend) {
    url = url + "?PageIndex=1&ReturnUrl=" + $("input[type='hidden'][id$='hf_returnUrl']").val();
    if (extend != undefined) {
        url += extend;
    }
    dialog(url, "添加数据");
    return false;
}

function dialogQuoAdd(url, extend) {
    url = url + "?PageIndex=1&ReturnUrl=" + $("input[type='hidden'][id$='hf_returnUrl']").val();
    if (extend != undefined) {
        url += extend;
    }
   
    dialogQuo(url, "添加数据");
    return false;
}

function dialogAddCustom(url, width, height, extend) {
    url = url + "?PageIndex=1&ReturnUrl=" + $("input[type='hidden'][id$='hf_returnUrl']").val();
    if (extend != undefined) {
        url += extend;
    }
    dialogCustom(url, "添加数据", width, height);
    return false;
}

function dialogUpdate(url, idName) {
    if (checkUpdate()) {
        url = url + "?PageIndex=" + $("input[type='hidden'][id$='hf_pageIndex']").val() + "&ReturnUrl=" + $("input[type='hidden'][id$='hf_returnUrl']").val() + "&" + idName + "=" + arrayId;
        dialog(url, "修改数据");
    }
    return false;
}

function dialogSumbit(url, idName) {
    if (checkUpdate()) {
        url = url + "?PageIndex=" + $("input[type='hidden'][id$='hf_pageIndex']").val() + "&ReturnUrl=" + $("input[type='hidden'][id$='hf_returnUrl']").val() + "&" + idName + "=" + arrayId;
        dialogSb(url, "提交数据");
    }
    return false;
}

function dialogRejected(url, idName) {
    if (checkUpdate()) {
        url = url + "?PageIndex=" + $("input[type='hidden'][id$='hf_pageIndex']").val() + "&ReturnUrl=" + $("input[type='hidden'][id$='hf_returnUrl']").val() + "&" + idName + "=" + arrayId;
        dialogQuo(url, "退回数据");
    }
    return false;
}

function dialogQuoUpdate(url, idName) {
    if (checkUpdate()) {
        url = url + "?PageIndex=" + $("input[type='hidden'][id$='hf_pageIndex']").val() + "&ReturnUrl=" + $("input[type='hidden'][id$='hf_returnUrl']").val() + "&" + idName + "=" + arrayId;
        dialogQuo(url, "修改数据");
    }
    return false;
}

function dialogQuoPriceUpdate(url, idName) {
    if (checkUpdate()) {
        url = url + "?PageIndex=" + $("input[type='hidden'][id$='hf_pageIndex']").val() + "&ReturnUrl=" + $("input[type='hidden'][id$='hf_returnUrl']").val() + "&" + idName + "=" + arrayId;
        dialogQuo(url, "价格修改数据");
    }
    return false;
}

function dialogQuoOtherUpdate(url, idName) {
    if (checkUpdate()) {
        url = url + "?PageIndex=" + $("input[type='hidden'][id$='hf_pageIndex']").val() + "&ReturnUrl=" + $("input[type='hidden'][id$='hf_returnUrl']").val() + "&" + idName + "=" + arrayId;
        dialogQuo(url, "其它信息修改数据");
    }
    return false;
}

function dialogUpdateCustom(url, idName, width, height) {
    if (checkUpdate()) {
        url = url + "?PageIndex=" + $("input[type='hidden'][id$='hf_pageIndex']").val() + "&ReturnUrl=" + $("input[type='hidden'][id$='hf_returnUrl']").val() + "&" + idName + "=" + arrayId;
        dialogCustom(url, "修改数据", width, height);
    }
    return false;
}

function dialogUpdateSingle(url) {
    dialog(url, "修改数据");
    return false;
}

function dialogquoUpdateSingle(url) {
    dialogQuo(url, "修改数据");
    return false;
}

function dialogUpdateCustomSingle(url, width, height) {
    dialogCustom(url, "修改数据", width, height);
    return false;
}

function dialogDetail(url) {
    dialog(url, "查看数据");
}

function dialogquoDetail(url) {
    dialogQuo(url, "查看数据");
}

function dialogInsquoDetail(url, idName) {
    if (checkUpdate()) {
        url = url + "?PageIndex=" + $("input[type='hidden'][id$='hf_pageIndex']").val() + "&ReturnUrl=" + $("input[type='hidden'][id$='hf_returnUrl']").val() + "&" + idName + "=" + arrayId;
        dialogQuo(url, "查看数据");
    }
    return false;
}

function dialogDetailCustom(url, width, height) {
    dialogCustom(url, "查看数据", width, height);
}

function dialogCheck(url, title, idName) {
    if (checkUpdate()) {
        url = url + "?PageIndex=" + $("input[type='hidden'][id$='hf_pageIndex']").val() + "&ReturnUrl=" + $("input[type='hidden'][id$='hf_returnUrl']").val() + "&" + idName + "=" + arrayId;
        dialog(url, title);
    }
    return false;
}

function dialogCheckCustom(url, title, idName, width, height) {
    if (checkUpdate()) {
        url = url + "?PageIndex=" + $("input[type='hidden'][id$='hf_pageIndex']").val() + "&ReturnUrl=" + $("input[type='hidden'][id$='hf_returnUrl']").val() + "&" + idName + "=" + arrayId;
        dialogCustom(url, title, width, height);
    }
    return false;
}

//获取当前iframe的ID
function getFrameId() {
    var frameId;
    var url = location.href;
    $("iframe", top.document).each(function () {
        if ($(this).get(0).contentWindow.document.location.href == url) {
            frameId = $(this).get(0).id;
            return false;
        }
    })
    return frameId;
}

var arrayId = "";
//判断选中
function checkUpdate() {
    arrayId = "";
    var cnum = 0;
    var num = document.getElementsByTagName("input");
    for (i = 0; i < num.length; i++) {
        if (num[i].type == "checkbox" && num[i].id.indexOf("_chkChoose") >= 0) {
            if (num[i].checked == true && num[i].name != '') {
                cnum++;
                if (arrayId != "") arrayId += ",";
                arrayId += $(num[i]).next("input[type='hidden']").val();
            }
        }
    }
    if (cnum == 0) {
        top.Dialog.alert('请选择要操作的数据！');
        return false;
    }
    else if (cnum != 1) {
        top.Dialog.alert('您只能操作一条数据！');
        return false;
    }
    else {
        return true;
    }
}

function dialogShowTaskCustom(url, title, width, height) {
    top.Dialog.open({ URL: url, ID: "b1", Width: width, Height: height, Title: title });
}