using UnityEngine;

public interface IWayPoint
{
    public Vector3 GetWayPointPosition(int index);

    public Vector3[] ModifyWayPointPosition(int index, Vector3 position);
}