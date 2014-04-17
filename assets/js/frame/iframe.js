var allExpanded = false;

$(document).ready(function () {	
    $('body').layout({
        defaults: {
            paneClass: "ui-inner",
            closable: false,
            resizable: false
        },
        north: {
            size: 70
        }
    });
	
	if(window.location.hash != ""){
		$(window.location.hash).effect("highlight", {}, 3000);
		slideDown($(window.location.hash).children()[0]);
	}
	
	$('.dropdown-menu a').click(function() {
		$($(this).attr('href')).effect("highlight", {}, 3000);
		window.location.hash = $(this).attr('href');
		slideDown($(window.location.hash).children()[0]);
		postUrl();
	});
	
	$('#sd-class-diagram a, #sd-sequence-diagram a').click(function() {
		window.location = $(this).attr('xlink:href');		
		$(window.location.hash).effect("highlight", {}, 3000);
		slideDown($(window.location.hash).children()[0]);
		postUrl();
		return false;
	});

	$('.member-header').click(function(){
		toggleSlide(this);
	});

	$('#expand-all-button').click(function(){
		if(allExpanded){
			allExpanded = false;
			$('.member-header').each(function(index){			
				slideUp(this);
			});
		}
		else{
			allExpanded = true;
			$('.member-header').each(function(index){			
				slideDown(this);
			});
		}
	});
	
	$('#print-button').click(function(){
		$('.ui-inner-center').print();
	});

	postUrl();
});

function slideUp(header){
	$(header).next().slideUp();				
	var icon = $($($(header).children()[0]).children()[0]);
	icon.removeClass('icon-caret-down');
	icon.addClass('icon-caret-right');
}

function slideDown(header){
	$(header).next().slideDown();				
	var icon = $($($(header).children()[0]).children()[0]);
	icon.removeClass('icon-caret-right');
	icon.addClass('icon-caret-down');
}

function toggleSlide(header){
	var body = $(header).next();
	body.slideToggle();
	
	var icon = $($($(header).children()[0]).children()[0]);
	if(icon.hasClass('icon-caret-right')){
		icon.removeClass('icon-caret-right');
		icon.addClass('icon-caret-down');
	}
	else{
		icon.removeClass('icon-caret-down');
		icon.addClass('icon-caret-right');
	}
}

function postUrl(){	
	var splittedUrl = window.location.toString().split('/');
	var site = splittedUrl[splittedUrl.length - 2] + "/" + splittedUrl[splittedUrl.length - 1];
	var splittedSite = site.split('#');
	var siteUrl = '#' + splittedSite[0].substring(0, splittedSite[0].length - 5);

	if(splittedSite.length == 2){
		siteUrl += '?' + splittedSite[1];
	}
	
    parent.postMessage(siteUrl, '*');
}