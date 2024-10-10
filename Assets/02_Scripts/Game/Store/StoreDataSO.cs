using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class StoreData
{

    public int price;
    public ScriptableObject obj;

}

[CreateAssetMenu(menuName = "SO/Store/Data")]
public sealed class StoreDataSO : ScriptableObject
{

    [SerializeField] private List<StoreData> _storeDatas = new();
    public IReadOnlyList<StoreData> StoreDatas => _storeDatas;

}
