using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;
public class CharacterBrain : SerializedMonoBehaviour, IDamageAble, IMoveAble
{
    [field: SerializeField] public MeshAgent agent { get; set; }
    [field: SerializeField] public Transform ObjectAnimationForRotation { get; set; }
    [field: SerializeField] public Transform directionTarget { get; set; }
    [field: SerializeField] public SlashCollider slashCollider { get; set; }

    [SerializeField] protected CharacterAnimator _characterAnimator;
    [SerializeField] protected CharacterAttribute _characterAttribute;
    [field: SerializeField] public float MaxHealth { get; set; } = 100f;
    [field: SerializeField] public float CurrentHealth { get; set; } = 100f;
    [field: SerializeField] public virtual bool Alive { get; }

    private void Start()
    {
    }

    #region IDamageAble
    public virtual void TakeDamage(float damage)
    {
        CurrentHealth -= damage;
        if (CurrentHealth <= 0)
            Die();
    }
    public virtual void Die()
    {
        throw new System.NotImplementedException();
    }
    #endregion

    #region IMoveAble
    [Button]
    public void MoveDirection(Vector3 location)
    {
        agent.MoveToDirection(location);
        if (agent.IsMove == true)
            return;
        StartCoroutine(CheckDestination());
    }
    IEnumerator CheckDestination()
    {
        agent.IsMove = true;
        yield return new WaitUntil(() => CheckLastPath() || !Alive );
        agent.AgentBody.isStopped = true;
        agent.IsMove = false;
    }

    public void RotateDirection(Vector3 direction)
    {
        throw new System.NotImplementedException();
    }
    protected bool CheckLastPath()
    {
        return Vector3.Distance(transform.position, agent.LastPath) <= agent.AgentBody.radius;
    }
    #endregion
    
    protected float GetDistanceToTarget()
    {
        return Vector3.Distance(transform.position, directionTarget.position);
    }
}
