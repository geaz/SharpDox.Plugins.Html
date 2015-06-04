import can from "can";

import "../../assets/css/sd-header.css!";

export default can.Component.extend({
	tag: 'sd-header',
	template: can.view('header-template'),
	viewModel: {
		projectName: sharpDox.projectData.name,
		hasLogo: sharpDox.projectData.hasLogo
	}
});
