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
    var splittedUrl = window.location.toString().split('/');
	var site = splittedUrl[splittedUrl.length - 1];
	var splittedSite = site.split('#');
	var siteUrl = '#' + splittedSite[0].substring(0, splittedSite[0].length - 5);
	
	if(splittedSite.length == 2){
		siteUrl += '?' + splittedSite[1];
	}
	
    parent.postMessage($('#frame-content').outerHeight(true) + 200, '*');
	parent.postMessage(siteUrl, '*');
}