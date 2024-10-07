public interface IStatContainer<TKey>
{

    public void AddModify<T>(TKey key, T mod);
    public void RemoveModify<T>(TKey key, T value);

}
