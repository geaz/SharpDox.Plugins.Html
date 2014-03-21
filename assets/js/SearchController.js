var SearchController = function() {
	$('#search-wrapper i').on('click', function(){ 
		if($('#search-wrapper').css('right') == '0px'){
			$('#search-wrapper').animate({'right':'-275px'});
		}
		else{
			$('#search-wrapper').animate({'right':'0px'});
		}
	});
	
	this._mouseDownHappened = false;
	this._searchcontext = $('#navigation-data');
}

SearchController.prototype = {

	search: function(searchString){
		if(searchString != null && searchString != ""){
			var searchresult = this._searchcontext.find('p:contains("' + searchString + '")');
			var result = [];
			$.each(searchresult, function(key, value){
				var name = $(value).text();
				var dataType = $(value).parent().parent().attr('data-type');
				var dataUrl = $(value).parent().parent().attr('data-url');
				if(dataType != null && dataUrl != null){
					result.push(new SearchEntry(name, dataType, dataUrl));
				}
			});
			
			$('#search-result').empty();
			var that = this;
			var ul = document.createElement('ul');
			if(result.length > 0){
				$.each(result, function(key, value){	
					var li = document.createElement('li');
					$(li).addClass('search-entry');
					$(li).append('<a href="#' + value.dataUrl + '"><p>' + value.name + '</p><small>' + value.dataType + '</small></a>');
					$(li).on('mousedown', function() { that._mouseDownHappened = true; });
					$(li).on('mouseup', function() { that.hide(); });
					
					$(ul).append($(li));
				});
			}
			else{
			}
			$('#search-result').append(ul);
			if(!$('#search-result').is(':visible')){
				$('#search-result-wrapper').show()
				$('#search-result').slideToggle();
			}
		}
		else{
			$('#search-result').empty();
			this.hide();
		}
	},
	
	hide: function(){	
		if(!this._mouseDownHappened){
			if($('#search-result').is(':visible')){			
				$('#search-result').slideToggle("fast", function() { $('#search-result-wrapper').hide() });
			}
		}
		else{
			this._mouseDownHappened = false;
		}
	}
	
};