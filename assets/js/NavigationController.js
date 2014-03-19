var NavigationController = function() {
	this._oldHash = "";
	this._navigationRoot = $('#navigation-root').clone(true);
}

NavigationController.prototype = {

	init: function(dataUrl){
		if(dataUrl == ""){
			this.loadRoot();
		}
		else{
			this.loadDataUrl(dataUrl);
		}
	},

	loadRoot: function(){
		var newNav = this._navigationRoot.clone(true);
		$('#navigation').empty();
		$('#navigation').append(newNav);
		newNav.show();
		this.initNav();
		
		this.setDocSite("article/home.html");
	},
	
	loadDataUrl: function(dataUrl){
		if(dataUrl == "" || dataUrl == this._oldHash){
			return
		}		
		this._oldHash = dataUrl;
		
		var navItem = this._navigationRoot.find('li[data-url="' + dataUrl + '"]');
		var type = navItem.attr('data-type');
		var childNav = navItem.children('ul');
		
		if(childNav.length == 0){
			var newNav = this._navigationRoot.find('li[data-url="' + dataUrl + '"]').parent().clone(true);
		}
		else{
			var newNav = childNav.clone(true);
		}
		
		if(newNav != null && newNav.length > 0){
			$('#navigation').empty();
			$('#navigation').append(newNav);
			newNav.show();
			this.initNav();
		}	
		
		if(type == "member"){
			var splitted = dataUrl.split('?');
			this.setDocSite('type/' + splitted[0] + '.html#' + splitted[1]);
		}
		else if(type != null){
			this.setDocSite(type + "/" + dataUrl + ".html");
		}
	},
	
	initNav: function(){
		var that = this;
		$('#navigation>ul>li').has('ul[class="navigation-sub"]').click(function () {	
			var newNav = $(this).children('ul').clone(true);
			newNav.show();
			
			$('#navigation').empty();
			$('#navigation').append(newNav);	
			
			that.initNav();
		});

		$('.navigation-back a').click(function () {	
			var newNav = history.pop();
			newNav.show();
			
			$('#navigation').empty();
			$('#navigation').append(newNav);	

			that.initNav();
		});
	},
	
	setDocSite: function(site){
		$("#docframe").attr('src', site);
	}

};