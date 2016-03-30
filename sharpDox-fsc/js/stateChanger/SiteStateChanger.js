import $ from 'jquery';
import { StateChanger } from '../../vendor/FSC';

export default class SiteStateChanger extends StateChanger{       
    setSelectedTargetFx(targetFx){
        this._triggerChange({'selectedTargetFx': targetFx});
    }
   
    setToHome(){
        this._triggerChange({'gettingPage': true});
        
        let that = this;
        $.getJSON("data/articles/home.json", function( data ) {  
            let changes = { };                      
            changes['gettingPage'] = false;
            changes['currentPageTargetFxs'] = sharpDox.projectData.targetFxs;
            changes['currentPageType'] = 'article';
            changes['currentPageId'] = undefined;
            changes['currentPageData'] = data;
            
            that._triggerChange(changes);
        });
    }
   
    setCurrentPageToArticle(id){        
        this._triggerChange({'gettingPage': true});
        
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
    
    setCurrentPageToNamespace(id){
        this._triggerChange({'gettingPage': true});    
        
        let that = this;   
        $.getJSON("data/namespaces/" + id + ".json", function( namespace ) {           
            let currentState = this._requestCurrentState();
            let changes = { };  
            changes['gettingPage'] = false;
            changes['currentPageTargetFxs'] = Object.keys(namespace);
            
            if(namespace[currentState.get('selectedTargetFx')] !== undefined){ 
                changes['currentPageData'] = namespace[currentState.get('selectedTargetFx')];     
            }
            else{
                changes['selectedTargetFx'] = Object.keys(namespace)[0];
                changes['currentPageData'] = namespace[0];    
            }
            
            changes['currentPageType'] = 'namespace';
            changes['currentPageId'] = id;
            
            that._triggerChange(changes);
        });
    } 
    
    setCurrentPageToType(id){
        this._triggerChange({'gettingPage': true});      
        
        let that = this;  
        $.getJSON("data/types/" + id + ".json", function( type ) {
            let currentState = this._requestCurrentState();            
            let changes = { };  
            changes['gettingPage'] = false;
            changes['currentPageTargetFxs'] = Object.keys(type);
            
            if(type[currentState.get('selectedTargetFx')] !== undefined){ 
                changes['currentPageData'] = type[currentState.get('selectedTargetFx')];
            }
            else{
                changes['selectedTargetFx'] = Object.keys(type)[0];
                changes['currentPageData'] = type[0];      
            }
            
            changes['currentPageType'] = 'type';
            changes['currentPageId'] = id;
            
            that._triggerChange(changes);
        });
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