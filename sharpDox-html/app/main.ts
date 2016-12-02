import './main.css';

import {enableProdMode} from '@angular/core';
import { bootstrap } from '@angular/platform-browser-dynamic';
import {ROUTER_DIRECTIVES} from '@angular/router';

import {provide} from '@angular/core';
import {LocationStrategy, HashLocationStrategy, APP_BASE_HREF} from '@angular/common';
        
import {StateService} from './state/StateService';
import {SiteStateChanger} from './state/SiteStateChanger';

import { appRouterProviders } from './components/app.routes';
import { AppComponent } from './components/app.component';

//enableProdMode();
bootstrap(AppComponent, [appRouterProviders,
                        ROUTER_DIRECTIVES, 
                        StateService, 
                        SiteStateChanger,
                        provide(LocationStrategy, {useClass: HashLocationStrategy}),
                        provide(APP_BASE_HREF, { useValue: '!' })]);