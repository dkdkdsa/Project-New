using System.Collections.Generic;
using UnityEngine;

public enum TowerEventType
{

    Attack,

}

public abstract class TowerBase : UnitBase
{

    protected IController _rotateController;
    protected IController _attackController;
    protected IController _targetController;

    public void Inject(IController rotateController, IController attackController, IController targetController)
    {
        _rotateController = rotateController;
        _attackController = attackController;
        _targetController = targetController;
    }

}