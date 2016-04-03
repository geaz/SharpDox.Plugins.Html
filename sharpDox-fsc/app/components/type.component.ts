import {Component, Input} from 'angular2/core';
import {RouteParams} from 'angular2/router';

import {ContentBase} from '../ContentBase';
import {StateService} from '../state/StateService';
import {SiteStateChanger} from '../state/SiteStateChanger';

@Component({
    selector: 'sd-type',
    templateUrl: '/templates/content/type/type.html',
    styleUrls: ['./templates/content/type/type.css']
})
export class TypeComponent extends ContentBase { 
    
    public currentPageData : any = {};
    
    constructor(private _routeParams : RouteParams, 
                private _siteStateChanger : SiteStateChanger,                
                _stateService : StateService){ 
        super("sd-type", _stateService);
    }
    
    notify(state){
        this.currentPageData = state.get("SiteStateChanger.currentPageData");
    }
    
    ngAfterViewInit(){
        let id = this._routeParams.get('id');
        this._siteStateChanger.setCurrentPageToType(id);
    }
    
}