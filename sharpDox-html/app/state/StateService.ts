import {Injectable} from '@angular/core';
import {StateContainer} from 'fsc';

@Injectable()
export class StateService {
       
    stateContainer : StateContainer;
       
    constructor(){     
        this.stateContainer = new StateContainer();
    }
    
}
