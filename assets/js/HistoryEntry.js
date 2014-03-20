var HistoryEntry = function(name, dataUrl) {
	this.name = name;
	this.dataUrl = dataUrl;
}

Object.defineProperty(HistoryEntry.prototype, 'name', {

    get: function() {
        return this._name;
    },
    
    set: function(value){
        this._name = value;
    }
    
});


Object.defineProperty(HistoryEntry.prototype, 'dataUrl', {

    get: function() {
        return this._dataUrl;
    },
    
    set: function(value){
        this._dataUrl = value;
    }
    
});
