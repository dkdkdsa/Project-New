using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerBaseInstaller : InstallerBase<TowerBase>
{
    protected override void Inject(TowerBase[] targets)
    {

        foreach (var target in targets)
        {

            //Bind
            IController rotateC = null;
            IController attackC = null;
            IController targetC = GetComponent<TowerTargetController>();
            //
            target.Inject(rotateC, attackC, targetC);

        }

    }

}
