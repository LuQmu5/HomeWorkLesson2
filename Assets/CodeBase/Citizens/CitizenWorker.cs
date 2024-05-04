using System.Collections.Generic;
using UnityEngine;

public class CitizenWorker : Citizen
{
    protected override Dictionary<CitizenBehaviours, Transform> GetBehaviourWayPointsMap()
    {
        return new Dictionary<CitizenBehaviours, Transform>()
        {
            [CitizenBehaviours.Sleep] = Bed,
            [CitizenBehaviours.Work] = Work,
        };
    }

    protected override Dictionary<DayTime, CitizenBehaviours> GetDayRoutineMap()
    {
        return new Dictionary<DayTime, CitizenBehaviours>()
        {
            [new DayTime(10)] = CitizenBehaviours.Work,
            [new DayTime(20)] = CitizenBehaviours.Sleep,
        };
    }

    protected override Dictionary<CitizenBehaviours, IState> GetStatesBehaviourMap()
    {
        return new Dictionary<CitizenBehaviours, IState>()
        {
            [CitizenBehaviours.Sleep] = new CitizenSleepState(_stateMachine, this),
            [CitizenBehaviours.Work] = new CitizenWorkState(_stateMachine, this),
            [CitizenBehaviours.Move] = new CitizenMoveToPointState(_stateMachine, this),
        };
    }
}