import {Component} from 'angular2/core';

import {StateService} from '../state/StateService';
import {SiteStateChanger} from '../state/SiteStateChanger';

@Component({
    selector: 'sharpdox-app',
    template: '<h1>test</h1>',
    providers: [StateService, SiteStateChanger]
})
export class AppComponent { 
    
    constructor(private _stateService : StateService, private _siteStateChanger : SiteStateChanger){
        console.log("test");
        console.dir(_siteStateChanger);
    }
    
}