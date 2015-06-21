import $ from "jquery";
import can from "can";
import prism from "./vendor/prism/prism";

import "./assets/css/reset.css!";
import "./assets/css/font-awesome.css!";
import "./assets/css/font.css!";
import "./assets/css/typography.css!";
import "./assets/css/main.css!";
import "./vendor/prism/prism.css!";

import Router from "./js/router";
import SiteController from "./js/controller/SiteController";

import sdLoader from "./js/components/sd-loader";
import sdHeader from "./js/components/sd-header";
import sdNav from "./js/components/sd-nav";
import sdTitleBar from "./js/components/sd-titlebar";
import sdFxChanger from "./js/components/sd-fxchanger";
import sdContentFrame from "./js/components/sd-content";
import sdFooter from "./js/components/sd-footer";

//set homepage title
document.title = sharpDox.projectData.name;

//create and start router
var router = new Router();
router.start();

//start the app
$('#app').html(can.view('app-template', { sitecontroller: new SiteController() }));
