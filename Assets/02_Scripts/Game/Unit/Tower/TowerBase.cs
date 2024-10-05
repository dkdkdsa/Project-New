using System.Collections.Generic;
using UnityEngine;

public abstract class TowerBase : UnitBase, ILocalInject
{

    protected List<IController> _controllers;
    public Transform Target { get; set; }

    public virtual void LocalInject(ComponentList list)
    {

        _controllers = list.FindAll<IController>();

    }

    protected virtual void Update()
    {

        foreach (var controller in _controllers)
        {

            if (!controller.Active)
                continue;

            controller.Control();

        }

    }

}