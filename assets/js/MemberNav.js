var activeDiv;

$(window).on("load", function () {
    $(window).hashchange(function() {
        onHashChange();
    });

	$(window).hashchange();
});

function onHashChange(){
	if(window.location.hash) {
		if(activeDiv != undefined) activeDiv.hide();
		activeDiv = $(window.location.hash);

		$(window.location.hash).show();
		changed(window.location.hash);
	} else {
		if(activeDiv != undefined) activeDiv.hide();
		activeDiv = $("#typeIndex");

		$("#typeIndex").show();
		changed();
	}
}

function changed(displayedMember){
    var body = document.body,
    html = document.documentElement,
    height = body.offsetHeight + 50;
    if(height === 0){
        height = html.offsetHeight + 50;
    }
    parent.postMessage({'height' : height, 'displayMember': displayedMember}, '*');
}