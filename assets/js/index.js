$(document).ready(function () {	
	$(window).hashchange(function() {
        navigationController.loadDataUrl(window.location.hash.slice(1));
    });	
	
	var navigationController = new NavigationController();
	navigationController.init(window.location.hash.slice(1));
});