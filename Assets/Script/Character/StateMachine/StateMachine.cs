using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachine<T> 
{
    public State<T> CurrentState { get; set; }
    public void Initalize(State<T> StartingState)
    {
        CurrentState = StartingState;
        CurrentState.EnterState();
    }
    public void ChangeState(State<T> newState)
    {
        CurrentState.ExitState();
        CurrentState = newState;
    }
}
