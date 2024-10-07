using System.Collections.Generic;
using UnityEngine;

public abstract class UIView<TModel, TEventKey> : MonoBehaviour, IEventContainer<TEventKey>
{

    private Dictionary<TEventKey, IEventContainer<TEventKey>.Event> _eventContainer = new();

    /// <summary>
    /// 모델을 기반으로 그리기
    /// </summary>
    /// <param name="model">모델</param>
    public abstract void Viewing(in TModel model);

    public void NotifyEvent(TEventKey key, params object[] value)
    {
        if(_eventContainer.TryGetValue(key, out var v))
            v?.Invoke(value);
    }

    public void RegisterEvent(TEventKey key, IEventContainer<TEventKey>.Event evt)
    {
        if(!_eventContainer.ContainsKey(key))
            _eventContainer.Add(key, null);

        _eventContainer[key] += evt;
    }

    public void UnregisterEvent(TEventKey key, IEventContainer<TEventKey>.Event evt)
    {
        if (!_eventContainer.ContainsKey(key))
            return;
        _eventContainer[key] -= evt;
    }
}
