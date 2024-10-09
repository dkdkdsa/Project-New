public enum GlobalEvent
{
    TowerSelect
}
public interface IEventManager : IManager, IEventContainer<GlobalEvent>
{
}