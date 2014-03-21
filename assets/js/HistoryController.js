var HistoryController = function() {
	this._history = [];
}

HistoryController.prototype = {

	add: function(name, url){
		this.history.push(new HistoryEntry(name, url));
		this.refreshHistoryBar();
	},
	
	refreshHistoryBar: function(){
		var historyBar = $('#historybar');
		var historyEntry = this.history[this.history.length - 1];
		
		if(this.history.length > 1){
			historyBar.append('<li><i class="historyicon icon-chevron-sign-right"></i></li>');	
		}
		var entry = $('<li><a class="historyentry" href="#' + historyEntry.dataUrl + '"> ' + historyEntry.name + '</a></li>');
		historyBar.append(entry);
		entry.show('fast');		
		
		if(this.history.length > 1 && !$('#historybar-wrapper').is(':visible')){
			$('#historybar-wrapper').show();
			$('#historybar-wrapper').animate({'bottom': '0'});
			$('#search-wrapper').animate({'bottom': '44px'});
			$('#sidebar').css('margin-bottom', '44px');
			$('#content').css('margin-bottom', '44px');
		}
		
		if($('#historybar').get(0).scrollWidth > $('#historybar').width()){
			historyBar.animate({'scrollLeft':$('#historybar').get(0).scrollWidth - $('#historybar').width()});
		}
	}
	
};

Object.defineProperty(HistoryController.prototype, 'history', {

    get: function() {
        return this._history;
    },
    
    set: function(value){
        this._history = value;
    }
    
});