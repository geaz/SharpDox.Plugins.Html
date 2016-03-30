import RiotView from '../RiotView';

export default class FooterPresenter{
    constructor(templateUrl){           
        let self = this;    
        this._view = new RiotView(templateUrl, "sd-footer", () =>{
            self._bindView();
        }); 
    }
        
    _bindView(){
        for(let key in this._view.tags){
            this._view.tags[key].update({
                projectName: sharpDox.projectData.name,
                author: sharpDox.projectData.author,
                homepage: sharpDox.projectData.homepage,
                version: sharpDox.projectData.version,
                footerLine: sharpDox.projectData.footerLine,
                footerText: sharpDox.strings.footerText
            });
        }        
    }  
}