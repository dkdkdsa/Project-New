using System;
using System.Collections.Generic;
using UnityEngine;

public static class Managers
{

    private static Dictionary<Type, IManager> _managerContainer = new();

    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
    private static void Bind()
    {

        GameObject root = new GameObject("@!STATIC_MANAGERS!@");

#if UNITY_EDITOR

        UnityEditor.EditorApplication.quitting += HandleQuit;

#else
    
        Application.quitting += HandleQuit;

#endif
        var resourceManager = root.AddComponent<AddressableResourceManager>();
        _managerContainer.Add(typeof(IResourceManager), resourceManager);
        _managerContainer.Add(typeof(ISoundManager), new SoundManager());

        foreach (var manager in _managerContainer.Values)
        {
            manager.Init();
        }

    }

    private static void HandleQuit()
    {

        foreach(var item in _managerContainer.Values)
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