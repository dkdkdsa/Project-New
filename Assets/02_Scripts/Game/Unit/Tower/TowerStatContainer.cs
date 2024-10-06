using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerStatContainer : MonoBehaviour, IValueContainer<int>, IStatContainer<int>
{
    public void AddModify<T>(int key, T mod)
    {
        throw new System.NotImplementedException();
    }

    public T GetValue<T>(int key)
    {
        throw new System.NotImplementedException();
    }

    public void RemoveModify<T>(int key, T value)
    {
        throw new System.NotImplementedException();
    }

    public void SetValue<T>(int key, T value)
    {
        throw new System.NotImplementedException();
    }
}
