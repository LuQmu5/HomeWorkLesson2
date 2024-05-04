using System;
using System.Collections.Generic;
using UnityEngine;

public class CitizenStateMachine : IStateSwitcher
{
    private Dictionary<CitizenBehaviours, IState> _statesMap;
    private IState _currentState;

    public void Init(Dictionary<CitizenBehaviours, IState> statesMap)
    {
        _statesMap = statesMap;
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
