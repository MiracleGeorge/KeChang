//ajax修改

$(function () {
    $(".tableMain table tr td .lbl_ajaxUpdate").click(function () {
        //判断是否有修改权限
        if ($(this).closest("tr").find("td:last a[id$='lnk_update']").length > 0) {
            $(this).hide().siblings(".txt_ajaxUpdate").show().select();
            $(this).hide().siblings(".ddl_ajaxUpdate").show().focus();
        }
    })
    $(".tableMain table tr td .txt_ajaxUpdate").keydown(function (e) {
        if (e.which == 13) {
            $(this).blur();
            return false;
        }
    })
    $(".tableMain table tr td .txt_ajaxUpdate").blur(function () {
        if ($(this).validationEngine("validate")) {
            return;
        }
        $(this).siblings(".lbl_ajaxUpdate").text($(this).val());
        $(this).hide().siblings(".lbl_ajaxUpdate").show();
        //ajax更新
        ajaxUpdate($(this).closest("tr").find("td:first input[type='hidden'][id$='hf_id']").val(), $(this).attr("field"), $(this).val());
    })
    $(".tableMain table tr td .ddl_ajaxUpdate").change(function (e) {
        $(this).blur();
        return false;
    })
    $(".tableMain table tr td .ddl_ajaxUpdate").blur(function () {
        if ($(this).validationEngine("validate")) {
            return;
        }
        $(this).siblings(".lbl_ajaxUpdate").text($(this).find("option:selected").text());
        $(this).hide().siblings(".lbl_ajaxUpdate").show();
        //ajax更新
        ajaxUpdate($(this).closest("tr").find("td:first input[type='hidden'][id$='hf_id']").val(), $(this).attr("field"), $(this).val());
    })
    $(".tableMain table tr td .img_ajaxUpdate").click(function () {
        //判断是否有修改权限
        if ($(this).closest("tr").find("td:last a[id$='lnk_update']").length > 0) {
            if ($(this).attr("data-value") == "1") {
                $(this).attr("data-value", "0");
                $(this).attr("src", $(this).attr("src").replace("active.gif", "no_active.gif"));
            }
            else {
                $(this).attr("data-value", "1");
                $(this).attr("src", $(this).attr("src").replace("no_active.gif", "active.gif"));
            }
            //ajax更新
            ajaxUpdate($(this).closest("tr").find("td:eq(0) input[type='hidden'][id$='hf_id']").val(), $(this).attr("field"), $(this).attr("data-value"));
        }
    })
})

function ajaxUpdate(id, field, value) {
    $.ajax({
        type: "POST",
        url: "/View/DataAction.aspx",
        data: {
            act: "AjaxUpdate",
            bllName: $("#bllName").val(),
            id: id,
            field: field,
            value: value
        },
        success: function (data) { },
        error: function () { }
    });
}