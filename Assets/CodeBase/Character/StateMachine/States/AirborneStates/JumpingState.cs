public class JumpingState : AirborneState
{
    private JumpingStateConfig _config;

    public JumpingState(IStateSwitcher stateSwitcher, StateMachineData data, Character character) : base(stateSwitcher, data, character)
        => _config = character.Config.AirborneStateConfig.JumpingStateConfig;

    public override void Enter()
    {
        base.Enter();

        Data.YVelocity = _config.StartYVelocity;

        View.StartJumping();
    }

    public override void Exit()
    {
        base.Exit();

        View.StopJumping();
    }

    public override void Update()
    {
        base.Update();

        if (Data.YVelocity < 0)
            StateSwitcher.SwitchState<FallingState>();
    }
}

public class DamagedState : AirborneState
{
    private AirborneStateConfig _config;

    public DamagedState(IStateSwitcher stateSwitcher, StateMachineData data, Character character) : base(stateSwitcher, data, character)
        => _config = character.Config.AirborneStateConfig;

    public override void Enter()
    {
        base.Enter();

        Data.YVelocity = _config.DamageForcePower.y;
        Data.XVelocity = _config.DamageForcePower.x;

        View.StartJumping();
    }

    public override void Exit()
    {
        base.Exit();

        View.StopJumping();
    }

    public override void Update()
    {
        base.Update();

        if (Data.YVelocity < 0)
            StateSwitcher.SwitchState<FallingState>();
    }
}
