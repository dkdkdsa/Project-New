using System.Collections.Generic;
using UnityEngine;

public class UnitFactory : MonoBehaviour, IFactory<ISpawnable>
{
    private Dictionary<string, GameObject> _prefabContainer = new();

    private void Awake()
    {

        Factorys.AddFactory(typeof(IFactory<ISpawnable>), this);

    }

    public ISpawnable CreateInstance(PrefabData data = default, object extraData = null)
    {
        var ins = _prefabContainer[data.prefabKey];

        if (ins == null) return null;

        //객체 생성 부분 나중에 Pooling으로 바꿀것
        var obj = Instantiate(ins).GetComponent<ISpawnable>();
        obj.Init();

        return obj;
    }

    private void OnDestroy()
    {

        Factorys.RemoveFactory(typeof(IFactory<ISpawnable>));

    }
}
