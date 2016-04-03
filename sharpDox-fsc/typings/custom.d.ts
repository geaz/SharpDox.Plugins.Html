declare var sharpDox;
declare function require(module:string);
declare function svgPanZoom(id : string);
declare function svgPanZoom(id : string, config : any);
declare function canvg(canvas : HTMLCanvasElement, svgData : string, config : any);

interface HTMLElement{
    getBBox();
}

interface JQuery { 
    splitPane(); 
    bind(element: any, func : any)
}