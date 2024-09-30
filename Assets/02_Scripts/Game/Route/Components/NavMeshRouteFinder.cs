using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class NavMeshRouteFinder : MonoBehaviour, IRoute
{
    private NavMeshAgent _agent;
    private Vector3[] _routes;

    private int _routeIndex = 0;

    private void Awake()
    {
        _agent = GetComponent<NavMeshAgent>();
    }

    public void GetRoute(Vector3[] routes)
    {
        _routes = routes;
    }

    public Vector3 ReturnRoute()
    {
        if (_routeIndex >= _routes.Length - 1) return _routes[_routeIndex];

        if (!_agent.pathPending) // 경로 계산이 완료되었는지 확인
        {
            if (_agent.remainingDistance <= _agent.stoppingDistance)
            {
                _routeIndex++;
            }
        }

        return _routes[_routeIndex];
    }
}
