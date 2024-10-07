using UnityEngine;

public class AttackComponent : MonoBehaviour, IAttackable<IDamageable>
{
    public void Attack(float damage, IDamageable target)
    {
        target.TakeDamage(damage);
    }

}
