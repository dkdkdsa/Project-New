using UnityEngine;

public class HpComponent : MonoBehaviour, IHpable, IDamageable
{

    [field:SerializeField] public float Hp { get; protected set; }

    public event IHpable.HpChanged OnHpChanged;


    public void TakeDamage(float damage)
    {

        float old = Hp;
        Hp -= damage;

        OnHpChanged?.Invoke(old, damage);

    }

}
