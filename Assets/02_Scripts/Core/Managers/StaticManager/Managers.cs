using System;
using System.Collections.Generic;
using UnityEngine;

public static class Managers
{

    private static Dictionary<Type, IManager> _managerContainer;

    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
    private static void Bind()
    {

        _managerContainer = new();

#if UNITY_EDITOR

        UnityEditor.EditorApplication.quitting += HandleQuit;

#else
    
        Application.quitting += HandleQuit;

#endif
        _managerContainer.Add(typeof(IResourceManager), new AddressableResourceManager());
        _managerContainer.Add(typeof(ISoundManager), new SoundManager());
        _managerContainer.Add(typeof(IEventManager), new EventManager());

        foreach (var manager in _managerContainer.Values)
        {
            manager.Init();
        }

    }

    private static void HandleQuit()
    {

        foreach (var item in _managerContainer.Values)
        {
            item.Dispose();
        }

    }

    public static T GetManager<T>() where T : IManager
    { 

        if (_managerContainer.TryGetValue(typeof(T), out var value))
        {
            return value.Cast<T>();
        }

        return default;

    }

}