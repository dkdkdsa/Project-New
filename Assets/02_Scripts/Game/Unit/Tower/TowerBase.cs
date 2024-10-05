using System.Collections.Generic;

public class TowerBase : UnitBase, ILocalInject
{

    protected List<IController> _controllers;

    public void LocalInject(ComponentList list)
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