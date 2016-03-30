import RiotView from '../RiotView';

export default class TitlePresenter{
    constructor(templateUrl, cb){             
        this._view = new RiotView(templateUrl, "sd-titlebar", () => {
            cb();
        }); 
    }
        
    notify(state){
        for(let key in this._view.tags){
            this._view.tags[key].update({
                currentPageData: state.get("currentPageData"),
                currentPageType: state.get("currentPageType")
            });
        }        
    }  
}