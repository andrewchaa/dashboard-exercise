function showChart(selDate) {
    $.get('/api/dailyreturns/us/' + selDate, function (data) {
        console.log(data);
        var chartData = {
            labels: data.Labels,
            series: data.Data
        };
        new Chartist.Line('.ct-chart', chartData);
    });
}

$(function () {
    var selDate = $('#selDate').val();
    showChart(selDate);

    $('#selDate').change(function () {
        showChart($(this).val());
    });
})
