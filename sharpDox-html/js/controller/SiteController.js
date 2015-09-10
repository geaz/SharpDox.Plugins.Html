import can from "can";

export default class SiteController{
  constructor(){
    this.setModel();
    this.bindEvents();
    this.setPageFromHash();
  }

  setModel(){
    //contains:
    //- currentPageType
    //- currentPageId
    //- currentPage
    //- currentTargetFx
    //- targetFxs
    this.site = new can.Map();
    this.site.attr('targetFxs', sharpDox.projectData.targetFxs);

    var that = this;
    this.site.bind('currentTargetFx', function(ev, newVal, oldVal) {
      that.setPageFromHash();
    });
  }

  bindEvents(){
    var that = this;
    can.route.bind('id', function() {
      that.setPageFromHash();
    });
  }

  showLoader(show, delegate){
    if(show){
      var left = $('#main').css('left');
      if(left == 'auto'){
        $('sd-loader').css('left', '300');
      }
      else {
        $('sd-loader').css('left', left);
      }
      
      $('sd-loader').css('width', $('#main').css('width'));
      $('sd-loader').fadeIn(delegate);
    }
    else{
      $('sd-loader').fadeOut();
    }
  }

  setPageFromHash(){
    var that = this;
    this.showLoader(true, function(){
      if(can.route.attr('type') === 'article'){
        that.setPageToArticle(can.route.attr('id'));
      }
      else if(can.route.attr('type') == 'namespace'){
        that.setPageToNamespace(can.route.attr('id'));
      }
      else if(can.route.attr('type') == 'type'){
        that.setPageToType(can.route.attr('id'));
      }
      else{        
        $.getJSON("data/articles/home.json", function( data ) {
          that.site.attr('currentPageType', { isArticle: true, isNamespace: false, isType: false });
          that.site.attr('currentPage', data);
        });
      }
    });
  }

  setPageToArticle(id){
    var that = this;
    $.getJSON("data/articles/" + id + ".json", function( data ) {
        that.site.attr('targetFxs', sharpDox.projectData.targetFxs);
        that.site.attr('currentPageType', { isArticle: true, isNamespace: false, isType: false });
        that.site.attr('currentPageId', id);
        that.site.attr('currentPage', data);
    });
  }

  setPageToNamespace(id){
    var that = this;
    $.getJSON("data/namespaces/" + id + ".json", function( namespace ) {
        if(namespace[that.site.attr('currentTargetFx')] !== undefined){
          that.site.attr('targetFxs', Object.keys(namespace));
          namespace = namespace[that.site.attr('currentTargetFx')];
        }
        else{
          that.site.attr('targetFxs', Object.keys(namespace));
          that.site.attr('currentTargetFx', Object.keys(namespace)[0]);
          namespace = namespace[0];
        }
        
        that.site.attr('currentPageType', { isArticle: false, isNamespace: true, isType: false });
        that.site.attr('currentPageId', id);
        that.site.attr('currentPage', namespace);
    });
  }

  setPageToType(id){
    var that = this;
    $.getJSON("data/types/" + id + ".json", function( type ) {
        if(type[that.site.attr('currentTargetFx')] !== undefined){
          that.site.attr('targetFxs', Object.keys(type));
          type = type[that.site.attr('currentTargetFx')];
        }
        else{
          that.site.attr('targetFxs', Object.keys(type));
          that.site.attr('currentTargetFx', Object.keys(type)[0]);
          type = type[0];
        }
        
        that.site.attr('currentPageType', { isArticle: false, isNamespace: false, isType: true });
        that.site.attr('currentPageId', id);
        that.site.attr('currentPage', type);
    });
  }
}
