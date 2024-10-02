using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Spawner<T> : MonoBehaviour where T : ISpawnable
{
    /// <summary>
    /// 객체 Key
    /// </summary>
    protected PrefabData _data;

    /// <summary>
    /// 보조 데이터
    /// </summary>
    protected object _extraData;

    /// <summary>
    /// IFactory<ISpawnable>를 상속받는 Factory
    /// </summary>
    private IFactory<ISpawnable> _factory;

    protected virtual void Start()
    {
        _factory = Factorys.GetFactory<IFactory<ISpawnable>>();
    }

    /// <summary>
    /// 생성할 객체의 데이터를 받아온다
    /// </summary>
    /// <param name="data">객체 Key</param>
    /// <param name="extraData">보조 데이터</param>
    public void GetInstanceData(PrefabData data, object extraData = null)
    {
        _data = data;
        _extraData = extraData;
    }

    /// <summary>
    /// 객체를 Factory에서 생성해준다
    /// </summary>
    /// <returns></returns>
    public T SpawnUnit()
    {
        T instance = _factory.CreateInstance(_data, _extraData).Cast<T>();

        SpawnSetting(instance);

        return instance;
    }

    /// <summary>
    /// 생성할 객체를 설정해준다
    /// </summary>
    /// <param name="instance">객체</param>
    protected abstract void SpawnSetting(T instance);
}
