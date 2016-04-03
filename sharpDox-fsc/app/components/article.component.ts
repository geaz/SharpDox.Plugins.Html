import {Component, Input} from 'angular2/core';
import {RouteParams} from 'angular2/router';

import {ContentBase} from '../ContentBase';
import {StateService} from '../state/StateService';
import {SiteStateChanger} from '../state/SiteStateChanger';

@Component({
    selector: 'sd-article',
    templateUrl: '/templates/content/article/article.html',
    styleUrls: ['./templates/content/article/article.css']
})
export class ArticleComponent extends ContentBase { 
    
    constructor(_routeParams : RouteParams, 
                _siteStateChanger : SiteStateChanger,
                _stateService : StateService){ 
        super("sd-article", _routeParams, _siteStateChanger, _stateService);      
    }
    
    ngOnInit(){        
        let id = this._routeParams.get('id');
        this._siteStateChanger.setCurrentPageToArticle(id);     
    }
    
}