using System;
using UnityEngine;

public class CharacterAnimator : MonoBehaviour
{
    public enum AnimationStates { Idle, Movement, Move, RandomMove, Chase, Attack, RunAtk, FollowRunAtk, Rolling, RangeAttack, UseSkill, MoveToTarget }
    public enum MovementType { Idle, Run }
    public enum AttackStep { step1, step2, step3, step4 }

    [SerializeField] private Animator ator = null;
    [SerializeField] protected AnimationStates currentAnimationState;
    [SerializeField] protected MovementType currentMovementType;
    [SerializeField] protected AttackStep comboATK;
    public AnimationStates CurrentAnimationState
    {
        get { return currentAnimationState; }
    }
    public MovementType CurrentMovementType
    {
        get { return currentMovementType; }
    }
    public AttackStep ComboATK
    {
        get { return comboATK; }
    }
    public string currentTrigger = "";
    public Animator Ator
    {
        get
        {
            if (ator == null)
                GetComponent<Animator>();
            return ator;
        }
    }
    public void SetAnimationState(AnimationStates type)
    {
        currentAnimationState = type;
    }
    public void SetTrigger(AnimationStates type)
    {
        SetTrigger(type.ToString());
        currentAnimationState = type;
    }
    public void SetMovement(MovementType type, float Vertical, float Horizontal)
    {
        SetFloat("vertical", Vertical);
        SetFloat("horizontal", Horizontal);
        currentAnimationState = AnimationStates.Movement;
        currentMovementType = type;
    }
    public void SetDirection(float x, float z)
    {
        SetFloat("RightLeft", x);
        SetFloat("UpDown", z);
    }
    public void SetComboAttack(int step)
    {
        SetTrigger(step.ToString());
        currentAnimationState = AnimationStates.Attack;
        comboATK = (AttackStep)step;
    }
    public void SetTrigger(string param)
    {
        if (param.Equals(currentTrigger))
            return;
        if (!String.IsNullOrEmpty(currentTrigger))
            Ator.ResetTrigger(currentTrigger);

        Ator.SetTrigger(param);
        currentTrigger = param;
    }
    public void ResetTrigger()
    {
        currentTrigger = "";
    }
    public void SetBool(string param, bool value)
    {
        Ator.SetBool(param, value);
    }
    public void SetFloat(string param, float value)
    {
        Ator.SetFloat(param, value);
    }
    public void SetInt(string param, int value)
    {
        Ator.SetInteger(param, value);
    }
    
}
