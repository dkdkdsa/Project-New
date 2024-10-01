using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : EnemyBase
{
    private IRouteable _routeBaseMovement;

    public override void Init()
    {

    }

    public override void LocalInject(ComponentList list)
    {
        base.LocalInject(list);

        _routeBaseMovement = list.Find<IRouteable>();
    }

    public override void RouteMovement(Vector3[] routes, bool repeatMovement = false)
    {
        _routeBaseMovement.GetRoute(routes, repeatMovement);
    }
}