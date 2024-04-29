using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOverPanel : MonoBehaviour
{
    [SerializeField] private Button _restartButton;
    [SerializeField] private Button _exitButton;

    public event Action ExitButtonClicked;
    public event Action RestartButtonClicked;

    private void OnEnable()
    {
        _restartButton.onClick.AddListener(OnRestartButtonClicked);
        _exitButton.onClick.AddListener(OnExitButtonClicked);
    }

    private void OnDisable()
    {
        _restartButton.onClick.RemoveListener(OnRestartButtonClicked);
        _exitButton.onClick.RemoveListener(OnExitButtonClicked);
    }

    public void Show() => gameObject.SetActive(true);

    public void Hide() => gameObject.SetActive(false);

    private void OnExitButtonClicked()
    {
        ExitButtonClicked?.Invoke();
    }

    private void OnRestartButtonClicked()
    {
        RestartButtonClicked?.Invoke();
    }
}
