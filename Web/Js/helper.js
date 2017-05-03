; (function ($) {
    $.fn.extend({
        //文本框光标移至末尾
        textRangeEnd: function () {
            if ($(this)[0].createTextRange) {//IE浏览器
                var range = $(this)[0].createTextRange();
                range.move("character", $(this).val().length);
                range.collapse(true);
                range.select();
            } else {//非IE浏览器
                $(this)[0].setSelectionRange($(this).val().length, $(this).val().length);
                $(this)[0].focus();
            }
        },
        //银行卡号格式化
        bankFormat: function (obj) {
            var str = "";
            obj.val(obj.val().substr(0, 19));
            var account = obj.val();
            var index = account.length % 4 == 0 ? account.length / 4 : account.length / 4 + 1;
            for (var i = 0; i < index; i++) {
                if (str != "") str += " ";
                str += account.substr(i * 4, 4);
            }
            $(this).text(str);
        },
        //设置文本框只能输入数字
        setNumber: function () {
            $(this).prop("type", "tel").keypress(function (e) {
                return e.keyCode >= 48 && e.keyCode <= 57;
            })
        },
        //设置文本框只能输入数字/小数
        setDecimal: function () {
            $(this).prop("type", "tel").keypress(function (e) {
                return (e.keyCode >= 48 && e.keyCode <= 57) || e.keyCode == 46;
            })
        }
    });
})(jQuery);

//获取URL参数
function QueryString(name) {
    var reg = new RegExp("(^|&)" + name + "=([^&]*)(&|$)");
    var r = window.location.search.substr(1).match(reg);
    if (r != null) return unescape(r[2]); return "";
}

//在图片名称前加入一个字符，得到缩略图的地址
function SmallImageFilePath(imagefile, smallstring) {
    var stem = "";
    if ($.trim(imagefile) != "") {
        var str = imagefile.split("/");
        for (var i = 0; i < str.length; i++) {
            //最后一个
            if (str.length != 0 && i == str.length - 1) {
                stem += smallstring + str[i];
            }
            else {
                stem += str[i] + "/";
            }
        }
    }
    return stem;
}

//设置时间format
Date.prototype.Format = function (format) {
    /* 
    * eg:format="yyyy-MM-dd hh:mm:ss"; 
    */
    var o = {
        "M+": this.getMonth() + 1, // month
        "d+": this.getDate(), // day
        "h+": this.getHours() % 12 == 0 ? 12 : this.getHours() % 12, //hour
        "H+": this.getHours(), // hour  
        "m+": this.getMinutes(), // minute  
        "s+": this.getSeconds(), // second  
        "q+": Math.floor((this.getMonth() + 3) / 3), // quarter  
        "S": this.getMilliseconds()
        // millisecond  
    };

    if (/(y+)/.test(format)) {
        format = format.replace(RegExp.$1, (this.getFullYear() + "").substr(4 - RegExp.$1.length));
    }

    for (var k in o) {
        if (new RegExp("(" + k + ")").test(format)) {
            format = format.replace(RegExp.$1, RegExp.$1.length == 1 ? o[k] : ("00" + o[k]).substr(("" + o[k]).length));
        }
    }
    return format;
};

//表单验证
function FormValidate() {
    return $("form").validationEngine("validate");
}