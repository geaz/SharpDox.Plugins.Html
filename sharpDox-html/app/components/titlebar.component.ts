import {Component} from '@angular/core';

import {StateService} from '../state/StateService';

@Component({
    selector: 'sd-titlebar',
    templateUrl: './templates/titlebar/titlebar.html',
    styleUrls: ['./templates/titlebar/titlebar.css']
})
export class TitleBarComponent{
    
    public strings : any;
    public currentPageData : any;
    public currentPageType : string;
    
    private _subscriberId : number;
    
    constructor(private _stateService : StateService){
        this.strings = sharpDox.strings;
    }
    
    ngOnInit(){        
        this._subscriberId = this._stateService.stateContainer.registerSubscriber(this);
    }
    
    ngOnDestory(){
        this._stateService.stateContainer.unregisterSubscriber(this._subscriberId);
    }
    
    notify(state){
        this.currentPageData = state.get("SiteStateChanger.currentPageData");
        this.currentPageType = state.get("SiteStateChanger.currentPageType");
    }
    
}