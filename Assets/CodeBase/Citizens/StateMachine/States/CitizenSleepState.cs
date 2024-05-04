public class CitizenSleepState : CitizenActionState
{
    public CitizenSleepState(IStateSwitcher stateSwitcher, Citizen citizen) : base(stateSwitcher, citizen)
    {
    }

    protected override bool IsActionCanStarted()
    {
        return true;
    }

    protected override void OnActionStartFailed()
    {
        
    }

    protected override void StartAction()
    {
        
    }

    protected override void StopAction()
    {
        
    }
}
