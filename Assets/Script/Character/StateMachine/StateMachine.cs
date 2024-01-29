using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachine<T> 
{
    public State<T> CurrentEnemyState { get; set; }
    public void Initalize(State<T> StartingState)
    {
        CurrentEnemyState = StartingState;
        CurrentEnemyState.EnterState();
    }
    public void ChangeState(State<T> newState)
    {
        CurrentEnemyState.ExitState();
        CurrentEnemyState = newState;
    }
}
