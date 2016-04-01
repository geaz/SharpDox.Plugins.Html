export class StateContainer {
    constructor();
    constructor(initialState : any);
    constructor(initialState : any, debug : boolean);
    
    registerStateChanger(stateChanger : StateChanger) : void;
    unregisterStateChanger(stateChanger : StateChanger) : void;
    
    registerSubscriber(subscriber : any) : void;
    unregisterSubscriber(subscriber : any) :void;
}
export class HistoryStateContainer {}
export class StateChanger {
    _triggerChange(stateChanges : any) : void;
}