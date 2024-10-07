using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackTower : TowerBase, ILocalInject
{

    protected IValueContainer<int> _valueContnainer;
    protected ITimer<float> _coolDownTimer;
    protected IController _attack;
    protected IController _target;
    protected IController _rotate;

    public void Inject(IController attack, IController target, IController rotate)
    {
        _attack = attack;
        _target = target;
        _rotate = rotate;
    }

    public void LocalInject(ComponentList list)
    {

        _valueContnainer = list.Find<IValueContainer<int>>();

    }

    protected override void Awake()
    {

        base.Awake();

        _coolDownTimer = TimerHelper.GetTimer<float>();

    }

}
