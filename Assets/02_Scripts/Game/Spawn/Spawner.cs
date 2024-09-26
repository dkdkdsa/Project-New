using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour, ILocalInject
{
    private IWayPoint _wayPoint;

    public void LocalInject(ComponentList list)
    {
        _wayPoint = list.Find<IWayPoint>();
    }
}