var NavigationController = function () {
    this._title = $('#subtitle p');
	this.init();
}

NavigationController.prototype = {

    init: function () {
		var that = this;
        $('#navigation').jstree();
		$("#navigation").bind("select_node.jstree", function (e, data) {
			var href = data.instance.get_node(data.node, true).children('a').attr('href');
			if(href != "#") {
				that._title.html(data.node.text);
				document.location = href;
			}
			
			if(data.node.parent != "#")
				data.instance.open_node(data.node);
							
			return false;
		});
		
		var url = window.location.hash.slice(1);
		if(url == "") url = "home";
				
		this.setDocSite(url);
    },

    setDocSite: function (site) {
		if(site == "home") {
			this.selectNode('node-' + homeString);
			$("#content").attr('src', "article/home.html");
		}
		else if(site != "") {
			this.selectNode('node-' + site);
			$("#content").attr('src', site + ".html");		
		}
    },
	
	selectNode: function(nodeID){
		$('#navigation').jstree('deselect_all');
		$('#navigation').jstree('select_node', nodeID);
	}

};