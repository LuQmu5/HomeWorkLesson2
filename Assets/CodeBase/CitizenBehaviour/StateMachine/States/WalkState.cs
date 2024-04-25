using UnityEngine;

public class WalkState : IUpdatableState
{
    private readonly IStateSwitcher _stateSwitcher;
    private readonly CitizenBehaviour _citizenBehaviour;

    public WalkState(IStateSwitcher stateSwitcher, CitizenBehaviour citizen)
    {
        _stateSwitcher = stateSwitcher;
        _citizenBehaviour = citizen;
    }

    public virtual void Enter()
    {
        Debug.Log("Enter: " + GetType());
    }

    public virtual void Exit()
    {
        Debug.Log("Exit: " + GetType());
    }

    public virtual void Update()
    {

    }
}

public class WorkState : IState
{
    private readonly IStateSwitcher _stateSwitcher;
    private readonly CitizenBehaviour _citizenBehaviour;

    public WorkState(IStateSwitcher stateSwitcher, CitizenBehaviour citizen)
    {
        _stateSwitcher = stateSwitcher;
        _citizenBehaviour = citizen;
    }

    public virtual void Enter()
    {
        Debug.Log("Enter: " + GetType());
    }

    public virtual void Exit()
    {
        Debug.Log("Exit: " + GetType());
    }

    public virtual void Update()
    {

    }
}

public class SleepState : IState
{
    private readonly IStateSwitcher _stateSwitcher;
    private readonly CitizenBehaviour _citizenBehaviour;

    public SleepState(IStateSwitcher stateSwitcher, CitizenBehaviour citizen)
    {
        _stateSwitcher = stateSwitcher;
        _citizenBehaviour = citizen;
    }

    public virtual void Enter()
    {
        Debug.Log("Enter: " + GetType());
    }

    public virtual void Exit()
    {
        Debug.Log("Exit: " + GetType());
    }

    public virtual void Update()
    {

    }
}