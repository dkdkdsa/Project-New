using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerUpgrader : StatUpgrader<int, float>
{
    protected override bool ApplyCost()
    {

        Debug.Log(1);
        return true;

    }

}
