using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour, ILocalInject
{
    [SerializeField] private EnemyMovementController _controller;
    [SerializeField] private bool _repeatMovement;

    private IWayPoint _wayPoint;

    public void LocalInject(ComponentList list)
    {
        _wayPoint = list.Find<IWayPoint>();
    }

    private void Start()
    {
        
    }

    private void OnGUI()
    {
        _wayPoint.RepeatMoevement(_repeatMovement);
    }

    //private void SpawnUnit(GameObject unit)
    //{
    //    unit = Instantiate(_controller);
    //    unit.transform.position = _wayPoint.GetWayPointPosition(0);
    //}
    //
    //private void SetRoute()
    //{
    //    obj.GetPath(_wayPoint.Route());
    //}
}