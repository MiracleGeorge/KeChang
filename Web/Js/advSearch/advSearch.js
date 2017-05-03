//高级搜索脚本
$(function () {
    var expanded = true;
    $("#advSearch .bar").click(function () {
        if (expanded) {
            $("#advSearch table").show();
            $("#advSearch .bar").css('background-position', '-0px 0px');
        } else {
            $("#advSearch table").fadeOut(300);
            $("#advSearch .bar").css('background-position', '-25px 0px');
        }
        expanded = !expanded;
    });
});