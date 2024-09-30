using UnityEngine;

public interface IWayPoint
{
    /// <summary>
    /// 경로 반환(Vector3[])
    /// </summary>
    /// <returns></returns>
    public Vector3[] Route();

    /// <summary>
    /// index값에 해당하는 경로 반환(Vector)
    /// </summary>
    /// <param name="index"></param>
    /// <returns></returns>
    public Vector3 GetWayPointPosition(int index);
}