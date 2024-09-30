using UnityEngine;

public interface IRoute
{
    public void GetRoute(Vector3[] routes, bool isRepeat = false);

    public Vector3 ReturnRoute();
}