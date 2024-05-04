using UnityEngine;

public class CitizenWorkState : CitizenFailableActionState
{
    public CitizenWorkState(IStateSwitcher stateSwitcher, Citizen citizen) : base(stateSwitcher, citizen)
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
        Debug.Log("start work");
    }

    protected override void StopAction()
    {
        Debug.Log("stop work");
    }
}
