using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSetting : MonoBehaviour, IWaveSettingHandler
{
    public float WaveStartTime;
    public float DefaultSpawnInterval;
    public List<WaveData> WaveData = new();

    public float DefaultSpawnTime => DefaultSpawnInterval;

    public float WaveIntervalTime => WaveStartTime;

    public int Wave => WaveData.Count;

    public SpawnData GetSpawnData(int wave, int index)
    {
        return WaveData[wave].SpawnDatas[index];
    }

    public WaveData GetWaveData(int wave)
    {
        return WaveData[wave];
    }

    public int SpawnUnitCountInWave(int wave)
    {
        return WaveData[wave].SpawnDatas.Count;
    }
}