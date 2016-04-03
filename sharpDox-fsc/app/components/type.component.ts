import {Component, Input} from 'angular2/core';
import {RouteParams} from 'angular2/router';

import {ContentBase} from '../ContentBase';
import {StateService} from '../state/StateService';
import {SiteStateChanger} from '../state/SiteStateChanger';

import {MemberComponent} from './member.component';

@Component({
    selector: 'sd-type',
    templateUrl: '/templates/content/type/type.html',
    styleUrls: ['./templates/content/type/type.css'],
    directives: [MemberComponent]
})
export class TypeComponent extends ContentBase { 
    
    public currentPageData : any = {};
    
    constructor(_routeParams : RouteParams, 
                _siteStateChanger : SiteStateChanger,                
                _stateService : StateService){ 
        super("sd-type", _routeParams, _siteStateChanger, _stateService);   
    }
    
    ngOnInit(){
        let id = this._routeParams.get('id');
        this._siteStateChanger.setCurrentPageToType(id);
    }
    
}