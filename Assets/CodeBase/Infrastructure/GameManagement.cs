using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using UnityEngine;

public class GameManagement
{
    private readonly CharacterStats _characterStats;
    private readonly Character _character;
    private readonly IReadOnlyCollection<RefreshableObject> _refreshableObjects;
    private readonly Vector3 _characterStartPosition;

    public GameManagement(CharacterStats characterStats, Character character, IReadOnlyCollection<RefreshableObject> refreshableObjects)
    {
        _characterStats = characterStats;
        _character = character;
        _characterStartPosition = character.transform.position;
        _refreshableObjects = refreshableObjects;
    }

    public void EndGame()
    {
        Debug.Log("GG");

        _character.Controller.enabled = false;
        _character.Input.Disable();
        _character.View.Hide();
    }

    public void ExitGame()
    {
        Debug.Log("Exit");
        Application.Quit();
    }

    public void RestartGame()
    {
        Debug.Log("restart");
        _characterStats.ResetStats();
        _character.transform.position = _characterStartPosition;

        foreach (var obj in _refreshableObjects)
            obj.Refresh();

        _character.Controller.enabled = true;
        _character.Input.Enable();
        _character.View.Show();
    }
}