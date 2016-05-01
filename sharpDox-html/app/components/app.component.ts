import {Component} from 'angular2/core';
import {RouteConfig, ROUTER_DIRECTIVES} from 'angular2/router';

import {StateService} from '../state/StateService';
import {SiteStateChanger} from '../state/SiteStateChanger';

import {HeaderComponent} from './header.component';
import {TitleBarComponent} from './titlebar.component';
import {FxChangerComponent} from './fxChanger.component';
import {NavComponent} from './nav.component';
import {ArticleComponent} from './content/article.component';
import {NamespaceComponent} from './content/namespace.component';
import {TypeComponent} from './content/type.component';
import {FooterComponent} from './footer.component';

@Component({
    selector: 'sharpdox-app',
    templateUrl: '/templates/app/app.html',
    styleUrls: ['./templates/app/app.css'],
    directives: [ROUTER_DIRECTIVES, 
                HeaderComponent, 
                TitleBarComponent,
                FxChangerComponent,
                NavComponent, 
                FooterComponent]
})
@RouteConfig([
    { path:'/', redirectTo: ['Article', { id: 'home' }] },
    { path:'/article/:id', name: 'Article', component: ArticleComponent },
    { path:'/namespace/:id', name: 'Namespace', component: NamespaceComponent },
    { path:'/type/:id/:member', name: 'Member', component: TypeComponent },
    { path:'/type/:id', name: 'Type', component: TypeComponent }
])
export class AppComponent { 
    
    public hideLoader : boolean;
    
    private _subscriberId : number;
    
    constructor(private _stateService : StateService, private _siteStateChanger : SiteStateChanger){}
    
    ngOnInit(){
        this._subscriberId = this._stateService.stateContainer.registerSubscriber(this);
    }
    
    ngAfterViewInit(){
        $('#wrapper').splitPane();
    }
    
    ngOnDestory(){
        this._stateService.stateContainer.unregisterSubscriber(this._subscriberId);
    }
    
    notify(state, changedStates){
        if(changedStates.indexOf("SiteStateChanger.gettingPage") > -1){ 
            $('#loader').css('left', $('#main').css('left'));      
            $('#loader').css('width', $('#main').css('width'));   
            this.hideLoader = !state.get("SiteStateChanger.gettingPage"); //negate it to get the loader shown on initial page load
        }
    }
    
}