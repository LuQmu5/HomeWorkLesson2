using System;

public class GameManagementMediator : IDisposable
{
    private GameOverPanel _gameOverPanel;
    private CharacterStats _characterStats;
    private GameManagement _gameManagement;

    public GameManagementMediator(GameOverPanel gameOverPanel, CharacterStats characterStats, GameManagement gameManagement)
    {
        _gameOverPanel = gameOverPanel;
        _characterStats = characterStats;
        _gameManagement = gameManagement;

        _gameOverPanel.RestartButtonClicked += OnRestartButtonClicked;
        _gameOverPanel.ExitButtonClicked += OnExitButtonClicked;
        _characterStats.HealthChanged += OnCharacterHealthChanged;
    }

    public void Dispose()
    {
        _gameOverPanel.RestartButtonClicked -= OnRestartButtonClicked;
        _gameOverPanel.ExitButtonClicked -= OnExitButtonClicked;
        _characterStats.HealthChanged -= OnCharacterHealthChanged;
    }

    private void OnCharacterHealthChanged(int newValue)
    {
        if (newValue == 0)
        {
            _gameOverPanel.Show();
            _gameManagement.PauseGame();
            _gameManagement.HideCharacterView();
        }
    }

    private void OnExitButtonClicked()
    {
        _gameManagement.ExitGame();
    }

    private void OnRestartButtonClicked()
    {
        _gameOverPanel.Hide();
        _gameManagement.RestartGame();
        _gameManagement.ShowCharacterView();
    }
}
