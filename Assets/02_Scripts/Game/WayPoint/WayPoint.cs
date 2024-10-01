using UnityEngine;

public class WayPoint : MonoBehaviour, IWayPoint
{
    /// <summary>
    /// Route의 Point
    /// </summary>
    [SerializeField] private Vector3[] _points;

    private Vector3 _currentPosition;

    /// <summary>
    /// WayPointEditor에서 사용하는 points;
    /// </summary>
    public Vector3[] Points => _points;

    /// <summary>
    /// WayPointEditor에서 사용하는 현재 포지션
    /// </summary>
    public Vector3 CurrentPosition => _currentPosition;

    public Vector3 GetWayPointPosition(int index)
    {
        return CurrentPosition + _points[index];
    }

    public Vector3[] Route()
    {
        return _points;
    }

    private void Start()
    {
        _currentPosition = transform.position;
    }

#if UNITY_EDITOR

    private void OnDrawGizmos()
    {
        for (int i = 0; i < _points.Length; i++)
        {
            //Point를 원으로 시각화
            Gizmos.color = Color.green;
            Gizmos.DrawWireSphere(_points[i] + _currentPosition, 0.5f);

            //원끼리 이어지는 선 시각화
            if (i < _points.Length - 1)
            {
                Gizmos.color = Color.gray;
                Gizmos.DrawLine(_points[i] + _currentPosition, _points[i + 1] + _currentPosition);
            }
        }
    }

#endif
}