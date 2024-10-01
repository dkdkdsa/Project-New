using UnityEngine;

public interface IRoute
{
    public void GetRoute(Vector3[] routes, bool isRepeat = false);
}

public interface IRouteable : IRoute
{
    public Vector3 ReturnRoute();
}