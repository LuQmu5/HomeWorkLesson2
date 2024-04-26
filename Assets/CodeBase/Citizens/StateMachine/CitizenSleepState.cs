using System.Collections;
using UnityEngine;

public class CitizenSleepState : IState
{
    private const float MinDistanceToLayInBed = 1;

    private Citizen _citizen;
    private ICoroutineRunner _coroutineRunner;
    private Coroutine _currentCoroutine;

    public CitizenSleepState(Citizen citizen)
    {
        _citizen = citizen;
        _coroutineRunner = citizen;
    }

    public void Enter()
    {
        if (GetDistanceToBed() > MinDistanceToLayInBed)
        {
            _currentCoroutine = _coroutineRunner.StartCoroutine(GoingToBed());
        }
        else
        {
            LayDownInBed();
        }
    }

    public void Update() { }

    public void Exit()
    {
        if (_currentCoroutine != null)
            _coroutineRunner.StopCoroutine(_currentCoroutine);

        Debug.Log("Ах, встаю встаю...");
    }

    private IEnumerator GoingToBed()
    {
        Debug.Log("Ах...пойду-ка я домой спать...");
        _citizen.Mover.isStopped = false;

        while (GetDistanceToBed() > MinDistanceToLayInBed)
        {
            _citizen.Mover.SetDestination(_citizen.Bed.position);

            yield return null;
        }

        _citizen.Mover.isStopped = true;
        LayDownInBed();
    }

    private void LayDownInBed()
    {
        Debug.Log("спать...");
    }

    private float GetDistanceToBed()
    {
        return Vector3.Distance(_citizen.transform.position, _citizen.Bed.position);
    }
}
