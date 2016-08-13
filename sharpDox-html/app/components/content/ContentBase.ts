import {ActivatedRoute} from '@angular/router';

import {StateService} from '../../state/StateService';
import {SiteStateChanger} from '../../state/SiteStateChanger';

export class ContentBase {    
        
    public currentPageData : any = {}; 
    public strings : any;    
    
    private subscriberId : number;
    private contentChanged : boolean;    
    private routeChanged : boolean;
    private routeSubscription : any; 

    constructor(private contentType : string,
                protected route : ActivatedRoute,
                protected siteStateChanger : SiteStateChanger,
                private stateService : StateService){ }   

    ngOnInit(){
        this.strings = sharpDox.strings;        
        this.subscriberId = this.stateService.stateContainer.registerSubscriber(this);
        this.routeSubscription = this.route.params.subscribe(params => {
            let id = params['id'];
            if(!this.siteStateChanger.setCurrentPage(id, this.contentType)){
                this.routeChanged = true;
            }
        });
    }
    
    ngAfterViewChecked(){ 
        if(this.contentChanged || this.routeChanged){
            if (this.currentPageData.title) (<any>document).title = sharpDox.projectData.name + " - " + this.currentPageData.title;
            else if (this.currentPageData.name) (<any>document).title = sharpDox.projectData.name + " - " + this.currentPageData.name;
                             
            $('#main').scrollTop(0); 
            this.setHighlighting();
            this.setLinks();
            this.setSvg();
            this.setSvgLinks(); 
            this.hideMemberContents();
            this.scrollToMember(); 

            if(this.contentChanged){
                this.siteStateChanger.showLoader(false);
            }
            
            this.contentChanged = false;   
            this.routeChanged = false;
        }
    }
    
    ngOnDestroy(){
        this.stateService.stateContainer.unregisterSubscriber(this.subscriberId);
        this.routeSubscription.unsubscribe();
    }

    setChanged(){
        this.contentChanged = true;
    }

    getCodeId(filename : string) : string{
        return filename.split(".")[0];
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
    
    private scrollToMember(){        
        let member = this.route.snapshot.params['member'];
        if(member && member != 'index' && member != 'code'){
            $('#' + member + ' .member-content').show();            
            $('#main').scrollTop($('#' + member).offset().top);
        }      
    }    
}