var NavigationController = function () {
    this._oldHash = "";
    this._historyController = new HistoryController();
    this._navigationRoot = $('#navigation-data').clone(true);
}

NavigationController.prototype = {

    init: function (dataUrl) {
        if (dataUrl == "") {
            this.loadRoot();
        }
        else {
            this.loadDataUrl(dataUrl);
        }
    },

    loadRoot: function () {
        var newNav = this._navigationRoot.clone(true);
        $('#navigation').empty();
        $('#navigation').append(newNav);
        newNav.show();
        this.initNav();

        this.setDocSite("article/home.html");
    },

    loadDataUrl: function (dataUrl) {
        if (dataUrl == "" || dataUrl == this._oldHash) {
            return
        }
        this._oldHash = dataUrl;

        var navItem = this._navigationRoot.find('li[data-url="' + dataUrl + '"]');
        var type = navItem.attr('data-type');
        var childNav = navItem.children('ul');

        if (childNav.length == 0) {
            var newNav = this._navigationRoot.find('li[data-url="' + dataUrl + '"]').parent().clone(true);
            this.updateBackNavigation(navItem.parent().parent(), null);
        }
        else {
            var newNav = childNav.clone(true);
            this.updateBackNavigation(navItem, null);
        }

        if (newNav != null && newNav.length > 0) {
            $('#navigation').empty();
            $('#navigation').append(newNav);
            newNav.show();
            this.initNav();
        }

        if (type == "member") {
            var splitted = dataUrl.split('?');
            this.setDocSite('type/' + splitted[0] + '.html#' + splitted[1]);
        }
        else if (type != null) {
            this.setDocSite(type + "/" + dataUrl + ".html");
        }

        this._historyController.add(navItem.children('a').children('p').html(), dataUrl);
    },

    initNav: function () {
        var that = this;
        $('#navigation>ul>li').has('ul[class="navigation-sub"]').click(function () {
            var newNav = $(this).children('ul').clone(true);
            newNav.show();

            $('#navigation').empty();
            $('#navigation').append(newNav);

            that.updateBackNavigation(that._navigationRoot.find('li[data-url="' + $(this).attr('data-url') + '"]'), null);
            that.initNav();
        });
    },

    setDocSite: function (site) {
        $("#docframe").attr('src', site);
    },

    updateBackNavigation: function (navItem, backNavigation) {
        var icon = "icon-caret-down";
        var navClass = "backnavigation";
        if (backNavigation == null) {
            $('#backnavigation').empty();
            backNavigation = [];
            icon = "icon-caret-right";
            navClass = "currentnavigation";
        }

        var type = navItem.attr('data-type');
        var parent = navItem.parent();
        if ((parent != null && parent.is('ul') && !parent.is('#navigation-data')) ||
			(parent.is('#navigation-data') && type == "placeholder")) {

            var that = this;
            var navigationLinkWrapper = $('<li class="' + navClass + '">');
            var navigationLink = $('<a href="#"><i class="' + icon + '"></i> <p>' + navItem.children('a').children('p').text() + '</p></a>');
            navigationLink.off('click');
            navigationLink.on('click', function () {
                that.updateBackNavigation(navItem, null);

                var newNav = navItem.children('ul').clone(true);
                newNav.show();

                $('#navigation').empty();
                $('#navigation').append(newNav);

                that.initNav();
            });

            navigationLinkWrapper.append(navigationLink);
            $('#backnavigation').prepend(navigationLinkWrapper);
            backNavigation.push(navigationLinkWrapper);

            this.updateBackNavigation(parent.parent(), backNavigation);
        }
        else if (backNavigation != null && backNavigation.length > 0) {
            var that = this;
            var navigationLinkWrapper = $('<li class="backnavigation">');
            var navigationLink = $('<a href="#"><i class="icon-caret-down"></i> <p>Home</p></a>');
            navigationLink.off('click');
            navigationLink.on('click', function () {
                $('#backnavigation-wrapper').slideUp();

                var newNav = that._navigationRoot.clone(true);
                newNav.show();

                $('#navigation').empty();
                $('#navigation').append(newNav);

                that.initNav();
            });

            navigationLinkWrapper.append(navigationLink);
            $('#backnavigation').prepend(navigationLinkWrapper);
            backNavigation.push(navigationLinkWrapper);
        }

        if (backNavigation.length > 0 && !$('#backnavigation-wrapper').is(':visible')) {
            $('#backnavigation-wrapper').slideDown();
        }
        else if (backNavigation.length == 0 && $('#backnavigation-wrapper').is(':visible')) {
            $('#backnavigation-wrapper').slideUp();
        }
    }

};