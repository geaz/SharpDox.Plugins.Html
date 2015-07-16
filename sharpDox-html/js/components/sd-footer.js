import can from "can";

import "../../assets/css/sd-footer.css!";

export default can.Component.extend({
	tag: 'sd-footer',
	template: can.view('templates/footer.mustache'),
	viewModel: {
		projectName: sharpDox.projectData.name,
		author: sharpDox.projectData.author,
		homepage: sharpDox.projectData.homepage,
		version: sharpDox.projectData.version,
		footerLine: sharpDox.projectData.footerLine,
		footerText: sharpDox.strings.footerText
	}
});
