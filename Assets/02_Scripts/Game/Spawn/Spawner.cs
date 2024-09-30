using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour, ILocalInject
{
    [SerializeField] private EnemyMovementController _controller;
    private IWayPoint _wayPoint;

    public void LocalInject(ComponentList list)
    {
        _wayPoint = list.Find<IWayPoint>();
    }

    private void Start()
    {
        var obj = Instantiate(_controller);
        obj.transform.position = _wayPoint.GetWayPointPosition(0);
        obj.GetPath(_wayPoint.Route());
    }
}