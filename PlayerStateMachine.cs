using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStateMachine 
{
    public State CurrentState { get; private set; }

    public void Initialize(State _startState)
    {
        CurrentState = _startState;
        CurrentState.Enter();
    }

    public void ChangeState(State _newState)
    {
        CurrentState.Exit();
        CurrentState = _newState;
        CurrentState.Enter();
    }

}
