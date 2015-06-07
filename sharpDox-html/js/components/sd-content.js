import can from "can";
import SiteController from "../controller/SiteController";

import "../../assets/css/sd-content.css!";

export default can.Component.extend({
	tag: 'sd-content',
	template: can.view('content-template'),
	viewModel: {
		siteController: new SiteController(),
		strings: sharpDox.strings,
		setViewModel: function(){
			this.siteController.setPageFromHash();
			this.attr('currentPage', this.siteController.currentPage);
			this.attr('currentPageType', this.siteController.currentPageType);
		}
	},
	events: {
		"inserted": function(){
			this.viewModel.setViewModel();
		},
		"{can.route} change": function() {
			this.viewModel.setViewModel();
    }
	}
});
