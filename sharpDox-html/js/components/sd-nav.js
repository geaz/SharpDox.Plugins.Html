import can from "can";

import jstree from "../../vendor/jstree/jstree";
import "../../assets/css/sd-nav.css!";
import "../../vendor/jstree/default/style.css!";

import SiteController from "../controller/SiteController";

export default can.Component.extend({
	tag: 'sd-nav',
	template: '<div id="nav"></div>',
	viewModel: {
		strings: sharpDox.strings,
		getNavNodes: function(node){
			
			var nodeData = sharpDox.navigationData;
			if(node.parents.length > 0){				
				var i = node.parents.length - 2;
				while(i >= 0){
					nodeData = $.grep(nodeData, function(e){ return e.id == node.parents[i]; })[0].children;
					i--;
				}				
				nodeData = $.grep(nodeData, function(e){ return e.id == node.id; })[0].children;
			}			
			
			var nodes = [];
			$.each(nodeData, function(key, value){
				var tmpNode = {
					id: value.id,
					text: value.text,
					icon: value.icon
				};
				if("children" in value && value.children.length > 0){
					tmpNode.children = true;
				}
				else if(!("children" in value) || value.children.length == 0){
					tmpNode.children = false;
				}
				nodes.push(tmpNode);
			});
			return nodes;
		}
	},
	events: {
		"inserted": function(){
			var that = this;
			$('#nav').jstree({
				'core' : {
			        'data' : function (obj, cb) {
						cb.call(this, that.viewModel.getNavNodes(obj));
			        }
			    }
			});
			
			$("#nav").bind("select_node.jstree", function (e, data) {
	            var href = data.instance.get_node(data.node, true).children('a').attr('href');
				if (href != "#")
					document.location = href;

				data.instance.open_node(data.node);	
	            return false;
     	 	});
			  
			this.viewModel.sitecontroller.site.bind('currentPageId', function(ev, newVal, oldVal){
				$('#nav').jstree('deselect_all');
	      		$('#nav').jstree('select_node', newVal);
			});
		}
	}
});
