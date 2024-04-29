using System.Collections;
using UnityEngine;

public class DamagedState : IState
{
    private CharacterStateMachine _stateMachine;
    private Character _character;
    private Coroutine _pushingBackCoroutine;

    public DamagedState(CharacterStateMachine stateMachine, Character character)
    {
        _stateMachine = stateMachine;
        _character = character;
    }

    public void Enter()
    {
        _pushingBackCoroutine = _character.StartCoroutine(PushingBack());
        _character.View.PlayDamagedAnimation();
    }

    public void Exit()
    {
        if (_pushingBackCoroutine != null)
            _character.StopCoroutine(_pushingBackCoroutine);
    }

    public void HandleInput()
    {
        
    }

    public void Update()
    {
        
    }

    private IEnumerator PushingBack()
    {
        int directionX = _character.transform.position.x < _character.LastDamageSourcePosition.x ? -1 : 1;
        Vector3 firstPoint = _character.transform.position + new Vector3(directionX * 2.5f, 0);
        Vector3 secondPoint = _character.transform.position + new Vector3(directionX * 2, 2);
        Vector3 thirdPoint = _character.transform.position + new Vector3(directionX * 1.5f, 3);
        Vector3 fourthPoint = _character.transform.position;
        float time = 1; // 0 - 1
        float speed = 2;

        while (time > 0)
        {
            _character.transform.position = Bezier.GetPoint(firstPoint, secondPoint, thirdPoint, fourthPoint, time);
            time -= Time.deltaTime * speed;

            yield return null;
        }

        _pushingBackCoroutine = null;
        _stateMachine.SwitchState<IdlingState>();
    }
}
