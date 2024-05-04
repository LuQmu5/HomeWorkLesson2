public abstract class CitizenActionState : CitizenBaseState
{
    public CitizenActionState(IStateSwitcher stateSwitcher, Citizen citizen) : base(stateSwitcher, citizen)
    {
    }

    public override void Enter()
    {
        base.Enter();

        if (IsActionCanStarted())
            StartAction();
        else
            OnActionStartFailed();
    }

    public override void Exit()
    {
        base.Exit();

        StopAction();
    }

    protected abstract bool IsActionCanStarted();
    protected abstract void OnActionStartFailed();
    protected abstract void StartAction();
    protected abstract void StopAction();
}