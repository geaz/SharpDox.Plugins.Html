$(document).ready(function(){
	$.each($('.svgpan'), function(index, value){
		var id = $(value).attr('id');
		id = "#" + id + " svg";
		svgPanZoom.init({ 'selector': id, 'minZoom': 0.1 });
	});
});