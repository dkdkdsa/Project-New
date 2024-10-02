using System.Collections.Generic;
using UnityEngine;

public class UnitFactory : MonoBehaviour, IFactory<ISpawnable>
{


    /// <summary>
    /// 디버깅용 수정 나중에 리소스 매니져로 로딩 할 수 있도록 바꿀것
    /// </summary>
    [SerializeField] private List<GameObject> _debugSpawn = new();

    private Dictionary<string, GameObject> _prefabContainer = new();

    private void Awake()
    {

        Factorys.AddFactory(typeof(IFactory<ISpawnable>), this);

        foreach(var item in _debugSpawn)
        {

            _prefabContainer.Add(item.name, item);

        }

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
