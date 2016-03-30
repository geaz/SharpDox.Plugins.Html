import RiotView from '../RiotView';

export default class HeaderPresenter{
    constructor(templateUrl){       
        let self = this;        
        this._view = new RiotView(templateUrl, "sd-header", () =>{
            self._bindView();    
        }); 
    }
        
    _bindView(){
        for(let key in this._view.tags){
            this._view.tags[key].update({
                projectName: sharpDox.projectData.name,
		        hasLogo: sharpDox.projectData.hasLogo,
            });
        }        
    }   
}