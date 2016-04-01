import {Component} from 'angular2/core';
import {RouteParams} from 'angular2/router';

import {StateService} from '../state/StateService';
import {SiteStateChanger} from '../state/SiteStateChanger';

@Component({
    selector: 'sd-article',
    templateUrl: '/templates/article/article.html',
    styleUrls: ['./templates/article/article.css']
})
export class ArticleComponent { 
    
    public currentPageData : any;
    
    constructor(private _routeParams : RouteParams, 
                private _stateService : StateService,
                private _siteStateChanger : SiteStateChanger){ 
        _stateService.stateContainer.registerSubscriber(this);
    }
    
    notify(state){
        this.currentPageData = state.get("SiteStateChanger.currentPageData");
    }
    
    ngAfterViewInit(){
        let id = this._routeParams.get('id');
        this._siteStateChanger.setCurrentPageToArticle(id);
    }
    
}