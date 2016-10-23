function showChart() {
    $.get('/api/capitals', function (data) {
        console.log(data);
        var chartData = {
            labels: data.Labels,
            series: data.Data
        };
        new Chartist.Line('.ct-chart', chartData);
    });
}

$(function () {
    showChart();

})
