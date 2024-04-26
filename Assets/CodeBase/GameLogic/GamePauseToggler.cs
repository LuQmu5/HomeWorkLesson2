using System;
using UnityEngine;

public class GamePauseToggler : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Time.timeScale = Convert.ToInt32(Time.timeScale == 0);
        }
    }
}
