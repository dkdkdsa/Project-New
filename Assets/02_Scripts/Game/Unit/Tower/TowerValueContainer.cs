using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class StatPair<T, TValue> where T : StatBase<TValue>
{

    public string name;
    public T stat;

}

public class TowerValueContainer : MonoBehaviour, IValueContainer<int>, IStatContainer<int>
{

    [SerializeField] private List<StatPair<FloatStat, float>> _floatStats = new();

    private Dictionary<int, FloatStat> _floatStatContainer;
    private Transform _target;

    private void Awake()
    {

        _floatStatContainer = new();

        foreach (var pair in _floatStats)
        {

            _floatStatContainer.Add(pair.name.GetHash(), new FloatStat(pair.stat));

        }

    }

    public void AddModify<T>(int key, T mod)
    {

        if (_floatStatContainer.ContainsKey(key))
            _floatStatContainer[key].AddModify(mod.Cast<float>());

    }

    public void RemoveModify<T>(int key, T value)
    {

        if (_floatStatContainer.ContainsKey(key))
            _floatStatContainer[key].RemoveModify(value.Cast<float>());

    }

    public T GetValue<T>(int key)
    {

        if (_floatStatContainer.ContainsKey(key))
            return _floatStatContainer[key].Value.Cast<T>();
        else if (key == Hashs.TOWER_VALUE_TARGET)
            return _target.Cast<T>();

        return default;

    }

    public void SetValue<T>(int key, T value)
    {

        if (_floatStatContainer.ContainsKey(key))
            _floatStatContainer[key].SetValue(value.Cast<float>());
        else if (key == Hashs.TOWER_VALUE_TARGET)
            _target = value as Transform;

    }
}
