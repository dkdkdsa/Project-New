using System;

/// <summary>
/// 정적 매니져가 상속받는 base
/// </summary>
public interface IManager : IDisposable
{

    /// <summary>
    /// 초기화
    /// </summary>
    public void Init();
}