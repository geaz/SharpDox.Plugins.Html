import {Component, Input} from '@angular/core';
import {ActivatedRoute} from '@angular/router';
import {DomSanitizationService} from '@angular/platform-browser';
import {NotifySubscriber, State} from 'fsc';

import {ContentBase} from './ContentBase';
import {StateService} from '../../state/StateService';
import {SiteStateChanger} from '../../state/SiteStateChanger';

@Component({
    selector: 'sd-article',
    templateUrl: './templates/content/article/article.html',
    styleUrls: ['./templates/content/article/article.css']
})
export class ArticleComponent extends ContentBase implements NotifySubscriber{     
           
    private _routeSubscription : any;
    
    constructor(private sanitizer: DomSanitizationService,
                route : ActivatedRoute,                 
                siteStateChanger : SiteStateChanger,
                stateService : StateService){ 
        super('article', route, siteStateChanger, stateService);
    }

    notify(state : State) : void {
        var currentPageData = state["SiteStateChanger.currentPageData"];
        if(state.changedKeys.indexOf("SiteStateChanger.currentPageData") > -1 && currentPageData !== undefined){
            this.currentPageData = state["SiteStateChanger.currentPageData"];
            this.currentPageData.contentSanitized = this.sanitizer.bypassSecurityTrustHtml(this.currentPageData.content);
            super.setChanged();
        }        
    } 
}