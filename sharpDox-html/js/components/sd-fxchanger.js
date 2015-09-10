import can from "can";

import "../../assets/css/sd-fxchanger.css!";

export default can.Component.extend({
	tag: 'sd-fxchanger',
	template: can.view('templates/fxchanger.mustache'),
	helpers: {
    isSelected: function(options){
			var value = "";
			if(options.context === this.attr('site').attr('currentTargetFx')){
				value = "selected";
			}
			return value;
    }
  },
	events: {
		"inserted": function(){
			this.viewModel.attr('site', this.viewModel.sitecontroller.site);
			this.viewModel.sitecontroller.site.attr('currentTargetFx', $('#fx-changer').val());
		},
		"#fx-changer change": function(){
			this.viewModel.sitecontroller.site.attr('currentTargetFx', $('#fx-changer').val());
		}
	}
});
