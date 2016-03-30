import "../../vendor/jstree/jstree";

import RiotView from '../RiotView';

export default class NavPresenter{
    constructor(templateUrl){  
        let self = this;          
        this._view = new RiotView(templateUrl, "sd-nav", () => {
            self._createNav();
        }); 
    }
        
    _createNav(){
        $('#nav').jstree({
            'core' : {
                'data' : sharpDox.navigationData
            }
        });
        
        $("#nav").bind("select_node.jstree", function (e, data) {
            var href = data.instance.get_node(data.node, true).children('a').attr('href');
            if (href != "#")
                document.location = href;

            data.instance.open_node(data.node);	
            return false;
        });     
    }  
}