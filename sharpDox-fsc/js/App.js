import splitter from "../vendor/splitter/jquery.splitter";

import SiteStateChanger from './stateChanger/SiteStateChanger';

import LoaderPresenter from './presenters/LoaderPresenter.js';
import HeaderPresenter from './presenters/HeaderPresenter.js';
import NavPresenter from './presenters/NavPresenter.js';
import ContentPresenter from './presenters/ContentPresenter.js';
import TitleBarPresenter from './presenters/TitleBarPresenter.js';
import FooterPresenter from './presenters/FooterPresenter.js';
import FxChangerPresenter from './presenters/FxChangerPresenter.js';

export default class App{
    constructor(stateContainer){
        this._stateContainer = stateContainer;
        
        this._initApp();
        this._startApp();
    }
    
    _initApp(){
        this._siteStateChanger = new SiteStateChanger();
        this._stateContainer.registerStateChanger(this._siteStateChanger);
        
        let self = this;
        this._headerPresenter = new HeaderPresenter('/templates/header.tag');           
        this._footerPresenter = new FooterPresenter('/templates/footer.tag'); 
        this._titleBarPresenter = new TitleBarPresenter('/templates/titlebar.tag', () =>{
            self._stateContainer.registerSubscriber(self._titleBarPresenter);
        });
        let fxChangerPresenter = new FxChangerPresenter('/templates/fxChanger.tag', this._siteStateChanger, () =>{
            self._stateContainer.registerSubscriber(fxChangerPresenter);
        });           
        this._loaderPresenter = new LoaderPresenter('/templates/loader.tag', () => {
            self._stateContainer.registerSubscriber(self._loaderPresenter);
        });        
        this._navPresenter = new NavPresenter('/templates/nav.tag', () => {
            self._stateContainer.registerSubscriber(self._navPresenter);
        });
        this._contentPresenter = new ContentPresenter('/templates/content.tag', this._stateContainer, this._siteStateChanger);
        
        $('#wrapper').splitPane();
    }
    
    _startApp(){
        this._siteStateChanger.setToHome();
    }
}