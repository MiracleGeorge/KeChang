/*edited by fukai*/

(function ($) {
    $.fn.validationEngineLanguage = function () { };
    $.validationEngineLanguage = {
        newLang: function () {
            $.validationEngineLanguage.allRules = {
                "required": {
                    "regex": "none",
                    "alertText": "* 非空选项.",
                    "alertTextCheckboxMultiple": "* 请选择一个选项",
                    "alertTextCheckboxe": "* 您必须钩选此项"
                },
                "minSize": {
                    "regex": "none",
                    "alertText": "* 最少 ",
                    "alertText2": " 个字符"
                },
                "maxSize": {
                    "regex": "none",
                    "alertText": "* 最多 ",
                    "alertText2": " 个字符"
                },
                "min": {
                    "regex": "none",
                    "alertText": "* 最小值为 "
                },
                "max": {
                    "regex": "none",
                    "alertText": "* 最大值为 "
                },
                "dateRange": {
                    "regex": "none",
                    "alertText": "* 无效的 ",
                    "alertText2": " 日期范围"
                },
                "dateTimeRange": {
                    "regex": "none",
                    "alertText": "* 无效的 ",
                    "alertText2": " 时间范围"
                },
                "past": {
                    "regex": "none",
                    "alertText": "* 日期必需早于 "
                },
                "future": {
                    "regex": "none",
                    "alertText": "* 日期必需晚于 "
                },
                "maxCheckbox": {
                    "regex": "none",
                    "alertText": "* 最多选择 ",
                    "alertText2": " 项."
                },
                "minCheckbox": {
                    "regex": "none",
                    "alertText": "* 至少选择 ",
                    "alertText2": " 项."
                },
                "equals": {
                    "regex": "none",
                    "alertText": "* 两次输入不一致,请重新输入."
                },
                "groupRequired": {
                    "regex": "none",
                    "alertText": "* 你必需选填其中一个"
                },
                "telephone": {
                    "regex": "^(0[0-9]{2,3}\-)?([2-9][0-9]{6,7})+(\-[0-9]{1,4})?$",
                    "alertText": "* 请输入有效的电话号码,如:010-29292929."
                },
                "fax": {
                    "regex": "^(0[0-9]{2,3}\-)?([2-9][0-9]{6,7})+(\-[0-9]{1,4})?$",
                    "alertText": "* 请输入有效的传真号码,如:010-29292929."
                },
                "mobilephone": {
                    "regex": "^[1][3,5,8,7][0-9]{9}$",
                    "alertText": "* 请输入有效的手机号码."
                },
                "muchTel": {
                    "regex": "^(1[3,5,8,7]{1}[\\d]{9})|(((400)-(\\d{3})-(\\d{4}))|^((\\d{7,8})|(\\d{4}|\\d{3})-(\\d{7,8})|(\\d{4}|\\d{3})-(\\d{3,7,8})-(\\d{4}|\\d{3}|\\d{2}|\\d{1})|(\\d{7,8})-(\\d{4}|\\d{3}|\\d{2}|\\d{1}))$)$",
                    "alertText": "* 请输入有效的电话号码."
                },
                "email": {
                    "regex": "^[a-zA-Z0-9_\.\-]+\@([a-zA-Z0-9\-]+\.)+[a-zA-Z0-9]{2,4}$",
                    "alertText": "* 请输入有效的邮箱地址."
                },
                "date": {
                    "regex": "^(([0-9]{3}[1-9]|[0-9]{2}[1-9][0-9]{1}|[0-9]{1}[1-9][0-9]{2}|[1-9][0-9]{3})-(((0[13578]|1[02])-(0[1-9]|[12][0-9]|3[01]))|((0[469]|11)-(0[1-9]|[12][0-9]|30))|(02-(0[1-9]|[1][0-9]|2[0-8]))))|((([0-9]{2})(0[48]|[2468][048]|[13579][26])|((0[48]|[2468][048]|[3579][26])00))-02-29)$",
                    "alertText": "* 请输入有效的日期,如:2008-08-08."
                },
                "datetime": {
                    "regex": "^((([0-9]{3}[1-9]|[0-9]{2}[1-9][0-9]{1}|[0-9]{1}[1-9][0-9]{2}|[1-9][0-9]{3})-(((0[13578]|1[02])-(0[1-9]|[12][0-9]|3[01]))|((0[469]|11)-(0[1-9]|[12][0-9]|30))|(02-(0[1-9]|[1][0-9]|2[0-8]))))|((([0-9]{2})(0[48]|[2468][048]|[13579][26])|((0[48]|[2468][048]|[3579][26])00))-02-29))\\s+([0-1]?[0-9]|2[0-3]):([0-5][0-9]):([0-5][0-9])$",
                    "alertText": "* 请输入有效的日期时间,如:2008-08-08 08:08:08."
                },
                "ip": {
                    "regex": "^(?:(?:25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\.){3}(?:25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)$",
                    "alertText": "* 请输入有效的IP."
                },
                "chinese": {
                    "regex": "^[\u4e00-\u9fa5]+$",
                    "alertText": "* 请输入中文."
                },
                "url": {
                    "regex": "^http(s)?://([\\w-]+\\.)+[\\w-]+(/[\\w- ./?%&=]*)?",
                    "alertText": "* 请输入有效的网址."
                },
                "zipcode": {
                    "regex": "^[1-9]\\d{5}$",
                    "alertText": "* 请输入有效的邮政编码."
                },
                "qq": {
                    "regex": "^[1-9]\\d{4,9}$",
                    "alertText": "* 请输入有效的QQ号码."
                },
                "onlyNumber": {
                    "regex": "^[-]?[0-9]+$",
                    "alertText": "* 请输入数字."
                },
                "onlyNumberWide": {
                    "regex": "^[-]?\\d+(\\.\\d{1,4})?$",
                    "alertText": "* 请输入整数或小数."
                },
                "onlyDecimal": {
                    "regex": "^[-]?\\d+(\\.\\d{1,4})$",
                    "alertText": "* 请输入4位以内的小数."
                },
                "illegalLetter": {
                    "regex": "^[^\`\{\}\[!\(\+~@#%\^&\*\)\|\\\\:;\'\"><\?/=_]+$",
                    "alertText": "* 含有非法字符,请检查."
                },
                "onlyLetter": {
                    "regex": "^[a-zA-Z]+$",
                    "alertText": "* 请输入英文字母."
                },
                "noSpecialCaracters": {
                    "regex": "^[0-9a-zA-Z]+$",
                    "alertText": "* 请输入英文字母或数字."
                },
                "username": {
                    "regex": "^[a-zA-Z][0-9a-zA-Z_]{3,15}$",
                    "alertText": "* 4~16个字符，可使用字母、数字及下划线，需以字母开头."
                },
                //后台脚本文件，插件会POST两个参数：fieldId；fieldValue，后台脚本直接 request即可
                "ajaxUser": {
                    "url": "/SYS/DataAction.aspx",
                    "extraData": "act=ajaxUser",
                    "alertText": "* 用户名已存在."
                },
                "ajaxUserPwd": {
                    "url": "/SYS/DataAction.aspx",
                    "extraData": "act=ajaxUserPwd",
                    "alertText": "* 原密码错误."
                },
                "ajaxValidateCode": {
                    "url": "/View/DataAction.aspx",
                    "extraData": "act=ajaxValidateCode",
                    "alertText": "* 验证码错误."
                },
                "ajaxMembername": {
                    "url": "/DataAction/MemberAction.aspx",
                    "extraData": "act=ajaxMembername",
                    "alertText": "* 用户名已存在."
                },
                "ajaxMemberPwd": {
                    "url": "/DataAction/MemberAction.aspx",
                    "extraData": "act=ajaxMemberPwd",
                    "alertText": "* 原密码错误."
                },
                "ajaxMemberEmail": {
                    "url": "/DataAction/MemberAction.aspx",
                    "extraData": "act=ajaxMemberEmail",
                    "alertText": "* 邮箱已存在."
                },
                "ajaxMemberEmail2": {
                    "url": "/DataAction/MemberAction.aspx",
                    "extraData": "act=ajaxMemberEmail2",
                    "alertText": "* 邮箱不存在."
                },
                "ajaxVerifyCode": {
                    "url": "/DataAction/MemberAction.aspx",
                    "extraData": "act=ajaxVerifyCode",
                    "alertText": "* 验证码错误."
                },
                "ajaxVerifyCode2": {
                    "url": "/DataAction/MemberAction.aspx",
                    "extraData": "act=ajaxVerifyCode2",
                    "alertText": "* 验证码错误."
                }
            }
        }
    }
})(jQuery);

