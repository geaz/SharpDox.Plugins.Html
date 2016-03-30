export default class RiotView{    
    constructor(templateUrl, cssSelector, cb){
        this.tags = [];
        
        this._templateUrl = templateUrl;
        this._cssSelector = cssSelector;
        this._loadView(cb);
    }   
    
    _loadView(cb){
        let self = this;
        riot.compile(self._templateUrl, function(){
            self.tags = riot.mount(self._cssSelector);
            cb();
        });
    }
}