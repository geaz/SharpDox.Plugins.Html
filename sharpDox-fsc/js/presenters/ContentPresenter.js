import RiotView from '../RiotView';

export default class ContentPresenter{
    constructor(templateUrl, stateContainer, siteStateChanger){           
        let self = this;    
        this._stateContainer = stateContainer;
        this._siteStateChanger = siteStateChanger;
        this._view = new RiotView(templateUrl, "sd-content", () =>{
            self._stateContainer.registerSubscriber(self);
            self._initPresenter();
            self._bindView();
        });
    }
       
    notify(state){
        for(let key in this._view.tags){
            this._view.tags[key].update({
                currentPageType: state.get("currentPageType")
            });
        }        
    }
        
    _initPresenter(){
        let self = this;
        
        
    }
        
    _bindView(){
        for(let key in this._view.tags){
            this._view.tags[key].update({
                
            });
        }        
    }  
}