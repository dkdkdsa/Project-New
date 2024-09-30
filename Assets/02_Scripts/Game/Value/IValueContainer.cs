public interface IValueContainer<TKey>
{

    public void SetValue<T>(TKey key, T value);
    public T GetValue<T>(TKey key);

}
