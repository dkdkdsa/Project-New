using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackTower : TowerBase
{

    protected IController _attack;
    protected IController _target;
    protected IController _rotate;

    public void Inject(IController attack, IController target, IController rotate)
    {
        _attack = attack;
        _target = target;
        _rotate = rotate;
    }

}
