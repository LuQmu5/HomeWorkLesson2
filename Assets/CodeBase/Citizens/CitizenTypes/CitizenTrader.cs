using System;
using System.Collections.Generic;
using UnityEngine;

public class CitizenTrader : Citizen
{
    [field: SerializeField] public Transform TradingPlace { get; private set; }

    private bool _isTrading = false;

    public event Action TradingStarted;
    public event Action TradingEnded;

    private void OnMouseDown()
    {
        _isTrading = !_isTrading;

        if (_isTrading)
            TradingStarted?.Invoke();
        else
            TradingEnded?.Invoke();
    }

    public override void Attack()
    {
        _stateMachine.SwitchStateForBehaviour(CitizenBehaviours.Flee);
    }

    protected override Dictionary<CitizenBehaviours, Transform> GetBehaviourWayPointsMap()
    {
        return new Dictionary<CitizenBehaviours, Transform>()
        {
            [CitizenBehaviours.Sleep] = Bed,
            [CitizenBehaviours.Work] = TradingPlace,
        };
    }

    protected override Dictionary<DayTime, CitizenBehaviours> GetDayRoutineMap()
    {
        return new Dictionary<DayTime, CitizenBehaviours>()
        {
            [new DayTime(9)] = CitizenBehaviours.Work,
            [new DayTime(1)] = CitizenBehaviours.Sleep,
        };
    }

    protected override Dictionary<CitizenBehaviours, IState> GetStatesBehaviourMap()
    {
        return new Dictionary<CitizenBehaviours, IState>()
        {
            [CitizenBehaviours.Sleep] = new CitizenSleepState(_stateMachine, this),
            [CitizenBehaviours.Work] = new CitizenTradeState(_stateMachine, this),
            [CitizenBehaviours.Move] = new CitizenMoveToPointState(_stateMachine, this),
            [CitizenBehaviours.Flee] = new CitizenFleeState(_stateMachine, this),
        };
    }
}