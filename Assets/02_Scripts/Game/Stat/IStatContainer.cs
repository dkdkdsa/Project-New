using System.Collections.Generic;

public interface IStatContainer<TKey>
{

    public void AddModify<T>(TKey key, T mod);
    public void RemoveModify<T>(TKey key, T value);
    public IReadOnlyList<T> GetStatData<T>();
    public T GetStat<T>(TKey key);

}
