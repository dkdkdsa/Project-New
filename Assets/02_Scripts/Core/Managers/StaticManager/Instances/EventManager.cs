using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EventManager : IEventManager
{

    private Dictionary<GlobalEvent, IEventContainer<GlobalEvent>.Event> _eventContainer = new();

    public void Init()
    {
    }

    public void NotifyEvent(GlobalEvent key, params object[] value)
    {
    }

    public void RegisterEvent(GlobalEvent key, IEventContainer<GlobalEvent>.Event evt)
    {
    }

    public void UnregisterEvent(GlobalEvent key, IEventContainer<GlobalEvent>.Event evt)
    {
    }

    public void Dispose()
    {
    }

}
