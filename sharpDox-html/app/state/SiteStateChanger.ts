import {Injectable} from '@angular/core';
import { StateChanger } from '../../vendor/FSC';
import { StateService } from './StateService';

@Injectable()
export class SiteStateChanger extends StateChanger{     
    
    constructor(private _stateService : StateService){
        super();      
        this._stateService.stateContainer.registerStateChanger(this);
    }
      
    setSelectedTargetFx(targetFx : string) : void{
        this._triggerChange({'selectedTargetFx': targetFx});
    }
   
    setCurrentPageToArticle(id : string) : void{     
        this._triggerChange({'gettingPage': true, 'currentPageId': undefined});
        
        let that = this;
        $.getJSON("data/articles/" + id + ".json", function( data ) {            
            let changes = { };                      
            changes['gettingPage'] = false;
            changes['currentPageTargetFxs'] = sharpDox.projectData.targetFxs;
            changes['currentPageType'] = 'article';
            changes['currentPageId'] = id;
            changes['currentPageData'] = data;
            
            that._triggerChange(changes);
        });
    } 
    
    setCurrentPageToNamespace(id : string) : void{
        this._triggerChange({'gettingPage': true, 'currentPageId': undefined});    
        
        let that = this;   
        $.getJSON("data/namespaces/" + id + ".json", function( namespace ) {           
            let currentState = that._requestCurrentState();
            let changes = { };  
            changes['gettingPage'] = false;
            changes['currentPageTargetFxs'] = Object.keys(namespace);
            
            if(namespace[currentState.get('SiteStateChanger.selectedTargetFx')] !== undefined){ 
                changes['currentPageData'] = namespace[currentState.get('SiteStateChanger.selectedTargetFx')];     
            }
            else{
                changes['selectedTargetFx'] = Object.keys(namespace)[0];
                changes['currentPageData'] = namespace[Object.keys(namespace)[0]];    
            }
            
            changes['currentPageType'] = 'namespace';
            changes['currentPageId'] = id;
            that._triggerChange(changes);
        });
    } 
    
    setCurrentPageToType(id : string) : void{
        this._triggerChange({'gettingPage': true, 'currentPageId': undefined});      
        
        let that = this;  
        $.getJSON("data/types/" + id + ".json", function( type ) {
            let currentState = that._requestCurrentState();            
            let changes = { };  
            changes['gettingPage'] = false;
            changes['currentPageTargetFxs'] = Object.keys(type);
            
            if(type[currentState.get('SiteStateChanger.selectedTargetFx')] !== undefined){ 
                changes['currentPageData'] = type[currentState.get('SiteStateChanger.selectedTargetFx')];
            }
            else{
                changes['selectedTargetFx'] = Object.keys(type)[0];
                changes['currentPageData'] = type[Object.keys(type)[0]];      
            }
            
            changes['currentPageType'] = 'type';
            changes['currentPageId'] = id;            
            that._triggerChange(changes);
        });
    } 
    
    resetCurrentPage() : void{
        let currentState = this._requestCurrentState();
        let currentPageType = currentState.get('SiteStateChanger.currentPageType');
        let currentPageId = currentState.get('SiteStateChanger.currentPageId');
        
        if(currentPageType === 'article') { this.setCurrentPageToArticle(currentPageId); } 
        else if(currentPageType === 'namespace') { this.setCurrentPageToNamespace(currentPageId); }  
        else if(currentPageType === 'type') { this.setCurrentPageToType(currentPageId); }         
    }
    
    get initialState(){
        return {            
            'gettingPage': false,
            'selectedTargetFx': sharpDox.projectData.targetFxs[0],
            'currentPageTargetFxs': sharpDox.projectData.targetFxs,
            'currentPageType':'',
            'currentPageId': undefined,
            'currentPageData': {}
        }
    }
    
    get name(){ return "SiteStateChanger"; }
    
};