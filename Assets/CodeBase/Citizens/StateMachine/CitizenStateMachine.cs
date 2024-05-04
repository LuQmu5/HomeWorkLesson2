using System;
using System.Collections.Generic;

public class CitizenStateMachine : IStateSwitcher
{
    private Dictionary<CitizenBehaviours, IState> _statesMap;
    private IState _currentState;
    private Citizen _citizen;

    public CitizenStateMachine(Citizen citizen)
    {
        _citizen = citizen;

        _statesMap = new Dictionary<CitizenBehaviours, IState>()
        {
            [CitizenBehaviours.Sleep] = new CitizenSleepState(this, _citizen),
            [CitizenBehaviours.Move] = new CitizenMoveToPointState(this, _citizen),
            [CitizenBehaviours.Work] = new CitizenWorkState(this, _citizen),
        };
    }

    public void SwitchStateForBehaviour(CitizenBehaviours behaviour)
    {
        if (_statesMap.ContainsKey(behaviour) == false)
            throw new ArgumentException($"can't find state for {behaviour} behaviour");

        var state = _statesMap[behaviour];

        _currentState?.Exit();
        _currentState = state;
        _currentState.Enter();
    }

    public void Update()
    {
        _currentState?.Update();
    }
}
