import {Component} from 'angular2/core';
import {ROUTER_DIRECTIVES} from 'angular2/router';

@Component({
    selector: 'sd-header',
    templateUrl: './templates/header/header.html',
    styleUrls: ['./templates/header/header.css'],
    directives: [ROUTER_DIRECTIVES]
})
export class HeaderComponent { 
    
    public projectName : string;
    public hasLogo : boolean;
    
    constructor(){ 
        this.projectName = sharpDox.projectData.name;
        this.hasLogo = sharpDox.projectData.hasLogo;
    }
    
}