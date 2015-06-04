import can from "can";
import SiteController from "../controller/SiteController";

import "../../assets/css/sd-titlebar.css!";

export default can.Component.extend({
	tag: 'sd-titlebar',
	template: can.view('titlebar-template'),
	viewModel: {
		siteController: new SiteController()
	},
	events: {
		"inserted": function(){
			this.viewModel.siteController.setPageFromHash();
			this.viewModel.attr('title', this.viewModel.siteController.currentPage.title);
			this.viewModel.attr('subTitle', this.viewModel.siteController.currentPage.subTitle);
		},
		"{can.route} change": function() {
			this.viewModel.siteController.setPageFromHash();
			this.viewModel.attr('title', this.viewModel.siteController.currentPage.title);
			this.viewModel.attr('subTitle', this.viewModel.siteController.currentPage.subTitle);
    }
	}
});
