using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class CharacterBrain : MonoBehaviour, IDamageAble, IMoveAble
{
    [field: SerializeField] public MeshAgent agent { get; set; }
    [field: SerializeField] public Transform ObjectAnimationForRotation { get; set; }
    [field: SerializeField] public Transform directionTarget { get; set; }
    [field: SerializeField] public SlashCollider slashCollider { get; set; }
    
    [SerializeField] protected CharacterAnimator _characterAnimator;
    [SerializeField] protected CharacterAttribute _characterAttribute;
    [field: SerializeField] public float maxHealth { get; set; } = 100f;
    [field: SerializeField] public float CurrentHealth { get; set; } = 100f;
    [field: SerializeField] public bool Alive { get; }

    private void Start()
    {
        agent.Initialized();
    }

    #region IDamageAble
    public void TakeDamage(float damage)
    {
        CurrentHealth -= damage;
        if (CurrentHealth <= 0)
        {
            Die();
        }
    }
    public void Die()
    {
        throw new System.NotImplementedException();
    }
    #endregion

    #region IMoveAble
    public void MoveDirection(Vector3 location)
    {
        throw new System.NotImplementedException();
    }

    #endregion
}
