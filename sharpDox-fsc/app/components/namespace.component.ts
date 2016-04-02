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
    
    public strings : any;
    public disqusShortName : string;
    public currentPageData : any = {};
    
    constructor(private _routeParams : RouteParams, 
                private _siteStateChanger : SiteStateChanger,                
                _stateService : StateService){ 
        super("sd-namespace", _stateService);
        this.strings = sharpDox.strings;
        this.disqusShortName = sharpDox.projectData.disqusShortName;
    }
    
    notify(state){
        this.currentPageData = state.get("SiteStateChanger.currentPageData");
    }
    
    ngAfterViewInit(){
        let id = this._routeParams.get('id');
        this._siteStateChanger.setCurrentPageToNamespace(id);
        
        $('#main').scrollTop(0);        
    }
    
}