using UnityEngine;

public class NormalRunningState : BaseRunState
{
    public NormalRunningState(IStateSwitcher stateSwitcher, StateMachineData data, Character character) : base(stateSwitcher, data, character)
    {
    }

    public override void Enter()
    {
        base.Enter();

        Data.Speed = Character.Config.GroundedStateConfig.NormalRunSpeed;
    }

    public override void Update()
    {
        base.Update();

        if (IsShiftDown)
            StateSwitcher.SwitchState<SprintingState>();

        if (IsAltDown)
            StateSwitcher.SwitchState<WalkingState>();
    }
}
