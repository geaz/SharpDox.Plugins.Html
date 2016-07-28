import {Component, Input} from '@angular/core';
import {DomSanitizationService} from '@angular/platform-browser';
import {ActivatedRoute} from '@angular/router';

import {StateService} from '../../state/StateService';
import {SiteStateChanger} from '../../state/SiteStateChanger';

@Component({
    selector: 'sd-code',
    templateUrl: './templates/content/code/code.html',
    styleUrls: ['./templates/content/code/code.css']
})
export class CodeComponent { 
    
    public currentPageData : any = {};

    private _routeSubscription : any;
    private _subscriberId : any;
    private _contentChanged : boolean; 

    constructor(private _sanitizer: DomSanitizationService,
                private _route : ActivatedRoute,
                protected _siteStateChanger : SiteStateChanger,
                private _stateService : StateService){
        this._subscriberId = this._stateService.stateContainer.registerSubscriber(this, true);
    }   

    ngOnInit(){    
        this._routeSubscription = this._route.params.subscribe(params => {
            let id = params['id'];
            this._siteStateChanger.setCurrentPageToType(id);            
        });
    }

    ngAfterViewChecked(){ 
        if(this._contentChanged){
            this._contentChanged = false;      
            this.setHighlighting();
        }
    }

    ngOnDestroy(){
        this._routeSubscription.unsubscribe();
        this._stateService.stateContainer.unregisterSubscriber(this._subscriberId);
    }

    notify(state, changedStates){
        this.currentPageData = state.get("SiteStateChanger.currentPageData");      
        if(this.currentPageData.regions !== undefined){
            for(let i = 0; i < this.currentPageData.regions.length; i++){
                this.currentPageData.regions[i].contentSanitized = this._sanitizer.bypassSecurityTrustHtml(this.currentPageData.regions[i].content.replace(/</g, '&lt;').replace(/>/g, '&gt'));
            }
            this._contentChanged = true;
        }         
    }

    private setHighlighting(){
        let codeBlocks = $('pre code');
        for(let i = 0; i < codeBlocks.length; i++){
            Prism.highlightElement(codeBlocks[i], false);
        } 
    }
}