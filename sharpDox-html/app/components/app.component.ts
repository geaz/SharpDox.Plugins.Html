import {Component} from '@angular/core';
import {ROUTER_DIRECTIVES} from '@angular/router';

import {LoaderComponent} from './loader.component';
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
    templateUrl: './templates/app/app.html',
    styleUrls: ['./templates/app/app.css'],
    directives: [ROUTER_DIRECTIVES, 
                LoaderComponent,
                HeaderComponent, 
                TitleBarComponent,
                FxChangerComponent,
                NavComponent, 
                FooterComponent],
    precompile: [ArticleComponent, NamespaceComponent, TypeComponent]
})
export class AppComponent {  

    public disqusShortName : string = sharpDox.projectData.disqusShortName;

    ngAfterViewInit(){
        $('#wrapper').splitPane();
        this.initDisqus();
    }    

    private initDisqus() {
        if(this.disqusShortName != null){            
            (<any>window).disqus_config = function () {
                this.page.url = window.location.href;
                this.page.identifier = document.title;
                this.page.title = document.title;
            };
            
            var dsq = document.createElement('script'); 
            dsq.type = 'text/javascript'; 
            dsq.async = true;
            dsq.src = 'https://' + this.disqusShortName + '.disqus.com/embed.js';
            (document.getElementsByTagName('head')[0] || document.getElementsByTagName('body')[0]).appendChild(dsq);
        }
    }
}