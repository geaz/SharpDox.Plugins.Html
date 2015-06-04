import can from "can";

export default class SiteController{
  constructor(){
    this.repository = sharpDox.repositoryData;
    this.articles = sharpDox.articles;
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
      this.currentPage = this.articles["home"];
    }
  }

  setPageToArticle(id){
    var article = this.articles[id];
    if(article !== undefined){
      this.currentPageId = "article-" + id;
      this.currentPage = article;
    }
  }

  setPageToNamespace(id){

  }

  setPageToType(id){

  }
}
