using System;
using System.Collections.Generic;
using UnityEngine;

public static class Factorys
{

    private static Dictionary<Type, IFactoryable> _factoryBindContainer = new Dictionary<Type, IFactoryable>();

    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
    public static void Bind()
    {

        _factoryBindContainer.Add(typeof(IFactory<GameObject>, new PrefabFactory());

    }

    public static void AddFactory(Type type, IFactoryable factory)
    {
        _factoryBindContainer.Add(type, factory);
    }

    public static void RemoveFactory(Type type)
    {
        _factoryBindContainer.Remove(type);
    }

    public static T GetFactory<T>() where T : class, IFactoryable
    {

        if (_factoryBindContainer.TryGetValue(typeof(T), out var factory))
        {
            return factory as T;
        }

        return null;

    }

}
