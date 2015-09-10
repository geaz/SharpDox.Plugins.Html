import can from "can";

import "../../assets/css/sd-loader.css!";

export default can.Component.extend({
	tag: 'sd-loader',
	template: can.view('templates/loader.mustache')
});
