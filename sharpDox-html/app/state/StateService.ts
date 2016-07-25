import {Injectable} from '@angular/core';
import {StateContainer} from '../../vendor/FSC';

@Injectable()
export class StateService {
       
    stateContainer : StateContainer;
       
    constructor(){     
        this.stateContainer = new StateContainer();
    }
    
}
