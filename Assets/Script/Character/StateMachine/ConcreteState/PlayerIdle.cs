using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
        if (Input.GetMouseButtonDown(0))
        {
            GameUtilities.ScreenRayCastOnWorld(character.MoveDestination);
        }
        if (Input.GetMouseButton(1))
        {
            character.MoveDestination(GameUtilities.MousePositionInWorld());
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            character.DashMoveDirection(character.transform.position + character.transform.forward * 5);
            character.agent.SetSpeed(15);
        }
        if (character.Horizontal != 0 || character.Vertical != 0)
        {
            character.agent.MoveToDirection(new Vector3(character.Horizontal, 0, character.Vertical));
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }

}
