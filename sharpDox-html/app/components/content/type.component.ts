import {Component, Input} from '@angular/core';
import {ActivatedRoute} from '@angular/router';
import {DomSanitizationService} from '@angular/platform-browser';

import {ContentBase} from './ContentBase';
import {StateService} from '../../state/StateService';
import {SiteStateChanger} from '../../state/SiteStateChanger';

import {MemberComponent} from './member.component';

@Component({
    selector: 'sd-type',
    templateUrl: './templates/content/type/type.html',
    styleUrls: ['./templates/content/type/type.css'],
    directives: [MemberComponent]
})
export class TypeComponent extends ContentBase { 
    
    public currentPageData : any = {};
    
    constructor(_route : ActivatedRoute,
                _sanitizer: DomSanitizationService, 
                _siteStateChanger : SiteStateChanger,                
                _stateService : StateService){ 
        super("sd-type", _sanitizer, _route, _siteStateChanger, _stateService);   
        
        let id = this._route.snapshot.params['id'];
        this._siteStateChanger.setCurrentPageToType(id);
    }
    
}