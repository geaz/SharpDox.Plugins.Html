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
            if (href != "#" && !doNotLoad) {
                that._title.html(data.node.text);
                document.location = href;
            }
            else {
                doNotLoad = false;
            }

            if (data.node.parent != "#")
                data.instance.open_node(data.node);

            return false;
        });

        var url = window.location.hash.slice(1);
        if (url == "") url = "home";

        this.setDocSite(url);
    },

    setDocSite: function (site) {
        this.showLoader();
        if (site == "home") {
            this.selectNode('node-' + homeString);
            $("#content").attr('src', "article/home.html");
        }
        else if (site != "") {

            var splitted = site.split('?');
            if (splitted.length == 2) {
                site = splitted[0] + ".html#" + splitted[1];
            }
            else {
                site = splitted[0] + ".html";
            }

            doNotLoad = true;
            this.selectNode('node-' + splitted[0]);
            $("#content").attr('src', site);
        }
    },

    selectNode: function (nodeID) {
        $('#navigation').jstree('deselect_all');
        $('#navigation').jstree('select_node', nodeID);
    },

    showLoader: function () {
        $('#loader').css('top', $('#content').css('top'));
        $('#loader').css('left', $('#content').css('left'));
        $('#loader').css('height', $('#content').css('height'));
        $('#loader').css('width', $('#content').css('width'));
        $('#loader').css('padding-top', (parseInt($('#loader').css('height'), 10) / 2) + "px");

        $('#loader').show();
    }
};