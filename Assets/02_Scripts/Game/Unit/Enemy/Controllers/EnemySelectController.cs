using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum InputType : byte
{
    None = 0,

    Hover,
    Click
}

[RequireComponent(typeof(BoxCollider))]
public class EnemySelectController : MonoBehaviour, ILocalInject, IController, IEventContainer<int>
{
    private Dictionary<int, IEventContainer<int>.Event> _eventContainer = new();
    public InputType InputData;

    public bool Active { get; set; } = true;

    public void LocalInject(ComponentList list)
    {

    }

    public void Control(params object[] param)
    {

    }

    public void NotifyEvent(int key, params object[] value)
    {
        if (_eventContainer.TryGetValue(key, out var @event))
            @event?.Invoke(value);
    }

    public void RegisterEvent(int key, IEventContainer<int>.Event evt)
    {
        if (!_eventContainer.ContainsKey(key))
            _eventContainer.Add(key, null);

        _eventContainer[key] += evt;
    }

    public void UnregisterEvent(int key, IEventContainer<int>.Event evt)
    {
        if (!_eventContainer.ContainsKey(key)) return;

        _eventContainer[key] -= evt;
    }
}