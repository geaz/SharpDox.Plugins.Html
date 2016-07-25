import {Component} from '@angular/core';

import {StateService} from '../state/StateService';
import {SiteStateChanger} from '../state/SiteStateChanger';

@Component({
    selector: 'sd-fxchanger',
    templateUrl: './templates/fxChanger/fxChanger.html',
    styleUrls: ['./templates/fxChanger/fxChanger.css']
})
export class FxChangerComponent{
    
    public currentPageTargetFxs : any;
    public selectedTargetFx : string;
    
    private _subscriberId : number;
    
    constructor(private _stateService : StateService, private _siteStateChanger : SiteStateChanger){
        this._subscriberId = this._stateService.stateContainer.registerSubscriber(this);
    }
    
    ngOnDestory(){
        this._stateService.stateContainer.unregisterSubscriber(this._subscriberId);
    }
    
    notify(state, changedStates){
        this.currentPageTargetFxs = state.get("SiteStateChanger.currentPageTargetFxs");
        this.selectedTargetFx = state.get("SiteStateChanger.selectedTargetFx");
    }
    
    setTargetFx(data){
        this._siteStateChanger.setSelectedTargetFx(data.target.selectedOptions[0].innerText);
        this._siteStateChanger.resetCurrentPage();
    }
    
}