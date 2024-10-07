using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovementController : MonoBehaviour, IController, ILocalInject, IRouteHandler
{
    public bool Active { get; set; } = true;

    private IRouteable    _route;
    private IMoveable _move;


    public void LocalInject(ComponentList list)
    {
        _move  = list.Find<IMoveable>();
        _route = list.Find<IRouteable>();
    }

    public void GetRoute(Vector3[] routes, bool isRepeat = false)
    {
        _route.GetRoute(routes, isRepeat);
    }

    public void Control(params object[] param)
    {
        if (!Active) return;

        _move.Move(_route.ReturnRoute(), 5f);
    }
}