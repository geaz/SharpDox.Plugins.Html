import {Component, Input} from '@angular/core';
import {DomSanitizationService} from '@angular/platform-browser';

@Component({
    selector: 'sd-member',
    templateUrl: './templates/content/member/member.html',
    styleUrls: ['./templates/content/member/member.css']
})
export class MemberComponent{
    
    @Input() public member : any;
    
    public strings : any;
    
    constructor(private _sanitizer: DomSanitizationService){
        this.strings = sharpDox.strings;
    }
    
    toogleMember(event){
        var content = $(event.target).parent().parent().next();
        content.slideToggle();
    }

    getSanitized(value){
        return this._sanitizer.bypassSecurityTrustHtml(value);
    }
    
}