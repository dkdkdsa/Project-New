using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IValueContainer<TKey>
{
    
    public void SetValue<T>(TKey key, T value);
    public T GetValue<T>(TKey key);

}
