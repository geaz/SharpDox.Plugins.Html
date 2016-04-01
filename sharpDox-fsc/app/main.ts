import {bootstrap} from 'angular2/platform/browser';
import {ROUTER_PROVIDERS} from 'angular2/router';

import {provide} from 'angular2/core';
import {LocationStrategy, HashLocationStrategy} from 'angular2/router';
        
import {StateService} from './state/StateService';
import {SiteStateChanger} from './state/SiteStateChanger';

import { AppComponent } from './components/app.component';

bootstrap(AppComponent, [StateService, 
                        SiteStateChanger,
                        ROUTER_PROVIDERS, 
                        provide(LocationStrategy, {useClass: HashLocationStrategy})]);