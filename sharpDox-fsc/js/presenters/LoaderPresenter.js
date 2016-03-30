import RiotView from '../RiotView';

export default class LoaderPresenter{
    constructor(templateUrl, cb){   
        this._view = new RiotView(templateUrl, "sd-loader", () => {
            cb();
        }); 
    }
    
    notify(state){
        for(let key in this._view.tags){
            this._view.tags[key].update({
                gettingPage: state.get("SiteStateChanger.gettingPage")
            });
        }        
    }    
}