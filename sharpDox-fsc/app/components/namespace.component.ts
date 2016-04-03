import {Component, Input} from 'angular2/core';
import {RouteParams} from 'angular2/router';

import {ContentBase} from '../ContentBase';
import {StateService} from '../state/StateService';
import {SiteStateChanger} from '../state/SiteStateChanger';

@Component({
    selector: 'sd-namespace',
    templateUrl: '/templates/content/namespace/namespace.html',
    styleUrls: ['./templates/content/namespace/namespace.css']
})
export class NamespaceComponent extends ContentBase { 
    
    public currentPageData : any = {};
    
    constructor(_routeParams : RouteParams, 
                _siteStateChanger : SiteStateChanger,                
                _stateService : StateService){ 
        super("sd-namespace", _routeParams, _siteStateChanger, _stateService);   
    }
    
    ngOnInit(){
        let id = this._routeParams.get('id');
        this._siteStateChanger.setCurrentPageToNamespace(id);
    }
    
}