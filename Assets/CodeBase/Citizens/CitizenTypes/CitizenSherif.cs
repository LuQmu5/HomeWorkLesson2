using System;
using System.Collections.Generic;
using UnityEngine;

public class CitizenSherif : Citizen
{
    [field: SerializeField] public Transform[] PatrolPoints { get; private set; }

    public override void Attack()
    {
        SwitchBehaviour(CitizenBehaviours.SelfDefending);
    }

    protected override Dictionary<CitizenBehaviours, Transform> GetBehaviourWayPointsMap()
    {
        return new Dictionary<CitizenBehaviours, Transform>()
        {
            [CitizenBehaviours.Sleep] = Bed,
        };
    }

    protected override Dictionary<DayTime, CitizenBehaviours> GetDayRoutineMap()
    {
        return new Dictionary<DayTime, CitizenBehaviours>()
        {
            [new DayTime(7)] = CitizenBehaviours.Patrol,
            [new DayTime(22)] = CitizenBehaviours.Sleep,
        };
    }

    protected override Dictionary<CitizenBehaviours, IState> GetStatesBehaviourMap()
    {
        return new Dictionary<CitizenBehaviours, IState>()
        {
            [CitizenBehaviours.Sleep] = new CitizenSleepState(_stateMachine, this),
            [CitizenBehaviours.Patrol] = new CitizenPatrolState(_stateMachine, this),
            [CitizenBehaviours.Move] = new CitizenMoveToPointState(_stateMachine, this),
            [CitizenBehaviours.SelfDefending] = new CitizenDefendingState(_stateMachine, this),
        };
    }
}
