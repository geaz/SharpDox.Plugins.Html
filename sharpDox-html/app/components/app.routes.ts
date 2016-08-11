import { provideRouter, RouterConfig } from '@angular/router';

import {ArticleComponent} from './content/article.component';
import {NamespaceComponent} from './content/namespace.component';
import {TypeComponent} from './content/type.component';

const routes : RouterConfig = [
    { path:'', redirectTo: 'article/home', pathMatch: 'full' },
    { path:'article/:id', component: ArticleComponent },
    { path:'namespace/:id', component: NamespaceComponent },
    { path:'type/:id', redirectTo: 'type/:id/index' },
    { path:'type/:id/:member', component: TypeComponent }
];

export const appRouterProviders = [
    provideRouter(routes)
];