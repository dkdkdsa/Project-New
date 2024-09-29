/// <summary>
/// 정적 매니져가 상속받는 base
/// </summary>
public interface IManager
{
    /// <summary>
    /// 생성 되었을 때
    /// </summary>
    public void Created();

    /// <summary>
    /// 초기화ㄴ
    /// </summary>
    public void Init();
}