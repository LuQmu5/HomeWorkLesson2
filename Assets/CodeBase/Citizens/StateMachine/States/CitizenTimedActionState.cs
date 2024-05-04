using System.Collections;
using UnityEngine;

public abstract class CitizenTimedActionState : CitizenActionState
{
    private float _timeToReset = 5;
    private Coroutine _coroutine;

    public CitizenTimedActionState(IStateSwitcher stateSwitcher, Citizen citizen) : base(stateSwitcher, citizen)
    {
    }

    protected override void StartAction()
    {
        _coroutine = _citizen.StartCoroutine(StartResetingTimer());
    }

    protected override void StopAction()
    {
        _citizen.StopCoroutine(_coroutine);
    }

    private IEnumerator StartResetingTimer()
    {
        OnTimerStarted();

        float timer = _timeToReset;

        while (timer > 0)
        {
            timer -= Time.deltaTime;

            yield return null;
        }

        OnTimerEnded();
    }

    protected abstract void OnTimerStarted();
    protected abstract void OnTimerEnded();
}