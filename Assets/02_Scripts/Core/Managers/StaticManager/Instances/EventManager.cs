using System.Collections.Generic;


public class EventManager : IEventManager
{

    private Dictionary<GlobalEvent, IEventContainer<GlobalEvent>.Event> _eventContainer = new();

    public void Init()
    {
    }

    public void NotifyEvent(GlobalEvent key, params object[] value)
    {
        if (_eventContainer.ContainsKey(key))
        {
            _eventContainer[key]?.Invoke(value);
        }
    }

    public void RegisterEvent(GlobalEvent key, IEventContainer<GlobalEvent>.Event evt)
    {

        if (!_eventContainer.ContainsKey(key))
            _eventContainer.Add(key, null);

        _eventContainer[key] += evt;

    }

    public void UnregisterEvent(GlobalEvent key, IEventContainer<GlobalEvent>.Event evt)
    {

        if (!_eventContainer.ContainsKey(key))
            return;

        _eventContainer[key] -= evt;

    }

    public void Dispose()
    {
    }

}
