using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design.Serialization;
using UnityEngine;

public class Enemy : CharacterBrain
{
    #region StateMachine Variables
    public EnemyStateMachine StateMachine { get; set; }
    public EnemyIdieState IdieState { get; set; }
    public EnemyChaseState ChaseState { get; set; }
    public EnemyAttackState AttackState { get; set; }
    #endregion
    private void Awake()
    {
        StateMachine = new EnemyStateMachine();

        IdieState = new EnemyIdieState(this, StateMachine);
        ChaseState = new EnemyChaseState(this, StateMachine);
        AttackState = new EnemyAttackState(this, StateMachine);
    }
    private void Start()
    {
        StateMachine.Initalize(IdieState);
    }
}
