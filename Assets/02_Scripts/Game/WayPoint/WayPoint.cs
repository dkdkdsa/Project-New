using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WayPoint : MonoBehaviour
{
    //waypoint에 쓸 points;
    [SerializeField] private Vector3[] _points;

    //마지막 point와 첫 번째 point를 연결할 것인가 여부
    public bool IsLinked { get; set; }

    private Vector3 _currentPosition;

    //WayPointEditor에서 사용하는 points;
    public Vector3[] Points => _points;
    //WayPointEditor에tj 사용하는 현재 포지션
    public Vector3 CurrentPosition => _currentPosition;

    private void Start()
    {
        _currentPosition = transform.position;
    }

    /// <summary>
    /// index 위치의 Route Point
    /// </summary>
    public Vector3 GetWayPointPosition(int index)
    {
        return CurrentPosition + _points[index];
    }

#if UNITY_EDITOR

    private void OnDrawGizmos()
    {
        for (int i = 0; i < _points.Length; i++) //기즈모 원
        {
            Gizmos.color = Color.green;
            Gizmos.DrawWireSphere(_points[i] + _currentPosition, 0.5f);

            if (i < _points.Length - 1) //기즈모 선
            {
                DrawLine(i, i + 1);
            }
        }

        if(IsLinked)
        {
            DrawLine(_points.Length - 1, 0);
        }
    }

    private void DrawLine(int fromIdx, int toIdx)
    {
        Gizmos.color = Color.gray;
        Gizmos.DrawLine(_points[fromIdx] + _currentPosition, _points[toIdx] + _currentPosition);
    }

#endif
}