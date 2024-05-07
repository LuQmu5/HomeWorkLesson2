public abstract class BaseState : IState
{
    protected readonly IStateSwitcher StateSwitcher;
    protected readonly StateMachineData Data;
    protected readonly Character Character;

    public BaseState(IStateSwitcher stateSwitcher, StateMachineData data, Character character)
    {
        StateSwitcher = stateSwitcher;
        Data = data;
        Character = character;
    }

    public virtual void Enter()
    {
        Character.Damaged += OnCharacterDamaged;
        Character.Died += OnCharacterDied;
    }

    public virtual void Exit()
    {
        Character.Damaged -= OnCharacterDamaged;
        Character.Died -= OnCharacterDied;
    }

    public virtual void HandleInput()
    {
        
    }

    public virtual void Update()
    {

    }

    private void OnCharacterDamaged()
    {
        StateSwitcher.SwitchState<DamagedState>();
    }

    private void OnCharacterDied()
    {
        StateSwitcher.SwitchState<IdlingState>();
    }
}
