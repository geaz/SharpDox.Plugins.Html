import can from "can";

export default class SiteController{
  constructor(){
    this.articles = sharpDox.articles;
    this.namespaces = sharpDox.namespaceData;
    this.types = sharpDox.typeData;
    this.currentPageType = {
      isArticle: false,
      isNamespace: false,
      isType: false
    }

    this.bindEvents();
    this.setPageFromHash();
  }

  bindEvents(){
    var that = this;
    can.route.bind('change', function() {
      that.setPageFromHash();
    });
  }

  setPageFromHash(){
    if(can.route.attr('type') === 'article'){
      this.setPageToArticle(can.route.attr('id'));
    }
    else if(can.route.attr('type') == 'namespace'){
      this.setPageToNamespace(can.route.attr('id'));
    }
    else if(can.route.attr('type') == 'type'){
      this.setPageToType(can.route.attr('id'));
    }
    else{
      this.currentPageType.isArticle = true;
      this.currentPageType.isNamespace = false;
      this.currentPageType.isType = false;

      this.currentPage = this.articles["home"];
    }
  }

  setPageToArticle(id){
    var article = this.articles[id];
    if(article !== undefined){
      this.currentPageType.isArticle = true;
      this.currentPageType.isNamespace = false;
      this.currentPageType.isType = false;

      this.currentPageId = "article-" + id;
      this.currentPage = article;
    }
  }

  setPageToNamespace(id){
    var namespace = this.namespaces[id];
    if(namespace !== undefined){
      this.currentPageType.isArticle = false;
      this.currentPageType.isNamespace = true;
      this.currentPageType.isType = false;

      this.currentPageId = "namespace-" + id;
      this.currentPage = namespace;
    }
  }

  setPageToType(id){
    var type = this.types[id];
    if(type !== undefined){
      this.currentPageType.isArticle = false;
      this.currentPageType.isNamespace = false;
      this.currentPageType.isType = true;

      this.currentPageId = "type-" + id;
      this.currentPage = type;
    }
  }
}
