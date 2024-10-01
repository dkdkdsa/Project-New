using UnityEngine;
using UnityEngine.AI;

/// <summary>
/// NavMeshAgent를 사용하는 객체의 경로 찾기
/// </summary>
[RequireComponent(typeof(NavMeshAgent))]
public class NavMeshRouteFinder : MonoBehaviour, IRoute
{
    private NavMeshAgent _agent;
    private Vector3[] _routes;
    private bool _isRepeat;

    private int _routeIndex = 0;

    private void Awake()
    {
        _agent = GetComponent<NavMeshAgent>();
    }

    /// <summary>
    /// 경로와 반복 여부 받기
    /// </summary>
    /// <param name="routes">경로</param>
    /// <param name="isRepeat">반복 여부</param>
    public void GetRoute(Vector3[] routes, bool isRepeat = false)
    {
        _routes = routes;
        _isRepeat = isRepeat;
    }

    /// <summary>
    /// 현재 위치와 비교하여 가야할 경로를 반환(Vector3)
    /// </summary>
    /// <returns></returns>
    public Vector3 ReturnRoute()
    {
        if (!_isRepeat && _routeIndex >= _routes.Length - 1)
        {
            return _routes[_routeIndex];
        }

        if (!_agent.pathPending && _agent.remainingDistance <= _agent.stoppingDistance) // 경로 계산이 완료되었는지 확인
        {
            if (_routeIndex >= _routes.Length - 1)
            {
                _routeIndex = 0;
            }
            else
            {
                _routeIndex++;
            }
        }

        return _routes[_routeIndex];
    }
}
