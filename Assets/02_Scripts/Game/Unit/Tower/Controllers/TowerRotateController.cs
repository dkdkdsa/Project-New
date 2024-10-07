using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerRotateController : MonoBehaviour, IController, ILocalInject
{

    private IEventContainer<TowerEventType> _event;
    private IValueContainer<int> _value;

    public bool Active { get; set; }

    public void LocalInject(ComponentList list)
    {

        _event = list.Find<IEventContainer<TowerEventType>>();
        _value = list.Find<IValueContainer<int>>();

    }

    private void Awake()
    {

        _event.RegisterEvent(TowerEventType.Rotate, Control);

    }

    public void Control(params object[] param)
    {

        var target = _value.GetValue<Transform>(Hashs.TOWER_VALUE_TARGET);

        var dir = (target.position - transform.position).normalized;
        dir.y = 0;

        transform.forward = dir;

    }

}
