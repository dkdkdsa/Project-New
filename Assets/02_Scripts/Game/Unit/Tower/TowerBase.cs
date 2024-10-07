using System.Collections.Generic;

public enum TowerEventType
{

    Attack,
    Rotate

}

public abstract class TowerBase : UnitBase, IEventContainer<TowerEventType>
{

    private Dictionary<TowerEventType, IEventContainer<TowerEventType>.Event> _eventContainer = new();

    public void NotifyEvent(TowerEventType key, params object[] value)
    {
        if (_eventContainer.ContainsKey(key))
        {
            _eventContainer[key]?.Invoke(value);
        }
    }

    public void RegisterEvent(TowerEventType key, IEventContainer<TowerEventType>.Event evt)
    {

        if (!_eventContainer.ContainsKey(key))
            _eventContainer.Add(key, null);

        _eventContainer[key] += evt;

    }

    public void UnregisterEvent(TowerEventType key, IEventContainer<TowerEventType>.Event evt)
    {

        if (!_eventContainer.ContainsKey(key))
            return;

        _eventContainer[key] -= evt;

    }
}