import {Component, Input} from 'angular2/core';

@Component({
    selector: 'sd-member',
    templateUrl: './templates/content/member/member.html',
    styleUrls: ['./templates/content/member/member.css']
})
export class MemberComponent{
    
    @Input() public member : any;
    
    public strings : any;
    
    constructor(){
        this.strings = sharpDox.strings;
    }
    
    toogleMember(event){
        var content = $(event.target).parent().parent().next();
        content.slideToggle();
    }
    
}