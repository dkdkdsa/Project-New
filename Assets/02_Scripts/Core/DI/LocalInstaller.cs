using System.Collections.Generic;
using UnityEngine;

public class LocalInstaller : InstallerBase
{

    protected override void Awake()
    {
        
        var compoList = new ComponentList(GetComponentsInChildren<Component>());

        foreach(var inj in GetComponentsInChildren<ILocalInject>())
        {

            inj.LocalInject(compoList);

        }

    }

  
}
