import {Component} from '@angular/core';
import {Router, NavigationEnd} from '@angular/router';

import {StateService} from '../state/StateService';
import {SiteStateChanger} from '../state/SiteStateChanger';

@Component({
    selector: 'sd-fxchanger',
    templateUrl: './templates/fxChanger/fxChanger.html',
    styleUrls: ['./templates/fxChanger/fxChanger.css']
})
export class FxChangerComponent{
    
    public currentRoute : string;
    public currentPageType : any;
    public currentPageId : string;
    public currentPageTargetFxs : any;
    public selectedTargetFx : string;
    
    private _subscriberId : number;
    private _routeSubscription : any;
    
    constructor(private _router : Router,
                private _stateService : StateService, 
                private _siteStateChanger : SiteStateChanger){
        this._subscriberId = this._stateService.stateContainer.registerSubscriber(this);
    }

    ngOnInit(){    
        this._routeSubscription = this._router.events.subscribe(event => {
            if(event instanceof NavigationEnd){
                if(event.url.startsWith("/code")){
                    this.currentRoute = "code";
                }
                else if(event.url.startsWith("/type")){
                    this.currentRoute = "type";
                }                              
            }
        });
    }
    
    ngOnDestory(){
        this._stateService.stateContainer.unregisterSubscriber(this._subscriberId);
    }
    
    notify(state, changedStates){
        this.currentPageTargetFxs = state.get("SiteStateChanger.currentPageTargetFxs");
        this.selectedTargetFx = state.get("SiteStateChanger.selectedTargetFx");
        this.currentPageType = state.get("SiteStateChanger.currentPageType");
        this.currentPageId = state.get("SiteStateChanger.currentPageId");
    }
    
    setTargetFx(data){
        this._siteStateChanger.setSelectedTargetFx(data.target.selectedOptions[0].innerText);
        this._siteStateChanger.resetCurrentPage();
    }
    
}