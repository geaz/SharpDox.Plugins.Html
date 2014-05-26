$(document).ready(function () {

    $.each($('.svgpan'), function (index, value) {
        var parentId = $(value).attr('id');
        var id = "#" + parentId + " svg";
        var svgDia = svgPanZoom(id, { 'minZoom': 0.1, fit: false });
    });
	
	$('.resetZoom a').click(function () {
        var svgPan = svgPanZoom("#" + $(this).parent().parent().prev().attr('id') + " svg");
        svgPan.resetZoom();
        svgPan.center();
    });
	
	var gotClicked = false;
	$('.save a').click(function () {
		if($(this).attr('href') == "#") //just create diagram one time
		{
			var svgPan = svgPanZoom("#" + $(this).parent().parent().prev().attr('id') + " svg");
			svgPan.resetZoom();
			svgPan.center();

			var isClassDiagram = $(this).parent().parent().prev().attr('id') == "sd-class-diagram";
			if(isClassDiagram) gotClicked = false; //if classdiagram set gotClicked to false
		
			var bbox = $($(this).parent().parent().prev().children()[0])[0].getBBox();
			var svgData = "<svg xmlns='http://www.w3.org/2000/svg' width='" + (bbox.width + 10) + "' height='" + (bbox.height + 55) + "'>" + $($($($(this).parent().parent().prev()).children()[0]).children()[0]).html().trim() + "</svg>";
		
			var link = this;
			var canvas = document.createElement('canvas');
			canvg(canvas, svgData, {
				renderCallback: function() {
					var png_dataurl = canvas.toDataURL();
					link.download = "diagram.png";
					link.href = png_dataurl;
				
					//Classdiagrams get not downloaded automatically - workaround
					if(isClassDiagram && !gotClicked){
						gotClicked = true;
						link.click();
					}
				}
			});
		}
    });

    $('.member-content').css('display', 'none');
	
});