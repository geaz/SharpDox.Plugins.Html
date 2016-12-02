import {Component} from '@angular/core';
import {State, NotifySubscriber} from 'fsc';

import {StateService} from '../state/StateService';

@Component({
    selector: 'sd-loader',
    templateUrl: './templates/loader/loader.html',
    styleUrls: ['./templates/loader/loader.css']
})
export class LoaderComponent implements NotifySubscriber{

    public showLoader : boolean;

    private subscriberId : number;
    
    constructor(private stateService : StateService){ }
    
    ngOnInit(){        
        this.subscriberId = this.stateService.stateContainer.registerSubscriber(this);
    }
    
    ngOnDestory(){
        this.stateService.stateContainer.unregisterSubscriber(this.subscriberId);
    }

    notify(state : State) : void{
        if(state.changedKeys.indexOf("SiteStateChanger.showLoader") > -1){ 
            $('#loader').css('left', $('#main').css('left'));      
            $('#loader').css('width', $('#main').css('width'));   
            this.showLoader = state["SiteStateChanger.showLoader"]; //negate it to get the loader shown on initial page load
        }
    }  
}