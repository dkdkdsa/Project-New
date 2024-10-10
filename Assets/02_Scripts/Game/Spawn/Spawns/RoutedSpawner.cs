using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoutedSpawner : Spawner<IRouteBaseSpawnable>, IRouteHandler
{
    private Vector3[] _routes;
    private bool _isRepeat;

    public void GetRoute(Vector3[] routes, bool repeatMovement = false)
    {
        _routes = routes;
        _isRepeat = repeatMovement;
    }

    protected override void SpawnSetting(IRouteBaseSpawnable instance)
    {
        instance.RouteMovement(_routes, _isRepeat);
    }
}