$(document).ready(function () {
	if (window.attachEvent) { // ::sigh:: IE8 support
		window.attachEvent("onmessage", OnLoadPage, false);
	} else {
		window.addEventListener("message", OnLoadPage, false);
	}
	
	HashLoad();
});

function OnLoadPage(event)
{
	var iframe = $('#docFrame');
	if (event.data != null)
	{
		window.location.hash = window.location.hash.split('#')[1];
		if(event.data.displayMember != null){
			var displayedMember = event.data.displayMember;			
			window.location.hash = window.location.hash.split('#')[1] + '#' + displayedMember.slice(1);
		}
		height = event.data.height;		
		iframe.height(parseInt(height));		
	}
	 
	window.scrollTo(0, 0);
}

function HashLoad(){
	if(window.location.hash != '' && window.location.hash != '#'){
		SetDocSite(window.location.hash.slice(1));
	}
	else{
		SetDocSite('article/home.html');
	}
}
