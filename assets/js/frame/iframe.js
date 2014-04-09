$(document).ready(function () {	
    $('body').layout({
        defaults: {
            paneClass: "ui-inner",
            closable: false,
            resizable: false
        }
    });

	$('.member-header').click(function(){
		$(this).next().slideToggle();		
		
		var icon = $($($(this).children()[0]).children()[0]);
		if(icon.hasClass('icon-caret-right')){
			icon.removeClass('icon-caret-right');
			icon.addClass('icon-caret-down');
		}
		else{
			icon.removeClass('icon-caret-down');
			icon.addClass('icon-caret-right');
		}
	});

	$('#expand-all-button').click(function(){
		$('.member-header').each(function(index){
			$(this).next().slideDown();
			
			var icon = $($($(this).children()[0]).children()[0]);
			icon.removeClass('icon-caret-right');
			icon.addClass('icon-caret-down');
		});
	});
	
	$('#print-button').click(function(){
		$('.ui-inner-center').print();
	});

	postUrl();
});

function postUrl(){	
	var splittedUrl = window.location.toString().split('/');
	var site = splittedUrl[splittedUrl.length - 2] + "/" + splittedUrl[splittedUrl.length - 1];
	var siteUrl = '#' + site.substring(0, site.length - 5);

    parent.postMessage(siteUrl, '*');
}