using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IDamageAble 
{
     SlashCollider SlashCollider { get; set; }
    float MaxHealth { get; set; }
    float CurrentHealth { get; set; }
    bool Alive { get; }
    void TakeDamage(float damage);
    void Die();
}
