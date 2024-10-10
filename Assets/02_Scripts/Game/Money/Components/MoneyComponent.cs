using UnityEngine;

public class MoneyComponent : MonoBehaviour, IMoney, ILocalInject
{
    [field: SerializeField] public int Money { get; private set; }

    public void LocalInject(ComponentList list)
    {
        Singletons.AddSingleton(typeof(IMoney), this);
    }

    public void AddMoney(int amount)
    {
        Money += amount;
    }

    public void RemoveMoney(int amount)
    {
        Money -= amount;
    }
    private void OnDestroy()
    {
        Singletons.RemoveSingleton(typeof(IMoney));
    }
}
