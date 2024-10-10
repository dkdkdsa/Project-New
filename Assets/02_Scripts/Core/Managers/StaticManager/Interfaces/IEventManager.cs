public enum GlobalEvent
{
    UnitSelect,
    EnemySelect
}
public interface IEventManager : IManager, IEventContainer<GlobalEvent>
{
}