using UnityEngine;

public interface IRoute
{
    public void GetRoute(Vector3[] routes);

    public Vector3 ReturnRoute();
}