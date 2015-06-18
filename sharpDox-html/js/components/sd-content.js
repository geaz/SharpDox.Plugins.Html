import can from "can";
import SiteController from "../controller/SiteController";

import "../../assets/css/sd-content.css!";
import "../../assets/css/markdown.css!";

export default can.Component.extend({
	tag: 'sd-content',
	template: can.view('content-template'),
	viewModel: {
		strings: sharpDox.strings,
		setViewModel: function(){
			this.attr('currentPage', this.sitecontroller.currentPage);
			this.attr('currentPageType', this.sitecontroller.currentPageType);
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
