import {Component, Input} from '@angular/core';
import {ActivatedRoute} from '@angular/router';
import {DomSanitizationService} from '@angular/platform-browser';

import {ContentBase} from './ContentBase';
import {StateService} from '../../state/StateService';
import {SiteStateChanger} from '../../state/SiteStateChanger';

@Component({
    selector: 'sd-namespace',
    templateUrl: './templates/content/namespace/namespace.html',
    styleUrls: ['./templates/content/namespace/namespace.css']
})
export class NamespaceComponent extends ContentBase { 
    
    public currentPageData : any = {};

    private _routeSubscription : any;
    
    constructor(private _sanitizer: DomSanitizationService,
                _route : ActivatedRoute,                 
                _siteStateChanger : SiteStateChanger,                
                _stateService : StateService){ 
        super("sd-namespace", _route, _siteStateChanger, _stateService);
    }

    ngOnInit(){    
        this._routeSubscription = this._route.params.subscribe(params => {
            let id = params['id'];
            this._siteStateChanger.setCurrentPageToNamespace(id);
        });
    }

    ngOnDestroy(){
        this._routeSubscription.unsubscribe();
        super.ngOnDestroy();
    }

    notify(state, changedStates){
        var currentPagId = state.get("SiteStateChanger.currentPageData");
        if(changedStates.indexOf("SiteStateChanger.currentPageData") > -1 && currentPagId !== undefined){
            this.currentPageData = state.get("SiteStateChanger.currentPageData");
            super.contentChanged();
        }        
    } 
}