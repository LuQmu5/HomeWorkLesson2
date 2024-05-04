using UnityEngine;

public abstract class CitizenBaseState : IState
{
    protected readonly IStateSwitcher _stateSwitcher;
    protected readonly Citizen _citizen;

    public CitizenBaseState(IStateSwitcher stateSwitcher, Citizen citizen)
    {
        _stateSwitcher = stateSwitcher;
        _citizen = citizen;
    }

    public virtual void Enter()
    {
        _citizen.BehaviourSwitched += OnCitizenBehaviourSwitched;
    }

    public virtual void Exit()
    {
        _citizen.BehaviourSwitched -= OnCitizenBehaviourSwitched;
    }

    public virtual void Update()
    {
        Debug.Log("Current State: " + GetType());
    }

    private void OnCitizenBehaviourSwitched(CitizenBehaviours newBehaviour)
    {
        _stateSwitcher.SwitchStateForBehaviour(newBehaviour);
    }
}
