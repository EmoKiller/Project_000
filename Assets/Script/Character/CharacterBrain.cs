using Sirenix.OdinInspector;
using System.Collections;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Events;

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
    public void MoveDestination(Vector3 positon, UnityAction action = null)
    {
        agent.MoveToDestination(positon);
        if (agent.IsMove == true) return;
        StartCoroutine(CheckDestination(action));
    }
    public void DashMoveDirection(Vector3 positon)
    {
        if (agent.IsMove == true) return;
        agent.SetSpeed(25);
        if (agent.AgentBody.Raycast(positon, out NavMeshHit raycastHit))
        {
            if (raycastHit.hit)
            {
                float distance = Vector3.Distance(transform.position, positon);
                float distanceReflect = distance - Vector3.Distance(transform.position, raycastHit.position);
                Debug.DrawLine(transform.position, raycastHit.position, Color.red);
                Debug.DrawLine(raycastHit.position, GameUtilities.MousePositionInWorld(), Color.blue);
                Vector3 reflectDirection = Vector3.Reflect(raycastHit.position - transform.position, raycastHit.normal);
                Debug.DrawRay(raycastHit.position, reflectDirection.normalized * distanceReflect, Color.cyan, 0.5f);
                MoveDestination(raycastHit.position, () => { DashMoveDirection(transform.position + reflectDirection.normalized * distanceReflect); });
            }
            return;
        }
        MoveDestination(positon);
    }
    IEnumerator CheckDestination(UnityAction action = null)
    {
        agent.IsMove = true;
        yield return new WaitUntil(() => CheckLastPath() || !Alive);
        agent.AgentBody.isStopped = true;
        agent.IsMove = false;
        agent.SetSpeed(4);
        action?.Invoke();
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
