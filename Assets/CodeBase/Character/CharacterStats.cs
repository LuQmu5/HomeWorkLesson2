using System;

public class CharacterStats
{
    private int _currentLevel;
    private int _maxHealth;
    private int _currentHealth;

    public int CurrentLevel => _currentLevel;
    public int MaxHealth => _maxHealth;
    public int CurrentHealth => _currentHealth;

    public event Action<int> LevelChanged;
    public event Action<int> HealthChanged;

    public CharacterStats()
    {
        _currentLevel = 1;
        _maxHealth = 30;
        _currentHealth = _maxHealth;

        LevelChanged?.Invoke(_currentLevel);
        HealthChanged?.Invoke(_currentHealth);
    }

    public void ApplyDamage(int amount)
    {
        if (amount < 0)
            throw new ArgumentOutOfRangeException(nameof(amount) + " can't be less than 0");

        _currentHealth -= amount;

        if (_currentHealth < 0)
            _currentHealth = 0;

        HealthChanged?.Invoke(_currentHealth);
    }

    public void IncreaseLevel(int amount = 1)
    {
        if (amount < 1)
            throw new ArgumentOutOfRangeException(nameof(amount) + " can't be less than 1");

        _currentLevel += amount;

        LevelChanged?.Invoke(_currentLevel);
    }

    public void ResetStats()
    {
        _currentLevel = 1;
        _maxHealth = 30;
        _currentHealth = _maxHealth;

        LevelChanged?.Invoke(_currentLevel);
        HealthChanged?.Invoke(_currentHealth);
    }
}