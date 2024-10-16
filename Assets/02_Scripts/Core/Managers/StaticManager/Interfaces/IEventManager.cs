public enum GlobalEvent
{
    UnitSelect,
}
public interface IEventManager : IManager, IEventContainer<GlobalEvent>
{
}