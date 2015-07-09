import can from "can";

import Mousewheel from "../../vendor/svg/jquery.mousewheel";
import svgPanZoom from "../../vendor/svg/svg-pan-zoom";


import SiteController from "../controller/SiteController";

import "../../assets/css/sd-content.css!";
import "../../assets/css/markdown.css!";

export default can.Component.extend({
	tag: 'sd-content',
	template: can.view('content-template'),
	viewModel: {
		strings: sharpDox.strings,
		setHighlight: function(){
      		$('#syntax').html($('#dummy-syntax').html()); //because of Prism the syntax will not update. So i have to do a dummy bind and copy the value to the syntax box.
	        Prism.highlightAll();
		},
		setLinks: function(){
			$('a').filter(function() {
	      	   return this.hostname && this.hostname !== location.hostname;
	      	}).attr("target","_blank");
		},
		hideLoader: function(){
			$('sd-loader').fadeOut();
		},
		setSvg: function(){
			$.each($('.svgpan'), function (index, value) {
	            var parentId = $(value).attr('id');
	            var id = "#" + parentId + " object";
	            svgPanZoom(id, { 'minZoom': 0.1, fit: false });
	        });
		}
	},
	events: {
		"inserted": function(){
			this.viewModel.attr('site', this.viewModel.sitecontroller.site);
			var that = this;
			this.viewModel.sitecontroller.site.bind('currentPage', function(ev, newVal, oldVal){
				setTimeout(function(){
					that.viewModel.setHighlight();
					that.viewModel.setLinks();
					that.viewModel.hideLoader();
					that.viewModel.setSvg();
				}, 250);
			});
		},
		".member-header click": function(header){
			var body = $(header).next();
		    body.slideToggle();
		
		    var icon = $($($(header).children()[0]).children()[0]);
		    if (icon.hasClass('icon-caret-right')) {
		        icon.removeClass('icon-caret-right');
		        icon.addClass('icon-caret-down');
		    }
		    else {
		        icon.removeClass('icon-caret-down');
		        icon.addClass('icon-caret-right');
		    }
		}
	}
});
