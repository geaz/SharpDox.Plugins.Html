import {Component} from 'angular2/core';
import {RouteConfig, ROUTER_DIRECTIVES} from 'angular2/router';

import {StateService} from '../state/StateService';
import {SiteStateChanger} from '../state/SiteStateChanger';

import {HeaderComponent} from './header.component';
import {TitleBarComponent} from './titlebar.component';
import {NavComponent} from './nav.component';
import {ArticleComponent} from './article.component';
import {NamespaceComponent} from './namespace.component';
import {FooterComponent} from './footer.component';

@Component({
    selector: 'sharpdox-app',
    templateUrl: '/templates/app/app.html',
    styleUrls: ['./templates/app/app.css'],
    directives: [ROUTER_DIRECTIVES, 
                HeaderComponent, 
                TitleBarComponent,
                NavComponent, 
                FooterComponent]
})
@RouteConfig([
    { path:'/', redirectTo: ['Article', { id: 'home' }] },
    { path:'/article/:id', name: 'Article', component: ArticleComponent },
    { path:'/namespace/:id', name: 'Namespace', component: NamespaceComponent }
])
export class AppComponent { 
    
    constructor(private _stateService : StateService, private _siteStateChanger : SiteStateChanger){ }
    
    ngAfterViewInit(){
        $('#wrapper').splitPane();
    }
    
}