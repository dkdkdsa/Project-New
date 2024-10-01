using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Spawner<T> : MonoBehaviour, ILocalInject
{
    protected PrefabData _data;
    protected object _extraData;

    private IFactory<T> _factory;

    public void GetInstanceData(PrefabData data = default, object extraData = null)
    {
        _data = data;
        _extraData = extraData;
    }

    public virtual void LocalInject(ComponentList list)
    {
        _factory = Factorys.GetFactory<IFactory<T>>();
    }

    public T SpawnUnit()
    {
        T instance = _factory.CreateInstance(_data, _extraData);

        SpawnSetting(instance);

        return instance;
    }

    protected abstract void SpawnSetting(T instance);
}
