public abstract class CitizenFailableActionState : CitizenActionState
{
    public CitizenFailableActionState(IStateSwitcher stateSwitcher, Citizen citizen) : base(stateSwitcher, citizen)
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

    protected abstract bool IsActionCanStarted();
    protected abstract void OnActionStartFailed();
}