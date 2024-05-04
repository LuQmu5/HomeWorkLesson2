public abstract class CitizenActionState : CitizenBaseState
{
    public CitizenActionState(IStateSwitcher stateSwitcher, Citizen citizen) : base(stateSwitcher, citizen)
    {
    }

    public override void Enter()
    {
        base.Enter();

        StartAction();
    }

    public override void Exit()
    {
        base.Exit();

        StopAction();
    }

    protected abstract void StartAction();
    protected abstract void StopAction();
}
