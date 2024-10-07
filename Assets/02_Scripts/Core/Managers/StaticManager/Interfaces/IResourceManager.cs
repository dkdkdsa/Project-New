using System.Collections.Generic;
using UnityEngine;

public struct ResourceMap<T> where T : Object
{

    public string key;
    public T data;

}

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

    /// <summary>
    /// 모든 리소스를 가져온다
    /// </summary>
    /// <typeparam name="T">리소스의 타입</typeparam>
    /// <param name="key">리소스의 키</param>
    /// <returns>리소스의 인스턴스</returns>
    public IReadOnlyList<ResourceMap<T>> GetResources<T>(string key) where T : Object;

    /// <summary>
    /// 모든 리소스를 가져온다
    /// </summary>
    /// <typeparam name="T">리소스의 타입</typeparam>
    /// <param name="key">리소스의 키</param>
    /// <returns>리소스의 인스턴스</returns>
    public IReadOnlyList<ResourceMap<T>> GetResources<T>(int key) where T : Object;

}