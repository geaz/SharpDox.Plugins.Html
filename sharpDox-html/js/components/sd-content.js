import can from "can";
import SiteController from "../controller/SiteController";

import "../../assets/css/sd-content.css!";

export default can.Component.extend({
	tag: 'sd-content',
	template: can.view('content-template'),
	viewModel: {
		siteController: new SiteController()
	},
	events: {
		"inserted": function(){
			this.viewModel.siteController.setPageFromHash();
			this.viewModel.attr('content', this.viewModel.siteController.currentPage.content);
		},
		"{can.route} change": function() {
			this.viewModel.siteController.setPageFromHash();
			this.viewModel.attr('content', this.viewModel.siteController.currentPage.content);
    }
	}
});
