$(document).ready(function () {
    $.each($('.svgpan'), function (index, value) {
        var parentId = $(value).attr('id');
        var id = "#" + parentId + " svg";
        var svgDia = svgPanZoom(id, { 'minZoom': 0.1, fit: false });
    });

    $('.member-content').css('display', 'none');
});