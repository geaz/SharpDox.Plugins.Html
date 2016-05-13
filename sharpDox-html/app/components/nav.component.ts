import {Component, Inject} from 'angular2/core';
import {ROUTER_DIRECTIVES} from 'angular2/router';

import {StateService} from '../state/StateService';

@Component({
    selector: 'sd-nav',
    templateUrl: './templates/nav/nav.html',
    styleUrls: ['./templates/nav/nav.css'],
    directives: [ROUTER_DIRECTIVES]
})
export class NavComponent { 
    
    private _subscriberId : number;
    private _autoSelect : boolean;
    
    constructor(private _stateService : StateService){ }
    
    ngAfterViewInit(){
        $('#nav').jstree({
            'core' : {
                'data' : sharpDox.navigationData
            }
        });
        
        var self = this;
        $("#nav").bind("select_node.jstree", function(e, data) {
            if(!self._autoSelect){
                var href = data.instance.get_node(data.node, true).children('a').attr('href');
                if (href != "#")
                    document.location = href;

                data.instance.open_node(data.node);	
                return false;
            }
            else { self._autoSelect = false; }
        });
        
        this._subscriberId = this._stateService.stateContainer.registerSubscriber(this);
    }
    
    ngOnDestory(){
        this._stateService.stateContainer.unregisterSubscriber(this._subscriberId);
    }
    
    notify(state, changedStates){
        let currentPageId = state.get('SiteStateChanger.currentPageId');
        if((changedStates === null || changedStates.indexOf("SiteStateChanger.currentPageId") > -1) 
            && currentPageId !== undefined && currentPageId !== 'home'){
                
            this._autoSelect = true;
            $('#nav').jstree('deselect_all');
            $('#nav').jstree('select_node', currentPageId);  
               
        }              
    }
    
}