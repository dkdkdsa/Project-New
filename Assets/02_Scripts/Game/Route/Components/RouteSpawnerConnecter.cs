using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(IRouteHandler))]
[RequireComponent(typeof(IWayPoint))]
public class RouteSpawnerConnecter : MonoBehaviour, ILocalInject
{
    [SerializeField] private bool _isRepeat;

    private IRouteHandler _routeSpawner;
    private IWayPoint _wayPoint;

    public void LocalInject(ComponentList list)
    {
        _routeSpawner = list.Find<IRouteHandler>();
        _wayPoint     = list.Find<IWayPoint>();
    }

    private void Awake()
    {
        _routeSpawner.GetRoute(_wayPoint.Route(), _isRepeat);
    }
}