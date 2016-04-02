export class ContentBase {    
        
    private _lastContent : string;
    private _contentChanged : boolean;
        
    constructor(private _selector : string){ }    
    
    ngDoCheck(){
        let currentContent = $(this._selector).html();
        if(currentContent != this._lastContent){
            this._lastContent = currentContent;
            this._contentChanged = true;
        }
    }
    
    ngAfterViewInit(){        
        $('#main').scrollTop(0);        
    }  
    
    ngAfterViewChecked(){ 
        if(this._contentChanged){
            this._contentChanged = false;
            let codeBlocks = $('pre code');
            for(let i = 0; i < codeBlocks.length; i++){
                Prism.highlightElement(codeBlocks[i], false);
            } 
            this._lastContent = $(this._selector).html();
        }
    }
    
}