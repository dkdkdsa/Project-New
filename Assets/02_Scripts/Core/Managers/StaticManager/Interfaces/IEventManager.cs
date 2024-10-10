public enum GlobalEvent
{
    TowerSelect,
    EnemySelect
}
public interface IEventManager : IManager, IEventContainer<GlobalEvent>
{
}