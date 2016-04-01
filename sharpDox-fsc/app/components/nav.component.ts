import {Component} from 'angular2/core';
import {ROUTER_DIRECTIVES} from 'angular2/router';

@Component({
    selector: 'sd-nav',
    templateUrl: '/templates/nav/nav.html',
    styleUrls: ['./templates/nav/nav.css'],
    directives: [ROUTER_DIRECTIVES]
})
export class NavComponent { 
    
    ngAfterViewInit(){
        $('#nav').jstree({
            'core' : {
                'data' : sharpDox.navigationData
            }
        });
        
        $("#nav").bind("select_node.jstree", function(e, data) {
            var href = data.instance.get_node(data.node, true).children('a').attr('href');
            if (href != "#")
                document.location = href;

            data.instance.open_node(data.node);	
            return false;
        });
    }
    
}