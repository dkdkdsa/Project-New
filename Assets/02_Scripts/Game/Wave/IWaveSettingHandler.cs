public interface IWaveSettingHandler
{
    /// <summary>
    /// 기본 생성 시간
    /// </summary>
    public float DefaultSpawnTime { get; }

    /// <summary>
    /// 웨이브간의 시간 간격
    /// </summary>
    public float WaveIntervalTime { get; }

    /// <summary>
    /// 모든 웨이브
    /// </summary>
    public int Wave { get; }

    /// <summary>
    /// 현재 웨이브(0부터 시작)
    /// </summary>
    public int CurrentWave { get; set; }




    /// <summary>
    /// 지정 웨이브에 실행해야 할 웨이브의 개수
    /// </summary>
    /// <param name="wave">지정 웨이브</param>
    /// <returns></returns>
    public int SpawnUnitCountInWave(int wave);

    /// <summary>
    /// 지정 웨이브의 index에 위치한 값
    /// </summary>
    /// <param name="wave">지정 웨이브</param>
    /// <param name="index">지정 웨이브의 인덱스</param>
    /// <returns></returns>
    public SpawnData GetSpawnData(int wave, int index);

    /// <summary>
    /// 지정 웨이브의 값
    /// </summary>
    /// <param name="wave">지정 웨이브</param>
    /// <returns></returns>
    public WaveData GetWaveData(int wave);
}