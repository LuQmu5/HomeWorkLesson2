using System.Collections;
using UnityEngine;

public class CitizenPatrolState : CitizenActionState
{
    private float _minDistanceToPoint = 2f;
    private int _currentPointIndex = 0;
    private Transform[] _patrolPoints;
    private Coroutine _patrolCoroutine;
    private Transform _currentPoint;

    public CitizenPatrolState(IStateSwitcher stateSwitcher, CitizenSherif citizen) : base(stateSwitcher, citizen)
    {
        _patrolPoints = citizen.PatrolPoints;
    }

    protected override bool IsActionCanStarted()
    {
        return true;
    }

    protected override void OnActionStartFailed()
    {
        
    }

    protected override void StartAction()
    {
        _patrolCoroutine = _citizen.StartCoroutine(Patroling());
    }

    protected override void StopAction()
    {
        _citizen.StopCoroutine(_patrolCoroutine);
    }

    private IEnumerator Patroling()
    {
        _currentPoint = _patrolPoints[_currentPointIndex];

        while (true)
        {
            while (Vector3.Distance(_citizen.transform.position, _currentPoint.position) > _minDistanceToPoint)
            {
                _citizen.Mover.SetDestination(_currentPoint.position);

                yield return null;
            }

            _currentPoint = GetNextPoint();
        }
    }

    private Transform GetNextPoint()
    {
        _currentPointIndex++;

        if (_currentPointIndex >= _patrolPoints.Length)
            _currentPointIndex = 0;

        return _patrolPoints[_currentPointIndex];
    }
}