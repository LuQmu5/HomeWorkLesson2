using System.Collections;
using UnityEngine;

public class CitizenFleeState : IState
{
    private Citizen _citizen;
    private ICoroutineRunner _coroutineRunner;
    private Coroutine _currentCoroutine;

    public CitizenFleeState(Citizen citizen)
    {
        _citizen = citizen;
        _coroutineRunner = citizen;
    }

    public void Enter()
    {
        Debug.Log("Помогите! На меня давят...");
        _currentCoroutine = _citizen.StartCoroutine(Fleeing());
    }

    public void Exit()
    {
        if (_currentCoroutine != null)
            _coroutineRunner.StopCoroutine(_currentCoroutine);

        Debug.Log("Возможно просто ветер...");
    }

    public void Update()
    {
        Debug.Log("ААА! ХЕЛП");
    }

    private IEnumerator Fleeing()
    {
        int randomIterrationsCount = Random.Range(1, 4);
        _citizen.Mover.isStopped = false;

        for (int i = 0; i < randomIterrationsCount; i++)
        {
            float randomFleeTime = Random.Range(1f, 2f);
            _citizen.Mover.SetDestination(_citizen.transform.position + new Vector3(Random.Range(-100, 100), 0, Random.Range(-100, 100)));

            yield return new WaitForSeconds(randomFleeTime);
        }

        _citizen.Mover.isStopped = true;
        _citizen.BackToDayRoutine();
    }
}