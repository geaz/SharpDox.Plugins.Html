$(document).ready(function () {
    $.each($('.svgpan'), function (index, value) {
        var parentId = $(value).attr('id');
        var id = "#" + parentId + " svg";
        var svgDia = svgPanZoom(id, { 'minZoom': 0.1 });

        var bbox = $(id + " g")[0].getBBox();
        var diaWidth = bbox.width;
        var diaHeight = bbox.height;

        var parentWidth = $(value).width();
        var parentHeight = $(value).height();

        svgDia.pan({ x: (parentWidth - diaWidth) / 2, y: (parentHeight - diaHeight) / 2 })
    });

    $('.member-content').css('display', 'none');
});