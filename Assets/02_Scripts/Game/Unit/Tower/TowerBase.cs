using System.Collections.Generic;
using UnityEngine;

public enum TowerEventType
{

    Attack,

}

public abstract class TowerBase : UnitBase, IEventContainer<TowerEventType>
{

    public ITimer<float> _coolDownTimer;

    protected override void Awake()
    {

        base.Awake();
        _coolDownTimer = TimerHelper.GetTimer<float>();

    }

    public void NotifyEvent(TowerEventType key, params object[] value)
    {
    }

    public void RegisterEvent(TowerEventType key, IEventContainer<TowerEventType>.Event evt)
    {
    }

    public void UnregisterEvent(TowerEventType key, IEventContainer<TowerEventType>.Event evt)
    {
    }

}