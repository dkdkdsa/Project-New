using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

/// <summary>
/// NavMeshAgent를 사용하는 객체의 이동
/// </summary>
[RequireComponent(typeof(NavMeshAgent))]
public class NavMeshMovement : MonoBehaviour, IMoveable
{
    private NavMeshAgent _agent;

    private void Awake()
    {
        _agent = GetComponent<NavMeshAgent>();
    }

    public void Move(in Vector3 vec, in float speed)
    {
        _agent.speed = speed;
        _agent.SetDestination(vec);
    }
}
