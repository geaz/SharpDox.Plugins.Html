import {Component} from '@angular/core';
import {MappingSubscriber} from 'fsc';

import {StateService} from '../state/StateService';

@Component({
    selector: 'sd-titlebar',
    templateUrl: './templates/titlebar/titlebar.html',
    styleUrls: ['./templates/titlebar/titlebar.css']
})
export class TitleBarComponent implements MappingSubscriber{
    
    public strings : any;
    public currentPageData : any;
    public currentPageType : string;
    
    private subscriberId : number;
    
    constructor(private stateService : StateService){ }
    
    ngOnInit(){     
        this.strings = sharpDox.strings;   
        this.subscriberId = this.stateService.stateContainer.registerSubscriber(this);
    }
    
    ngOnDestory(){
        this.stateService.stateContainer.unregisterSubscriber(this.subscriberId);
    }

    get mappings(){
        return {
            "SiteStateChanger.currentPageData" : "currentPageData",
            "SiteStateChanger.currentPageType" : "currentPageType"
        } as {[stateKey:string]:string}
    }   
}