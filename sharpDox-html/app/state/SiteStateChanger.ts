import {Injectable} from '@angular/core';
import { StateChanger } from 'fsc';
import { StateService } from './StateService';

@Injectable()
export class SiteStateChanger extends StateChanger{     
    
    constructor(private stateService : StateService){
        super();
        this.stateService.stateContainer.registerStateChanger(this);
    }
      
    setSelectedTargetFx(targetFx : string) : void{
        this.triggerChange({'selectedTargetFx': targetFx});
    }

    setCurrentPage(id : string, type : string, reload : boolean = false) : boolean{
        let pageChanged = false;
        let currentPageId = this.requestStateCopy()['SiteStateChanger.currentPageId'];
        if(currentPageId != id || reload){
            pageChanged = true;
            if(type == 'article') {
                this.setCurrentPageToArticle(id);
            }
            else if(type == 'type'){
                this.setCurrentPageToType(id);
            }
            else if(type == 'namespace'){
                this.setCurrentPageToNamespace(id);
            }
        }        
        return pageChanged;
    } 
    
    resetCurrentPage() : void{
        let currentState = this.requestStateCopy();
        let currentPageType = currentState['SiteStateChanger.currentPageType'];
        let currentPageId = currentState['SiteStateChanger.currentPageId'];
        this.setCurrentPage(currentPageId, currentPageType, true);       
    }

    showLoader(show : boolean) : void{
        this.triggerChange({'showLoader':show});
    }

    private setCurrentPageToArticle(id : string) : void{     
        this.triggerChange({'showLoader': true, 'currentPageId': null});
        
        let that = this;
        $.getJSON("data/articles/" + id + ".json", function( data ) {            
            let changes = { };                     
            changes['currentPageTargetFxs'] = sharpDox.projectData.targetFxs;
            changes['currentPageType'] = 'article';
            changes['currentPageId'] = id;
            changes['currentPageData'] = data;
            
            that.triggerChange(changes);
        });
    } 
    
    private setCurrentPageToNamespace(id : string) : void{
        this.triggerChange({'showLoader': true, 'currentPageId': null});    
        
        let that = this;   
        $.getJSON("data/namespaces/" + id + ".json", function( namespace ) {           
            let currentState = that.requestStateCopy();
            let changes = { };  
            changes['currentPageTargetFxs'] = Object.keys(namespace);
            
            if(namespace[currentState['SiteStateChanger.selectedTargetFx']] !== undefined){ 
                changes['currentPageData'] = namespace[currentState['SiteStateChanger.selectedTargetFx']];     
            }
            else{
                changes['selectedTargetFx'] = Object.keys(namespace)[0];
                changes['currentPageData'] = namespace[Object.keys(namespace)[0]];    
            }
            
            changes['currentPageType'] = 'namespace';
            changes['currentPageId'] = id;
            that.triggerChange(changes);
        });
    } 
    
    private setCurrentPageToType(id : string) : void{
        this.triggerChange({'showLoader': true, 'currentPageId': null});      
        
        let that = this;  
        $.getJSON("data/types/" + id + ".json", function( type ) {
            let currentState = that.requestStateCopy();            
            let changes = { };  
            changes['currentPageTargetFxs'] = Object.keys(type);
            
            if(type[currentState['SiteStateChanger.selectedTargetFx']] !== undefined){ 
                changes['currentPageData'] = type[currentState['SiteStateChanger.selectedTargetFx']];
            }
            else{
                changes['selectedTargetFx'] = Object.keys(type)[0];
                changes['currentPageData'] = type[Object.keys(type)[0]];      
            }
            
            changes['currentPageType'] = 'type';
            changes['currentPageId'] = id;            
            that.triggerChange(changes);
        });
    } 
    
    getInitialState(){
        return {            
            'showLoader': true,
            'selectedTargetFx': sharpDox.projectData.targetFxs[0],
            'currentPageTargetFxs': sharpDox.projectData.targetFxs,
            'currentPageType':'',
            'currentPageId': null,
            'currentPageData': {}
        }
    }
    
    getName(){ return "SiteStateChanger"; }
    
};