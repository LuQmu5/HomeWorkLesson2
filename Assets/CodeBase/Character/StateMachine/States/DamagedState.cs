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
        yield return null;
    }

    private IEnumerator PushingBackSin()
    {
        float amplitude = 3;
        float speed = 4;
        float time = 2;

        while (time > 0)
        {
            _character.Controller.Move(new Vector2
            {
                x = -1 * amplitude * Mathf.Cos(Time.time * speed),
                y = -1 * amplitude * Mathf.Sin(Time.time * speed)
            } * Time.deltaTime);

            time -= Time.deltaTime;

            yield return null;
        }

        _stateMachine.SwitchState<IdlingState>();
    }
}
