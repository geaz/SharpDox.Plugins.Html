import {Component, Inject} from '@angular/core';
import {ROUTER_DIRECTIVES} from '@angular/router';
import {State, NotifySubscriber} from 'fsc';

import {StateService} from '../state/StateService';

@Component({
    selector: 'sd-nav',
    templateUrl: './templates/nav/nav.html',
    styleUrls: ['./templates/nav/nav.css'],
    directives: [ROUTER_DIRECTIVES]
})
export class NavComponent implements NotifySubscriber{ 
    
    private subscriberId : number;
    private autoSelect : boolean;
    
    constructor(private stateService : StateService){ }
    
    ngAfterViewInit(){
        var self = this;
        $('#nav').bind('ready.jstree', function(e, data) {
            $("#nav").bind("select_node.jstree", function(e, data) {
                if(!self.autoSelect){
                    var href = data.instance.get_node(data.node, true).children('a').attr('href');
                    if (href != "#")
                        document.location = href;

                    data.instance.open_node(data.node);	
                    return false;
                }
                else { self.autoSelect = false; }
            });              
            self.subscriberId = self.stateService.stateContainer.registerSubscriber(self, true);  
        });

        $('#nav').jstree({
            'core' : {
                'data' : sharpDox.navigationData
            }
        });
    }
    
    ngOnDestory(){
        this.stateService.stateContainer.unregisterSubscriber(this.subscriberId);
    }
    
    notify(state : State){
        let currentPageId = state['SiteStateChanger.currentPageId'];
        if(currentPageId !== null && currentPageId !== 'home'){                
            this.autoSelect = true;
            $('#nav').jstree('deselect_all');
            $('#nav').jstree('select_node', currentPageId);                 
        }     
        else{
            $('#nav').jstree('deselect_all');
        }         
    }
    
}