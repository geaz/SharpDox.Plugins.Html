import can from "can";

import jstree from "../../vendor/jstree/jstree";
import "../../assets/css/sd-nav.css!";
import "../../vendor/jstree/default/style.css!";

import SiteController from "../controller/SiteController";

export default can.Component.extend({
	tag: 'sd-nav',
	template: can.view('nav-template'),
	viewModel: {
		siteController: new SiteController()
	},
	events: {
		"inserted": function(){
			this.viewModel.siteController.setPageFromHash();
			this.viewModel.attr('children', sharpDox.navigationData);
			$('#nav').jstree();
		},
		"{can.route} change": function() {
			this.viewModel.siteController.setPageFromHash();
    }
	}
});
