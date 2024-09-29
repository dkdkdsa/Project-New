using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Managers
{
    
    private static Dictionary<Type, IManager> _managerContainer = new();

    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
    private static void Bind()
    {



    }

    public static T GetManager<T>() where T : IManager
    {

        if(_managerContainer.TryGetValue(typeof(T), out var value))
        {
            return value.Cast<T>();
        }

        return default;

    }

}