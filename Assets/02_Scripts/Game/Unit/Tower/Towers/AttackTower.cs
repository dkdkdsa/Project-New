using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackTower : TowerBase
{

    protected IController _attack;
    protected IController _target;

    public void Inject(IController attack, IController target)
    {
        _attack = attack;
        _target = target;
    }

}
