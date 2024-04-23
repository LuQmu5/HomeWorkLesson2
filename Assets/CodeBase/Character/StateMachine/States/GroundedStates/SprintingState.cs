public class SprintingState : GroundedState
{
    private readonly GroundedStateConfig _config;

    public SprintingState(IStateSwitcher stateSwitcher, StateMachineData data, Character character) : base(stateSwitcher, data, character)
        => _config = character.Config.GroundedStateConfig;

    public override void Enter()
    {
        base.Enter();

        Data.Speed = _config.SprintStateConfig.SprintSpeed;

        View.StartSprinting();
    }

    public override void Exit()
    {
        base.Exit();

        View.StopSprinting();
    }

    public override void Update()
    {
        base.Update();

        if (IsHorizontalInputZero())
            StateSwitcher.SwitchState<IdlingState>();

        if (IsShiftDown)
            return;

        StateSwitcher.SwitchState<RunningState>();
    }
}
