using System.Collections;
using UnityEngine;

public class CitizenFleeState : CitizenTimedActionState
{
    private Coroutine _fleeCoroutine;

    public CitizenFleeState(IStateSwitcher stateSwitcher, Citizen citizen) : base(stateSwitcher, citizen)
    {
    }

    protected override void OnTimerEnded()
    {
        Debug.Log("кажется пронесло...");

        _citizen.StopCoroutine(_fleeCoroutine);

        _stateSwitcher.SwitchStateForBehaviour(_citizen.CurrentRoutineBehaviour);
    }

    protected override void OnTimerStarted()
    {
        Debug.Log("ПОМОГИТЕ!");

        _fleeCoroutine = _citizen.StartCoroutine(Fleeing());
    }

    private IEnumerator Fleeing()
    {
        float minTimeToSwitchDireciton = 0.5f;
        float maxTimeToSwitchDireciton = 1.5f;

        while (true)
        {
            yield return new WaitForSeconds(Random.Range(minTimeToSwitchDireciton, maxTimeToSwitchDireciton));

            _citizen.Mover.SetDestination(GetRandomFleePoint());
        }
    }

    private Vector3 GetRandomFleePoint()
    {
        float minX = -5;
        float minZ = -5;
        float maxX = 5;
        float maxZ = 5;

        return _citizen.transform.position + Vector3.right * Random.Range(minX, maxX) + Vector3.forward * Random.Range(minZ, maxZ);
    }
}
