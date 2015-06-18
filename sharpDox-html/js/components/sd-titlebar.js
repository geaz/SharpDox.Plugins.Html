import can from "can";
import SiteController from "../controller/SiteController";

import "../../assets/css/sd-titlebar.css!";

export default can.Component.extend({
	tag: 'sd-titlebar',
	template: can.view('titlebar-template'),
	viewModel: {
		setViewModel: function(){
			if(this.sitecontroller.currentPageType.isArticle){
				this.attr('title', this.sitecontroller.currentPage.title);
				this.attr('subTitle', this.sitecontroller.currentPage.subTitle);
			}
			else if(this.sitecontroller.currentPageType.isNamespace){
				this.attr('title', this.sitecontroller.currentPage.name);
				this.attr('subTitle', sharpDox.strings.assembly + ": " + this.sitecontroller.currentPage.assembly);
			}
			else if(this.siteController.currentPageType.isType){
				this.attr('title', this.sitecontroller.currentPage.name);
				this.attr('subTitle', sharpDox.strings.namespace + ": " + this.sitecontroller.currentPage.namespace);
			}
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
