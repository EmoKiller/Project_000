using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.VirtualTexturing;

public class EnemyStateMachine 
{
    public EnemyState CurrentEnemyState { get; set; }
    public void Initalize(EnemyState StartingState)
    {
        CurrentEnemyState = StartingState;
        CurrentEnemyState.EnterState();
    }
    public void ChangeState(EnemyState newState)
    {
        CurrentEnemyState.ExitState();
        CurrentEnemyState = newState;
    }
}
