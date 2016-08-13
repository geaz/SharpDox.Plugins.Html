import {Component, Input} from '@angular/core';
import {ActivatedRoute, Router, NavigationEnd} from '@angular/router';
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
    
    public currentPageId : string;
    public currentPageData : any = {};
    public showCode : boolean = false;
    
    private routerSubscription : any;

    constructor(private sanitizer: DomSanitizationService, 
                private router : Router,
                route : ActivatedRoute,
                siteStateChanger : SiteStateChanger,                
                stateService : StateService){ 
        super('type', route, siteStateChanger, stateService);   
    }
        
    ngOnInit(){    
        this.showCode = this.router.url.indexOf("/code") > -1;  
        this.routerSubscription = this.router.events.subscribe(event => {
            if(event instanceof NavigationEnd){
                this.showCode = event.url.indexOf("/code") > -1;                          
            }
        });
        super.ngOnInit();
    }
    
    ngOnDestory(){
        this.routerSubscription.unsubscribe();
        super.ngOnDestroy();
    }

    notify(state : State) : void {
        let currentPageData = state["SiteStateChanger.currentPageData"];
        if(state.changedKeys.indexOf("SiteStateChanger.currentPageData") > -1 && currentPageData !== undefined){
            this.currentPageId = state["SiteStateChanger.currentPageId"];
            this.currentPageData = state["SiteStateChanger.currentPageData"];
            this.currentPageData.linkedSyntaxSanitized = this.sanitizer.bypassSecurityTrustHtml(this.currentPageData.linkedSyntax);
            this.currentPageData.classDiagramSanitized = this.sanitizer.bypassSecurityTrustHtml(this.currentPageData.classDiagram);

            if(this.currentPageData.regions !== undefined){
                for(let i = 0; i < this.currentPageData.regions.length; i++){
                    this.currentPageData.regions[i].contentSanitized = this.sanitizer.bypassSecurityTrustHtml(this.currentPageData.regions[i].content.replace(/</g, '&lt;').replace(/>/g, '&gt'));
                }
            }  

            super.setChanged();
        }        
    } 
}