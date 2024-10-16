using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static EnemyStatusUIController;

public class EnemyStatusUIController : UIController<EnemyStatusModel, EnemyStatusUIView, ActionType>
{

    private IEventManager _evtMgr;
    private IHpable _currentSelectHp;
    private EnemyBase _currentEnemy;

    public enum ActionType
    {



    }

    private void Awake()
    {
        
        _evtMgr = Managers.GetManager<IEventManager>();
        _evtMgr.RegisterEvent(GlobalEvent.UnitSelect, HandleSelect);

    }

    private void Update()
    {

        if (_currentEnemy != null)
            return;

        _model.hp = _currentSelectHp.Hp;
        _m

    }

    private void HandleSelect(object[] param)
    {

        if (param[0] is not EnemyBase)
            return;

        var enemy = param[0].Cast<EnemyBase>();
        _currentEnemy = enemy;

        var name = enemy.Data.Name;
        _currentSelectHp = enemy.GetComponent<IHpable>();
        _currentSelectHp.OnHpChanged += HandleHpChanged;

        _model = new();
        _model.name = name;
        _model.hp = _currentSelectHp.Hp;
        _model.position = enemy.transform.position;

        _view.Viewing(_model);

    }

    private void HandleHpChanged(float oldValue, float newValue)
    {

        _model.hp = newValue;

    }

}
