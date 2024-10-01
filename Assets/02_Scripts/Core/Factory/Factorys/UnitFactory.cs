using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitFactory : MonoBehaviour, IFactory<IRouteBaseSpawnable>
{
    private Dictionary<string, GameObject> _prefabContainer = new();

    public IRouteBaseSpawnable CreateInstance(PrefabData data = default, object extraData = null)
    {
        var ins = _prefabContainer[data.prefabKey];

        if (ins == null) return null;

        //객체 생성 부분 나중에 Pooling으로 바꿀것
        var obj = Instantiate(ins).GetComponent<IRouteBaseSpawnable>();
        obj.Init();

        return obj;
    }
}
