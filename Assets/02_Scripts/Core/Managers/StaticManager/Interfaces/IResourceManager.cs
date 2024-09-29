using UnityEngine;

public interface IResourceManager : IManager
{

    /// <summary>
    /// 리소스를 가져온다
    /// </summary>
    /// <typeparam name="T">리소스의 타입</typeparam>
    /// <param name="key">리소스의 키</param>
    /// <returns>리소스의 인스턴스</returns>
    public T GetResource<T>(string key) where T : Object;

    /// <summary>
    /// 리소스를 가져온다
    /// </summary>
    /// <typeparam name="T">리소스의 타입</typeparam>
    /// <param name="key">리소스의 키</param>
    /// <returns>리소스의 인스턴스</returns>
    public T GetResource<T>(int key) where T : Object;

}