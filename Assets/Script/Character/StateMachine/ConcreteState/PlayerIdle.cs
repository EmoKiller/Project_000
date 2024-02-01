using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class PlayerIdle : State<Player>
{
    public PlayerIdle(Player character, StateMachine<Player> characterStateMachine) : base(character, characterStateMachine)
    {
    }

    public override void EnterState()
    {
        base.EnterState();
    }

    public override void ExitState()
    {
        base.ExitState();
    }

    public override void FrameUpdate()
    {
        base.FrameUpdate();
        character.PlayerMove();
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
