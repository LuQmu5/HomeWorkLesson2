public class SprintingState : BaseRunState
{
    public SprintingState(IStateSwitcher stateSwitcher, StateMachineData data, Character character) : base(stateSwitcher, data, character)
    {
    }

    public override void Enter()
    {
        base.Enter();

        Data.Speed = Character.Config.GroundedStateConfig.SprintSpeed;
    }

    public override void Update()
    {
        base.Update();

        if (IsShiftDown == false)
            StateSwitcher.SwitchState<NormalRunningState>();

        if (IsAltDown)
            StateSwitcher.SwitchState<WalkingState>();
    }
}
