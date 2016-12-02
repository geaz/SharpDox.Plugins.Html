import {Component, Input} from '@angular/core';
import {ActivatedRoute} from '@angular/router';
import {DomSanitizationService} from '@angular/platform-browser';
import {State, NotifySubscriber} from 'fsc';

import {ContentBase} from './ContentBase';
import {StateService} from '../../state/StateService';
import {SiteStateChanger} from '../../state/SiteStateChanger';

@Component({
    selector: 'sd-namespace',
    templateUrl: './templates/content/namespace/namespace.html',
    styleUrls: ['./templates/content/namespace/namespace.css']
})
export class NamespaceComponent extends ContentBase implements NotifySubscriber{ 
        
    public currentPageData : any = {};
    
    constructor(route : ActivatedRoute,                 
                siteStateChanger : SiteStateChanger,                
                stateService : StateService){ 
        super('namespace', route, siteStateChanger, stateService);
    }

    notify(state : State) : void {
        var currentPagId = state["SiteStateChanger.currentPageData"];
        if(state.changedKeys.indexOf("SiteStateChanger.currentPageData") > -1 && currentPagId !== undefined){
            this.currentPageData = state["SiteStateChanger.currentPageData"];
            super.setChanged();
        }        
    } 
}