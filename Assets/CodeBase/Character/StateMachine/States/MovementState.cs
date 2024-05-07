using UnityEngine;

public abstract class MovementState : BaseState
{
    protected MovementState(IStateSwitcher stateSwitcher, StateMachineData data, Character character) : base(stateSwitcher, data, character)
    {
    }

    protected PlayerInput Input => Character.Input;
    protected CharacterController Controller => Character.Controller;
    protected CharacterView View => Character.View;

    protected bool IsShiftDown => Input.Movement.Sprint.ReadValue<float>() == 1;
    protected bool IsAltDown => Input.Movement.Walk.ReadValue<float>() == 1;

    private Quaternion TurnRight => new Quaternion(0, 0, 0, 0);
    private Quaternion TurnLeft => Quaternion.Euler(0, 180, 0);

    public override void Enter()
    {
        base.Enter();

        Debug.Log(GetType());
        AddInputActionsCallbacks();
    }

    public override void Exit()
    {
        RemoveInputActionsCallbacks();

        base.Exit();
    }

    public override void HandleInput()
    {
        Data.XInput = ReadHorizontalInput();
        Data.XVelocity = Data.XInput * Data.Speed;
    }

    public override void Update()
    {
        if (Controller.enabled == false)
            return; 

        Vector3 velocity = GetConvertedVelocity();
        Controller.Move(velocity * Time.deltaTime);
        Character.transform.rotation = GetRotationFrom(velocity);
    }

    protected virtual void AddInputActionsCallbacks() { }

    protected virtual void RemoveInputActionsCallbacks() { }

    protected bool IsHorizontalInputZero() => Data.XInput == 0;

    private Vector3 GetConvertedVelocity() => new Vector3(Data.XVelocity, Data.YVelocity, 0);

    private float ReadHorizontalInput() => Input.Movement.Move.ReadValue<float>();

    private Quaternion GetRotationFrom(Vector3 velocity)
    {
        if (velocity.x > 0)
            return TurnRight;

        if (velocity.x < 0)
            return TurnLeft;

        return Character.transform.rotation;
    }
}
