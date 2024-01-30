using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class State<T>
{
    protected T character;
    protected StateMachine<T> characterStateMachine;
    public State(T character, StateMachine<T> characterStateMachine)
    {
        this.character = character;
        this.characterStateMachine = characterStateMachine;
    }
    public virtual void EnterState() { }
    public virtual void ExitState() { }
    public virtual void FrameUpdate() { }
    public virtual void PhysicsUpdate() { }
    //public virtual void AnimationTriggerEvent(CharacterBrain. triggerType) { }
}
