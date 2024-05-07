using System.Collections;
using UnityEngine;

public class GameManagement
{
    private CharacterStats _characterStats;
    private Character _character;
    private IEnumerable _resetableObjects;

    private Vector3 _characterStartPosition;

    public GameManagement(CharacterStats characterStats, Character character, IEnumerable resetableObjects)
    {
        _characterStats = characterStats;
        _character = character;
        _characterStartPosition = character.transform.position;
        _resetableObjects = resetableObjects;
    }

    public void PauseGame()
    {
        Time.timeScale = 0;
    }

    public void ShowCharacterView()
    {
        _character.View.Model.SetActive(true);
    }

    public void HideCharacterView()
    {
        _character.View.Model.SetActive(false);
    }

    public void ExitGame()
    {
        Debug.Log("Exit");
        Application.Quit();
    }

    public void RestartGame()
    {
        Debug.Log("restart");
        Time.timeScale = 1;
        _characterStats.ResetStats();

        foreach (GameObject obj in _resetableObjects)
        {
            obj.SetActive(true);
        }
    }
}