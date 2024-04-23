public class WalkingState : GroundedState
{
    private readonly GroundedStateConfig _config;

    public WalkingState(IStateSwitcher stateSwitcher, StateMachineData data, Character character) : base(stateSwitcher, data, character)
        => _config = character.Config.GroundedStateConfig;

    public override void Enter()
    {
        base.Enter();

        Data.Speed = _config.WalkStateConfig.WalkSpeed;

        View.StartWalking();
    }

    public override void Exit()
    {
        base.Exit();

        View.StopWalking();
    }

    public override void Update()
    {
        base.Update();

        if (IsHorizontalInputZero())
            StateSwitcher.SwitchState<IdlingState>();

        if (IsAltDown)
            return;

        StateSwitcher.SwitchState<RunningState>();
    }
}
