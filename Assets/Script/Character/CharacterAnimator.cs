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
    Action triggerSound = null;
    Action triggerSound2 = null;
    Action SpawnObj = null;
    Action SpawnObj2 = null;
    Action SpawnObj3 = null;
    Action SpawnObj4 = null;
    Action dashAtk = null;
    Action step1aniAtk = null;
    Action step2aniAtk = null;
    Action step3aniAtk = null;
    Action step4aniAtk = null;
    Action StartAni = null;
    Action FinishAni = null;
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
    public void AddStepAniAtk(Action step1ani, Action step2ani, Action step3ani, Action step4ani)
    {
        this.step1aniAtk = step1ani;
        this.step2aniAtk = step2ani;
        this.step3aniAtk = step3ani;
        this.step4aniAtk = step4ani;
    }
    public void AddStFishAni(Action StartAni, Action FinishAni)
    {
        this.StartAni = StartAni;
        this.FinishAni = FinishAni;
    }
    public void AddDashAtk(Action dashAtk)
    {
        this.dashAtk = dashAtk;
    }
    public void AddSpawnObj(Action SpawnObj)
    {
        this.SpawnObj = SpawnObj;
    }
    public void AddSpawnObj(Action SpawnObj, Action SpawnObj2)
    {
        this.SpawnObj = SpawnObj;
        this.SpawnObj2 = SpawnObj2;
    }
    public void AddSpawnObj(Action SpawnObj, Action SpawnObj2, Action SpawnObj3)
    {
        this.SpawnObj = SpawnObj;
        this.SpawnObj2 = SpawnObj2;
        this.SpawnObj3 = SpawnObj3;
    }
    public void AddSpawnObj(Action SpawnObj, Action SpawnObj2, Action SpawnObj3, Action SpawnObj4)
    {
        this.SpawnObj = SpawnObj;
        this.SpawnObj2 = SpawnObj2;
        this.SpawnObj3 = SpawnObj3;
        this.SpawnObj4 = SpawnObj4;
    }
    public void AddTriggerSound(Action sound)
    {
        this.triggerSound = sound;
    }
    public void AddTriggerSound(Action sound, Action sound2)
    {
        this.triggerSound = sound;
        this.triggerSound2 = sound2;
    }
    public void StartAnimation()
    {
        StartAni?.Invoke();
    }
    public void FinishAnimation()
    {
        FinishAni?.Invoke();
        ResetTrigger();
    }
    public void Step1AniAtk()
    {
        step1aniAtk?.Invoke();
    }
    public void Step2AniAtk()
    {
        step2aniAtk?.Invoke();
    }
    public void Step3AniAtk()
    {
        step3aniAtk?.Invoke();
    }
    public void Step4AniAtk()
    {
        step4aniAtk?.Invoke();
    }
    public void DashAtk()
    {
        dashAtk?.Invoke();
    }
    public void SpawnObjs()
    {
        SpawnObj?.Invoke();
    }
    public void SpawnObjs2()
    {
        SpawnObj2?.Invoke();
    }
    public void SpawnObjs3()
    {
        SpawnObj3?.Invoke();
    }
    public void SpawnObjs4()
    {
        SpawnObj4?.Invoke();
    }
    public void TriggerSound()
    {
        triggerSound?.Invoke();
    }
    public void TriggerSound2()
    {
        triggerSound2?.Invoke();
    }
}
