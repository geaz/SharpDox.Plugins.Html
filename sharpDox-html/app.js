import $ from "jquery";
import can from "can";

import "./assets/css/reset.css!";
import "./assets/css/font-awesome.css!";
import "./assets/css/font.css!";
import "./assets/css/typography.css!";
import "./assets/css/main.css!";

import Router from "./js/router";
import SiteController from "./js/controller/SiteController";

import sdHeader from "./js/components/sd-header";
import sdNav from "./js/components/sd-nav";
import sdTitleBar from "./js/components/sd-titlebar";
import sdFxChanger from "./js/components/sd-fxchanger";
import sdContentFrame from "./js/components/sd-content";
import sdFooter from "./js/components/sd-footer";

var router = new Router();
router.start();

document.title = sharpDox.projectData.name;
$('#app').html(can.view('app-template'));
