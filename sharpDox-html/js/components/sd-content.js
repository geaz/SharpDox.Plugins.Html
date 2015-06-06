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
			this.viewModel.attr('currentPage', this.viewModel.siteController.currentPage);
			this.viewModel.attr('currentPageType', this.viewModel.siteController.currentPageType);
		},
		"{can.route} change": function() {
			this.viewModel.siteController.setPageFromHash();
			this.viewModel.attr('currentPage', this.viewModel.siteController.currentPage);
			this.viewModel.attr('currentPageType', this.viewModel.siteController.currentPageType);
    }
	}
});
