
//$(document).ready(function () {
 
//    alert($(".chosen-single")).val()
//})

//添加订单
$("#addOrder").live("click", function () {
  
    $.ajax({
        url: "/REBATE/PolicyService.asmx/GetBrandAndItemList",
        type: "post",
        datatype: "json",
        //contentType:"application/json;charset=utf-8",
        success: function (data) {

            var brandObj = $.parseJSON(data);
            var brandOption = "";
            var itemOption = "";
            //读取品牌数据
            $.each(brandObj.brandList, function (i, item) {

                brandOption += "<option value=" + item.id + ">" + item.Name + "</option>";
            })
            $.each(brandObj.itemList, function (i, item) {

                itemOption += "<option value=" + item.id + ">" + item.Name + "</option>";
            })
            var node = "<tr>";
            node += "<td align=\"center\">";
            node += " <select name=\"ddl_brand\" class=\"validate[required]\"><option value=\"0\">请选择<option/>" + brandOption + "</select>";
            node += "</td>";
            node += "<td align=\"center\">";
            node += "<select name=\"ddl_item\"><option value=\"0\">请选择<option/>" + itemOption + "</select>";
            node += "</td>";
            node += "<td align=\"center\">";
            node += "<input type=\"text\" name=\"ddl_DisCount\" class=\"validate[required,custom[onlyNumberWide]] input_100\" />";
            //node += "</td>";
            //node += "<td align=\"center\">";
            //node += "<input type=\"text\" name=\"txt_inspectiondate\" class=\"validate[required,custom[date]] Wdate input_100\"  onfocus=\"WdatePicker()\"  />";
            //node += "</td>";  
            //node += "<td align=\"center\">";
            //node += "<input type=\"text\" name=\"txt_SRdate\" class=\"validate[custom[date]] Wdate input_100\" onfocus=\"this.blur()\" />";
            //node += "</td>";
            //node += "<td align=\"center\">";
            //node += "<input type=\"text\" name=\"txt_readatet\" class=\"validate[custom[date]] Wdate input_100\" onfocus=\"this.blur()\" />";
            //node += "</td>";
            //node += "<td align=\"center\">";
            //node += "<input type=\"text\" name=\"txt_inspectionAmount\" class=\"validate[required,custom[onlyNumberWide]] input_100\" />";
            //node += "</td>";
            node += "<td align=\"center\">";
            node += "<a href=\"javascript:;\" class=\"deleteOrder\">删行</a>";
            node += "</td>";
            node += "</tr>";
            $("#addOrder").next().append(node);
            $(function () {
                $("select").chosen();
                $("select").each(function () {
                    if ($(this).hasClass("validate[required]")) {
                        $(this).next(".chosen-container").addClass("validate[required]");
                    }
                })
            })
        }
    }
       )
   
})


//删除订单
$(".deleteOrder").live("click", function () {
    $(this).closest("tr").remove();
})

//添加报告
$("#addReport").live("click", function () {
    var id = 1;
    if ($(this).next().find("tr").length > 4) {
        id = parseInt($(this).next().find("tr:last input[name='rdreportresult_id']").val()) + 1;
    }
    var node = "<tr>";
    node += "<td align=\"center\">";
    node += "<input type='hidden' name='rdreportresult_id' value='" + id + "' />";
    node += "<input type=\"text\" name=\"txt_reportcode\" class=\"validate[required,maxSize[50]] input_100\" />";
    node += "</td>";
    node += "<td align=\"center\">";
    node += "<input type=\"radio\" name=\"rdreportresult_" + id + "\" value='1' />";
    node += "</td>";
    node += "<td align=\"center\">";
    node += "<input type=\"radio\" name=\"rdreportresult_" + id + "\" value='2' />";
    node += "</td>";
    node += "<td align=\"center\">";
    node += "<input type=\"radio\" name=\"rdreportresult_" + id + "\" value='3' />";
    node += "</td>";
    node += "<td align=\"center\">";
    node += "<input type=\"radio\" name=\"rdreportresult_" + id + "\" value='4' />";
    node += "</td>";
    node += "<td align=\"center\">";
    node += "<select name=\"txt_failreason\"><option>--请选择--</option><option>Shipping mark</option><option>Barcode</option><option>PSI missing</option><option>Packaging physical</option><option>Packaging printings</option><option>IM / label</option><option>Function / Assembly</option><option>Over AQL</option><option>Safety</option><option>Product Construction</option><option>Raw material / moisture</option><option>Appearance</option><option>Differences between CC and PSI</option><option>Other (fill in remarks)</option></select>";
    node += "</td>";
    node += "<td align=\"center\">";
    node += "<input type=\"text\" name=\"txt_failcomment\" class=\"validate[maxSize[3000]] input_100\" />";
    node += "</td>";
    node += "<td align=\"center\">";
    node += "<a href=\"javascript:;\" class=\"deleteReport\">删行</a>";
    node += "</td>";
    node += "</tr>";
    $(this).next().append(node);
})
//删除报告
$(".deleteReport").live("click", function () {
    $(this).closest("tr").remove();
})

//添加价格
$("#addPrice").live("click", function () {
    var node = "<tr>";
    node += "<td align=\"center\">";
    node += "<input type=\"text\" name=\"txt_TestItem\" class=\"validate[required,funcCall[checkOrderNo]] input_100\" />";
    node += "</td>";
    node += "<td align=\"center\">";
    node += "<input type=\"text\" name=\"txt_ReferenceClause\" class=\"validate[required] input_100\" />";
    node += "</td>";
    node += "<td align=\"center\">";
    node += "<input type=\"text\" name=\"txt_Testunitprice\" class=\"validate[required,custom[onlyNumberWide]] input_100\" />";
    node += "</td>";
    node += "<td align=\"center\">";
    node += "<input type=\"text\" name=\"txt_Testqty\" class=\"validate[required,custom[onlyNumberWide]] input_100\" />";
    node += "</td>";
    node += "<td align=\"center\">";
    node += "<input type=\"text\" name=\"txt_Testsubtotal\" class=\"validate[required,custom[onlyNumberWide]] input_100\"  onfocus=\"this.blur()\" />";
    node += "</td>";
    node += "<td align=\"center\">";
    node += "<a href=\"javascript:;\" class=\"deletePrice\">删行</a>";
    node += "</td>";
    node += "</tr>";
    $(this).next().append(node);
})
//删除价格
$(".deletePrice").live("click", function () {
    $(this).closest("tr").remove();
})
