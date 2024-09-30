using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[RequireComponent(typeof(LocalInstaller))]
public abstract class EnemyBase : UnitBase, ILocalInject
{

    protected List<IController> _contaollers;

    public void LocalInject(ComponentList list)
    {
        _contaollers = list.FindAll<IController>();
    }

    protected virtual void Update()
    {
        foreach(var controller in _contaollers)
        {
            controller.Control();
        }
    }

}