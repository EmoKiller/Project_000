using Sirenix.OdinInspector;
using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Events;
using UnityEngine.UIElements;

public class CharacterBrain : SerializedMonoBehaviour, IDamageAble, IMoveAble 
{
    [field: SerializeField] public MeshAgent Agent { get; set; }
    [field: SerializeField] public Transform DirectionTarget { get; set; }
    [field: SerializeField] public SlashCollider SlashCollider { get; set; }
    [field: SerializeField] public CharacterAnimator CharacterAnimator { get; set; }
    [field: SerializeField] public CharacterAttribute CharacterAttribute { get; set; }
    [field: SerializeField] public float MaxHealth { get; set; } = 100f;
    [field: SerializeField] public float CurrentHealth { get; set; } = 100f;
    [field: SerializeField] public virtual bool Alive { get; }

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
    public void MoveDestination(Vector3 positon, UnityAction action = null)
    {
        Agent.MoveToDestination(positon);
        if (Agent.IsMove == true) return;
        StartCoroutine(CheckDestination(action));
    }
    public void DashMoveDirection(Vector3 position)
    {
        if (Agent.IsMove == true) return;
        Agent.SetSpeed(10);
        if (Agent.AgentBody.Raycast(position, out NavMeshHit raycastHit))
        {
            Debug.DrawLine(transform.position, raycastHit.position, Color.red);
            Debug.DrawLine(raycastHit.position, GameUtilities.MousePositionInWorld(), Color.blue);
            MoveDestination(raycastHit.position);
            return;
        }
        MoveDestination(position);
    }
    public void DashMoveDirectionReflect(Vector3 positon)
    {
        if (Agent.IsMove == true) return;
        Agent.SetSpeed(25);
        if (Agent.AgentBody.Raycast(positon, out NavMeshHit raycastHit))
        {
            float distance = Vector3.Distance(transform.position, positon);
            float distanceReflect = distance - Vector3.Distance(transform.position, raycastHit.position);
            Vector3 reflectDirection = Vector3.Reflect(raycastHit.position - transform.position, raycastHit.normal);
            Debug.DrawLine(transform.position, raycastHit.position, Color.red);
            Debug.DrawLine(raycastHit.position, GameUtilities.MousePositionInWorld(), Color.blue);
            Debug.DrawRay(raycastHit.position, reflectDirection.normalized * distanceReflect, Color.cyan, 0.5f);
            MoveDestination(raycastHit.position, () => { DashMoveDirectionReflect(transform.position + reflectDirection.normalized * distanceReflect); });
            return;
        }
        MoveDestination(positon);
    }
    IEnumerator CheckDestination(UnityAction action = null)
    {
        Agent.IsMove = true;
        yield return new WaitUntil(() => CheckLastPath() || !Alive);
        Agent.AgentBody.isStopped = true;
        Agent.IsMove = false;
        Agent.SetSpeed(4);
        action?.Invoke();
    }
    public void RotateDirection(Vector3 direction)
    {
        throw new System.NotImplementedException();
    }
    protected bool CheckLastPath()
    {
        return Vector3.Distance(transform.position, Agent.LastPath) <= Agent.AgentBody.radius;
    }
    #endregion

    protected float GetDistanceToTarget()
    {
        return Vector3.Distance(transform.position, DirectionTarget.position);
    }
}
