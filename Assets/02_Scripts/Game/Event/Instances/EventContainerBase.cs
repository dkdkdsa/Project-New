using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 모노를 사용하는 EventContainer들의 기본형
/// </summary>
public abstract class EventContainerBase<TKey> : MonoBehaviour, IEventContainer<TKey>
{

    private Dictionary<TKey, IEventContainer<TKey>.Event> _eventContainer = new Dictionary<TKey, IEventContainer<TKey>.Event>();

    public void NotifyEvent(TKey key, params object[] value)
    {

        if (_eventContainer.TryGetValue(key, out var evt))
            evt?.Invoke(value);

    }

    public void RegisterEvent(TKey key, IEventContainer<TKey>.Event evt)
    {

        if (!_eventContainer.ContainsKey(key))
            _eventContainer.Add(key, null);

        _eventContainer[key] += evt;

    }

    public void UnregisterEvent(TKey key, IEventContainer<TKey>.Event evt)
    {

        if (!_eventContainer.ContainsKey(key))
            return;

        _eventContainer[key] -= evt;

    }

}
