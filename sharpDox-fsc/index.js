import 'jquery';
import './node_modules/riot/riot+compiler';

import { StateContainer } from './vendor/FSC';

import App from './js/App';

/* Init the Application */
let stateContainer = new StateContainer();
let application = new App(stateContainer);