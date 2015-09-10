import can from "can";

export default class Router{
	constructor(){	
		can.route(":type/:id");
	}

	start(){
		can.route.ready();
	}
}
