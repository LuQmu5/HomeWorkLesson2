using System.Collections;
using UnityEngine;

public class CitizenWorkState : IState
{
    private const float MinDistanceToWorkingPlace = 2;

    private Citizen _citizen;
    private ICoroutineRunner _coroutineRunner;

    public CitizenWorkState(Citizen citizen)
    {
        _citizen = citizen;
        _coroutineRunner = citizen;
    }

    public void Enter()
    {
        if (GetDistanceToWorkingPlace() > MinDistanceToWorkingPlace)
        {
            _coroutineRunner.StartCoroutine(GoingToWork());
        }
        else
        {
            Work();
        }
    }

    public void Update() { }

    public void Exit()
    {
        Debug.Log("Ура. Домой!");
    }

    private IEnumerator GoingToWork()
    {
        Debug.Log("Опять работа..Ну, я пошёл...");
        _citizen.Mover.isStopped = false;

        while (GetDistanceToWorkingPlace() > MinDistanceToWorkingPlace)
        {
            _citizen.Mover.SetDestination(_citizen.WorkingPlace.position);
            Debug.Log("топаю на работу");

            yield return null;
        }

        _citizen.Mover.isStopped = true;
        Work();
    }

    private void Work()
    {
        Debug.Log("жоска работаю");
    }

    private float GetDistanceToWorkingPlace()
    {
        return Vector3.Distance(_citizen.transform.position, _citizen.WorkingPlace.position);
    }
}
