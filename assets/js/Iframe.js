$(window).on("load", function () {
    resize();
});

$(window).on("resize", function() {
	resize();
});

function resize(){
    parent.postMessage($('#frame-content').outerHeight(true) + 155, '*');
}