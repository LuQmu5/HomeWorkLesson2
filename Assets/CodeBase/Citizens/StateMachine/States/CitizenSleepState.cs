using System;
using UnityEngine;

public class CitizenSleepState : CitizenActionState
{
    public CitizenSleepState(IStateSwitcher stateSwitcher, Citizen citizen) : base(stateSwitcher, citizen)
    {
    }

    protected override bool IsActionCanStarted()
    {
        return _citizen.IsWayPointReached();
    }

    protected override void OnActionStartFailed()
    {
        _stateSwitcher.SwitchStateForBehaviour(CitizenBehaviours.Move);
    }

    protected override void StartAction()
    {
        Debug.Log("start sleep");
    }

    protected override void StopAction()
    {
        Debug.Log("stop sleep");
    }
}
