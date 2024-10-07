using UnityEngine;

public class TowerAttackController : MonoBehaviour, IController, ILocalInject
{

    private IEventContainer<TowerEventType> _event;
    private IValueContainer<int> _value;
    private IAttackable _attack;

    public bool Active { get; set; }

    public void LocalInject(ComponentList list)
    {
        _event = list.Find<IEventContainer<TowerEventType>>();
        _value = list.Find<IValueContainer<int>>();
        _attack = list.Find<IAttackable>();
    }

    private void Awake()
    {

        _event.RegisterEvent(TowerEventType.Attack, Control);

    }

    public void Control(params object[] param)
    {

        _attack.Attack(_value.GetValue<float>(Hashs.TOWER_VALUE_ATTACKPOWER));

    }

}
