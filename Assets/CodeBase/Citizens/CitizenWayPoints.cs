using System;
using System.Collections.Generic;
using UnityEngine;

public class CitizenWayPoints
{
    private Dictionary<CitizenBehaviours, Transform> _wayPointsMap;

    public Transform WorkingPlace { get; private set; }
    public Transform Bed { get; private set; }

    public Vector3 CurrentWayPoint { get; private set; }

    public CitizenWayPoints(Transform bed, Transform workingPlace)
    {
        Bed = bed;
        WorkingPlace = workingPlace;

        _wayPointsMap = new Dictionary<CitizenBehaviours, Transform>()
        {
            [CitizenBehaviours.Sleep] = Bed,
            [CitizenBehaviours.Work] = WorkingPlace,
        };
    }

    public void SwitchCurrentWayPoint(CitizenBehaviours behaviour)
    {
        if (_wayPointsMap.ContainsKey(behaviour) == false)
            throw new ArgumentException($"can't find waypoint for {behaviour}");

        CurrentWayPoint = _wayPointsMap[behaviour].position;
    }
}
