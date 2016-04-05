import {RouteParams} from 'angular2/router';

import {StateService} from '../../state/StateService';
import {SiteStateChanger} from '../../state/SiteStateChanger';

export class ContentBase {    
        
    public disqusShortName : string;   
    public currentPageData : any = {}; 
    public strings : any;    
    
    private _subscriberId : number;
    private _contentChanged : boolean;        
           
    constructor(private _selector : string, 
                protected _routeParams : RouteParams,
                protected _siteStateChanger : SiteStateChanger,
                private _stateService : StateService){        
        this.disqusShortName = sharpDox.projectData.disqusShortName;  
        this.strings = sharpDox.strings;
        this._subscriberId = this._stateService.stateContainer.registerSubscriber(this);
    }   
    
    notify(state, changedStates){
        if(changedStates.indexOf("SiteStateChanger.currentPageData") > -1){
            this.currentPageData = state.get("SiteStateChanger.currentPageData");
            this._contentChanged = true;
        }        
    } 
    
    ngAfterViewInit(){        
        $('#main').scrollTop(0);        
    }  
    
    ngAfterViewChecked(){ 
        if(this._contentChanged){
            this._contentChanged = false;
            this.initDisqus();
            this.setHighlighting();
            this.setLinks();
            this.setSvg();
            this.setSvgLinks(); 
            this.hideMemberContents();
        }
    }
    
    ngOnDestory(){
        this._stateService.stateContainer.unregisterSubscriber(this._subscriberId);
    }
    
    private setHighlighting(){
        let codeBlocks = $('pre code');
        for(let i = 0; i < codeBlocks.length; i++){
            Prism.highlightElement(codeBlocks[i], false);
        } 
    }
    
    private setLinks(){
        $('a').filter(function() {
            return this.hostname && this.hostname !== location.hostname;
        }).attr("target","_blank");
    }
    
    private initDisqus() {
        if(this.disqusShortName != null){
            (<any>window).disqus_title = document.title;
            (<any>window).disqus_url = window.location.href;
            var dsq = document.createElement('script'); 
            dsq.type = 'text/javascript'; 
            dsq.async = true;
            dsq.src = 'http://' + sharpDox.projectData.disqusShortName + '.disqus.com/embed.js';
            (document.getElementsByTagName('head')[0] || document.getElementsByTagName('body')[0]).appendChild(dsq);
        }
    }
    
    private setSvg(){
        $.each($('.svgpan'), function (index, value) {
            var parentId = $(value).attr('id');
            var fit = $(value).attr('data-fit');

            var id = "#" + parentId + " svg";
            svgPanZoom(id, { fit: (fit == "True") });
        });
    }
		
    private setSvgLinks(){
        $('.resetZoom').click(function () {
            var svgPan = svgPanZoom("#" + $(this).parent().prev().attr('id') + " svg");
            svgPan.resetZoom();
            svgPan.center();
        });
        
        var gotClicked = false;
        $('.save a').click(function (event) {
            if ($(this).attr('href') == "#") //create diagram just one time
            {
                event.preventDefault();
                var svgPan = svgPanZoom("#" + $(this).parent().parent().prev().attr('id') + " svg");
                svgPan.resetZoom();
                svgPan.center();

                var isClassDiagram = $(this).parent().parent().prev().attr('id') == "sd-class-diagram";
                gotClicked = false; //set gotClicked to false

                var bbox = $($(this).parent().parent().prev().children()[0])[0].getBBox();
                var svgData = "<svg xmlns='http://www.w3.org/2000/svg' width='" + (bbox.width + 10) + "' height='" + (bbox.height + 55) + "'>" + $($($($(this).parent().parent().prev()).children()[0]).children()[0]).html().trim() + "</svg>";

                var link = this;
                var canvas = document.createElement('canvas');
                canvg(canvas, svgData, {
                    renderCallback: function () {
                        var png_dataurl = canvas.toDataURL();
                        link.download = "diagram.png";
                        link.href = png_dataurl;

                        //Diagrams get not downloaded automatically - workaround
                        if (!gotClicked) {
                            gotClicked = true;
                            link.click();
                        }
                    }
                });
            }
        });
    }
    
    private hideMemberContents(){
        $('.member-content').hide();
    }
    
}