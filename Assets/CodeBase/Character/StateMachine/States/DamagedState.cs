using System.Collections;
using UnityEngine;

public class DamagedState : IState
{
    private CharacterStateMachine _stateMachine;
    private Character _character;

    public DamagedState(CharacterStateMachine stateMachine, Character character)
    {
        _stateMachine = stateMachine;
        _character = character;
    }

    public void Enter()
    {
        _character.StartCoroutine(PushingBack());
        _character.View.PlayDamagedAnimation();
    }

    public void Exit()
    {
        
    }

    public void HandleInput()
    {
        
    }

    public void Update()
    {
        
    }

    private IEnumerator PushingBack()
    {
        float pushForce = 3;
        float animationSpeed = 10;
        Vector3 endPosition = _character.transform.position + Vector3.up * pushForce + Vector3.left * pushForce;

        while (Vector3.Distance(_character.transform.position, endPosition) > 0.5f)
        {
            _character.transform.position = Vector3.MoveTowards(_character.transform.position, endPosition, Time.deltaTime * animationSpeed);
            Debug.Log(1);

            yield return null;
        }

        _stateMachine.SwitchState<IdlingState>();
    }
}
