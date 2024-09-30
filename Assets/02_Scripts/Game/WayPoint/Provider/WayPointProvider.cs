using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// WayPoint 반환자 
/// </summary>
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

    public Vector3[] Route()
    {
        return _wayPoint.Points;
    }
}