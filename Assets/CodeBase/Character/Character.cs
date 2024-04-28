using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class Character : MonoBehaviour
{
    [SerializeField] private CharacterView _view;
    [SerializeField] private GroundChecker _groundChecker;

    private CharacterConfig _config;
    private PlayerInput _input;
    private CharacterStateMachine _stateMachine;
    private CharacterStats _stats;
    private CharacterController _controller;

    public PlayerInput Input => _input;
    public CharacterController Controller => _controller;
    public CharacterConfig Config => _config;
    public CharacterView View => _view;
    public GroundChecker GroundChecker => _groundChecker;

    public void Init(CharacterConfig config)
    {
        _controller = GetComponent<CharacterController>();

        _config = config;
        _input = new PlayerInput();
        _view.Initialize();
        _stateMachine = new CharacterStateMachine(this);
    }

    private void Update()
    {
        _stateMachine.Update();        
        _stateMachine.HandleInput();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out LevelUpper levelUpper))
        {
            _stateMachine.SwitchState<DamagedState>();
        }
    }

    private void OnEnable() => _input.Enable();

    private void OnDisable() => _input.Disable();
}
