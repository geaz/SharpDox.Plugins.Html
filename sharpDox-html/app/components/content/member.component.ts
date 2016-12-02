import {Component, Input} from '@angular/core';
import {DomSanitizationService} from '@angular/platform-browser';

@Component({
    selector: 'sd-member',
    templateUrl: './templates/content/member/member.html',
    styleUrls: ['./templates/content/member/member.css']
})
export class MemberComponent{

    @Input() public currentPageId : string;    
    @Input() public member : any;
    @Input() public last : boolean;

    public showCode : boolean;

    public strings : any;
    
    constructor(private _sanitizer: DomSanitizationService){
        this.strings = sharpDox.strings;
    }

    ngOnInit(){
        this.showCode = sharpDox.projectData.showCode;
        this.member.linkedSyntaxSanitized = this._sanitizer.bypassSecurityTrustHtml(this.member.linkedSyntax);

        if(this.member.type == "method"){
            this.member.sequenceDiagramSanitized = this._sanitizer.bypassSecurityTrustHtml(this.member.sequenceDiagram);
        }
    }
    
    toogleMember(event){
        var content = $(event.target).parent().parent().next();
        content.slideToggle();
    }  

    getCodeId(filename : string) : string{
        return filename.split(".")[0];
    }  
}