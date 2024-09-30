using UnityEngine;

public interface IWayPoint
{
    public Vector3[] Route();

    public Vector3 GetWayPointPosition(int index);

    public void RepeatMoevement(bool value);
}