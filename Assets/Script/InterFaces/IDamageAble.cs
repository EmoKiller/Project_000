
public interface IDamageAble 
{
    SlashCollider slashCollider { get; set; }
    float maxHealth { get; set; }
    float CurrentHealth { get; set; }
    bool Alive { get; }
    void TakeDamage(float damage);
    void Die();
}
