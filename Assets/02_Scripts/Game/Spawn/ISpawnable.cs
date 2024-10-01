using UnityEngine;

public interface ISpawnable
{
    public void Init();
}

public interface IRouteBaseSpawnable : ISpawnable
{
    public void RouteMovement(Vector3[] routes, bool repeatMovement = false);
}