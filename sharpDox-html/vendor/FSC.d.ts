export class StateContainer {
    constructor();
    constructor(initialState : any);
    constructor(initialState : any, debug : boolean);
    
    registerStateChanger(stateChanger : StateChanger) : void;
    unregisterStateChanger(stateChanger : StateChanger) : void;
    
    registerSubscriber(subscriber : any) : number;
    registerSubscriber(subscriber : any, notifyOnSubscribe : boolean ) : number;
    unregisterSubscriber(subscriberId : number) :void;
}
export class HistoryStateContainer {}
export class StateChanger {
    _triggerChange(stateChanges : any) : void;
    _requestCurrentState() : any;
}