//纵向菜单脚本
$(function () {
    $(".list_menu a:not('.disabled')").click(function () {
        $(this).parent().addClass("current").siblings().removeClass("current");
    })
});