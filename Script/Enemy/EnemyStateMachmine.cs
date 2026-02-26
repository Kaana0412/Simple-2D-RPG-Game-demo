using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStateMachmine
{
    public EnemyState CurrentState { get; private set; }

    public void Initialize(EnemyState _StartState)
    {  
        CurrentState = _StartState;
        CurrentState.Enter();
    }

    public void ChangeState(EnemyState _newState)
    {
        CurrentState.Exit();
        CurrentState = _newState;
        CurrentState.Enter();

    }
}
