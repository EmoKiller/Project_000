using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRolling : State<Player>
{
    public PlayerRolling(Player character, StateMachine<Player> characterStateMachine) : base(character, characterStateMachine)
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
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
