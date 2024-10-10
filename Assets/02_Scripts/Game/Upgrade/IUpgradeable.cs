using System;

public interface IUpgradeable
{

    /// <summary>
    /// 업그레이드 가능한 객체의 레벨
    /// </summary>
    public int Level { get; }

    /// <summary>
    /// 업그레이드 되었을 때 발행되는 이벤트
    /// </summary>
    public event Action OnUpgraded;

    /// <summary>
    /// 업그레이드에 필요한 코스트를 반환
    /// </summary>
    /// <returns>필요 코스트</returns>
    public int GetCost();

    /// <summary>
    /// 업그레이드 실행
    /// </summary>
    /// <returns>업그레이드 성공 여부</returns>
    public bool Upgrade();

}