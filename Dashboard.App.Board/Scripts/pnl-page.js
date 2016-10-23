function showPnl(selDate) {
    $.get('/api/Pnls/' + selDate, function (data) {
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
    showPnl(selDate);

    $('#selDate').change(function () {
        showPnl($(this).val());
    });
})
