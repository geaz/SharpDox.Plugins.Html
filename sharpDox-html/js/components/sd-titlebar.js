import can from "can";
import SiteController from "../controller/SiteController";

import "../../assets/css/sd-titlebar.css!";

export default can.Component.extend({
	tag: 'sd-titlebar',
	template: can.view('titlebar-template'),
	viewModel: {
		siteController: new SiteController(),
		setViewModel: function(){
			this.siteController.setPageFromHash();
			if(this.siteController.currentPageType.isArticle){
				this.attr('title', this.siteController.currentPage.title);
				this.attr('subTitle', this.siteController.currentPage.subTitle);
			}
			else if(this.siteController.currentPageType.isNamespace){
				this.attr('title', this.siteController.currentPage.name);
				this.attr('subTitle', sharpDox.strings.assembly + ": " + this.siteController.currentPage.assembly);
			}
			else if(this.siteController.currentPageType.isType){
				this.attr('title', this.siteController.currentPage.name);
				this.attr('subTitle', sharpDox.strings.namespace + ": " + this.siteController.currentPage.namespace);
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
