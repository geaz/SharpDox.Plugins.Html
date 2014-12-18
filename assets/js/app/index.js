var doNotLoad = false;

$(document).ready(function () {
    if (window.attachEvent) { // ::sigh:: IE8 support
        window.attachEvent("onmessage", OnLoadPage, false);
    } else {
        window.addEventListener("message", OnLoadPage, false);
    }

    $(window).hashchange(function () {
        if (!doNotLoad)
            navigationController.setDocSite(window.location.hash.slice(1));
        else {
            doNotLoad = false;
            navigationController.selectNode('node-' + window.location.hash.slice(1));
        }
    });

    $('body').layout({
        center__maskIframesOnResize: true,
        defaults: {
            paneClass: "ui-outer",
            resizerClass: "ui-outer-resizer",
            closable: false,
            resizable: false
        },
        north: {
            size: 131
        },
        west: {
            resizable: true,
            size: 350
        }
    });
	
	$('#content').load(function () {		
        navigationController.hideLoader();
    });

    navigationController = new NavigationController();
	searchController = new SearchController("#searchInput", "#searchResults", searchIndex);
});

function OnLoadPage(event) {
    if (event.data != null) {
        if (window.location.hash != event.data && event.data != 'showLoader' && event.data != 'hideLoader') {
            doNotLoad = true;
            window.location.hash = event.data;
        }
        else if (event.data == 'showLoader') {
            navigationController.showLoader();
        }
		else if (event.data == 'hideLoader') {
            navigationController.hideLoader();
        }
    }
}
