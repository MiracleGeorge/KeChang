<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Charts.aspx.cs" Inherits="Charts" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <script type="text/javascript" src="https://cdn.hcharts.cn/jquery/jquery-1.8.3.min.js"></script>
</head>
<body>
    <form id="form1" runat="server">
           <script src="https://cdn.hcharts.cn/highcharts/5.0.10/highcharts.js"></script>
    <script src="https://cdn.hcharts.cn/highcharts/5.0.10/modules/exporting.js"></script>

    <div id="container" style="min-width: 310px; height: 400px; max-width: 600px; margin: 0 auto"></div>



    <script type="text/javascript">


$(document).ready(function () {
    $.ajax({
        type: "POST",
        url: "/REBATE/PolicyService.asmx/GetChartsSource",
        data: "",
        dataType: "json",
        success: function (response) {
            $.each(response, function (indexInArray, valueOfElement) {

            });
            // Build the chart
            Highcharts.chart('container', {
                chart: {
                    plotBackgroundColor: null,
                    plotBorderWidth: null,
                    plotShadow: false,
                    type: 'pie'
                },
                title: {
                    text: '这里是标题'
                },
                tooltip: {
                    pointFormat: '{series.name}: <b>{point.percentage:.1f}%</b>'
                },
                plotOptions: {
                    pie: {
                        allowPointSelect: true,
                        cursor: 'pointer',
                        dataLabels: {
                            enabled: false
                        },
                        showInLegend: true
                    }
                },
                series: [{
                    name: 'Brands',
                    colorByPoint: true,
                    data: [{
                        name: '小明',
                        y: 10
                    }, {
                        name: '小红',
                        y: 20,
                        sliced: true,
                        selected: true
                    }, {
                        name: '小刚',
                        y: 30
                    }, {
                        name: '呵呵',
                        y: 10
                    }, {
                        name: '哈哈',
                        y: 20
                    }, {
                        name: '红红',
                        y: 10
                    }]
                }]
            });
        }
    });
   
});
    </script>
    </form>
</body>
</html>
