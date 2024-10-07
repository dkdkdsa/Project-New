using UnityEngine;

public class TowerAttackController : MonoBehaviour, IController, ILocalInject
{

    private IEventContainer<TowerEventType> _event;
    private IValueContainer<int> _value;
    private IAttackable<IDamageable> _attack;

    public bool Active { get; set; }

    public void LocalInject(ComponentList list)
    {
        _event = list.Find<IEventContainer<TowerEventType>>();
        _value = list.Find<IValueContainer<int>>();
        _attack = list.Find<IAttackable<IDamageable>>();
    }

    private void Awake()
    {

        _event.RegisterEvent(TowerEventType.Attack, Control);

    }

    public void Control(params object[] param)
    {

        var target = _value.GetValue<Transform>(Hashs.TOWER_VALUE_TARGET);
        _attack.Attack(_value.GetValue<float>(Hashs.TOWER_VALUE_ATTACKPOWER), target.transform.GetComponent<IDamageable>());

    }

}
