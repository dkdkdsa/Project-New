using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static TowerStatusUIController;

public class TowerStatueModel
{

    public TowerStatueModel(TowerBase tower)
    {

        name = tower.name;
        icon = tower.Data.View;

        var upgrader = tower.GetComponent<TowerUpgrader>();
        currentLevel = upgrader.Level;
        statUpgradeDatas = upgrader.Datas;

        var stat = tower.GetComponent<IStatContainer<int>>();
        var stats = stat.GetStatData<StatPair<FloatStat, float>>();
        List<StatUIBinding> bindings = new List<StatUIBinding>();
        foreach(var item in stats)
        {

            bindings.Add(new StatUIBinding 
            { 
                name = item.name, 
                value = stat.GetStat<FloatStat>(item.name.GetHash()).Value 
            });

        }

        binding = bindings;

    }

    public readonly string name;
    public readonly Sprite icon;
    public readonly int currentLevel;
    public readonly IReadOnlyList<StatUIBinding> binding;
    public readonly IReadOnlyList<StatUpgradeData<int, float>> statUpgradeDatas;

}

public class StatUIBinding
{

    public string name;
    public float value;

}

public class TowerStatusUIController : UIController<TowerStatueModel, TowerStatusUIView, ActionType>
{

    private TowerBase _currentTower;
    private IUpgradeable _currentUpgrade;
    private IEventManager _evtMgr;

    public enum ActionType
    {

        Upgrade,
        Sell

    }

    public override void LocalInject(ComponentList list)
    {

        base.LocalInject(list);

        _evtMgr = Managers.GetManager<IEventManager>();

        _evtMgr.RegisterEvent(GlobalEvent.UnitSelect, HandleTowerSelected);

        _view.RegisterEvent(ActionType.Upgrade, HandleUpgrade);
        _view.RegisterEvent(ActionType.Sell, HandleSell);

    }

    private void HandleSell(object[] param)
    {
    }

    private void HandleUpgrade(object[] param)
    {

        _currentUpgrade.Upgrade();
        _model = new TowerStatueModel(_currentTower);

        _view.Viewing(_model);
    }

    private void HandleTowerSelected(object[] param)
    {

        var tower = param[0].Cast<TowerBase>();
        _currentTower = tower;
        _currentUpgrade = tower.GetComponent<IUpgradeable>();

        _model = new TowerStatueModel(tower);

        _view.Viewing(_model);

    }
}
