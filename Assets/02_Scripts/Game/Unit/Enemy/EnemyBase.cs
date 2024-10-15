using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[RequireComponent(typeof(LocalInstaller))]
public abstract class EnemyBase : UnitBase, IRouteBaseSpawnable
{
    public abstract void Init();

    public abstract void RouteMovement(Vector3[] routes, bool repeatMovement = false);
}