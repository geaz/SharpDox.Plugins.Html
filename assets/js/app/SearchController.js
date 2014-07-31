var SearchController = function(inputId, resultsDivId, searchIndex){
	this._searchIndex = searchIndex;
	this._resultsDivId = resultsDivId;
	this._resultsFound = false;
	this.init(inputId);
}

SearchController.prototype = {

	init: function(inputId){
		var searchController = this;
		
		$(inputId).on('input',function(e){
			searchController.search(this.value);
		});
		$(inputId).on('focus',function(e){
			searchController.showResults();
		});
		$(inputId).on('blur',function(e){
			searchController.hideResults();
		});
	},
	
	search: function(searchText){
		var searchController = this;
		searchController._resultsFound = false;
		
		var results = $(this._resultsDivId);
		results.empty();
		
		if(searchText != ""){
			results.append("<ul>");
			$.each(this._searchIndex, function(key, value){
				if(value.Name.toLowerCase().indexOf(searchText.toLowerCase()) > -1){
					results.append('<li><a href="' + value.Url + '">' + value.Name + '<p class="result-item-footer">' + value.Type + '</p></a></li>');
					searchController._resultsFound = true;
				}
			});
			results.append("</ul>");
			
			if(!searchController._resultsFound){
				results.append('<p class="no-results">No results found</p>');
			}
			
			this.showResults();
		}
		else{
			this.hideResults();
		}
	},

	showResults: function(){	
		if(this._resultsFound){
			$(this._resultsDivId).slideDown();
		}
	},
	
	hideResults: function(){
		$(this._resultsDivId).slideUp();
	}
	
}