using System;
using System.Collections.Generic;
using UnityEngine;

public static class Singletons
{

    private static Dictionary<Type, object> _singletonContainer = new();

    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
    private static void Bind()
    {

        _singletonContainer.Add(typeof(IUser), new User(new MoneyInstance()));

    }

    public static void AddSingleton(Type type, object obj)
    {
        _singletonContainer.Add(type, obj);
    }

    public static T GetSingleton<T>()
    {
        return _singletonContainer[typeof(T)].Cast<T>();
    }

    public static void RemoveSingleton(Type t)
    {
        _singletonContainer.Remove(t);
    }
}
