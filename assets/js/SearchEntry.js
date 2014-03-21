var SearchEntry = function(name, dataType, dataUrl) {
	this.name = name;
	this.dataType = dataType;
	this.dataUrl = dataUrl;
}

Object.defineProperty(SearchEntry.prototype, 'name', {

    get: function() {
        return this._name;
    },
    
    set: function(value){
        this._name = value;
    }
    
});

Object.defineProperty(SearchEntry.prototype, 'dataType', {

    get: function() {
        return this._dataType;
    },
    
    set: function(value){
        this._dataType = value;
    }
    
});

Object.defineProperty(SearchEntry.prototype, 'dataUrl', {

    get: function() {
        return this._dataUrl;
    },
    
    set: function(value){
        this._dataUrl = value;
    }
    
});
