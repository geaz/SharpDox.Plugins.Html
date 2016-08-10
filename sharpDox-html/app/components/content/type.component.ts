import {Component, Input} from '@angular/core';
import {ActivatedRoute} from '@angular/router';
import {DomSanitizationService} from '@angular/platform-browser';
import {State, NotifySubscriber} from 'fsc';

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
export class TypeComponent extends ContentBase implements NotifySubscriber{ 
    
    public currentPageData : any = {};
    
    constructor(private sanitizer: DomSanitizationService, 
                route : ActivatedRoute,
                siteStateChanger : SiteStateChanger,                
                stateService : StateService){ 
        super('type', route, siteStateChanger, stateService);   
    }
        
    notify(state : State) : void {
        let currentPageData = state["SiteStateChanger.currentPageData"];
        if(state.changedKeys.indexOf("SiteStateChanger.currentPageData") > -1 && currentPageData !== undefined){
            this.currentPageData = state["SiteStateChanger.currentPageData"];
            this.currentPageData.linkedSyntaxSanitized = this.sanitizer.bypassSecurityTrustHtml(this.currentPageData.linkedSyntax);
            this.currentPageData.classDiagramSanitized = this.sanitizer.bypassSecurityTrustHtml(this.currentPageData.classDiagram);
            super.setChanged();
        }        
    } 
}