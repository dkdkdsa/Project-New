using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovementController : MonoBehaviour, IController, ILocalInject
{
    private IRoute    _route;
    private IMoveable _move;

    public void LocalInject(ComponentList list)
    {
        _move  = list.Find<IMoveable>();
        _route = list.Find<IRoute>();
    }

    public void GetPath(Vector3[] routes, bool isRepeat)
    {
        _route.GetRoute(routes, isRepeat);
    }

    private void Update()
    {
        Control();
    }

    public void Control()
    {
        _move.Move(_route.ReturnRoute(), 5f);
    }
}