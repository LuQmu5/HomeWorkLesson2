using System.Collections.Generic;
using UnityEngine;

public class CitizenWorker : Citizen
{
    [field: SerializeField] public Transform WorkingPlace { get; private set; }

    public override void Attack()
    {
        SwitchBehaviour(CitizenBehaviours.Flee);
    }

    protected override Dictionary<CitizenBehaviours, Transform> GetBehaviourWayPointsMap()
    {
        return new Dictionary<CitizenBehaviours, Transform>()
        {
            [CitizenBehaviours.Sleep] = Bed,
            [CitizenBehaviours.Work] = WorkingPlace,
        };
    }

    protected override Dictionary<DayTime, CitizenBehaviours> GetDayRoutineMap()
    {
        return new Dictionary<DayTime, CitizenBehaviours>()
        {
            [new DayTime(8)] = CitizenBehaviours.Work,
            [new DayTime(18)] = CitizenBehaviours.Sleep,
        };
    }

    protected override Dictionary<CitizenBehaviours, IState> GetStatesBehaviourMap()
    {
        return new Dictionary<CitizenBehaviours, IState>()
        {
            [CitizenBehaviours.Sleep] = new CitizenSleepState(_stateMachine, this),
            [CitizenBehaviours.Work] = new CitizenWorkState(_stateMachine, this),
            [CitizenBehaviours.Move] = new CitizenMoveToPointState(_stateMachine, this),
            [CitizenBehaviours.Flee] = new CitizenFleeState(_stateMachine, this),
        };
    }
}