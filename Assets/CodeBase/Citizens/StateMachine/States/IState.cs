public interface IState
{
    // public int PriorityWeight { get; protected set; }

    void Enter();
    void Exit();
    void Update();
}