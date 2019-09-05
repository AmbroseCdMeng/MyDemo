window.onload = function () {

    var echart_1 = echarts.init(document.getElementById('chart-1'));
    var echart_2 = echarts.init(document.getElementById('chart-2'));
    var echart_3 = echarts.init(document.getElementById('chart-3'));
    var echart_4 = echarts.init(document.getElementById('chart-4'));

    var data = [5, 20, 36, 10, 10, 20];
    init_chart(echart_1, data);
    init_chart(echart_2, data);
    init_chart(echart_3, data);
    init_chart(echart_4, data);

}

function init_chart(target, data) {
    var option = {
        title: {
            text: 'ECharts 示例'
        },
        tooltip: {},
        legend: {
            data: ['销量']
        },
        xAxis: {
            data: ["衬衫", "羊毛衫", "雪纺衫", "裤子", "高跟鞋", "袜子"]
        },
        yAxis: {},
        series: [{
            name: '销量',
            type: 'bar',
            data: data
        }]
    };

    // 使用刚指定的配置项和数据显示图表。
    target.setOption(option);

}