$(document).ready(function () {
    $.validationEngineLanguage.newLang();

    //表单验证
    $("form").validationEngine();
    $("form").bind("jqv.form.result", function (event, errorFound) {
        if (errorFound) {
            top.msgbox.prompt("红色框内容填写不正确，请按要求填写！", 1);
        }
    })
});

//保存显示加载状态
function SaveLoading() {
    if ($("form").validationEngine("validate")) {
        top.msgbox.prompt("操作中，请稍候...", 4);
    }
}

//验证身份证号
function checkIdCard(field, rules, i, options) {
    if (field.val() == "") return;
    //这个可以验证15位和18位的身份证，并且包含生日和校验位的验证。   
    //如果有兴趣，还可以加上身份证所在地的验证，就是前6位有些数字合法有些数字不合法。 
    var num = field.val().toUpperCase();
    //身份证号码为15位或者18位，15位时全为数字，18位前17位为数字，最后一位是校验位，可能为数字或字符X。   
    if (!(/(^\d{15}$)|(^\d{17}([0-9]|X)$)/.test(num))) {
        return "* 请输入有效的身份证号码.";
    }
    //校验位按照ISO 7064:1983.MOD 11-2的规定生成，X可以认为是数字10。 
    //下面分别分析出生日期和校验位 
    var len, re;
    len = num.length;
    if (len == 15) {
        re = new RegExp(/^(\d{6})(\d{2})(\d{2})(\d{2})(\d{3})$/);
        var arrSplit = num.match(re);

        //检查生日日期是否正确 
        var dtmBirth = new Date('19' + arrSplit[2] + '/' + arrSplit[3] + '/' + arrSplit[4]);
        var bGoodDay;
        bGoodDay = (dtmBirth.getYear() == Number(arrSplit[2])) && ((dtmBirth.getMonth() + 1) == Number(arrSplit[3])) && (dtmBirth.getDate() == Number(arrSplit[4]));
        if (!bGoodDay) {
            return "* 请输入有效的身份证号码.";
            return false;
        }
        else {
            //将15位身份证转成18位 
            //校验位按照ISO 7064:1983.MOD 11-2的规定生成，X可以认为是数字10。 
            var arrInt = new Array(7, 9, 10, 5, 8, 4, 2, 1, 6, 3, 7, 9, 10, 5, 8, 4, 2);
            var arrCh = new Array('1', '0', 'X', '9', '8', '7', '6', '5', '4', '3', '2');
            var nTemp = 0, i;
            num = num.substr(0, 6) + '19' + num.substr(6, num.length - 6);
            for (i = 0; i < 17; i++) {
                nTemp += num.substr(i, 1) * arrInt[i];
            }
            num += arrCh[nTemp % 11];
            //return num;  
            return true;
        }
    }
    if (len == 18) {
        re = new RegExp(/^(\d{6})(\d{4})(\d{2})(\d{2})(\d{3})([0-9]|X)$/);
        var arrSplit = num.match(re);

        //检查生日日期是否正确 
        var dtmBirth = new Date(arrSplit[2] + "/" + arrSplit[3] + "/" + arrSplit[4]);
        var bGoodDay;
        bGoodDay = (dtmBirth.getFullYear() == Number(arrSplit[2])) && ((dtmBirth.getMonth() + 1) == Number(arrSplit[3])) && (dtmBirth.getDate() == Number(arrSplit[4]));
        if (!bGoodDay) {
            return "* 请输入有效的身份证号码.";
            return false;
        }
        else {
            //检验18位身份证的校验码是否正确。 
            //校验位按照ISO 7064:1983.MOD 11-2的规定生成，X可以认为是数字10。 
            var valnum;
            var arrInt = new Array(7, 9, 10, 5, 8, 4, 2, 1, 6, 3, 7, 9, 10, 5, 8, 4, 2);
            var arrCh = new Array('1', '0', 'X', '9', '8', '7', '6', '5', '4', '3', '2');
            var nTemp = 0, i;
            for (i = 0; i < 17; i++) {
                nTemp += num.substr(i, 1) * arrInt[i];
            }
            valnum = arrCh[nTemp % 11];
            if (valnum != num.substr(17, 1)) {
                return "* 请输入有效的身份证号码.";
                return false;
            }
            //return num; 
            return true;
        }
    }
    return false;
}