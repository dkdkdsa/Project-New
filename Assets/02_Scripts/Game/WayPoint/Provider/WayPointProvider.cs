using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(WayPoint))]
public class WayPointProvider : MonoBehaviour, IWayPoint
{
    private WayPoint _wayPoint;

    private void Awake()
    {
        _wayPoint = GetComponent<WayPoint>();
    }

    public Vector3 GetWayPointPosition(int index)
    {
        return _wayPoint.GetWayPointPosition(index);
    }

    public Vector3[] ModifyWayPointPosition(int index, Vector3 position)
    {
        return _wayPoint.ModifyWayPointPosition(index, position);
    }
}