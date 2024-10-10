using System;
using System.Collections.Generic;

public static class Singletons
{

    private static Dictionary<Type, object> _singletonContainer = new();

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
