$(window).on("load", function () {
    resize();
});

function resize(){	
	var splittedUrl = window.location.toString().split('/');
	var site = splittedUrl[splittedUrl.length - 1];
	var splittedSite = site.split('?');
	var siteUrl = '#' + splittedSite[0].substring(0, splittedSite[0].length - 5);
	
    parent.postMessage($('#frame-content').outerHeight(true) + 200, '*');
    parent.postMessage(siteUrl, '*');
}