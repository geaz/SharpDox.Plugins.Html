import can from "can";
import SiteController from "../controller/SiteController";

import "../../assets/css/sd-titlebar.css!";

export default can.Component.extend({
	tag: 'sd-titlebar',
	template: can.view('templates/titlebar.mustache'),
	viewModel: {
		string: sharpDox.strings
	},
	events: {
		"inserted": function(){
			this.viewModel.attr('site', this.viewModel.sitecontroller.site);
		}
	}
});
