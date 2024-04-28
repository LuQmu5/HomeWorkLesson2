using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class Character : MonoBehaviour, ICoroutineRunner
{
    [SerializeField] private CharacterView _view;
    [SerializeField] private GroundChecker _groundChecker;

    private CharacterConfig _config;
    private PlayerInput _input;
    private CharacterStateMachine _stateMachine;
    private CharacterStats _stats;
    private CharacterController _controller;

    public Vector3 LastDamageSourcePosition { get; private set; }

    public PlayerInput Input => _input;
    public CharacterController Controller => _controller;
    public CharacterConfig Config => _config;
    public CharacterView View => _view;
    public GroundChecker GroundChecker => _groundChecker;

    public void Init(CharacterConfig config, CharacterStats stats)
    {
        _controller = GetComponent<CharacterController>();

        _config = config;
        _input = new PlayerInput();
        _stats = stats;
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
        if (other.TryGetComponent(out Spikes spikes))
        {
            LastDamageSourcePosition = spikes.transform.position;
            _stats.ApplyDamage(spikes.Damage);
            _stateMachine.SwitchState<DamagedState>();
        }

        if (other.TryGetComponent(out LevelUpper levelUpper))
        {
            levelUpper.gameObject.SetActive(false);
            _stats.IncreaseLevel();
        }
    }

    private void OnEnable() => _input.Enable();

    private void OnDisable() => _input.Disable();
}
