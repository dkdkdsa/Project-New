public interface IWaveTrigger
{
    /// <summary>
    /// 웨이브를 실행시켜주는 매서드
    /// </summary>
    public void StartWave();

    /// <summary>
    /// 다음 웨이브로 이동하게 해주는 매서드
    /// </summary>
    public void AllowWaveTransition();
}