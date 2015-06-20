import can from "can";
import SiteController from "../controller/SiteController";

import "../../assets/css/sd-content.css!";
import "../../assets/css/markdown.css!";

export default can.Component.extend({
	tag: 'sd-content',
	template: can.view('content-template'),
	viewModel: {
		strings: sharpDox.strings
	},
	events: {
		"inserted": function(){
			this.viewModel.attr('site', this.viewModel.sitecontroller.site);
		}
	}
});
