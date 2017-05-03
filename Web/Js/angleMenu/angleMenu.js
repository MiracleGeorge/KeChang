//横向菜单脚本
$(function () {
    $(".cusTab .cusTab_top .hand").click(function(){
        $(this).addClass("cusTab_current_center").siblings(".cusTab_normal_center").removeClass("cusTab_current_center");
        $(this).siblings(".cusTab_normal_middle").removeClass("cusTab_current_middle").removeClass("cusTab_current_middle2");
        $(this).prev(".cusTab_normal_middle").addClass("cusTab_current_middle2").removeClass("cusTab_current_middle");
        $(this).next(".cusTab_normal_middle").addClass("cusTab_current_middle").removeClass("cusTab_current_middle2");
        
        var index = $(this).index();
        var length = $(".cusTab .cusTab_top li").length;
        if(index == 1){
            $(".cusTab_normal_left").addClass("cusTab_current_left");
        }
        else{
            $(".cusTab_normal_left").removeClass("cusTab_current_left");
        }
        if(index == length - 2){
            $(".cusTab_normal_right").addClass("cusTab_current_right");
        }
        else{
            $(".cusTab_normal_right").removeClass("cusTab_current_right");
        }
        
        var local_index = (index - 1) / 2;
        $(".cusTab .cusTab_con:eq("+local_index+")").css("display","block").siblings(".cusTab_con").css("display","none");
    })
});