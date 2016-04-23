import {Component} from 'angular2/core';
import {RouteParams} from 'angular2/router';

@Component({
    selector: 'sd-footer',
    templateUrl: '/templates/footer/footer.html',
    styleUrls: ['./templates/footer/footer.css']
})
export class FooterComponent { 
    
    public projectName : string;
    public author : string;
    public homepage : string;
    public version : string;
    public footerLine : string;
    public footerText : string;
    
    constructor(){ 
        this.projectName = sharpDox.projectData.name;
        this.author = sharpDox.projectData.author;
        this.homepage = sharpDox.projectData.homepage;
        this.version = sharpDox.projectData.version;
        this.footerLine = sharpDox.projectData.footerLine;
        this.footerText = sharpDox.strings.footerText;   
    }
    
}