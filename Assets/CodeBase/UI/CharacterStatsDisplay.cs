using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CharacterStatsDisplay : MonoBehaviour
{
    [SerializeField] private TMP_Text _healthText;
    [SerializeField] private TMP_Text _levelText;

    private CharacterStats _characterStats;

    public void Init(CharacterStats characterStats)
    {
        _characterStats = characterStats;

        _healthText.text = $"HP {_characterStats.CurrentHealth}/{_characterStats.MaxHealth}";
        _levelText.text = "LVL " + _characterStats.CurrentLevel;

        _characterStats.LevelChanged += OnLevelChanged;
        _characterStats.HealthChanged += OnHealthChanged;
    }

    private void OnDestroy()
    {
        _characterStats.LevelChanged -= OnLevelChanged;
        _characterStats.HealthChanged -= OnHealthChanged;
    }

    private void OnHealthChanged(int newValue)
    {
        _healthText.text = $"HP {newValue}/{_characterStats.MaxHealth}";
    }

    private void OnLevelChanged(int newValue)
    {
        _levelText.text = "LVL " + newValue;
    }
}
