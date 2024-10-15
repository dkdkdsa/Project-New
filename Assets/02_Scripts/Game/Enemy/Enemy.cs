using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : EnemyBase, ILocalInject
{
    protected List<IController> _controllers = new();
    private IRouteable _routeBaseMovement;

    public override void Init()
    {
    }

    public void LocalInject(ComponentList list)
    {
        _controllers       = list.FindAll<IController>();
        _routeBaseMovement = list.Find<IRouteable>();
    }

    public override void RouteMovement(Vector3[] routes, bool repeatMovement = false)
    {
        _routeBaseMovement.GetRoute(routes, repeatMovement);

        transform.position = routes[0];
    }

    protected virtual void Update()
    {
        foreach (var controller in _controllers)
        {
            if (!controller.Active) continue;

            controller.Control();
        }
    }
}