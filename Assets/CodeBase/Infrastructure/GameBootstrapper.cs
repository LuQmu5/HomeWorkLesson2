using UnityEngine;

public class GameBootstrapper : MonoBehaviour, ICoroutineRunner
{
    private void Awake()
    {
        DayTimeSimulator dayTimeSimulator = new DayTimeSimulator(this, new DayTime(0, 0), 60);
    }
}
