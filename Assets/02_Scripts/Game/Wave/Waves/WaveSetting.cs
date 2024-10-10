using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSetting : MonoBehaviour, IWaveSettingHandler
{
    [SerializeField] private float _waveStartTime;
    [SerializeField] private float _defaultSpawnInterval;
    [SerializeField] private List<WaveData> _waveData;

    public float DefaultSpawnTime => _defaultSpawnInterval;

    public float WaveIntervalTime => _waveStartTime;

    public int Wave => _waveData.Count;

    public SpawnData GetSpawnData(int wave, int index)
    {
        return _waveData[wave].SpawnDatas[index];
    }

    public WaveData GetWaveData(int wave)
    {
        return _waveData[wave];
    }

    public int SpawnUnitCountInWave(int wave)
    {
        return _waveData[wave].SpawnDatas.Count;
    }

#if UNITY_EDITOR

    public List<WaveData> WaveData => _waveData;

#endif
}