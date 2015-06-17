import can from "can";

import "../../assets/css/sd-fxchanger.css!";

export default can.Component.extend({
	tag: 'sd-fxchanger',
	template: can.view('fxchanger-template'),
	viewModel: {
		targetFxs: sharpDox.projectData.targetFxs
	},
	events: {
		"inserted": function(){
		},
		"{can.route} change": function() {
    }
	}
});
