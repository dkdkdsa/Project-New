using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoutedSpawner : Spawner<IRouteBaseSpawnable>
{
    protected override void SpawnSetting(IRouteBaseSpawnable instance)
    {
        //instance.RouteMovement();
    }
}