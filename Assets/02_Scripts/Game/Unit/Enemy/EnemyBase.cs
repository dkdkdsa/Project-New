using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[RequireComponent(typeof(LocalInstaller))]
public abstract class EnemyBase : UnitBase, ILocalInject, IRouteBaseSpawnable
{
    protected List<IController> _controllers = new();
    protected Dictionary<string, IController> _controlDatas = new();

    public abstract void Init();

    public virtual void LocalInject(ComponentList list)
    {
        _controllers = list.FindAll<IController>();

        foreach(IController controller in _controllers)
        {
            _controlDatas.Add(controller.GetType().Name, controller);
        }
    }

    public abstract void RouteMovement(Vector3[] routes, bool repeatMovement = false);

    protected virtual void Update()
    {
        foreach(var controller in _controllers)
        {
            controller.Control();
        }
    }
}