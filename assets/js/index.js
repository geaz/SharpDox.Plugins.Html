$(document).ready(function () {	
	if (window.attachEvent) { // ::sigh:: IE8 support
        window.attachEvent("onmessage", OnLoadPage, false);
    } else {
        window.addEventListener("message", OnLoadPage, false);
    }
	
	$(window).hashchange(function() {
        navigationController.loadDataUrl(window.location.hash.slice(1));
    });	
	
	window.searchController = new SearchController();
	var navigationController = new NavigationController();
	navigationController.init(window.location.hash.slice(1));
});

function OnLoadPage(event) {
    var iframe = $('#docframe');
    if (event.data != null) {
		if(event.data.toString().indexOf('#') > -1){
			if(window.location.hash != event.data && event.data != '#home'){
				window.location.hash = event.data;
			}
		}
		else{
			var height = event.data;
			iframe.height(parseInt(height));	
		}		
    }
    window.scrollTo(0, 0);
}
