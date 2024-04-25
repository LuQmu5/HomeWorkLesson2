using System.Collections.Generic;
using System.Linq;

public class CitizenStateMachine: IStateSwitcher
{
    private List<IState> _states;
    private IState _currentState;

    public CitizenStateMachine(CitizenBehaviour citizenBehaviour)
    {
        _states = new List<IState>()
        {
            new WalkState(this, citizenBehaviour)
        };

        _currentState = _states[0];
        _currentState?.Enter();
    }

    public void SwitchState<T>() where T : IState
    {
        IState state = _states.FirstOrDefault(state => state is T);

        _currentState?.Exit();
        _currentState = state;
        _currentState?.Enter();
    }

    public void Update()
    {
        if (_currentState is IUpdatableState updatableState)
            updatableState.Update();
    }
}
