using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour, ILocalInject
{
    //이 부분은 나중에 스폰 컨트롤러에서 받아야함
    [SerializeField] private EnemyMovementController _controller;
    [SerializeField] private bool _repeatMovement;

    private IWayPoint _wayPoint;

    public void LocalInject(ComponentList list)
    {
        _wayPoint = list.Find<IWayPoint>();
    }

    private void Start()
    {
        SpawnUnit();
    }

    private void SpawnUnit()
    {
        EnemyMovementController unit = Instantiate(_controller);
        unit.transform.position = _wayPoint.GetWayPointPosition(0);
        unit.GetPath(_wayPoint.Route(), _repeatMovement);
    }
}