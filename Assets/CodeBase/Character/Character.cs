using System;
using System.Collections;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class Character : MonoBehaviour, ICoroutineRunner, ILevelable, IDamagable, IKnockbackable
{
    [SerializeField] private CharacterView _view;
    [SerializeField] private GroundChecker _groundChecker;

    private CharacterConfig _config;
    private PlayerInput _input;
    private CharacterStateMachine _stateMachine;
    private CharacterController _controller;
    private CharacterStats _stats;

    public PlayerInput Input => _input;
    public CharacterController Controller => _controller;
    public CharacterConfig Config => _config;
    public CharacterView View => _view;
    public GroundChecker GroundChecker => _groundChecker;

    public int CurrentLevel => _stats.CurrentLevel;
    public int MaxHealth => _stats.MaxHealth;
    public int CurrentHealth => _stats.CurrentHealth;
    public Coroutine KnockingBackCoroutine => _view.KnockingBackCoroutine;

    public event Action Damaged;
    public event Action Died;

    public void Init(CharacterConfig config, CharacterStats stats)
    {
        _controller = GetComponent<CharacterController>();

        _config = config;
        _stats = stats;

        _input = new PlayerInput();
        _stateMachine = new CharacterStateMachine(this);
    }

    private void Update()
    {
        _stateMachine.Update();        
        _stateMachine.HandleInput();
    }

    private void OnEnable() => _input.Enable();

    private void OnDisable() => _input.Disable();

    public void IncreaseLevel(int amount = 1)
    {
        _stats.IncreaseLevel(amount);
    }

    public void ApplyDamage(int amount)
    {
        _stats.DecreaseCurrentHealth(amount);
        Damaged?.Invoke();

        if (_stats.CurrentHealth == 0)
            Died?.Invoke();
    }

    public void Knockback(Vector3 from)
    {
        _view.PlayKnockingBackAnimation(from);
    }
}
