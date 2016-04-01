import {Component} from 'angular2/core';

import {StateService} from '../state/StateService';

@Component({
    selector: 'sd-titlebar',
    templateUrl: '/templates/titlebar/titlebar.html',
    styleUrls: ['./templates/titlebar/titlebar.css']
})
export class TitleBarComponent{
    
    public currentPageData : any;
    public currentPageType : string;
    
    constructor(private _stateService : StateService){
        _stateService.stateContainer.registerSubscriber(this);
    }
    
    notify(state){
        this.currentPageData = state.get("SiteStateChanger.currentPageData");
        this.currentPageType = state.get("SiteStateChanger.currentPageType");
    }
    
}