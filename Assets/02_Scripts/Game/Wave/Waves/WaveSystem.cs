using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(WaveSetting))]
public partial class WaveSystem : MonoBehaviour, ILocalInject, IWaveTrigger
{
    private Spawner<IRouteBaseSpawnable> _spawner;
    private IWaveSettingHandler _waveSetting;

    private int _currentWave    = 0;
    private bool _canChangeWave = false;

    public void LocalInject(ComponentList list)
    {
        _spawner     = list.Find<Spawner<IRouteBaseSpawnable>>();
        _waveSetting = list.Find<IWaveSettingHandler>();
    }

    public void StartWave()
    {
        StartCoroutine(OnWaveCoroutine());
    }

    public void AllowWaveTransition()
    {
        _canChangeWave = true;
    }

    #region WaveEvent

    /// <summary>
    /// Unit 생성
    /// </summary>
    /// <param name="index">현재 웨이브에 생성할 유닛의 인덱스</param>
    private void SpawnUnit(int index)
    {
        var prefab = _waveSetting.GetSpawnData(_currentWave, index).Prefab;

        PrefabData prefabData = new PrefabData
        {
            prefabKey = prefab.name,
        };

        _spawner.GetInstanceData(prefabData);
        _spawner.SpawnUnit();
    }

    /// <summary>
    /// Unit 생성이 아니라면 실행될 이벤트
    /// </summary>
    private void TriggerWaveEvent()
    {
        WaveHub.OnWaveEvent?.Invoke(_currentWave);
    }

    #endregion
}