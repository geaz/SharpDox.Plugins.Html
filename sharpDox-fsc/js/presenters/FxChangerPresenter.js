import RiotView from '../RiotView';

export default class FxChangerPresenter{
    constructor(templateUrl, siteStateChanger, cb){  
        let self = this;             
        this._siteStateChanger = siteStateChanger;
        this._view = new RiotView(templateUrl, "sd-fxChanger", () => {
            self._bindView();
            cb();
        }); 
    }
        //SWITCHER!!!
    notify(state){
        for(let key in this._view.tags){
            this._view.tags[key].update({
                selectedTargetFx: state.get("selectedTargetFx"),
                currentPageTargetFxs: state.get("currentPageTargetFxs")
            });
        }        
    }
            
    _bindView(){
        let self = this;
        for(let key in this._view.tags){
            this._view.tags[key].setTargetFx = (event) => {
                self._siteStateChanger.setSelectedTargetFx(event.target.value)
            }; 
        }
    }    
}