using UnityEngine;

public interface IRouteHandler
{
    /// <summary>
    /// 경로와 반복 여부를 받아온다
    /// </summary>
    /// <param name="routes">경로</param>
    /// <param name="isRepeat">반복 여부</param>
    public void GetRoute(Vector3[] routes, bool isRepeat = false);
}

public interface IRouteable : IRouteHandler
{
    public Vector3[] Routes { get; }
    public Vector3 ReturnRoute();
}