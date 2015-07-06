import can from "can";

export default class SiteController{
  constructor(){
    this.articles = sharpDox.articles;
    this.namespaces = sharpDox.namespaceData;
    this.types = sharpDox.typeData;
    this.members = sharpDox.memberData;

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
    can.route.bind('change', function() {
      that.setPageFromHash();
    });
  }

  showLoader(show, delegate){
    if(show){
      $('sd-loader').css('left', $('#main').css('left'));
      $('sd-loader').css('width', $('#main').css('width'));
      $('sd-loader i').css('margin-top', (parseInt($('sd-loader').css('height'), 10) / 2) + "px");

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
      else if(can.route.attr('type') == 'member'){
        that.setPageToMember(can.route.attr('id'));
      }
      else{
        that.site.attr('currentPageType', { isArticle: true, isNamespace: false, isType: false });
        that.site.attr('currentPage', that.articles["home"]);
      }
    });
  }

  setPageToArticle(id){
    var article = this.articles[id];
    if(article !== undefined){
      this.site.attr('targetFxs', sharpDox.projectData.targetFxs);
      this.site.attr('currentPageType', { isArticle: true, isNamespace: false, isType: false });
      this.site.attr('currentPageId', id);
      this.site.attr('currentPage', article);
    }
  }

  setPageToNamespace(id){
    var namespace = this.namespaces[id];
    if(namespace !== undefined && namespace[this.site.attr('currentTargetFx')] !== undefined){
      this.site.attr('targetFxs', Object.keys(namespace));
      namespace = namespace[this.site.attr('currentTargetFx')];
    }
    else if(namespace !== undefined){
      this.site.attr('targetFxs', Object.keys(namespace));
      this.site.attr('currentTargetFx', Object.keys(namespace)[0]);
      namespace = namespace[0];
    }

    if(namespace !== undefined){
      this.site.attr('currentPageType', { isArticle: false, isNamespace: true, isType: false });
      this.site.attr('currentPageId', id);
      this.site.attr('currentPage', namespace);
    }
  }

  setPageToType(id){
    var type = this.types[id];
    if(type !== undefined && type[this.site.attr('currentTargetFx')] !== undefined){
      this.site.attr('targetFxs', Object.keys(type));
      type = type[this.site.attr('currentTargetFx')];
    }
    else if(type !== undefined){
      this.site.attr('targetFxs', Object.keys(type));
      this.site.attr('currentTargetFx', Object.keys(type)[0]);
      type = type[0];
    }

    if(type !== undefined){
      this.site.attr('currentPageType', { isArticle: false, isNamespace: false, isType: true });
      this.site.attr('currentPageId', id);
      this.site.attr('currentPage', type);
    }
  }
  
  setPageToMember(id){
    var member = this.members[id];
    if(member !== undefined && member[this.site.attr('currentTargetFx')] !== undefined){
      this.site.attr('targetFxs', Object.keys(member));
      member = member[this.site.attr('currentTargetFx')];
    }
    else if(member !== undefined){
      this.site.attr('targetFxs', Object.keys(member));
      this.site.attr('currentTargetFx', Object.keys(member)[0]);
      member = member[0];
    }

    if(member !== undefined){
      this.site.attr('currentPageType', { isArticle: false, isNamespace: false, isType: true });
      this.site.attr('currentPageId', id);
      this.site.attr('currentPage', member);
    }
  }
}
