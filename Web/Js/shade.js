

//单条数据操作提示
function alertShade(alestr, url, idName, title, width, height) {
    var num = document.getElementsByTagName("input");
    var cnum = checkSelect(num);
    if (cnum == 0) {
        top.Dialog.alert(alestr);
    }
    else if (cnum == 1) {
        showShade(url, idName, title, width, height);
    }
    else {
        top.Dialog.alert('您只能操作一条数据！');
    }
    return false;
}

//多条数据操作提示
function alertShadeMuch(alestr, url, idName, title, width, height) {
    var num = document.getElementsByTagName("input");
    var cnum = checkSelect(num);
    if (cnum == 0) {
        top.Dialog.alert(alestr);
    }
    else {
        showShade(url, idName, title, width, height);
    }
    return false;
}

//显示遮罩（无确认信息，直接显示）
function showShade(url, idName, title, width, height, obj) {
    var infoId;
    if (obj != undefined) {
        infoId = $(obj).parent().siblings(0).find("input[type='hidden']:eq(0)").val();
    }
    else {
        infoId = arrayId;
    }
    url = url + "?PageIndex=" + $("input[type='hidden'][id$='hf_pageIndex']").val() + "&ReturnUrl=" + $("input[type='hidden'][id$='hf_returnUrl']").val() + "&" + idName + "=" + infoId;
    dialogCustom(url, title, width, height);
    return false;
}

var arrayId = "";
//判断是否只有一个选中了
function checkSelect(num) {
    arrayId = "";
    var cnum = 0;
    for (i = 0; i < num.length; i++) {
        if (num[i].type == "checkbox" && num[i].id.indexOf("_chkChoose") >= 0) {
            if (num[i].checked == true && num[i].name != '') {
                cnum++;
                if (arrayId != "") arrayId += ",";
                arrayId += $(num[i]).next("input[type='hidden']").val();
            }
        }
    }
    return cnum;
}