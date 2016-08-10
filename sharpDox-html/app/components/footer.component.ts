import {Component} from '@angular/core';

@Component({
    selector: 'sd-footer',
    templateUrl: './templates/footer/footer.html',
    styleUrls: ['./templates/footer/footer.css']
})
export class FooterComponent { 
    
    public projectName : string;
    public author : string;
    public homepage : string;
    public version : string;
    public footerLine : string;
    public footerText : string;
    public generatedBy : string;
    
    constructor(){ 
        this.projectName = sharpDox.projectData.name;
        this.author = sharpDox.projectData.author;
        this.homepage = sharpDox.projectData.homepage;
        this.version = sharpDox.projectData.version;
        this.footerLine = sharpDox.projectData.footerLine;
        this.footerText = sharpDox.strings.footerText;   
        this.generatedBy = sharpDox.strings.generatedBy;
    }
    
}