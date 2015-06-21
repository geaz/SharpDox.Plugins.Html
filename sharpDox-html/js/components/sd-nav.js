import can from "can";

import jstree from "../../vendor/jstree/jstree";
import "../../assets/css/sd-nav.css!";
import "../../vendor/jstree/default/style.css!";

import SiteController from "../controller/SiteController";

export default can.Component.extend({
	tag: 'sd-nav',
	template: can.view('nav-template'),
	viewModel: {
		strings: sharpDox.strings
	},
	events: {
		"inserted": function(){
			this.viewModel.attr('children', sharpDox.navigationData);
			$('#nav').jstree();
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
