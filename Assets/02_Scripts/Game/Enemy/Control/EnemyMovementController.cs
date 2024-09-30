using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovementController : MonoBehaviour, IController, ILocalInject
{
    public bool Active { get; set; } = true;

    private IRoute    _route;
    private IMoveable _move;


    public void LocalInject(ComponentList list)
    {
        _move  = list.Find<IMoveable>();
        _route = list.Find<IRoute>();
    }

    /// <summary>
    /// 생성해주는 객체로부터 경로를 받아온다
    /// </summary>
    /// <param name="routes">경로</param>
    /// <param name="isRepeat">경로의 움직임을 반복할 것인지 여부</param>
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

        if (!Active)
            return;

        _move.Move(_route.ReturnRoute(), 5f);
    }
}