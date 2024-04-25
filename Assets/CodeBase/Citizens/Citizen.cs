using System;
using UnityEngine;

public class Citizen : MonoBehaviour
{
    [SerializeField] private CitizenTypes _type;
    [SerializeField] private CitizenHome _home;
    [SerializeField] private CitizenWork _work;

    private CitizenBehaviourSwitcher _behaviourSwitcher;
    private CitizenBehaviour _currentBehaviour;

    public CitizenTypes Type => _type;

    public event Action<CitizenBehaviour> BehaviourChanged;

    public void Init(CitizenBehaviour startBehaviour)
    {
        _behaviourSwitcher = new CitizenBehaviourSwitcher(startBehaviour);
        _currentBehaviour = startBehaviour;

        BehaviourChanged?.Invoke(_currentBehaviour);
    }

    private void Update()
    {
        if (_behaviourSwitcher.CurrentBehaviour.IsActionCompleted)
        {
            if (_behaviourSwitcher.TryChangeBehaviour(_currentBehaviour.BehaviourAfterCompleteAction))
            {
                _currentBehaviour = _currentBehaviour.BehaviourAfterCompleteAction;

                BehaviourChanged?.Invoke(_currentBehaviour);
            }
        }
    }

    public void ChangeBehaviour(CitizenBehaviour newBehaviour)
    {
        _behaviourSwitcher.TryChangeBehaviour(newBehaviour);
    }
}
