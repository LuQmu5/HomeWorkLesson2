public class WalkingState : BaseRunState
{
    public WalkingState(IStateSwitcher stateSwitcher, StateMachineData data, Character character) : base(stateSwitcher, data, character)
    {
    }

    public override void Enter()
    {
        base.Enter();

        Data.Speed = Character.Config.GroundedStateConfig.WalkSpeed;
    }

    public override void Update()
    {
        base.Update();

        if (IsAltDown == false)
            StateSwitcher.SwitchState<NormalRunningState>();

        if (IsShiftDown)
            StateSwitcher.SwitchState<SprintingState>();
    }
}
