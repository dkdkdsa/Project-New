using System;
using System.Collections.Generic;
using UnityEngine;

public abstract class StatUpgrader<TKey, TValue> : MonoBehaviour, IUpgradeable, ILocalInject
{

    [field: SerializeField] public List<StatUpgradeData<TKey, TValue>> Datas { get; private set; } = new();

    private IStatContainer<TKey> _stat;

    public int Level { get; protected set; }

    public event Action OnUpgraded;

    public void LocalInject(ComponentList list)
    {

        _stat = list.Find<IStatContainer<TKey>>();

    }

    protected abstract bool ApplyCost();
    public int GetCost()
    {

        return Datas[Level].cost;

    }

    public bool Upgrade()
    {

        if(!(Datas.Count > Level))
            return false;

        Debug.Log(1);

        if (ApplyCost())
        {

            var obj = Datas[Level];
            foreach(var item in obj.datas)
            {

                _stat.AddModify(item.statKey, item.modify);

            }

            OnUpgraded?.Invoke();
            Level++;
            return true;

        }

        return false;

    }

}

[Serializable]
public class StatControlData<TKey, TValue>
{

    public TKey statKey;
    public TValue modify;

}

[Serializable]
public class StatUpgradeData<TKey, TValue>
{

    public int cost;
    public List<StatControlData<TKey, TValue>> datas = new();

}