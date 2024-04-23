public class RunningState : GroundedState
{
    private readonly GroundedStateConfig _config;

    public RunningState(IStateSwitcher stateSwitcher, StateMachineData data, Character character) : base(stateSwitcher, data, character)
        => _config = character.Config.GroundedStateConfig;

    public override void Enter()
    {
        base.Enter();

        Data.Speed = _config.NormalSpeed;

        View.StartRunning();
    }

    public override void Exit()
    {
        base.Exit(); 

        View.StopRunning();
    }

    public override void Update()
    {
        base.Update();

        if (IsHorizontalInputZero())
            StateSwitcher.SwitchState<IdlingState>();

        if (IsShiftDown)
            StateSwitcher.SwitchState<SprintingState>();

        if (IsAltDown)
            StateSwitcher.SwitchState<WalkingState>();
    }
}
