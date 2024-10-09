using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static TowerStatusUIController;

public class TowerStatueModel
{

    public string name;
    public List<StatUIBinding> binding;
    public IReadOnlyList<StatUpgradeData<int, float>> statUpgradeDatas;

}

public struct StatUIBinding
{

    public int hash;
    public float value;

}

public class TowerStatusUIController : UIController<TowerStatueModel, TowerStatusUIView, ActionType>
{

    public enum ActionType
    {

    }

}
