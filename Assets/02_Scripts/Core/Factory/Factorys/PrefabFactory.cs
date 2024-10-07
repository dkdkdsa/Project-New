using System.Collections.Generic;
using UnityEngine;

public class PrefabFactory : IFactory<GameObject>
{

    private Dictionary<string, GameObject> _prefabs;

    public GameObject CreateInstance(PrefabData data = default, object extraData = null)
    {

        if (_prefabs == null)
            Init();

        return Object.Instantiate(_prefabs[data.prefabKey]);

    }

    private void Init()
    {

        _prefabs = new Dictionary<string, GameObject>();

        var resMgr = Managers.GetManager<IResourceManager>();
        var ress = resMgr.GetResources<GameObject>("Prefab");

        foreach (var item in ress)
        {
            _prefabs.Add(item.key, item.data);
        }

    }
}
