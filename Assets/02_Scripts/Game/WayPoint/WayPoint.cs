using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WayPoint : MonoBehaviour
{
    [SerializeField] private Vector3[] _points; //waypoint에 쓸 points;
    private Vector3 _currentPosition;

    public Vector3[] Points => _points; //WayPointEditor에 쓸 points;
    public Vector3 CurrentPosition => _currentPosition;

    void Start()
    {
        _currentPosition = transform.position;
    }

    public Vector3 GetWayPointPosition(int index)
    {
        return CurrentPosition + _points[index];
    }

    public Vector3[] ModifyWayPointPosition(int index, Vector3 position)
    {
        _points[index] = position;

        return _points;
    }

    private void OnDrawGizmos()
    {
        if (transform.hasChanged) //gameStarted가 false고, 포지션 값이 바뀌었으면
        {
            _currentPosition = transform.position; //_currentPosition에 현재 포지션 값을 넣는다
        }

        for (int i = 0; i < _points.Length; i++) //기즈모 원
        {
            Gizmos.color = Color.green;
            Gizmos.DrawWireSphere(_points[i] + _currentPosition, radius: 0.5f); // radius 원 반지름

            if (i < _points.Length - 1) //기즈모 선
            {
                Gizmos.color = Color.gray;
                Gizmos.DrawLine(_points[i] + _currentPosition, _points[i + 1] + _currentPosition);
            }
        }
    }
}